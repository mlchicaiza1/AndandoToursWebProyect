var dataItiBtn = [];
//window.document.onload = getDataAjax();
function colorBtnItinerario(idItinerario,idBarco) {
    var action = '../Cruises/GetItineraBarcoBtn';
    var itinSlide0 = document.getElementById("carousel0");
    $.ajax({
        type: "POST",
        url: action,
        data: { idBarco },
        success: function (response) {
            dataItiBtn = response;
            console.log(dataItiBtn);
            dataItiBtn.forEach(function (element, index) {
                if (element.idBarcoItinerario == idItinerario) {
                    $("#" + idItinerario).addClass('h5button');
                    $("#" + idItinerario).removeClass('h5button-BEIGE');
                    $("#" + idItinerario).removeClass('colorBtnItin');
                    $("#" + idItinerario).addClass('colorBtnItinClick');
                } else {
                    $("#" + element.idBarcoItinerario).addClass('h5button-BEIGE');
                    $("#" + element.idBarcoItinerario).removeClass('h5button');
                    $("#" + element.idBarcoItinerario).addClass('colorBtnItin');
                    $("#" + element.idBarcoItinerario).removeClass('colorBtnItinClick');
                }
            });
        }
    });
    if (itinSlide0 != null)
        itinSlide0.remove();
}

function colorBtnItinerario2(idItinerario, idBarco) {
    var action = '../Cruises/GetItineraBarcoBtn';
    var itinSlide0 = document.getElementById("carousel0");

    $.ajax({
        type: "POST",
        url: action,
        data: { idBarco },
        success: function (response) {
            dataItiBtn = response;
            console.log(dataItiBtn);
            dataItiBtn.forEach(function (element, index) {
                if ((element.idBarcoItinerario + 100) == idItinerario) {
                    $("#" + (idItinerario )).addClass('h5button');
                    $("#" + (idItinerario )).removeClass('h5button-BEIGE');
                    $("#" + (idItinerario )).removeClass('colorBtnItin');
                    $("#" + (idItinerario )).addClass('colorBtnItinClick');
                } else {
                    $("#" + (element.idBarcoItinerario +100)).addClass('h5button-BEIGE');
                    $("#" + (element.idBarcoItinerario + 100)).removeClass('h5button');
                    $("#" + (element.idBarcoItinerario + 100)).addClass('colorBtnItin');
                    $("#" + (element.idBarcoItinerario + 100)).removeClass('colorBtnItinClick');
                }
            });
        }
    });
    if (itinSlide0 != null)
        itinSlide0.remove(); 
}
function navigate(target, idbarco) {
    //Perform your AJAX call to your Controller Action
    $.post(target, { id: idbarco });
}
function pro(id, url) {
    var action = url;
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            console.log(response)
        }
    });
}
function videoOpen() {
    var modalVideo = document.getElementById("videostoryProd");
// When the user clicks the button, open the modal
    modalVideo.style.display = "block";
    $('body').addClass('modal-open');
}

// When the user clicks on <span> (x), closeVideo the modal
function cerrarVideo() {
    var modalVideo = document.getElementById("videostoryProd");
// When the user clicks the button, open the modal
    $("iframe").each(function () {
        var src = $(this).attr('src');
        $(this).attr('src', src);
    });
    modalVideo.style.display = "none";
    $('body').removeClass('modal-open');
}
