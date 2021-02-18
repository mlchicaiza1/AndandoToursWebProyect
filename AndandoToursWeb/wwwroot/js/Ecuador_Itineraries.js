var dataItiBtn = [];
function colorBtnItinerarioEc(IdItinerarioBtn, idVista) {
    var action = '../../ecuador_itineraries/GetItineraEcBtn';
    var itinSlideEc0 = document.getElementById("carouselEc0");
    $.ajax({
        type: "POST",
        url: action,
        data: { idVista },
        success: function (response) {
            dataItiBtn = response;
            dataItiBtn.forEach(function (element, index) {
                if (element.idItinerarioBtn == IdItinerarioBtn) {
                    $("#" + IdItinerarioBtn).addClass('h5button');
                    $("#" + IdItinerarioBtn).removeClass('h5button-BEIGE');
                    $("#" + IdItinerarioBtn).removeClass('colorBtnItin');
                    $("#" + IdItinerarioBtn).addClass('colorBtnItinClick');
                } else {
                    $("#" + element.idItinerarioBtn).addClass('h5button-BEIGE');
                    $("#" + element.idItinerarioBtn).removeClass('h5button');
                    $("#" + element.idItinerarioBtn).addClass('colorBtnItin');
                    $("#" + element.idItinerarioBtn).removeClass('colorBtnItinClick');
                }
            });
        }
    });
    if (itinSlideEc0 != null)
        itinSlideEc0.remove();
}
function colorBtnItinerarioEc2(IdItinerarioBtn, idVista) {
    var action = '../../ecuador_itineraries/GetItineraEcBtn';
    var itinSlideEc0 = document.getElementById("carouselEc0");
    $.ajax({
        type: "POST",
        url: action,
        data: { idVista },
        success: function (response) {
            dataItiBtn = response;
            dataItiBtn.forEach(function (element, index) {
                if ((element.idItinerarioBtn + 100) == IdItinerarioBtn) {
                    $("#" + (IdItinerarioBtn)).addClass('h5button');
                    $("#" + (IdItinerarioBtn)).removeClass('h5button-BEIGE');
                    $("#" + (IdItinerarioBtn)).removeClass('colorBtnItin');
                    $("#" + (IdItinerarioBtn)).addClass('colorBtnItinClick');
                } else {
                    $("#" + (element.idItinerarioBtn + 100)).addClass('h5button-BEIGE');
                    $("#" + (element.idItinerarioBtn + 100)).removeClass('h5button');
                    $("#" + (element.idItinerarioBtn + 100)).addClass('colorBtnItin');
                    $("#" + (element.idItinerarioBtn + 100)).removeClass('colorBtnItinClick');
                }
            });
        }
    });
    if (itinSlideEc0 != null)
        itinSlideEc0.remove();
}