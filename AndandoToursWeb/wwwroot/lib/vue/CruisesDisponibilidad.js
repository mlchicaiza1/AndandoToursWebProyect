var cruisesDispo = new Vue({
    el: '#dipoCruises',
    data: {
        contTrip: "",
        contType: "",
        cont: "",
        categoryDispo:[],
        triptype: 'Cruises',
        checkColor: "#787778",
        maintripType: [],
        checkedBarcos: [],
        travelersTot: "Travelers",
        count: 2,
        count1: 0,
        dateTrip: 'Date',
        //Mensaje
        datanull:'',
        //DataPickerModal
        dateModal: 'Select your travel dates',
        countLen: 0,
        trip: [],
        menu: '',

        //Resettle date
        selectDate_1: null,
        selectDate: null,
        selectDateModal: null,
        datePickerSelect: [],
        datePickerSelect_1: [],
        contdatePicker_1: 0,
        contdatePicker_2: 0,

        //Todos los barcos
        ListBarcoCards: [],
        cargaDatos: {
            imgIsland: "loading...",
            imgIsland1: "loading...",
            imgIsland2: "loading...",
            imgIsland3: "loading...",
            imgIsland4: "loading...",
            imgIsland5: "loading...",
        },
        classObject: 'col-md-4',
        desBarco: [],
        eco: "eco",
        cardEco: "cardEco",
        cruisedetailsEco: "cruise-detailsEco",
        cruiseDetails: "cruise-details",
        wildAid: "wildAid",
        hide: "hide",
        //Paginacion Barcos
        nexid: 13,
        currentPage: 0,
        pageSize: 9,
        visibleTodos: [],
        //Variables disponibilidad de las Apis
        dispApiMaPa: [], //diponiblidad passion-MaryAnn
        dispApiOtrosBarcos: [],

        disApiRoyalInfinity: [],//disponibilidad api royal Barco Infinity
        disApiRoyalGranMajestic: [],//disponibilidad api royal Barco Gran Majestic
        disApiRoyal: [],//disponibilidad api royal
        idBarcoCard: '',
        //Detectar datos en la diponibilidad de barcos
        dispBarcosVerficarInf: 'Loading information…',
        dispVerficarOtrosBarcos:'Loading information…',

        disponibilidadBarcos:true,
        results: '',
        respuestaBarcos:'',

        DispSelectBarcoPaMa: [],
        DispSelectOtrosBarco: [],
        cabinas: [],
        
        //Seleccionar cabinas
        passengSelect: 'passengers',
        passengSelectCab2: 'passengers',

        passengCantCab1: 0,
        passengCantCab2: 0,
        //Datos de la disponibilidad en cada api
        datosFiltro: [],

        //Datos Cards barcos
        datoCardBarco: [],

        datBarcosSelect: '',

        //Itinerarios BARCOS
        itiBarco: [],
        itiBarcoBtn: [],
        filItinerAM: [],
        filItinerPM: [],
        datosIti: [],
        datosCompl: [],
        cont: 1,
        filtDias: [],
        filtAM: [],
        visible: true,
        numeroDeDias: '',
        idBarcoItinerario: '',
        active: 'item active',
        noActivo: 'item',
        itinerBlock: 'itinerBlock',
        itiner: 'itiner',
        itiCompDescripcionDescriptivoEn: '',
        contbtn: 0,

        //mensaje de validacion email
        email: '',
        colorEmailVal: '',
        show:'',
    },
    created: function () {
        this.getCategoriaDispo();
        this.getListBarcoCards();

    },
    methods: {
        getCategoriaDispo() {
            var vm = this;
            $.ajax({ url: "/CategoriaBarco", method: "GET" }).done(function (data) {
                vm.maintripType = data;
                vm.checkedTrip = data;
            });
        },
        getListBarcoCards: function (event) {
            var dp = this;

            if (event == undefined) {
                //Cargar datos en las cards desde la  sp getBarcosWeb, del controlador asi la vista 
                $.ajax({ url: "/BarcoBD", method: "GET" }).done(function (data) {
                    dp.ListBarcoCards = data;
                    for (let dat of data) {
                        var cadena = dat.barcoDescripcionCortaEn;
                        var temporal = document.createElement("div");
                        temporal.innerHTML = cadena;
                        var texto = temporal.textContent || temporal.innerText || "";
                        dp.desBarco.push(texto);
                    }

                });
                //Cargar datos de la  Api disponibilidad de los barcos, del controlador asi la vista 
                $.ajax({ url: "/Dispo", method: "GET" }).done(function (data) {
                    dp.dispApiMaPa = data;
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    if (console && console.log) {
                        dp.dispBarcosVerficarInf = "We couldn´t load the available departures. Please, try later";
                    }
                });

                $.ajax({ url: "/DispoOtrosBarcos", method: "GET" }).done(function (data) {
                    dp.dispApiOtrosBarcos = data;

                }).fail(function (jqXHR, textStatus, errorThrown) {
                    if (console && console.log) {
                        dp.dispVerficarOtrosBarcos = "We couldn´t load the available departures. Please, try later";

                    }
                });
            } else {
                //Iniciar variable para la paginacion
                dp.currentPage = 0;
                //funcion para acomodar y Limpiar datos para usar en filtros 
                this.datosFiltro = limpiarDatosDipoCruceros(dp.travelersTot, dp.dateTrip);
                dp.disponibilidadBarcos=true
                var selectBarcos = this.checkedBarcos;
                var idBarcofiltro = [];
                var listaCardsDispo = [];
                var travelers = this.datosFiltro[0];
                var date = this.datosFiltro[1];

                dp.ListBarcoCards = [];
                dp.desBarco = [];

                var DispSelectBarcoMaPa = dp.dispApiMaPa.filter(function (item) {
                    if (parseInt(item.totalDisponibilidad) >= travelers[1]) {
                        if (new Date(item.salFechaSalida).getTime() >= new Date(date[0]).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(date[1]).getTime()) {

                            return item;
                        }
                    }
                });
                var DispSelectBarco = dp.dispApiOtrosBarcos.filter(function (item) {
                    if (parseInt(item.salDispoTotalOtrosBarcos) >= travelers[1]) {
                        if (new Date(item.salFechaSalida).getTime() >= new Date(date[0]).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(date[1]).getTime()) {


                            return item;
                        }
                    }
                });
                

                if (DispSelectBarcoMaPa.length == 0 && DispSelectBarco.length==0) {
                    dp.disponibilidadBarcos = false
                    dp.results = 'No results'
                    dp.respuestaBarcos = 'To get more results, try adjusting your search'
                    var fechaInicio = new Date();
 
                    var DispSelectBarcoMaPa = dp.dispApiMaPa.filter(function (item) {
                        if (parseInt(item.totalDisponibilidad) >= 2) {
                            if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime() ) {

                                return item;
                            }
                        }
                    });
                    var DispSelectBarco = dp.dispApiOtrosBarcos.filter(function (item) {
                        if (parseInt(item.salDispoTotalOtrosBarcos) >= 2) {
                            if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime()) {


                                return item;
                            }
                        }
                    });
                }

                //Obtner el id de los barcos 
                for (let dat of DispSelectBarcoMaPa) {
                    idBarcofiltro.push(dat.idBarco)
                }

                for (let dat of DispSelectBarco) {
                    idBarcofiltro.push(dat.idBarco)
                }
                listaCardsDispo = idBarcofiltro.filter(function (value, index, self) {
                    return self.indexOf(value) === index;
                });

                //Al sleccionar las categorias, los barcos se filtraran en sus respectivos grupos de categorias        
                if (selectBarcos.length > 0) {
                    $.ajax({ url: "/BarcoBD", method: "GET" }).done(function (data) {
                        for (let dat of data) {
                            for (let itemCategoria of selectBarcos) {

                                if (itemCategoria == dat.barcoCategoriaTipoNombreEn) {

                                    for (let idBarcoDispo of listaCardsDispo) {
                                        if (idBarcoDispo == dat.idBarco) {

                                            //agregar barcos filtrados a la lista
                                            dp.ListBarcoCards.push(dat)

                                            //Quitar tags html a la descripcion de cada barco
                                            var cadena = dat.barcoDescripcionCortaEn;
                                            var temporal = document.createElement("div");
                                            temporal.innerHTML = cadena;
                                            var texto = temporal.textContent || temporal.innerText || "";
                                            dp.desBarco.push(texto);
                                        }
                                    }



                                }

                            }

                        }

                        if (dp.ListBarcoCards.length == 0) {
                            dp.disponibilidadBarcos = false
                            dp.results = 'No results'
                            dp.respuestaBarcos = 'To get more results, try adjusting your search'

                            for (let idBarcoDispo of listaCardsDispo) {

                                for (let dat of data) {

                                    if (idBarcoDispo == dat.idBarco) {
                                        //agregar barcos filtrados a la lista
                                        dp.ListBarcoCards.push(dat)
                                        //Quitar tags html a la descripcion de cada barco
                                        var cadena = dat.barcoDescripcionCortaEn;
                                        var temporal = document.createElement("div");
                                        temporal.innerHTML = cadena;
                                        var texto = temporal.textContent || temporal.innerText || "";
                                        dp.desBarco.push(texto);

                                    }

                                }

                            }
                        }
                    });
                    
                    
                }
                //Al no seleccionar ningun barco se cargan todos los barcos
                if (selectBarcos.length == 0) {
                    $.ajax({ url: "/BarcoBD", method: "GET" }).done(function (data) {

                        for (let idBarcoDispo of listaCardsDispo) {

                            for (let dat of data) {

                                if (idBarcoDispo == dat.idBarco) {
                                    //agregar barcos filtrados a la lista
                                    dp.ListBarcoCards.push(dat)
                                    //Quitar tags html a la descripcion de cada barco
                                    var cadena = dat.barcoDescripcionCortaEn;
                                    var temporal = document.createElement("div");
                                    temporal.innerHTML = cadena;
                                    var texto = temporal.textContent || temporal.innerText || "";
                                    dp.desBarco.push(texto);

                                }

                            }

                        }

                    });
                }

            }

           

             

            //Agregar datos de las cards a un contenedor de paginacion
            this.visibleTodos = this.ListBarcoCards.slice(this.currentPage * this.pageSize, (this.currentPage * this.pageSize) + this.pageSize);
            if (this.visibleTodos.length == 0 && this.currentPage > 0) {
                this.updatePage(this.currentPage - 1);
            }
        },

        

        //Abrir Modal availabilityModal.cshtml y guardar id de Barco Seleccionado
        ShowDispoBarco: function (event) {
            this.datoCardBarco = [];
            //tomar id de la card del barco en una variable para enviarla a una funcion (filtroDispoBarcosPaMa y filDispoBarcos) del computed
            this.idBarcoCard = event.currentTarget.id;

            //Obtner descripcion barco e imagen para el modal availability
            var idCard = event.currentTarget.id;
            this.datoCardBarco = this.ListBarcoCards.filter(function (item) {
                if (item.idBarco == idCard) {
                    return item;
                }
            });

            if (this.dateTrip == "Date" || this.dateTrip == "") {
                this.dateModal = "Select your travel dates";
            } else {
                if (this.dateTrip.split(',')[0] == "" || this.dateTrip.split(',')[1] == "") {
                    this.dateModal = this.dateTrip.replace(",", "")
                    
                } else {
                    this.dateModal = this.dateTrip;
                }
                
            }

            //Abrir modal de los barcos Passion-Mary Ann 
           
            switch (idCard) {
                case "85":
                    $('#avaiPaMaModal').modal('show');
                    break;
                case "73":
                    $('#avaiPaMaModal').modal('show');
                    break;
                default:
                    $('#avaiModal').modal('show');
                    break;
            }
            
           
        },

        getservicioPaMa: function (event) {
            $("#detailsCabPaMa").modal('show');
            var idSalidaBarco = event.currentTarget.id;
            
            this.cabinas = [];
            
            this.datBarcosSelect=idSalidaBarco;

            this.cabinas = this.DispSelectBarcoPaMa.filter(function (item) {
                if (item.idSalida == idSalidaBarco) {
                    return item;
                }
            });
            
        },

        converDispoTextInt: function (dispoOtrosBarcos) {
            var dispo;
            if (dispoOtrosBarcos == null) {
                dispo = 1;
            } else {
                dispo = parseInt(dispoOtrosBarcos);
            }
            return dispo;
        },

        getservicioOtrosBarcos: function (event) {
            $("#detailsCabOtrosBarcos").modal('show');
            var idSalidaBarco = event.currentTarget.id;
            this.cabinas = [];

            this.cabinas = this.DispSelectOtrosBarco.filter(function (item) {
                if (item.idSalida == idSalidaBarco) {
                    return item;
                }
            });

        },

        checkPassengers: function (event) {

            this.passengSelect = event.currentTarget.id + ' passengers';
            this.passengCantCab1 = event.currentTarget.id;

        },
        checkPassengersCab2: function (event) {

            this.passengSelectCab2 = event.currentTarget.id + ' passengers';
            this.passengCantCab2 = event.currentTarget.id;
        },

        SelectPasseng: function() {

            $("#btnPassenCabina1").removeClass("ValidTInyp input-iconoError ");

            $("#btnPassenCabina1").addClass("btn btn-default dropdown-toggle");

            $("#btnPassenCabina2").removeClass("ValidTInyp input-iconoError ");

            $("#btnPassenCabina2").addClass("btn btn-default dropdown-toggle");

            //Botones Movile
            $("#btnPassenCabinaMovile").removeClass("ValidTInyp input-iconoError ");
            $("#btnPassenCabinaMovile").addClass("btn btn-default dropdown-toggle");
            $("#btnPassenCabinaMovile2").removeClass("ValidTInyp input-iconoError ");
            $("#btnPassenCabinaMovile2").addClass("btn btn-default dropdown-toggle");
            
        },
        SelectPassengOtrsBarcos: function () {

            $("#btnPassenOtroBarco1").removeClass("ValidTInyp input-iconoError ");

            $("#btnPassenOtroBarco1").addClass("btn btn-default dropdown-toggle");

            $("#btnPassenOtroBarco2").removeClass("ValidTInyp input-iconoError ");

            $("#btnPassenOtroBarco2").addClass("btn btn-default dropdown-toggle");

            //Botones Movile
            $("#btnPassenOtrosBarcosMov").removeClass("ValidTInyp input-iconoError ");
            $("#btnPassenOtrosBarcosMov").addClass("btn btn-default dropdown-toggle");
            $("#btnPassenOtrosBarcosMov2").removeClass("ValidTInyp input-iconoError ");
            $("#btnPassenOtrosBarcosMov2").addClass("btn btn-default dropdown-toggle");


        },
        validar_email: function (email) {
            var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return regex.test(email) ? true : false;
        },
        writeTextValidacionEmail: function () {
            $("#emailClient").removeClass("ValidTInyp input-iconoError ");
            $('#emailClient').addClass("form-control");

            $("#emailClientOtrosBarcos").removeClass("ValidTInyp input-iconoError ");
            $('#emailClientOtrosBarcos').addClass("form-control");
            this.email = "";
        },
        writeTextValidacionName: function () {
            $("#nameClient").removeClass("ValidTInyp input-iconoError ");
            $('#nameClient').addClass("form-control");

            $("#nameClientOtrosBarcos").removeClass("ValidTInyp input-iconoError ");
            $('#nameClientOtrosBarcos').addClass("form-control");
        },
        //Cargar salida del barco, itinerarios e informacion del usuario del Passion-Mary
        loadDataBoatPassionMary: function () {


            var leadsBoars = new Object();
            leadsBoars.NombreBarco = this.cabinas[0].barcoNombre;
            leadsBoars.Itinerario = this.cabinas[0].itinNombre;
            leadsBoars.Noches = this.cabinas[0].noches;
            leadsBoars.SalCodigo = this.cabinas[0].idSalida;
            leadsBoars.Correo = document.getElementById("emailClient").value;
            leadsBoars.Nombre = document.getElementById("nameClient").value;
            leadsBoars.NummeroMax = parseInt(this.passengCantCab1) + parseInt(this.passengCantCab2);
            leadsBoars.Observacion = "";



            console.log(leadsBoars);
            $.ajax({
                type: "POST",
                url: "/Cruises/CreateLeadsBoats",
                data: JSON.stringify(leadsBoars),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response != null) {

                    } else {
                        alert("Something went wrong");
                    }
                },
                failure: function (response) {
                    alert(response.responseText);

                },

            });

            window.location.href = "../thank-you-page-availability/";


        },

        //Enviar informacion de los barcos Passion-Mary
        SendleadBoatPassionMary: function () {


            var EmailTxt = document.getElementById("emailClient");
            var NameTxt = document.getElementById("nameClient");
            var cantPassengCab = parseInt(this.passengCantCab1) + parseInt(this.passengCantCab2);


            if (this.validar_email($(EmailTxt).val())) {
                this.email = "";

                EmailTxt.className = "form-control input-icono";
            }
            else {

                EmailTxt.className = "ValidTInyp input-iconoError";
                this.email = "EMAIL MUST BE FORMATTED CORRECTLY";
                this.colorEmailVal = "red";
            }
            if ($(NameTxt).val().length == 0) {

                NameTxt.className = "ValidTInyp input-iconoError";

            } else {
                NameTxt.className = "form-control input-icono";


            }

            if (cantPassengCab == 0) {
                $("#btnPassenCabina1").addClass("ValidTInyp input-iconoError");
                $("#btnPassenCabina2").addClass("ValidTInyp input-iconoError");

                $("#btnPassenCabinaMovile").addClass("ValidTInyp input-iconoError");
                $("#btnPassenCabinaMovile2").addClass("ValidTInyp input-iconoError");

            }


            if (this.validar_email($(EmailTxt).val()) && $(NameTxt).val().length != 0 && cantPassengCab != 0) {
                this.loadDataBoatPassionMary();
            }
                
            
        },

        //Cargar salida del barco, itinerarios e informacion del usuario de otros Barcos
        loadDataBoatOthers: function () {


            var leadsBoars = new Object();
            leadsBoars.NombreBarco = this.cabinas[0].barcoNombre;
            leadsBoars.Itinerario = this.cabinas[0].itinNombre;
            leadsBoars.Noches = this.cabinas[0].noches;
            leadsBoars.SalCodigo = this.cabinas[0].idSalida;
            leadsBoars.Correo = document.getElementById("emailClientOtrosBarcos").value;
            leadsBoars.Nombre = document.getElementById("nameClientOtrosBarcos").value;
            leadsBoars.NummeroMax = parseInt(this.passengCantCab1) + parseInt(this.passengCantCab2);
            leadsBoars.Observacion = "";



            console.log(leadsBoars);
            $.ajax({
                type: "POST",
                url: "/Cruises/CreateLeadsBoats",
                data: JSON.stringify(leadsBoars),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response != null) {

                    } else {
                        alert("Something went wrong");
                    }
                },
                failure: function (response) {
                    alert(response.responseText);

                },

            });

            window.location.href = "../thank-you-page-availability/";


        },

        //Enviar informacion de los otros Barcos
        SendleadBoat: function () {


            var EmailTxt = document.getElementById("emailClientOtrosBarcos");
            var NameTxt = document.getElementById("nameClientOtrosBarcos");
            var cantPassengCab = parseInt(this.passengCantCab1) + parseInt(this.passengCantCab2);

            if (this.validar_email($(EmailTxt).val())) {
                this.email = "";

                EmailTxt.className = "form-control input-icono";
            }
            else {

                EmailTxt.className = "ValidTInyp input-iconoError";
                this.email = "EMAIL MUST BE FORMATTED CORRECTLY";
                this.colorEmailVal = "red";
            }
            if ($(NameTxt).val().length == 0) {

                NameTxt.className = "ValidTInyp input-iconoError";

            } else {
                NameTxt.className = "form-control input-icono";


            }

            if (cantPassengCab == 0) {
                $("#btnPassenOtroBarco1").addClass("ValidTInyp input-iconoError");
                $("#btnPassenOtroBarco2").addClass("ValidTInyp input-iconoError");

                $("#btnPassenOtrosBarcosMov").addClass("ValidTInyp input-iconoError");
                $("#btnPassenOtrosBarcosMov2").addClass("ValidTInyp input-iconoError");

            }

            if (this.validar_email($(EmailTxt).val()) && $(NameTxt).val().length != 0 && cantPassengCab != 0) {
                this.loadDataBoatOthers();
            }

           

            

        },

        closeModalCabinaPaMa: function () {

            this.passengSelect = 'passengers';
            this.passengSelectCab2 = 'passengers';
            this.SelectPasseng();
            var EmailTxt = document.getElementById("emailClient");
            var NameTxt = document.getElementById("nameClient");
            EmailTxt.value = "";
            NameTxt.value = "";

            this.passengCantCab1 = 0;
            this.passengCantCab2 = 0;
            //Quitar Clases de css
            $("#emailClient").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#emailClient').addClass("form-control");
            $("#nameClient").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#nameClient').addClass("form-control");
            this.email = "";


            $('#avaiPaMaModal').modal('show');
            document.querySelector('body').classList.add('hiddenBody');
            $('#detailsCabPaMa').modal('hide');
        },

        closeModalCabinaOtroBarco: function () {
            this.passengSelect = 'passengers';
            this.passengSelectCab2 = 'passengers';
            this.SelectPassengOtrsBarcos();

            var EmailTxt = document.getElementById("emailClientOtrosBarcos");
            var NameTxt = document.getElementById("nameClientOtrosBarcos");
            EmailTxt.value = "";
            NameTxt.value = "";

            this.passengCantCab1 = 0;
            this.passengCantCab2 = 0;

            //Quitar Clases de css
            $("#emailClientOtrosBarcos").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#emailClientOtrosBarcos').addClass("form-control");
            $("#nameClientOtrosBarcos").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#nameClientOtrosBarcos').addClass("form-control");
            this.email = "";
            $('#avaiModal').modal('show');
            document.querySelector('body').classList.add('hiddenBody');
            $('#detailsCabOtrosBarcos').modal('hide');
        },

        closeModalAvailability() {
            this.dateModal = "Select your travel dates";
            $('#dataPickerPaMa').datepicker('update');
            $('#dataPickerOtrosBarcos').datepicker('update');
            $('#datePickerBarcoInfinity').datepicker('update');
            $('#datePickerBarcoGranMajestic').datepicker('update');
            document.querySelector('body').classList.remove('hiddenBody');

            document.getElementById('blockSlide').style.display = 'none';
            document.getElementById('dispo-display').style.display = 'block';

            document.getElementById('blockSlideOtrosBarcos').style.display = 'none';
            document.getElementById('dispo-displayOtrosBarcos').style.display = 'block';
            if (window.innerWidth > 700) {

                document.getElementById('modalImgDispo').style.display = 'block';
                document.getElementById('modalImgDispoOtrosBarcos').style.display = 'block';
            } else {
                document.getElementById('modalImgDispo').style.display = 'none';
                document.getElementById('modalImgDispoOtrosBarcos').style.display = 'none';
            }
        },

        beforeMount: function () {
            this.getListBarcoCards();
        },
        updatePage(pageNumber) {
            this.currentPage = pageNumber;
        },

        totalPages() {
            return Math.ceil(this.ListBarcoCards.length / this.pageSize);
        },
        showPrevioustLink() {

            return this.currentPage == 0 ? false : true;
        },
        showNextLink() {

            return this.currentPage == (this.totalPages() - 1) ? false : true;
        },
        showPages(currentPage, num) {
            return currentPage + num;
        },

        checkTripType(event) {
           
            for (let listTrip of this.maintripType) {
                if (event.target.checked) {
                    if (listTrip.barcoCategoriaTipoNombreEn == event.target.value) {
                        document.getElementById(event.target.id).style.color = "#398AC9";
                        this.contType++;

                        $("#btnFiltroBarco").removeClass("btnVisibleFiltro");

                        //$("#btnFiltroBarco").addClass("btn btn-default dropdown-toggle");
                    }
                } else {
                    if (listTrip.barcoCategoriaTipoNombreEn == event.target.value) {
                        document.getElementById(event.target.id).style.color = "#787778";
                        this.triptype = "Cruises";
                        this.contType--;
                    }
                }
            }
            if (this.contType == 0) {
                this.contTrip = " ";
            } else if (this.contType == 1) {
                this.contTrip = "";
                this.triptype = this.checkedBarcos[0];

            } else {
                this.triptype = "Cruises";
                this.contTrip = " " + this.contType;
            }

            
        },
        moreTravelersAdu: function (event) {
            this.count++;
            this.travelersTot = "Travelers " + (this.count + this.count1);
            $("#btnFiltroBarco").removeClass("btnVisibleFiltro");
        },
        minusTravelersAdu: function (event) {
            if (this.count > 0) {
                this.count--;
                this.travelersTot = "Travelers " + (this.count + this.count1);
            }
            $("#btnFiltroBarco").removeClass("btnVisibleFiltro");
        },
        moreTravelersChild: function (event) {
            this.count1++;
            this.travelersTot = "Travelers " + (this.count + this.count1);
            $("#btnFiltroBarco").removeClass("btnVisibleFiltro");
        },
        minusTravelersChild: function (event) {
            if (this.count1 > 0) {
                this.count1--;
                this.travelersTot = "Travelers " + (this.count + this.count1);
            }
            $("#btnFiltroBarco").removeClass("btnVisibleFiltro");
        },
        resettleTravel: function () {
            this.count = 2;
            this.count1 = 0;
            this.travelersTot = "Travelers ";
        },
        applyTravel: function () {
            if (this.travelersTot == "Travelers") {

                this.travelersTot = "Travelers " + (this.count);
            }
            $('.applyTravelers').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        applyDate: function (event) {
            $('.applyDate').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        resettleDate: function () {
            this.dateTrip = "Date";
            this.selectDate_1 = null
            this.selectDate = null
            this.datePickerSelect = []
            this.datePickerSelect_1 = []
            this.contdatePicker_1 = 0;
            this.contdatePicker_2 = 0;
            $('#datepickerFilterPlanner').datepicker('update');
            $('#datepickerFilterPlanner_1').datepicker('update');
            $('#datepickerDispMovile').datepicker('update');
        },
        applyCruises: function () {

            $('.applyTravelers').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        resettleCruises: function () {

            for (var i = 0; i < 4;i++) {
                document.getElementById(i).style.color = "#787778";
            }
            this.cont = 0;
            this.contTrip = "";
            this.checkedBarcos = [];
            this.triptype = "Cruises";
        },

        modalBlockDispo: function () {
          
            document.getElementById('blockSlide').style.display = 'none';
            document.getElementById('dispo-display').style.display = 'block';

            document.getElementById('blockSlideOtrosBarcos').style.display = 'none';

            document.getElementById('dispo-displayOtrosBarcos').style.display = 'block';

            if (window.innerWidth > 700) {

                document.getElementById('modalImgDispo').style.display = 'block';
                document.getElementById('modalImgDispoOtrosBarcos').style.display = 'block';
            } else {
                document.getElementById('modalImgDispo').style.display = 'none';
                document.getElementById('modalImgDispoOtrosBarcos').style.display = 'none';
            }
           
        },

        //ITINERARIO BARCO 
        getItiner: async function (event) {
            var itb = this;
            targetId = event.currentTarget.id;
            itb.itiBarcoBtn = [];
            var i = 1;
            this.contbtn++;
            var dataIdbarco = this.idBarcoCard;
            var owl = $('.owl-carousel');
            owl.trigger('destroy.owl.carousel');
            await this.$nextTick();
            $.ajax({ url: "/GetItinerario/" + dataIdbarco + "/" + targetId, method: "GET" }).done(function (data) {
                itb.datosIti = data;
                //if (itb.datosIti.length == 0) {
                //    document.getElementById('myCarousel5').style.display = 'none';
                //} else {
                document.getElementById('blockSlide').style.display = 'block';
                document.getElementById('modalImgDispo').style.display = 'none';
                document.getElementById('dispo-display').style.display = 'none';

                document.getElementById('blockSlideOtrosBarcos').style.display = 'block';
                document.getElementById('modalImgDispoOtrosBarcos').style.display = 'none';
                document.getElementById('dispo-displayOtrosBarcos').style.display = 'none';

                for (let dat of data) {
                   var cadena = dat.diaNumero;
                   if (cadena + 1 == i) {
                       itb.filtDias = dat;
                       itb.itiBarcoBtn = itb.itiBarcoBtn.concat(itb.filtDias);
                       i++;
                   }
                }
                //}
                console.log(itb.itiBarcoBtn)
            });
        },
    },
    computed: {
        // FILTROS ITINER AM Y PM 
        buscarItiAm: function () {
            console.log(this.datosIti.filter((item) => item.diaParte.includes('AM')));
            return this.datosIti.filter((item) => item.diaParte.includes('AM'));
        },
        buscarItiPm: function () {
            console.log(this.datosIti.filter((item) => item.diaParte.includes('PM')));
            return this.datosIti.filter((item) => item.diaParte.includes('PM'));
        },
        colorAdu() {
            return { 'disabled': this.count < 1 }
        },
        colorChild() {
            return { 'disabled': this.count1 < 1 }
        },
        colorLenght() {
            return { 'disabled': this.countLen < 1 }
        },
        lenghtDay() {
            if (this.countLen < 1) {
                return " ";
            } else {
                return "  " + this.countLen;
            }
        },
        filterDate() {
            if (this.dateTrip == "") {
                return "Date";
            } else {
                return this.dateTrip;
            }
        },
        //Funcion obtener/filtrar barcos y vincular con la paginacion, 
        ShowCardsBarcos() {
           
            this.visibleTodos = this.ListBarcoCards.slice(this.currentPage * this.pageSize, (this.currentPage * this.pageSize) + this.pageSize);
            if (this.visibleTodos.length == 1 && this.ListBarcoCards.length == 1) {
                this.classObject = 'col-md-5';
            }
             //Verificar cantidad de  Barcos del sp GetBarcosWeb y acomodar diseño
            if (this.visibleTodos.length > 1 && this.ListBarcoCards.length > 1) {
                this.classObject = 'col-md-5';
            }

            if (this.visibleTodos.length == 0 && this.ListBarcoCards.length == 0) {
                this.datanull = 'We couldn´t load the available departures. Please, try later';
            }
            return this.visibleTodos;
        },

        //Ver Disponibilidad al seleccionar cada card de barco
        filDispoBarcos() {
            
            var idBarcoSelectCard = this.idBarcoCard;
            var f, f1, f2, fechaInicio, fechaFin;
            var travelers, date
            

            //Cargar disponibilidadCruceros con filtros.
            if (this.datosFiltro.length != 0) {
                travelers = this.datosFiltro[0];

            }

            if (this.DispSelectOtrosBarco.length == 0) {
                this.dispVerficarOtrosBarcos = "Not available information. Please, try later";
                console.log(this.dispVerficarOtrosBarcos)
            }

             //Cargar disponibilidadCruceros con filtros.
            if (this.dateModal == "Select your travel dates") {

                if (travelers == undefined) {
                    travelers = [0, 1]
                }
                this.DispSelectOtrosBarco = this.dispApiOtrosBarcos.filter(function (item) {
                    if (item.idBarco == idBarcoSelectCard) {
                        if (parseInt(item.salDispoTotalOtrosBarcos) >= travelers[1]) {
                            return item;
                        }
                    }
                });

                

            } else {
                if (this.dateModal.split(',').length == 1) {
                    f = this.dateModal.split(',')[0].split("-");
                    fechaInicio = new Date(f[0] + "-" + "20" + f[1]);

                    if (travelers == undefined) {
                        travelers = [0, 1]
                    }
                    this.DispSelectOtrosBarco = this.dispApiOtrosBarcos.filter(function (item) {
                        if (item.idBarco == idBarcoSelectCard) {
                            if (parseInt(item.salDispoTotalOtrosBarcos) >= travelers[1]) {
                                if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime()) {

                                    return item;
                                }
                            }

                        }
                    });
                }
                if (this.dateModal.split(',').length == 2) {
                    f = this.dateModal.split(',');
                    f1 = f[0].split("-");
                    f2 = f[1].split("-");
                    fechaInicio = new Date(f1[0] + "-" + "20" + f1[1]);
                    fechaFin = new Date(f2[0] + "-" + "20" + f2[1]);
                    fechaFin.setMonth(fechaFin.getMonth() + 1, 0);

                    if (travelers == undefined) {
                        travelers = [0, 1]
                    }
                    this.DispSelectOtrosBarco = this.dispApiOtrosBarcos.filter(function (item) {
                        if (item.idBarco == idBarcoSelectCard) {
                            if (parseInt(item.salDispoTotalOtrosBarcos) >= travelers[1]) {
                                if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(fechaFin).getTime()) {

                                    return item;
                                }
                            }

                        }
                    });

                }

                if (this.DispSelectOtrosBarco.length == 0) {
                    this.dispVerficarOtrosBarcos = "Not available departures. Try again";
                    var fecha = new Date();
                    this.DispSelectOtrosBarco = this.dispApiOtrosBarcos.filter(function (item) {
                        if (parseInt(item.salDispoTotalOtrosBarcos) >= 2) {
                            if (new Date(item.salFechaSalida).getTime() >= new Date(fecha).getTime()) {


                                return item;
                            }
                        }
                    });
                    console.log(this.dispVerficarOtrosBarcos)
                }
            }
            

            return this.DispSelectOtrosBarco;
        },

        //Filtros para los barcos Passion y Mary Ann
        filtroDispoBarcosPaMa() {

            var idBarcoSelectCard = this.idBarcoCard;
            var f, f1, f2, fechaInicio, fechaFin;
            var travelers
        
            //Cargar disponibilidadCruceros con filtros.
            if (this.datosFiltro.length != 0) {
                 travelers = this.datosFiltro[0];

            }

              //Cargar pagina disponibilidad-Cruceros con toda la diponibilidad de los barcos
            if (this.dateModal == "Select your travel dates") {

                if (travelers == undefined) {
                    travelers = [0, 1]
                }
                this.DispSelectBarcoPaMa = this.dispApiMaPa.filter(function (item) {
                    if (item.idBarco == idBarcoSelectCard) {
                        if (parseInt(item.totalDisponibilidad) >= travelers[1]) {
                                return item;
                        }
                    }
                });
            } else {
                if (this.dateModal.split(',').length == 1) {
                    f = this.dateModal.split(',')[0].split("-");
                    fechaInicio = new Date(f[0] + "-" + "20" + f[1]);
                    
                    if (travelers == undefined ) {
                        travelers = [0, 1]
                    }
                    this.DispSelectBarcoPaMa = this.dispApiMaPa.filter(function (item) {
                        if (item.idBarco == idBarcoSelectCard) {
                            if (parseInt(item.totalDisponibilidad) >= travelers[1]) {
                                if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime()) {

                                    return item;
                                }
                            }
 
                        }
                    });  
                }
                if (this.dateModal.split(',').length == 2) {
                    f = this.dateModal.split(',');
                    f1 = f[0].split("-");
                    f2 = f[1].split("-");
                    fechaInicio = new Date(f1[0] + "-" + "20" + f1[1]);
                    fechaFin = new Date(f2[0] + "-" + "20" + f2[1]);
                    fechaFin.setMonth(fechaFin.getMonth() + 1, 0);

                    if (travelers == undefined) {
                        travelers = [0, 1]
                    }
                    this.DispSelectBarcoPaMa = this.dispApiMaPa.filter(function (item) {
                        if (item.idBarco == idBarcoSelectCard) {
                            if (parseInt(item.totalDisponibilidad) >= travelers[1]) {
                                if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(fechaFin).getTime()) {

                                    return item;
                                }
                            }

                        }
                    });

                }

                if (this.DispSelectBarcoPaMa.length == 0) {
                    this.dispBarcosVerficarInf = "Not available departures. Try again";

                    var fecha = new Date();

                    this.DispSelectBarcoPaMa = this.dispApiMaPa.filter(function (item) {
                        if (parseInt(item.totalDisponibilidad) >= 2) {
                            if (new Date(item.salFechaSalida).getTime() >= new Date(fecha).getTime()) {

                                return item;
                            }
                        }
                    });
                }

            }
            

          
            return this.DispSelectBarcoPaMa;
        },

       
    },
     mounted() {
        var self = this;
        this.show = true;

        var today = new Date();

        var contdatePicker_1 = 0;
        var contdatePicker_2 = 0;
        var contdatePickerModal = 0;
        var datePickerSelect = [];
        var datePickerSelect_1 = [];
        var datePickerSelectModal = [];
        var selectDate_1, selectDate, selectDateModal = null;
        
        var recaptchaScript = document.createElement('script');
        recaptchaScript.setAttribute('src', '/js/funcionesCompVue.js');
        document.head.appendChild(recaptchaScript);
   

         $('#datepickerFilterPlanner').on('changeDate', function () {
             self.selectDate = $('#datepickerFilterPlanner').data('datepicker').getFormattedDate('M-yy')
             self.dateTrip = self.selectDate;
             $("#btnFiltroBarco").removeClass("btnVisibleFiltro");
             if (self.selectDate.split(',')[self.contdatePicker_1] !== undefined) {
                 self.datePickerSelect.push(self.selectDate.split(',')[self.contdatePicker_1]);
                 self.contdatePicker_1++;
             }

             if (self.datePickerSelect.length == 2 && self.datePickerSelect_1.length == 1) {
                 $('#datepickerFilterPlanner').datepicker('update');
                 $('#datepickerFilterPlanner_1').datepicker('update');
                 self.datePickerSelect_1 = [];
                 self.contdatePicker_2 = 0;
                 self.datePickerSelect.splice(1, 0, self.datePickerSelect[1]);
                 var f = self.datePickerSelect[1].split("-");
                 $('#datepickerFilterPlanner').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
             }
             if (self.datePickerSelect.length == 1 && self.datePickerSelect_1.length == 2) {
                 $('#datepickerFilterPlanner').datepicker('update');
                 $('#datepickerFilterPlanner_1').datepicker('update');
                 self.datePickerSelect_1 = [];
                 self.contdatePicker_2 = 0;
                 var f = self.datePickerSelect[0].split("-");
                 if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                     $('#datepickerFilterPlanner').datepicker('update', new Date());
                 } else {
                     $('#datepickerFilterPlanner').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                 }
             }
             if (self.datePickerSelect.length == 0 && self.datePickerSelect_1.length == 2) {
                 $('#datepickerFilterPlanner_1').datepicker('update');
                 self.datePickerSelect_1 = [];
                 self.contdatePicker_2 = 0;
                 self.dateTrip = self.self.selectDate;
             }
             if (self.datePickerSelect.length == 1 && self.datePickerSelect_1.length == 1) {
                 if (self.selectDate_1.split(',').length == 2) {
                     self.dateTrip = self.selectDate + "," + self.selectDate_1.split(',')[1];
                 } else {
                     self.dateTrip = self.selectDate + "," + self.selectDate_1;
                 }
                 if (self.selectDate_1.split(',').length == 3) {
                     self.dateTrip = self.selectDate + "," + self.selectDate_1.split(',')[2];
                 }
             }
             if (self.selectDate_1 == '' && self.selectDate == '') {
                 self.dateTrip = "Date";

             }
             if (self.selectDate.split(',').length == 2) {
                 var f = self.selectDate.split(',');
                 var f1 = f[0].split("-");
                 var f2 = f[1].split("-");
                 if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                     self.dateTrip = f[1] + "," + f[0];
                 }
             }


             if (self.datePickerSelect.length == 3) {
                 $('#datepickerFilterPlanner').datepicker('update');
                 var f = self.datePickerSelect[2].split("-");
                 if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                     $('#datepickerFilterPlanner').datepicker('update', new Date());
                 } else {
                     $('#datepickerFilterPlanner').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                 }
                 self.contdatePicker_1 = 1;
                 self.datePickerSelect = [];
                 self.datePickerSelect.push(f[0] + "-" + f[1]);
                 self.dateTrip = self.datePickerSelect[0];
             }
         });

         $('#datepickerFilterPlanner_1').on('changeDate', function () {
             self.selectDate_1 = $('#datepickerFilterPlanner_1').data('datepicker').getFormattedDate('M-yy')
             self.dateTrip = self.selectDate_1;
             $("#btnFiltroBarco").removeClass("btnVisibleFiltro");
             //Meses repetidos en array
             if (self.selectDate_1.split(',')[0] == self.selectDate_1.split(',')[1]) {
                 $('#datepickerFilterPlanner_1').datepicker('update');
                 self.dateTrip = "Date";
             }
             if (self.selectDate_1.split(',')[self.contdatePicker_2] !== undefined) {
                 self.datePickerSelect_1.push(self.selectDate_1.split(',')[self.contdatePicker_2]);
                 self.contdatePicker_2++;
             }
             if (self.datePickerSelect_1.length == 2 && self.datePickerSelect.length == 1) {
                 $('#datepickerFilterPlanner').datepicker('update');
                 $('#datepickerFilterPlanner_1').datepicker('update');
                 self.datePickerSelect = [];
                 self.contdatePicker_1 = 0;
                 self.datePickerSelect_1.splice(1, 0, self.datePickerSelect_1[1]);
                 var f = self.datePickerSelect_1[1].split("-");
                 $('#datepickerFilterPlanner_1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
             }
             if (self.datePickerSelect_1.length == 1 && self.datePickerSelect.length == 2) {
                 $('#datepickerFilterPlanner').datepicker('update');
                 $('#datepickerFilterPlanner_1').datepicker('update');
                 self.datePickerSelect = [];
                 self.contdatePicker_1 = 0;
                 var f = self.datePickerSelect_1[0].split("-");
                 if (f[0] == 'Jan') {
                     $('#datepickerFilterPlanner_1').datepicker('update', '01-20' + f[1]);
                 } else {
                     $('#datepickerFilterPlanner_1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                 }

             }
             if (self.datePickerSelect_1.length == 2 && self.datePickerSelect.length == 0) {
                 $('#datepickerFilterPlanner').datepicker('update');
                 self.datePickerSelect = [];
                 self.contdatePicker_1 = 0;
                 self.dateTrip = self.selectDate_1;
             }
             if (self.datePickerSelect.length == 1 && self.datePickerSelect_1.length == 1) {
                 if (self.selectDate.split(',').length == 2) {
                     self.dateTrip = self.selectDate.split(',')[1] + "," + self.selectDate_1;
                 } else {
                     self.dateTrip = self.selectDate + "," + self.selectDate_1;
                 }
                 if (self.selectDate.split(',').length == 3) {
                     self.dateTrip = self.selectDate.split(',')[2] + "," + self.selectDate_1;
                 }
             }
             if (self.selectDate_1 == '' && self.selectDate == '') {
                 self.dateTrip = "Date";

             }
             if (self.selectDate_1.split(',').length == 2) {
                 var f = self.selectDate_1.split(',');
                 var f1 = f[0].split("-");
                 var f2 = f[1].split("-");
                 if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                     self.dateTrip = f[1] + "," + f[0];
                 }
             }
             if (self.datePickerSelect_1.length == 3) {
                 var f = self.datePickerSelect_1[2].split("-");
                 if (f[0] == 'Jan') {
                     $('#datepickerFilterPlanner_1').datepicker('update', '01-20' + f[1]);
                 } else {
                     $('#datepickerFilterPlanner_1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                 }
                 self.contdatePicker_2 = 1;
                 self.datePickerSelect_1 = [];
                 self.datePickerSelect_1.push(f[0] + "-" + f[1]);
                 self.dateTrip = self.datePickerSelect_1[0];
             }



         });

        //DataPicker Para modal  de cruceros disponibilidad
        $('#dataPickerPaMa').on('changeDate', function () {
            selectDateModal = $('#dataPickerPaMa').data('datepicker').getFormattedDate('M-yy')
            self.dateModal = selectDateModal;
 

            if (selectDateModal.split(',')[contdatePickerModal] !== undefined) {
                datePickerSelectModal.push(selectDateModal.split(',')[contdatePickerModal]);
                contdatePickerModal++;
            }
            if (selectDateModal == '') {
                self.dateModal = "Select your travel dates";
            }
            if (selectDateModal.split(',').length == 2) {
                var f = selectDateModal.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateModal = f[1] + "," + f[0];
                }
            }
            if (datePickerSelectModal.length == 3) {
                $('#dataPickerPaMa').datepicker('update');
                var f = datePickerSelectModal[2].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#dataPickerPaMa').datepicker('update', new Date());
                } else {
                    $('#dataPickerPaMa').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                contdatePickerModal = 1;
                datePickerSelectModal = [];
                datePickerSelectModal.push(f[0] + "-" + f[1]);
                self.dateModal = datePickerSelectModal[0];
            }
        });


        $('#dataPickerOtrosBarcos').on('changeDate', function () {
            selectDateModal = $('#dataPickerOtrosBarcos').data('datepicker').getFormattedDate('M-yy')
            self.dateModal = selectDateModal;

            if (selectDateModal.split(',')[contdatePickerModal] !== undefined) {
                datePickerSelectModal.push(selectDateModal.split(',')[contdatePickerModal]);
                contdatePickerModal++;

            }
            if (selectDateModal == '') {
                self.dateModal = "Select your travel dates";
            }
            if (selectDateModal.split(',').length == 2) {
                var f = selectDateModal.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateModal = f[1] + "," + f[0];
                }
            }
            if (datePickerSelectModal.length == 3) {
                $('#dataPickerOtrosBarcos').datepicker('update');
                var f = datePickerSelectModal[2].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#dataPickerOtrosBarcos').datepicker('update', new Date());
                } else {
                    $('#dataPickerOtrosBarcos').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                contdatePickerModal = 1;
                datePickerSelectModal = [];
                datePickerSelectModal.push(f[0] + "-" + f[1]);
                self.dateModal = datePickerSelectModal[0];
            }
        });



        $('#datepickerDispMovile').on('changeDate', function () {
            selectDateModal = $('#datepickerDispMovile').data('datepicker').getFormattedDate('M-yy')
            self.dateTrip = selectDateModal;

            if (selectDateModal.split(',')[contdatePickerModal] !== undefined) {
                datePickerSelectModal.push(selectDateModal.split(',')[contdatePickerModal]);
                contdatePickerModal++;

            }
            if (selectDateModal == '') {
                self.dateTrip = "Date";
            }
            if (selectDateModal.split(',').length == 2) {
                var f = selectDateModal.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateTrip = f[1] + "," + f[0];
                }
            }
            if (datePickerSelectModal.length == 3) {
                $('#datepickerDispMovile').datepicker('update');
                var f = datePickerSelectModal[2].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#datepickerDispMovile').datepicker('update', new Date());
                } else {
                    $('#datepickerDispMovile').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                contdatePickerModal = 1;
                datePickerSelectModal = [];
                datePickerSelectModal.push(f[0] + "-" + f[1]);
                self.dateTrip = datePickerSelectModal[0];
            }
        });
    },
});

//=================FILTRO FECHA==========================//
Vue.filter('format_date', function fmt(date = '') {
    var options = { weekday: 'short', year: 'numeric', month: 'short', day: 'numeric' };
    var dateformat = new Date(date);
    return dateformat.toLocaleDateString('en-GB', options);
});