
//Create the javascript object with list of agents added to tool


var tmpEnterprise;

$(function () {

    //Load the enterprise's calendar
    ShowLoading();
    setTimeout(LoadCombos, 1);
    tmpEnterprise = $("#IdEnterprise").val();

    //First page combos change Event Handler
    $("#IdEnterprise").change(function () {


        //new plan or none is selected. Just Change the enterprise.
        if (selectedAgents.length === 0 && selectedEntities.length === 0 && selectedProducts.length === 0) {

            ShowLoading();
            setTimeout(LoadCombos, 200);
            resetSelections();
            return;
        }


        //show the dialog confirming the change.
        modalDialog(
            Plan360Strings_PLAN_ConfirmEnterpriseChange,
            Plan360Strings_ACTION_OperationConfirm,
            [Plan360Strings_OK, Plan360Strings_Cancel],
            function (btn) {

                if (btn === Plan360Strings_OK) {
                    ShowLoading();
                    setTimeout(LoadCombos, 200);
                    resetSelections();

                    tmpEnterprise = $("#IdEnterprise").val();

                } else {
                    $("#IdEnterprise").val(tmpEnterprise);
                }

            }
        );//modalDialog

    }); //Change


}); //Document.Ready


var ShowLoading = function () {

    $("#IdEnterprise-loading").show();
    $("#IdCalendar-loading").show();
    $("#IdOwner-loading").show();
    $("#agentLookupSalesForce-loading").show();
    $("#agentLookupRole-loading").show();
    $("#entityLookupEntity-loading").show();
    $("#productLookupBrand-loading").show();
    $("#productLookupCategory-loading").show();


}

var LoadCombos = function () {

    //load the JSON
    var urlJsonCalendar = "/Calendar/J_getbyenterprise/" + $("#IdEnterprise").val();
    var urlJsonUserProfile = "/UserProfile/J_getbyenterprise/" + $("#IdEnterprise").val();
    var urlJsonSalesForce = "/SalesForce/J_getbyenterprise/" + $("#IdEnterprise").val();
    var urlJsonAgentRoles = "/AgentRole/J_getall";
    var urlJsonEntities = "/Entity/J_getbyenterprise/" + $("#IdEnterprise").val();
    var urlJsonBrands = "/Brand/J_getbyenterprise/" + $("#IdEnterprise").val();
    var urlJsonCategory = "/ProductCategory/j_getall";

    $("#IdCalendar").html(getComboContent(urlJsonCalendar, "IdCalendar", "Name", Plan360Strings_ACTION_Select));
    $("#IdOwner").html(getComboContent(urlJsonUserProfile, "IdUser", "Name", Plan360Strings_ACTION_Select));
    $("#agentLookupRole").html(getComboContent(urlJsonAgentRoles, "IdAgentrole", "Name", Plan360Strings_ACTION_All));
    $("#agentLookupSalesForce").html(getComboContent(urlJsonSalesForce, "IdSalesforce", "Name", Plan360Strings_ACTION_All));
    $("#entityLookupEntity").html(getComboContent(urlJsonEntities, "IdEntity", "Name", Plan360Strings_ACTION_Select));
    $("#productLookupBrand").html(getComboContent(urlJsonBrands, "IdBrand", "Name", Plan360Strings_ACTION_All));
    $("#productLookupCategory").html(getComboContent(urlJsonCategory, "IdCategory", "Name", Plan360Strings_ACTION_All));

    $("#IdEnterprise-loading").hide();
    $("#IdCalendar-loading").hide();
    $("#IdOwner-loading").hide();
    $("#agentLookupSalesForce-loading").hide();
    $("#agentLookupRole-loading").hide();
    $("#entityLookupEntity-loading").hide();
    $("#productLookupBrand-loading").hide();
    $("#productLookupCategory-loading").hide();


}

var resetSelections = function () {


    selectedAgents = new Array();
    selectedProducts = new Array();
    selectedEntities = new Array();

    //Reset the selected items and tables
    $("#tbAgentLookupSearchResult").bootstrapTable('load', {});
    $("#tbProductLookupSearchResult").bootstrapTable('load', {});
    $("#tbEntityLookupSearchResult").bootstrapTable('load', {});

    drawSelectedAgentsGrid();
    drawSelectedEntitiesGrid();
    drawSelectedProductsGrid();
}