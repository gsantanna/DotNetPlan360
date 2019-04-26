


$(function () {

    $("#agentLookup_btn").click(function () {

        event.preventDefault();

        setTimeout(500, SearchAvaliableAgents());

        return false;
    });

    $("#agentLookup_btnAdd").click(function () {
        event.preventDefault();

        var selectedItens = $('#tbAgentLookupSearchResult').bootstrapTable('getSelections');

        if (selectedItens.length === 0) return false;

        $(selectedItens).each(function (idx, obj) {

            selectAgent(obj.IdAgent, obj.Code, obj.Name, obj.RoleDescription);

        });

        drawSelectedAgentsGrid();
        return false;
    });

    $("#agentLookup_btnAddAll").click(function () {

        event.preventDefault();

        var allItems = $('#tbAgentLookupSearchResult').bootstrapTable('getData');

        if (allItems.length === 0) return false;

        $(allItems).each(function (idx, obj) {

            selectAgent(obj.IdAgent, obj.Code, obj.Name, obj.RoleDescription);

        });

        drawSelectedAgentsGrid();

        return false;
    });

    $("#agentLookup_btnRemove").click(function () {
        event.preventDefault();

        var selectedItens = $('#tbSelectedAgents').bootstrapTable('getSelections');


        if (selectedItens.length === 0) return false;

        $(selectedItens).each(function (idx, obj) {

            removeAgent(obj.IdAgent);

        });

        drawSelectedAgentsGrid();






        return false;
    });

    $("#agentLookup_btnRemoveAll").click(function () {
        event.preventDefault();

        if (selectedAgents.length > 0) {
            selectedAgents = new Array();
            drawSelectedAgentsGrid();

        }
        return false;
    });
    


}); //Document.Ready


//Selected Agents CRUD
var selectAgent = function (idAgent, code, name, role) {

    //verify if agent is already selected
    if ((selectedAgents.length > 0 && $.grep(selectedAgents, function (item) { return item.IdAgent === idAgent }).length > 0)) {
        //Already exist ignore.
    } else {

        //Add the Dt
        selectedAgents[selectedAgents.length] =
        {
            'Selected': false,
            'IdAgent': idAgent,
            'Code': code,
            'Name': name,
            'Role': role
        };
    }; //if

} //.SelectAgent

var removeAgent = function (idAgent) {

    selectedAgents = $.grep(selectedAgents, function (obj) {
        return (obj["IdAgent"] !== idAgent);
    });
    drawSelectedAgentsGrid();

}; //.removeagent

var drawSelectedAgentsGrid = function () {

    $("#tbSelectedAgents").bootstrapTable('load', selectedAgents);

    //if the count changed, call the update event.
    setTimeout(updateSelectedEntitiesCount, 100);



}

var SearchAvaliableAgents = function () {

    //Configure the service's URL
    var urlJsonAgentSearch = "/Agent/J_SearchBySalesForce/?strSearch=" + $("#agentLookup_search").val();

    urlJsonAgentSearch += "&idEnterprise=" + $("#IdEnterprise").val();

    //if salesforce filter was selected
    if ($("#agentLookupSalesForce").val() > 0) {

        urlJsonAgentSearch += "&idSalesForce=" + $("#agentLookupSalesForce").val();
    }

    //if 
    if ($("#agentLookupRole").val() > 0) {
        urlJsonAgentSearch += "&idAgentRole=" + $("#agentLookupRole").val();
    }

    $("#tbAgentLookupSearchResult").bootstrapTable('refresh', { url: urlJsonAgentSearch });


}
//End Selected Agents CRUD
