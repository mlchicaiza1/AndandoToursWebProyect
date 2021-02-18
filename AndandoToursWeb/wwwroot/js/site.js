// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//
var btngalapagos = document.getElementById('btn-galapagosCruises'),
    btngalapagosIsland = document.getElementById('btn-galapagos-Island'),
    btnmainlandEcuador = document.getElementById('btn-mainlandEcuador'),
    btntravelPlanning = document.getElementById('btn-travelPlanning'),
    btntripTypes = document.getElementById('btn-tripTypes'),
    btntripFinderdesktop = document.getElementById('btn-tripFinderDesktop'),
    btntripFinderMovil = document.getElementById('btn-tripFinder'),
    btnregresarmenu = document.getElementById('btn-regresarMenu'),
    btnregresarCategorias = document.getElementById('btn-regresarCategorias');
logoAndando = document.getElementById('logoAndado');
btnCerrarMenu = document.getElementById('btn-cerrar-menu');
menuAndado = document.getElementById('menuAndando');
menuSecundario = document.getElementById('menusecundario');

grid = document.getElementById('grid'),
    subcategoria = document.getElementById('subcategoria'),
    contenedorEnlaceNav = document.querySelector('#menuAndando .contenedor-enlaces-nav'),
    contenedorSubCategorias = document.querySelector('#grid .contenedor-subcategorias');

arrow = document.getElementById('triangulo');

mensaje = document.getElementById('mensajeFijo');
contenidoFiltro = document.getElementById('contenidoFiltroId');

GalapagosCruisesFooter = document.getElementById('galapagos-cruises-footer');
GalapagosMainLandFooter = document.getElementById('galapagos-mainland-footer');
TravelPlanningFooter = document.getElementById('travel-planning-footer');

esDispositivoMovil = () => {
    if (window.innerWidth <= 800) {

        return true;
    } else {

        return false;
    }
}

esDispositivoMovil1 = () => window.innerWidth <= 800;


btngalapagos.addEventListener('mouseover', () => {
    document.getElementById('triangulo1').style.display = 'none';
    if (!esDispositivoMovil()) {
        grid.classList.add('activo');

        GalapagosCruisesFooter.classList.add('activofoot');
        GalapagosMainLandFooter.classList.remove('activofoot');
        TravelPlanningFooter.classList.remove('activofoot');
        document.getElementById('triangulo').style.display = 'flex';

        document.querySelectorAll('#menuAndando .subcategoria').forEach((subcategoria) => {
            //console.log(categoria.dataset.categoria);

            subcategoria.classList.remove('activo');


            if (subcategoria.dataset.categoria == 'galapagos-cruises') {

                subcategoria.classList.add('activo');
                const containerBanner = document.getElementById('subcategoria-bannerCruises');
                containerBanner.style.gridTemplateColumns = ' 1fr';
            }
        });


    }


});

btngalapagosIsland.addEventListener('mouseover', () => {
    document.getElementById('triangulo').style.display = 'none';
    document.getElementById('triangulo2').style.display = 'none';
    if (!esDispositivoMovil()) {
        grid.classList.add('activo');
        GalapagosCruisesFooter.classList.remove('activofoot');
        GalapagosMainLandFooter.classList.remove('activofoot');
        TravelPlanningFooter.classList.remove('activofoot');

        document.getElementById('triangulo1').style.display = 'flex';

        document.querySelectorAll('#menuAndando .subcategoria').forEach((subcategoria) => {
            //console.log(categoria.dataset.categoria);

            subcategoria.classList.remove('activo');

            if (subcategoria.dataset.categoria == 'galapagos-land') {

                subcategoria.classList.add('activo');
                const containerBanner = document.getElementById('subcategoria-bannerLand');
                containerBanner.style.gridTemplateColumns = ' 1fr';
            }
        });
    }


});



