function limp() {
    $(document.body).on('hidden.bs.modal', function () {
        $('.modal').removeData('bs.modal')
    });
}
function ValidEmailDaily() {
    var EmailTxt = document.getElementById("emailDaily");
    if ($(EmailTxt).val().length == 0) {
        EmailTxt.className = "ValidTInyp input-iconoError";
    } else {
        EmailTxt.className = "form-control input-icono";
    }
}


function ValidNombreDaily() {
    var NombreTxt = document.getElementById("nombreDaily");
    if ($(NombreTxt).val().length == 0) {
        NombreTxt.className = "ValidTInyp input-iconoError";
    } else {
        NombreTxt.className = "form-control input-icono";
    }
}
function ValidFechaDaily() {
    var fecha = document.getElementById("fecha");
    if ($(fecha).val().length == 0) {
        fecha.className = "ValidTInyp input-iconoError";
    } else {
        fecha.className = "form-control input-icono";
    }
}
function ValidarFormDaily() {
    ValidEmailDaily();
    ValidNombreDaily();
    ValidFechaDaily();
    ValidNumPassDaily();
}
function ValidNumPassDaily() {
    var travelers = document.getElementById("travelersDaily");
    console.log($(travelers).val().length)
    if ($(travelers).val() <= 0) {
        travelers.className = "ValidTInyp input-iconoError";
    } else {
        travelers.className = "form-control input-icono";
    }
}
function EnviarFormDaily() {
    var NombreTxt = document.getElementById("nombreDaily");
    var EmailTxt = document.getElementById("emailDaily");
    var TXtstart = document.getElementById("fecha");
    var travelers = document.getElementById("travelersDaily");
    if (($(EmailTxt).val().length == 0) || ($(NombreTxt).val().length == 0) || ($(TXtstart).val().length == 0) || ($(travelers).val() <= 0)) {
        ValidarFormDaily();
    } else {
        AprobarFormDaily();
    }
}
function AprobarFormDaily() {
    var name = document.getElementById('nombreDaily').value;
    var email = document.getElementById('emailDaily').value;
    var taylor = document.getElementById('daily').value;
    var travelers = document.getElementById('travelersDaily').value;
    var obser = document.getElementById('obser').value;
    var tituloProd = document.getElementById('titulo').innerHTML;
    var precio = document.getElementById('precioDaily').innerHTML;
    var fecha = document.getElementById('fecha').value;
    window.location.href = "../../../form_taylorMade/AuthorizePayment?email=" + email + "&name=" + name + "&form=" + taylor + "&obser=" + obser + "&nombreProduct=" + tituloProd + "&pasajero=" + travelers + "&precio=" + precio + "&fecha=" + fecha ;
}