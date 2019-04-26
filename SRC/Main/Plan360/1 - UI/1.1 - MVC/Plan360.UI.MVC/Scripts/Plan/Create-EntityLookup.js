
var LoadEntityMetadataCombo = function () {


    var idEntity = $("#entityLookupEntity").val();
    var urlJsonEntityMetadata = "/EntityMetadata/j_getbyentity/" + idEntity;
    $("#entityMetadataLookupEntity").html(getComboContent(urlJsonEntityMetadata, "IdEntitymetadata", "Name", Plan360Strings_ACTION_Select, Plan360Strings_ENTITY_SelectEntity));
    $("#entityMetadataLookupEntity-loading").hide();


}


$(function () {

    $("#entityMetadataLookupEntity-loading").show();
    setTimeout(LoadEntityMetadataCombo, 500);

    //Entity combo
    $("#entityLookupEntity").change(function () {

        //Reload Entity  metdata combos
        $("#entityMetadataLookupEntity-loading").show();
        setTimeout(LoadEntityMetadataCombo, 300);


    });

    //Search button 
    $("#entitiesLookup_btn").click(function () {
        event.preventDefault();
        SearchAvaliableEntities();
        return false;
    });


    //Selected lists buttons
        
    $("#entityLookup_btnAdd").click(function () {
        event.preventDefault();

        var selectedItens = $('#tbEntityLookupSearchResult').bootstrapTable('getSelections');
        if (selectedItens.length == 0) return false;


        $(selectedItens).each(function (idx, obj) {
            selectEntity(obj.IdEntityMetadata, obj.Field ,obj.Value, obj.Count);
        });

        drawSelectedEntitiesGrid();
        return false;
    });

    $("#entityLookup_btnAddAll").click(function () {

        event.preventDefault();

        var allItems = $('#tbEntityLookupSearchResult').bootstrapTable('getData');

        if (allItems.length == 0) return false;

        $(allItems).each(function (idx, obj) {
            selectEntity(obj.IdEntityMetadata, obj.Field, obj.Value, obj.Count);
        });

        drawSelectedEntitiesGrid();

        return false;
    });

    $("#entityLookup_btnRemove").click(function () {
        event.preventDefault();

        var selectedItens = $('#tbSelectedEntities').bootstrapTable('getSelections');


        if (selectedItens.length == 0) return false;

        $(selectedItens).each(function (idx, obj) {

            removeEntity(obj.IdEntityMetadata, obj.Value);

        });

        drawSelectedEntitiesGrid();






        return false;
    });

    $("#entityLookup_btnRemoveAll").click(function () {
        event.preventDefault();

        if (selectedEntities.length > 0) {
            selectedEntities = new Array();
            drawSelectedEntitiesGrid();

        }
        return false;
    });


}); //Document.Ready
 
//Selected Entities CRUD

var selectEntity = function (idEntityMetadata, field, value, count) {


    //verify if agent is already selected
    if ((selectedEntities.length > 0 && $.grep(selectedEntities, function (item) {
        return item.IdEntityMetadata == idEntityMetadata && item.Value == value;
    }).length > 0)) {
        //Already exist ignore.
    } else {

        //Add the Dt
        selectedEntities[selectedEntities.length] =
        {
            IdEntityMetadata: idEntityMetadata,
            Field: field,
            Value: value,
            Count: count
        };
    }; //if

} //.SelectEntity

var removeEntity = function (idEntityMetadata, value) {

    selectedEntities = $.grep(selectedEntities, function (obj) {
        return (!(obj["IdEntityMetadata"] == idEntityMetadata && obj["Value"] == value));
    });

    drawSelectedEntitiesGrid();

}; //.removeEntity

var drawSelectedEntitiesGrid = function () {

    $("#tbSelectedEntities").bootstrapTable('load', selectedEntities);



    setTimeout(function () {

        $("#s5tbSelectedEntities").bootstrapTable('load', selectedEntities);
        $("#s5SelectedEntitiesCount").html(selectedEntities.length);

    }, 1000);




}


var SearchAvaliableEntities = function () {

    var idEntmd = $("#entityMetadataLookupEntity").val();

    //if no agents selected 
    if (!(selectedAgents.length > 0 )) {

        $("#entitiesLookup_btn").popover({ content: Plan360Strings_PLAN_AgentsEmpty, title: Plan360Strings_Error });
        $("#entitiesLookup_btn").popover('show');

        setTimeout(function () {
            $("#entitiesLookup_btn").popover('destroy');
        }, 4000);
        return;
    } //.if no metadata selected 


    //if no metadata selected 
    if (typeof (idEntmd) == "undefined" || idEntmd <= 0) {

        $("#entitiesLookup_btn").popover({ content: Plan360Strings_PLAN_SearchEntityMetadataEmpty, title: Plan360Strings_Error });
        $("#entitiesLookup_btn").popover('show');

        setTimeout(function () {
            $("#entitiesLookup_btn").popover('destroy');
        }, 4000);
        return;
    } //.if no metadata selected 


    
    //do the json request and populate the results grid
    var urlJsonEntityData = "/EntityData/J_GetDistinctValuesByEntityMetadata";
    var pd = {
        'agents': selectedAgents,
        'id': idEntmd
    };

    //put the grid in loading status cus that ajax request can take about 20s to run.
    $("#tbEntityLookupSearchResult").bootstrapTable('showLoading');


    $.ajax({
        type: "POST",
        traditional: true,
        url: urlJsonEntityData,
        async: true,
        data: JSON.stringify(pd),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        complete: function (data, status) {

            if (status == "success") {

                //configure the data table 
                var dsResult = new Array();

                $.each(data.responseJSON, function (idx, obj) {

                    dsResult[dsResult.length] = {
                        IdEntityMetadata: idEntmd,
                        Field: $("#entityMetadataLookupEntity :selected").text(),
                        Value: obj["Value"],
                        Count: obj["Count"]
                    };

                }); //each

                $("#tbEntityLookupSearchResult").bootstrapTable('load', dsResult);

            } //if status

            $("#tbEntityLookupSearchResult").bootstrapTable('hideLoading');


        } //.Complete

    }); //.Ajax



}//.SearchAvaliableEntities
//end selected Entities CRUD

//update the iten's count in selected entities grid.
var updateSelectedEntitiesCount = function() {
    
    //if is any selected entity reload the quantity and redraw the grid.
    if (selectedEntities.length == 0) return;


    //For each combination of IdEntityMetadata and Value, upate the count field by an new ajax request using new agents
    $.each(selectedEntities, function (idx, obj) {

        //get the updated count.
        obj.Count = getUpdatedCount(obj.IdEntityMetadata, obj.Value);


    });//each

    //redraw selected entities grid
    drawSelectedEntitiesGrid();

}

//AJAX Methods

var getUpdatedCount = function(idEntityMetadata, value) {
    

    var urlJsonEntityData = "/EntityData/J_GetDistinctValuesByEntityMetadataValue";
    var pd = {
        'agents': selectedAgents,
        'value' : value , 
        'id': idEntityMetadata
    };

    var ret = 0;

    $.ajax({
        type: "POST",
        traditional: true,
        url: urlJsonEntityData,
        async: false,
        data: JSON.stringify(pd),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        complete: function (data, status) {

            if (status == "success") {

                ret = data.responseJSON;

            } //if status

        } //.Complete

    }); //.Ajax

    return ret;

}








