btnmainlandEcuador.addEventListener('mouseover', () => {
    document.getElementById('triangulo1').style.display = 'none';
    document.getElementById('triangulo3').style.display = 'none';
    if (!esDispositivoMovil()) {
        grid.classList.add('activo');
        GalapagosMainLandFooter.classList.add('activofoot');

        GalapagosCruisesFooter.classList.remove('activofoot');
        TravelPlanningFooter.classList.remove('activofoot');

        document.getElementById('triangulo2').style.display = 'flex';

        document.querySelectorAll('#menuAndando .subcategoria').forEach((subcategoria) => {
            //console.log(categoria.dataset.categoria);

            subcategoria.classList.remove('activo');

            if (subcategoria.dataset.categoria == 'avenue-volcanoes') {

                subcategoria.classList.add('activo');
                const containerBanner = document.getElementById('subcategoria-banner');
                containerBanner.style.gridTemplateColumns = ' 1fr';

            }
        });
    }
});

btntravelPlanning.addEventListener('mouseover', () => {
    document.getElementById('triangulo4').style.display = 'none';
    document.getElementById('triangulo2').style.display = 'none';
    arrow.classList.remove('activo');
    if (!esDispositivoMovil()) {
        grid.classList.add('activo');

        GalapagosMainLandFooter.classList.remove('activofoot');

        GalapagosCruisesFooter.classList.remove('activofoot');
        TravelPlanningFooter.classList.add('activofoot');

        document.getElementById('triangulo3').style.display = 'flex';

        document.querySelectorAll('#menuAndando .subcategoria').forEach((subcategoria) => {
            //console.log(categoria.dataset.categoria);

            subcategoria.classList.remove('activo');

            if (subcategoria.dataset.categoria == 'travel-planning') {

                subcategoria.classList.add('activo');
                const containerBanner = document.getElementById('subcategoria-bannerPlanning');
                containerBanner.style.gridTemplateColumns = ' 1fr';
            }
        });
    }
});

btntripTypes.addEventListener('mouseover', () => {
    document.getElementById('triangulo3').style.display = 'none';
    document.getElementById('triangulo5').style.display = 'none';
    if (!esDispositivoMovil()) {
        grid.classList.add('activo');

        GalapagosMainLandFooter.classList.remove('activofoot');

        GalapagosCruisesFooter.classList.remove('activofoot');
        TravelPlanningFooter.classList.remove('activofoot');

        contenidoFiltro.classList.remove('activo');
        document.getElementById('triangulo4').style.display = 'flex';

        document.querySelectorAll('#menuAndando .subcategoria').forEach((subcategoria) => {
            subcategoria.classList.remove('activo');

            if (subcategoria.dataset.categoria == 'family-travel') {

                subcategoria.classList.add('activo');
                const container = document.getElementById('subcategoria-banner1');
                container.style.gridTemplateColumns = ' 1fr';
            }
        });
    }

});

//Quitar menu en la pagina de TripPlanner
btntripFinderdesktop.addEventListener('mouseover', () => {
    document.getElementById('triangulo4').style.display = 'none';
    if (!esDispositivoMovil()) {
        var vistaUrl = window.location;
        var res = vistaUrl.pathname.split("/");
        if (res[2] == "tri_planner") {
            contenidoFiltro.classList.remove('activo');
            grid.classList.remove('activo');
            document.getElementById('triangulo5').style.display = 'none';
        } else {
            var menuSecund = document.getElementById('menusecundario');
            if (menuSecund.style.display == 'none') {
                console.log('dasda')
                document.getElementById('contenidoFiltroId').style.marginTop = '-40px';
            } else {
                document.getElementById('contenidoFiltroId').style.marginTop = '0px';
            }
            contenidoFiltro.classList.add('activo');
            grid.classList.remove('activo');
            document.getElementById('triangulo5').style.display = 'flex';
        }
    }
});


