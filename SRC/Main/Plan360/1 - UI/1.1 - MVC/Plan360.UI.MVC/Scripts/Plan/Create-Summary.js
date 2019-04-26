


$(function () {

    $("#lnkstep5").on("shown.bs.tab", function (e) {

        validatePlan();
        return;

    });


});//document.ready



//validate the plan and shows respective error messages.
var validatePlan = function () {
    //disable the save button.
    $('#btnSave').prop('disabled', true);


    var _isValid = true;

    //Plan Name
    if ($("#Name").val().length == 0) {
        _isValid = false;
        $("#s5Name").addClass("alert-danger");
        $("#s5Name").html(Plan360Strings_NotFill);
    } else {
        //Remove Name Error if Exists
        $("#s5Name").removeClass("alert-danger");
        $("#s5Name").html($("#Name").val());
    }

    //Plan Calendar
    $("#s5Enterprise").html($("#IdEnterprise :selected").text());

    if ($("#IdCalendar").val() > 0) {
        $("#s5Calendar").html($("#IdCalendar :selected").text());
        $("#s5Calendar").removeClass("alert-danger");
    } else {
        _isValid = false;
        $("#s5Calendar").addClass("alert-danger");
        $("#s5Calendar").html(Plan360Strings_NotFill);
    }


    //Plan Owner
    $("#s5Enterprise").html($("#IdEnterprise :selected").text());

    if ($("#IdOwner").val() > 0) {
        $("#s5User").html($("#IdOwner :selected").text());
        $("#s5User").removeClass("alert-danger");
    } else {
        _isValid = false;
        $("#s5User").addClass("alert-danger");
        $("#s5User").html(Plan360Strings_NotFill);
    }

    //Agents
    //s5SelectedAgentsCount
    $("#s5SelectedAgentsCount").html(selectedAgents.length);
    if (selectedAgents.length > 0) {
        $("#s5tbSelectedAgents").bootstrapTable('load', selectedAgents);
    } else {
        _isValid = false;
    }

    $("#s5SelectedEntitiesCount").html(selectedEntities.length);
    if (selectedEntities.length > 0) {
        $("#s5tbSelectedEntities").bootstrapTable('load', selectedEntities);
    } else {
        _isValid = false;
    }


    $("#s5SelectedProductsCount").html(selectedProducts.length);
    if (selectedProducts.length > 0) {
        $("#s5tbSelectedProducts").bootstrapTable('load', selectedProducts);
    } else {
        _isValid = false;
    }


    if (_isValid) {
        $('#btnSave').prop('disabled', false);
    }



}


//Save the Plan
$("#btnSave").click(function () {

    event.preventDefault();
    $("#btnSave").button("loading");

    //Prepare the AJAX post to save plan.

 

    var urlSavePlanAction = "/Plan/Save";
    var pd = {
        "idPlan" : idPlan,
        "idEnterprise": $("#IdEnterprise").val(),
        "idOwner": $("#IdOwner").val(),
        "idCalendar": $("#IdCalendar").val(),
        "name": $("#Name").val(),
        "agents": selectedAgents,
        "entities": selectedEntities,
        "products": selectedProducts
    };

    var ret;

    $.ajax({
        type: "POST",
        traditional: true,
        url: urlSavePlanAction,
        async: true,
        data: JSON.stringify(pd),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        complete: function (data, status) {

            if (status === "success") {

                ret = data.responseJSON;

                if (ret.Result == "success") {

                    modalDialog( ret.SuccessMessage , Plan360Strings_Success,
                    [Plan360Strings_Yes, Plan360Strings_No], function(btn) {

                        var rurl = "";
                            if (btn == Plan360Strings_Yes) {
                                rurl = "/Plan/Parametrize/" + ret.IdPlan;
                            } else {
                                rurl = "/Plan/Index";
                            }

                            $(location).attr('href', rurl);

                    });

                } else {

                    $.notify(Plan360Strings_ERROR_GenericUpdate, "error");
                    $("#btnSave").button("reset");
                }

            } //if status
            else {
                //print an error message to the user.
                $.notify(Plan360Strings_ERROR_GenericUpdate, "error");
                $("#btnSave").button("reset");
            }

        } //.Complete

    }); //.Ajax







});

