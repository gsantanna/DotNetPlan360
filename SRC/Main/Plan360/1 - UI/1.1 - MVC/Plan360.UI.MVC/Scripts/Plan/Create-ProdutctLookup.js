
$(function() {


    //Search button 
    $("#productLookup_btn").click(function () {
        event.preventDefault();
        SearchAvaliableProducts();
        return false;
    });


    //Selected lists buttons
    $("#productLookup_btnAdd").click(function () {
        event.preventDefault();

        var selectedItens = $('#tbProductLookupSearchResult').bootstrapTable('getSelections');
        if (selectedItens.length == 0) return false;


        $(selectedItens).each(function (idx, obj) {
            selectProduct(obj.IdProduct,obj.Code, obj.Name, obj.BrandName);
        });

        drawSelectedProductsGrid();
        return false;
    });

    $("#productLookup_btnAddAll").click(function () {

        event.preventDefault();

        var allItems = $('#tbProductLookupSearchResult').bootstrapTable('getData');

        if (allItems.length == 0) return false;

        $(allItems).each(function (idx, obj) {
            selectProduct(obj.IdProduct, obj.Code, obj.Name, obj.BrandName);
        });

        drawSelectedProductsGrid();

        return false;
    });

    $("#productLookup_btnRemove").click(function () {
        event.preventDefault();

        var selectedItens = $('#tbSelectedProducts').bootstrapTable('getSelections');


        if (selectedItens.length == 0) return false;

        $(selectedItens).each(function (idx, obj) {

            removeProduct(obj.IdProduct);

        });

        drawSelectedProductsGrid();






        return false;
    });

    $("#productLookup_btnRemoveAll").click(function () {
        event.preventDefault();

        if (selectedProducts.length > 0) {
            selectedProducts = new Array();
            drawSelectedProductsGrid();

        }
        return false;
    });


}); //Document.Ready


var SearchAvaliableProducts = function () {

    //Configure the service's URL
    var urlJsonProductSearch = "/Product/J_Search/?strSearch=" + $("#productLookup_search").val();

    //if brand filter was selected
    if ($("#productLookupBrand").val() > 0) {

        urlJsonProductSearch += "&idBrand=" + $("#productLookupBrand").val();
    }

    //if brand filter was selected
    if ($("#productLookupCategory").val() > 0) {

        urlJsonProductSearch += "&idCategory=" + $("#productLookupCategory").val();
    }



    //bind bootstrap table data direcctly
    $("#tbProductLookupSearchResult").bootstrapTable('refresh', { url: urlJsonProductSearch });


}


//Selected Products CRUD
var selectProduct = function (idProduct, code, name, brand) {

    //verify if product is already selected
    if ((selectedProducts.length > 0 && $.grep(selectedProducts, function (item) { return item.IdProduct == idProduct }).length > 0)) {
        //Already exist ignore.
    } else {

        //Add the Dt
        selectedProducts[selectedProducts.length] =
        {
            'Selected': false,
            'IdProduct': idProduct,
            'Code': code,
            'Name': name,
            'BrandName': brand
        };

    }; //if

} //.SelectProduct

var removeProduct = function (idProduct) {

    selectedProducts = $.grep(selectedProducts, function (obj) {
        return (obj["IdProduct"] !== idProduct);
    });
    drawSelectedProductsGrid();

}; //.removeproduct


var drawSelectedProductsGrid = function() {

    $("#tbSelectedProducts").bootstrapTable('load', selectedProducts);

    setTimeout(function() {
    
        $("#s5tbSelectedProducts").bootstrapTable('load', selectedProducts);
        $("#s5SelectedProductsCount").html(selectedProducts.length);


    } , 1000);

}


//End Selected Products CRUD
