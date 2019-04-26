//P360 Methods

$(document).ready(function () {

    //Do all pending notifications
    $(".SuccessMessageNotification").each(function () {
        $.notify($(this).html().trim(), "success");
    }); //SuccessMessageNotification Each


    $(".ErrorMessageNotification").each(function () {
        $.notify($(this).html().trim(), "error");
    }); //ErrorMessageNotification Each


});
 

//Modal Confirmation AddOn
//Rodrigo Guimarães fev/2/15
var modalDialog = function (msg, title, btns, cb) {


    var modal = "<div id='dvModalDialog' class='modal fade'>";
    modal += "      <div class='modal-dialog'> ";
    modal += "          <div class='modal-content'> ";

    modal += "              <div class='modal-header'>";
    modal += title;
    modal += "                  <button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
    modal += "              </div>";

    modal += "              <div class='modal-body'> ";
    modal += msg;
    modal += "              </div> ";

    modal += "              <div class='modal-footer'>";

    $(btns).each(function (idx, str) {
        modal += "<button type='button' id='dlg_btn_" + idx + "'  class='btn btn-default' data-dismiss='modal'>" + str + "</button>";
    });


    modal += "              </div>";

    modal += "          </div>";
    modal += "      </div>";
    modal += "</div>";

    $('body').append(modal);

    //handle the clicks 
    $(btns).each(function (idx, str) {

        $("#dlg_btn_" + idx).blur(function () {
            cb(str);
            $('body').remove("#dvModalDialog");
        });

    });


    $('#dvModalDialog').modal({ show: true });


}

//function to detect if value is realy a integer
function isInteger(value) {
    return (value == parseInt(value));
}
