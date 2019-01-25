

function Alert(message) {
    bootbox.dialog({
        message: "<div class='row'> " +
            "<div class='col-xs-1'><i class='fa fa-info' style='font-size: 25px; margin: 5px 15px;'></i></div>" +
            "<div class='col-xs-11'>" +
            "<h4 style='' >" + message + "</h4>" +
            "</div>" +
            "</div>",
        title: "Alerta",
        onEscape: true,
        buttons: {
            success: {
                label: "OK",
                className: "btn-success",
            }
        }
    });

};

function Ajax(url, data, success, error) {
    $.ajax(url, {
        method: "POST",
        data: data,
        success: success,
        error: error
    });
}

function Redirect(page) {

    Ajax("Home/" + page + "/", null, function (e) {
        $("#page-wrapper").children().remove();
        $("#page-wrapper").append(e);
    });
}