grid.addEventListener('mouseleave', () => {
    if (!esDispositivoMovil()) {
        grid.classList.remove('activo');

        GalapagosMainLandFooter.classList.remove('activofoot');
        GalapagosCruisesFooter.classList.remove('activofoot');
        TravelPlanningFooter.classList.remove('activofoot');

        contenidoFiltro.classList.remove('activo');
        document.getElementById('triangulo').style.display = 'none';
        document.getElementById('triangulo1').style.display = 'none';
        document.getElementById('triangulo2').style.display = 'none';
        document.getElementById('triangulo3').style.display = 'none';
        document.getElementById('triangulo4').style.display = 'none';
        document.getElementById('triangulo5').style.display = 'none';
        document.querySelectorAll('#menuAndando .subcategoria').forEach((elemento) => {

            elemento.classList.remove('activo');
        });
    }
});



contenidoFiltro.addEventListener('mouseleave', () => {
    if (!esDispositivoMovil()) {
        contenidoFiltro.classList.remove('activo');
        document.getElementById('triangulo5').style.display = 'none';
    }
});


document.getElementById('enlacesAndando').addEventListener('mouseover', () => {
    if (!esDispositivoMovil()) {
        grid.classList.remove('activo');
        GalapagosMainLandFooter.classList.remove('activofoot');
        GalapagosCruisesFooter.classList.remove('activofoot');
        TravelPlanningFooter.classList.remove('activofoot');
        contenidoFiltro.classList.remove('activo');
        document.getElementById('triangulo').style.display = 'none';
        document.getElementById('triangulo1').style.display = 'none';
        document.getElementById('triangulo2').style.display = 'none';
        document.getElementById('triangulo3').style.display = 'none';
        document.getElementById('triangulo4').style.display = 'none';
        document.getElementById('triangulo5').style.display = 'none';
    }
});



document.querySelectorAll('#btn-group ul li').forEach((elemento) => {
    elemento.addEventListener('mousedown', (e) => {

        contenidoFiltro.classList.add('activo');
    });
});


document.querySelectorAll('#menuAndando .contenedor-enlaces-nav div').forEach((elemento) => {
    elemento.addEventListener('mouseover', (e) => {


        // console.log(e.target.dataset.categoria);


        document.querySelectorAll('#menuAndando .categorias ').forEach((categoria) => {

            categoria.classList.remove('activo');
            if (categoria.dataset.categoria == e.target.dataset.categoria) {
                categoria.classList.add('activo');

            }

        });
    });
});


document.querySelectorAll('#menuAndando .categorias a').forEach((elemento) => {

    elemento.addEventListener('mouseenter', (e) => {

        if (!esDispositivoMovil()) {

            document.querySelectorAll('#menuAndando .subcategoria').forEach((categoria) => {

                categoria.classList.remove('activo');
                //console.log(categoria.dataset.categoria);

                if (categoria.dataset.categoria == e.target.dataset.categoria) {

                    categoria.classList.add('activo');
                }

            });
        }


    });


});

document.querySelectorAll('#menuAndando .subcategoria div a').forEach((subcategoria, indice) => {
    subcategoria.addEventListener('mouseenter', (e) => {
        document.querySelectorAll('#menuAndando .categorias a').forEach((valor, indice) => {
            if (subcategoria.dataset.categoria == valor.dataset.categoria) {
                valor.classList.add('actcolor');

            }

        });

        document.querySelectorAll('#menuAndando .categorias a i').forEach((flecha) => {

            if (subcategoria.dataset.categoria == flecha.dataset.categoria) {
                flecha.classList.add('actcolorFlec');
            }

        });
    });

    subcategoria.addEventListener('mouseleave', (e) => {

        document.querySelectorAll('#menuAndando .categorias a').forEach((valor, indice) => {
            valor.classList.remove('actcolor');

        });

        document.querySelectorAll('#menuAndando .categorias a i').forEach((flecha, indice) => {
            flecha.classList.remove('actcolorFlec');

        });
    });
});



//-----------------------------EventListener para pantallas dispositivo movil-------------------------------------------------

