var marker = [];
var filtHoteles = [];
var hotelesPrincipal = [];
var mapa = null;
var map;
var mapPrincipal;
function mapaFiltros(filtros) {
    
    //imagenes de pin
    //url de la data
    var descripHoteles = [];
    var hoteles = [];
    var marcador = [];
    var img1;
    img1 = {
        url: "/images/icon/mapIcon.png",
        size: new google.maps.Size(35, 50),
        origin: new google.maps.Point(0, 0), //origen de la iamgen
        anchor: new google.maps.Point(20, 60)
    };
    //ventanas informativas
    var infowindows = new google.maps.InfoWindow();
    var ventanaInfo = new google.maps.InfoWindow();
    var descripcion;
    //Mapa
        mapa = new google.maps.Map(document.getElementById('mapa'), {
            zoom: 6,
            center: { lat: -1.90, lng: -78.081177 },
        });
    if (filtros == null) {
        map = mapa;
            var action = '../GetMapaEcItiner';
            $.ajax({
                type: "GET",
                url: action,
                data: {},
                success: function (response) {
                    hoteles = response;
                    hoteles.forEach(function (element, index) {
                        longitud = element.latitudHotel;
                        descripHoteles.push(element.nombreHotel);
                        marcador.push({ lat: Number(element.latitudHotel), lng: Number(element.longitudHotel) });
                    });
                    var cont = 0;
                    for (var i = 0; i < marcador.length; i++) {
                        var marker = new google.maps.Marker({
                            position: marcador[i],
                            icon: img1,
                            map: map,
                            animation: google.maps.Animation.DROP,
                        });
                        filtHoteles.push(marker);
                        google.maps.event.addListener(marker, "click", (function (marker, i) {
                            return function () {
                                descripcion = '<section id="content" style="padding:0; max-width:205px">' +
                                    '<div id="imagen" >' +
                                    '</div>' + '<div col-xs-12>' + '<img src="' + hoteles[i].fotoHotel + '" style="width:200px;max-height:135px" alt="Alternate Text" />' +
                                    '<h5 id="firstHeading" class="secondHeading" style="color:#6f6d6d">Hotel Description</h5>' +
                                    '<h4 id=" ' + hoteles[i].idMapaHotel +' " class="firstHeading" style="color:#179fec;cursor:pointer" onclick="showInfHotel(this.id)" >' + hoteles[i].nombreHotel + '</h4>' +
                                    '<p style="text-aling:justify">Description:' + hoteles[i].descripcionHotel +
                                    '</div>' +
                                    '</section>';
                                ventanaInfo.setContent(descripcion);
                                ventanaInfo.open(map, marker);
                            }
                        })(marker, i));
                    }
                }
            });
            google.maps.event.addListener(map, 'idle', function () {
                showVisibleMarkers()
            });
        }
    else {
        map = mapa;
            marcador = [];
            filtHoteles = [];
            filtros.forEach(function (element, index) {
                longitud = element.latitudHotel;
                descripHoteles.push(element.nombreHotel);
                marcador.push({ lat: Number(element.latitudHotel), lng: Number(element.longitudHotel) });
            });
            for (var i = 0; i < marcador.length; i++) {
                var marker = new google.maps.Marker({
                    position: marcador[i],
                    icon: img1,
                    map: map,
                    animation: google.maps.Animation.DROP,
                });
                filtHoteles.push(marker);
                google.maps.event.addListener(marker, "click", (function (marker, i) {
                    return function () {
                        descripcion = '<section id="mapaFiltros" style="padding:0; max-width:205px">' +
                            '<div id="imagen" >' +
                            '</div>' + '<div col-xs-12>' + '<img src="' + filtros[i].fotoHotel + '" style="width:200px;max-height:135px" alt="Alternate Text" />' +
                            '<h5 id="firstHeading" class="secondHeading" style="color:#6f6d6d">Hotel Description</h5>' +
                            '<h4 id="firstHeading" class="firstHeading" style="color:#179fec">' + filtros[i].nombreHotel + '</h4>' +
                            '<p style="text-aling:justify">Description:' + filtros[i].descripcionHotel +'</div>' +'</section>';
                        ventanaInfo.setContent(descripcion);
                        ventanaInfo.open(map, marker);
                    }
                })(marker, i));
            }
        google.maps.event.addListener(map, 'idle', function () {
            showVisibleMarkersPrincipal();
            });
        }
}
function showVisibleMarkers() {
    var bounds = map.getBounds(), count = 0;
    for (var i = 0; i < filtHoteles.length; i++) {
        var marker = filtHoteles[i], infoPanel = $('.info-' + (i + 1)); // array indexes start at zero
       
        if (bounds.contains(marker.getPosition()) === true) {
            infoPanel.show();
            count++;
        }
        else {
            infoPanel.hide();
        }
    }
}
function showVisibleMarkersPrincipal() {
    var bounds = map.getBounds(), count = 0;
    for (var i = 0; i < filtHoteles.length; i++) {
        var marker = filtHoteles[i], infoPanel = $('.info-' + (i + 1)); // array indexes start at zero
        if (bounds.contains(marker.getPosition()) === true) {
            infoPanel.show();
            count++;
        }
        else {
            infoPanel.hide();
        }
    }
}
function clearMarkers() {
    for (var i = 0; i < marker.length; i++) {
        marker[i].setMap(null);
    }
    marker = [];
}
function fitroRegion(event) {
    var action = '../GetMapaEcItiner';
    marcador = [];
    var hotelesDatos = [];
    descripHoteles = [];
    $.ajax({
        type: "GET",
        url: action,
        data: {},
        success: function (response) {
            filtros = response;
            filtros.forEach(function (element, index) {
                if (element.region == event) {
                    hotelesDatos.push(element);
                }
                if (event == "All") {
                    hotelesDatos = filtros;
                }
            });
            mapaFiltros(hotelesDatos);
        }
    });
}
function cargarMap() {
    mapaFiltros(null);
}
function showInfHotel(idHotel) {
    console.log(idHotel);
    var idHotelLocal = localStorage.setItem("idHotelMap", idHotel);
    //$('#galeMapaModal').modal('show');
    //window.location.href = "../../../GetModalHotel?idHotel=" + idHotel;
}