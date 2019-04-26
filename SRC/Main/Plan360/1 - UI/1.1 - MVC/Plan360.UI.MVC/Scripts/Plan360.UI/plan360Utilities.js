
//Remove Duplicates from Array of objects
var ArrayRemoveDuplicates = function (inputArray) {
    var outputArray = new Array();

    if (inputArray.length > 0) {
        jQuery.each(inputArray, function (index, value) {
            if (jQuery.inArray(value, outputArray) == -1) {
                outputArray.push(value);
            }
        });
    }

    return outputArray;

}//RemoveDuplicates

//Sort the array by property name
var ArraySort = function (arr, propertyName, asc) {

    return arr.sort(function (a, b) {

        if (asc) {
            if (a[propertyName] < b[propertyName]) return -1;
            if (a[propertyName] > b[propertyName]) return 1;
            return 0;
        } else {

            if (a[propertyName] > b[propertyName]) return -1;
            if (a[propertyName] < b[propertyName]) return 1;
            return 0;
        }




    });


};

//Type convertions
var nullFix = function (obj) {

    if (typeof (obj) == "undefined" || obj == null) return "";

    return obj;
}

//QueryString and Http
var getParameterByName = function (name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}


//Markup Utilities
var mapObjectToString = function (string, obj) {

    $.each(
    Object.keys(obj), function (i, at) {
        string = string.split("{{" + at.toLowerCase() + "}}").join($(obj).attr(at));
    });


    return string;

}

//Ajax utilities
var getComboContent = function (ajaxUrl, valueField, textField, selectText, emptyText) {

    var strOut = "";


    $.ajax({
        url: ajaxUrl,
        dataType: 'json',
        async: false,
        success: function (data) {

            if (data.length ===0 && ( typeof (emptyText) !== 'undefined' && emptyText !== "")) {

                strOut = "<option value='-1'>"+ emptyText  +"</option>";
                return;
            }
            else if (typeof (selectText) !== 'undefined' && selectText !== "") {
                strOut += "<option value='-1' >" + selectText + "</option>";
            }



            $.each(data, function (idx, obj) {

                strOut += "<option value=" + obj[valueField] + " >" + obj[textField] + "</option>";


            }); //each



        }//success
    });//ajax

    return strOut;
}//.getComboContent




//Formating and validation utilities
// Numeric only control handler
jQuery.fn.ForceNumericOnly = function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.charCode || e.keyCode || 0;
            // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
            // home, end, period, and numpad decimal
            return (
                key == 8 ||
                key == 9 ||
                key == 13 ||
                key == 46 ||
                key == 110 ||
                key == 190 ||
                (key >= 35 && key <= 40) ||
                (key >= 48 && key <= 57) ||
                (key >= 96 && key <= 105));
        });
    });
};