btngalapagosSig = document.getElementById('btn-galapagosCruises-sig');
btngalapagosIslandSig = document.getElementById('btn-galapagos-Island-sig');
btnmainlandEcuadorSig = document.getElementById('btn-mainlandEcuador-sig');
btntravelPlanningSig = document.getElementById('btn-travelPlanning-sig');
imgbanner = document.getElementById('subcategoria-banner');

document.querySelector('#btn-menu-barras').addEventListener('click', (e) => {
    e.preventDefault();
    if (contenedorEnlaceNav.classList.contains('activo')) {
        contenedorEnlaceNav.classList.remove('activo');
        document.querySelector('body').style.overflow = 'visible';
    } else {
        contenedorEnlaceNav.classList.add('activo');
        document.querySelector('body').style.overflow = 'hidden';
    }
});

//Click en boton de todos las categorias (version movil)
btngalapagos.addEventListener('click', (e) => {
    e.preventDefault;
    mensaje.style.color = '#28981b';

    if (esDispositivoMovil()) {
        grid.classList.add('activo');
    } else {
        //window.open("/Cruises", "_self")
    }

});


btngalapagosIsland.addEventListener('click', (e) => {
    e.preventDefault;
    mensaje.style.color = '#28981b';

    if (esDispositivoMovil()) {
        grid.classList.add('activo');
    } else {
        //window.open("/Cruises", "_self")
    }
});

btnmainlandEcuador.addEventListener('click', (e) => {
    e.preventDefault;
    mensaje.style.color = '#28981b';

    if (esDispositivoMovil()) {
        grid.classList.add('activo');
    } else {
        //window.open("../ecuador-itineraries", "_self")
    }

});


btntravelPlanning.addEventListener('click', (e) => {
    e.preventDefault;
    mensaje.style.color = '#28981b';

    if (esDispositivoMovil()) {
        grid.classList.add('activo');
    } else {
        //window.open("/Planning", "_self")
    }

});


btntripTypes.addEventListener('click', (e) => {
    e.preventDefault;
    mensaje.style.color = '#28981b';

    if (esDispositivoMovil()) {
        grid.classList.add('activo');
    } else {
        //window.open("/trip_planner/tri_planner", "_self")
    }

});

btntripFinderMovil.addEventListener('click', (e) => {
    e.preventDefault;
    grid.classList.add('activo');
    mensaje.style.color = '#28981b';
    //btnCerrarMenu.classList.add('activo');

});

//boton de regresar en el menu categorias
//document.querySelector('#grid .categorias .btn-regresar').addEventListener('click', (e) => {
//    e.preventDefault();
//    grid.classList.remove('activo');
//    btnCerrarMenu.classList.remove('activo');

//});

btnregresarmenu.addEventListener('click', (e) => {
    e.preventDefault();
    grid.classList.remove('activo');
    btnCerrarMenu.classList.remove('activo');

});


document.querySelectorAll('#menuAndando  .categorias a').forEach((elemento) => {
    elemento.addEventListener('click', (e) => {
        if (esDispositivoMovil()) {
            contenedorSubCategorias.classList.add('activo');
            document.querySelectorAll('#menuAndando  .subcategoria').forEach((categoria) => {

                categoria.classList.remove('activo');

                if (categoria.dataset.categoria == e.target.dataset.categoria) {
                    categoria.classList.add('activo');


                }
            });
        }


    });

});



document.querySelectorAll('#grid .contenedor-subcategorias .subcategoria  .btn-regresar').forEach((boton) => {
    boton.addEventListener('click', (e) => {
        e.preventDefault();
        document.querySelectorAll('#grid .contenedor-subcategorias .subcategoria').forEach((categoria) => {

            categoria.classList.remove('activo');
        });


    });

});
btnCerrarMenu.addEventListener('click', (e) => {
    e.preventDefault();
    contenedorEnlaceNav.classList.remove('activo');
    document.querySelector('body').style.overflow = 'visible';
});



//Union del menu principal con el submenu

