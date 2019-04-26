$(function() {

    //if IdPlan > 0 Redraw all grids here

    setTimeout(function() {

        

        drawSelectedAgentsGrid();
        
        drawSelectedEntitiesGrid();
        
        drawSelectedProductsGrid();


        if (_id_calendar > 0) {
            $("#IdCalendar").val(_id_calendar);
        }

        if (_id_owner > 0) {
            $("#IdOwner").val(_id_owner);
        }





    }, 1000);

    
});



