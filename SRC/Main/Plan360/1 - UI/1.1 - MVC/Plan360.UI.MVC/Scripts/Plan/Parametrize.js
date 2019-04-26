var pendingCalculation = false;


$(function () {

    var tmpValue = 0;
    var calculationTimer;
    var asyncLock = false;


    $("#btnSave").click(UpdateParameters);

    //handle the user's input in any textboxes
    $('input').keypress(function (event) {

        if (event.keyCode == 13) {
            $(event.target).trigger("change");
            return false;
        }
        return true;

    });

    $('input').ForceNumericOnly();

    //if value was changed, start the timer job 
    $(".plan-param-count, .plan-param-percent").change(function () {

        pendingCalculation = true;

        //TODO: Test it on IE and Mozilla
        var idproduct = $(event.target).attr("idproduct");
        var idplanparameter = $(event.target).attr("idPlanParameter");
        var idplan = $(event.target).attr("idplan");

        calculationTimer = setTimeout(function () {

            if (asyncLock) return;
            asyncLock = true;
            Recalculate(idproduct, idplanparameter, idplan);
            asyncLock = false;

        }, 1000);

    });

    $(".plan-param-count, .plan-param-percent").focus(function () {
        //set the tempVariable value
        tmpValue = $(event.target).val();
    });


    ReloadProductUse();

});//Ready

//return object containing all product information 
var GetProductInfo = function (idProduct) {

    var prd = $.grep(productInfo, function (x) { return x.IdProduct == idProduct });

    return {
        IdProduct: $(prd).attr("IdProduct"),
        PackSize: $(prd).attr("PackSize")
    };

}


var ReloadProductUse = function () {


    var ajaxUrlOtherPlans = "/Plan/J_GetProductUsageInOtherPlans?idPlan=" + $("#IdPlan").val();

    $.ajax({
        url: ajaxUrlOtherPlans,
        dataType: 'json',
        async: true, //that one can be async
        success: function (data_usage_full) {


            //for each product, get the total ammount used in other calendars
            $(".total-calendar-cell").each(function (idx, obj) {
                var calendarUsed = 0;

                var productUsageData = $.grep(data_usage_full, function (o) { return o.idProduct == $(obj).attr("idProduct") });

                $(productUsageData).each(function (idx_du, obj_du) {
                    calendarUsed += parseInt(obj_du.TotalA);
                });//each data usage 



                $(".plan-param-totala[idproduct=" + $(obj).attr("idProduct") + "]").each(function (idx_ta, obj_ta) {
                    calendarUsed += parseInt($(obj_ta).val());
                });


                $(obj).html(calendarUsed);



                //Update the Total column 
                var avaliableTotal = (parseInt($(".total-product-stock[idproduct=" + $(obj).attr("idProduct") + "]").html()) - parseInt(calendarUsed));

                $(".avaliable-calendar-cell[idproduct=" + $(obj).attr("idProduct") + "]").html(avaliableTotal);

                if(avaliableTotal  < 0)
                {
                    $(".avaliable-calendar-cell[idproduct=" + $(obj).attr("idProduct") + "]").addClass("text-danger");
                } else 
                {
                    $(".avaliable-calendar-cell[idproduct=" + $(obj).attr("idProduct") + "]").removeClass("text-danger");
                }




            });//each total Calendar cell

        }//success

    });//ajax


}//reloadproductuse

var Recalculate = function (idProduct, idPlanParameter, idPlan) {

    if (!pendingCalculation) return;


    //get the input values 
    var count = $("[idplanparameter='" + idPlanParameter + "'].plan-param-count").val();
    var percent = $("[idplanparameter='" + idPlanParameter + "'].plan-param-percent").val();



    //validate the values
    if (typeof (idProduct) == 'undefined' || typeof (idPlanParameter) == 'undefined' || !isInteger(count) || !isInteger(percent)) return;

    //get the ajax calculation of total
    var ajaxUrl = "/Plan/J_GetCalculatedTotals?idPlanParameter=" + idPlanParameter + "&count=" + count + "&percentual=" + percent;
    var ajaxUrlOtherPlans = "/Plan/J_GetProductUsageInOtherPlans?idPlan=" + idPlan + "&idProduct=" + idProduct;

    //Load and print the calculation total 
    $.ajax({
        url: ajaxUrl,
        dataType: 'json',
        async: false,
        success: function (data) {

            //set the values 
            $("[idplanparameter='" + idPlanParameter + "'].plan-param-total").val(data.Total);
            $("[idplanparameter='" + idPlanParameter + "'].plan-param-totala").val(data.TotalA);


            //load and update the page's product usage indicator 
            $.ajax({
                url: ajaxUrlOtherPlans,
                dataType: 'json',
                async: true, //that one can be async
                success: function (data_usage) {

                    var calendarUsed = 0;

                    $(data_usage).each(function (idx_du, obj_du) {
                        calendarUsed += parseInt(obj_du.TotalA);
                    });//each data usage 

                    //Add the usage in the plan (all PlanA columns for product) 

                    $(".plan-param-totala[idproduct=" + idProduct + "]").each(function (idx_ta, obj_ta) {
                        calendarUsed += parseInt($(obj_ta).val());
                    });

                    var elem = $(".total-calendar-cell[idproduct='" + idProduct + "']").html(calendarUsed)


                }//success


            });//Product's usage ajax end


            pendingCalculation = false;

        }
    });


    //update the Calendar's usage field 





}

var UpdateParameters = function () {
    var objRet = new Array();


    $(".tb_planparameter").each(function (idx, obj) {

        objRet.push({
            IdPlanParameter: $(obj).attr("idplanparameter"),
            IdPlan: $("#IdPlan").val(),
            IdPlanProduct: $(obj).attr("idplanproduct"),
            IdPlanEntity: $(obj).attr("idplanentity"),
            Total: $(obj).find(".plan-param-total").val(),
            TotalA: $(obj).find(".plan-param-totala").val(),
            Percent: $(obj).find(".plan-param-percent").val(),
            Count: $(obj).find(".plan-param-count").val()

        });

    });//each 


    //do the ajax request 
    $.ajax({
        type: "POST",
        traditional: true,
        url: "/Plan/UpdateParameters",
        async: true,
        data: JSON.stringify(objRet),
        dataType: "json",
        contentType: "application/json; charset=utf-8"

    }).done(function (data, status) {

        $.notify(unescape(Plan360Strings_Success), "success");

    }).fail(function () {

        $.notify(Plan360Strings_ERROR_GenericUpdate, "error");

    });



}