$(document).ready(function () {


    //if (!esDispositivoMovil()) {
    //    document.getElementById("navpagina").classList.add("page-nav");
    //}
    var stickyToggle = function (sticky, stickyWrapper, scrollElement) {

        var stickyHeight = sticky.outerHeight();
        var stickyTop = stickyWrapper.offset().top;

        if (!esDispositivoMovil()) {

            if (scrollElement.scrollTop() >= (stickyTop - 100)) {
                menuSecundario.style.display = 'none';
                menuAndado.style.top = '0';
                stickyWrapper.height(stickyHeight - 50);
                sticky.addClass("is-sticky");
                btngalapagos.style.marginTop = '8px';

            }
            else {
                sticky.removeClass("is-sticky");
                stickyWrapper.height('0');
                menuSecundario.style.display = 'block';
                btngalapagos.style.marginTop = '0px';

            }

        } else {
            //document.getElementById("navpagina").classList.remove("page-nav");
            if (scrollElement.scrollTop() >= (stickyTop)) {
                menuSecundario.style.display = 'none';
                menuAndado.style.top = '0';
                if (window.innerWidth >= 474 && window.innerWidth < 960) {
                    stickyWrapper.height(stickyHeight - 50);
                } else {
                    stickyWrapper.height(stickyHeight - 90);
                }

                sticky.addClass("is-sticky");



            }
            else {
                sticky.removeClass("is-sticky");
                stickyWrapper.height('0');
                //menuAndado.style.top = '40px';
                menuSecundario.style.display = 'block';


            }
        }


    };

    // Find all data-toggle="sticky-onscroll" elements
    $('[data-toggle="sticky-onscroll"]').each(function () {
        var sticky = $(this);
        var stickyWrapper = $('<div>').addClass('sticky-wrapper'); // insert hidden element to maintain actual top offset on page
        sticky.before(stickyWrapper);
        sticky.addClass('sticky');

        // Scroll & resize events
        $(window).on('scroll.sticky-onscroll resize.sticky-onscroll', function () {
            stickyToggle(sticky, stickyWrapper, $(this));

        });
        // On page load
        stickyToggle(sticky, stickyWrapper, $(window));

    });


    var vistaUrl = window.location;
    var res = vistaUrl.pathname.split("/");

    switch (res[3]) {
        case "sierra-negra":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';

            }
            break;
        case "tintoreras-islet":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "cabo-rosa-tuneles":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "south-plazas":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "north-seymour":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "bartolome-island-sullivan-bay":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "pitt-point":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "kicker-rock":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "espanola-island":
            if (esDispositivoMovil()) {
                var btnInquiDaily = document.getElementById("btnDailyTours");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiDaily.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "amazon-tours-ecuador":
            if (esDispositivoMovil()) {
                console.log(res)
                var btnInquiEcuadorItin = document.getElementById("btnEcuadorItinerarios");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiEcuadorItin.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;

    }

    //Condicional para el modal Ecuador itinerarios, para dispositivos moviles

    switch (res[2]) {


        case "amazon-tours-ecuador":
            if (esDispositivoMovil()) {
                var btnInquiEcuadorItin = document.getElementById("btnEcuadorItinerarios");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiEcuadorItin.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "avenue-of-volcanoes":
            if (esDispositivoMovil()) {
                var btnInquiEcuadorItin = document.getElementById("btnEcuadorItinerarios");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiEcuadorItin.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "austral-paths":
            if (esDispositivoMovil()) {
                var btnInquiEcuadorItin = document.getElementById("btnEcuadorItinerarios");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiEcuadorItin.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "magical-north":
            if (esDispositivoMovil()) {
                var btnInquiEcuadorItin = document.getElementById("btnEcuadorItinerarios");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiEcuadorItin.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;
        case "cloud-forest":
            if (esDispositivoMovil()) {
                var btnInquiEcuadorItin = document.getElementById("btnEcuadorItinerarios");
                var btnInquireMovile = document.getElementById("btnInquireMovil");
                btnInquiEcuadorItin.classList.remove('desbl');
                btnInquireMovile.style.display = 'none';
            }
            break;


    }





});



//-----Home Cruises Card:Hover-----------------
$(document).ready(function () {
    $('.card-cruises').hover(

        function () {
            $(this).animate({
                marginTop: "-=1%",
            }, 200);
        },


        function () {
            $(this).animate({
                marginTop: "0%"
            }, 200);
        }

    );

});

//------------Filtros Menu--------------------------------
//------------Slider Filtros ----------------
$(function () {
    $("#slider-range").slider({
        range: true,
        min: 300,
        max: 7500,
        values: [300, 7500],
        slide: function (event, ui) {
            $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $("#amount").val("$" + $("#slider-range").slider("values", 0) +
        " - $" + $("#slider-range").slider("values", 1));

    $(".slider-rangePrice").slider({
        range: true,
        min: 300,
        max: 7500,
        values: [300, 7500],
        slide: function (event, ui) {
            $(".amountPrice").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $(".amountPrice").val("$" + $(".slider-rangePrice").slider("values", 0) +
        " - $" + $(".slider-rangePrice").slider("values", 1));
});
//$(function () {
//    $("#slider-rangePrice").slider({
//        range: true,
//        min: 1200,
//        max: 7500,
//        values: [1200, 7500],
//        slide: function (event, ui) {
//            $("#amountPrice").val("$" + ui.values[0] + " - $" + ui.values[1]);
//        }
//    });
//    $("#amountPrice").val("$" + $("#slider-rangePrice").slider("values", 0) +
//        " - $" + $("#slider-rangePrice").slider("values", 1));
//});
function resettlePricePlanner() {
    $(".slider-rangePrice").slider({
        range: true,
        min: 300,
        max: 7500,
        values: [300, 7500],
        slide: function (event, ui) {
            $(".amountPrice").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $(".amountPrice").val("$" + $(".slider-rangePrice").slider("values", 0) +
        " - $" + $(".slider-rangePrice").slider("values", 1));
}
function resettlePrice() {
    $("#slider-range").slider({
        range: true,
        min: 300,
        max: 7500,
        values: [300, 7500],
        slide: function (event, ui) {
            $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $("#amount").val("$" + $("#slider-range").slider("values", 0) +
        " - $" + $("#slider-range").slider("values", 1));
}
$(function () {
    $("#slider-range1").slider({
        range: true,
        min: 300,
        max: 7500,
        values: [300, 7500],
        slide: function (event, ui) {
            $("#amount1").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $("#amount1").val("$" + $("#slider-range1").slider("values", 0) +
        " - $" + $("#slider-range1").slider("values", 1));
});

function resettlePriceMov() {
    $("#slider-range1").slider({
        range: true,
        min: 300,
        max: 7500,
        values: [300, 7500],
        slide: function (event, ui) {
            $("#amount1").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $("#amount1").val("$" + $("#slider-range1").slider("values", 0) +
        " - $" + $("#slider-range1").slider("values", 1));
}

//--------------------Bloquear Menu----------------------------------------------------------------------

function bloq() {
    document.getElementById('filtrosAndando').style.display = 'flex';
    document.getElementById('contenidoFiltroId').classList.add('bloq');
    document.querySelector('body').classList.add('hiddenBody');

}
function desbloq() {
    document.getElementById('filtrosAndando').style.display = 'none';
    document.getElementById('contenidoFiltroId').classList.remove('bloq');
    document.querySelector('body').classList.remove('hiddenBody');
}

function localVisitor() {
    var prueba1 = document.getElementById("idVisit").value;
    console.log("local: " + Number(prueba1));
    localStorage.setItem('ViSite', JSON.stringify(Number(prueba1)));
}

//Open menu lateral 

function openNav() {
    if (window.innerWidth > 600) {

        document.getElementById("mySidenav").style.width = "47%";
    }
    if (window.innerWidth < 600) {

        document.getElementById("mySidenav").style.width = "80%";
    }

}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}


