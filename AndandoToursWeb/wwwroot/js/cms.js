$(document).ready(function () {
    var menu = document.getElementById("menuLateralCms");
    var menuSup = document.getElementById("menuSupCms");
    var vistaUrl = window.location;
    var res = vistaUrl.pathname.split("/");
    console.log(res)

    if (res[2] != "Login") {

        menu.classList.remove("desAct");
        menuSup.classList.remove("desAct");
    }
    if (res[4] == "Register" || res[4] == "ForgotPassword" || res[3] == "Login" || res[3] == "Account") {

        menu.classList.add("desAct");
        menuSup.classList.add("desAct");
    }

});

