//ITINERARIOS BARCOS
var ItinerBarco = new Vue({
    el: "#itinerBarco",
    data: {
        itiBarco: [],
        itiBarcoBtn: [],
        filItinerAM: [],
        filItinerPM: [],
        datosIti: [],
        datosCompl: [],
        cont: 1,
        itiIcon: 0,
        filtDias: [],
        filtAM: [],
        visible: false,
        numeroDeDias: '',
        idBarcoItinerario: '',
        active: 'item active',
        noActivo: 'item',
        itinerBlock: 'itinerBlock',
        itiner: 'itiner',
        itiCompDescripcionDescriptivoEn: '',
        contbtn: 0,
        displayReadMore: 'none',
        contReadMore: 1,
        dis: [],
        cabinas: [],
        active: 'item active',
        noActivo: 'item',
        limitDisponibilidad: 20,
        dateTrip: 'Select your travel dates',
        barcoFiltroFecha: null,
        deckplan: '',
        availa: '',
        availab: '',
        morecruises: '',
        //Seleccionar cabina
        passengSelect: 'passengers',
        passengSelectCab2: 'passengers',
        passengCantCab1: 0,
        passengCantCab2: 0,
        //Label Cargar Datos
        dispBarcosVerficarInf: 'Loading information…',
        dispVerficarOtrosBarcos: 'Loading information…',
        //mensaje de validacion email
        email: '',
        colorEmailVal: '',
        datBarcosSelect:'',
    },
    created: function () {
        this.getDispon();
        this.CargarInformacionVista();
    },
    methods: {
        getReadMore: function () {
            this.contReadMore++;
            if (this.contReadMore == 2) {
                this.displayReadMore = "contents";
            }
            if (this.contReadMore == 3) {
                this.displayReadMore = "none";
                this.contReadMore = 1;
            }
        },
        CargarInformacionVista() {
            var vm = this;
            var vistaUrl = window.location;
            var res = vistaUrl.pathname.split("/");
            if (res.length == 3) {
                switch (res[2]) {
                    case "golondrina":
                        vm.deckplan = "GOLONDRINA´S DECK PLAN";
                        break;
                    case "fragata":
                        vm.deckplan = "FRAGATA´S DECK PLAN";
                        break;
                    case "grand-majestic":
                        vm.availab = "GRAND MAJESTIC´S AVAILABILITY";
                        vm.deckplan = "GRAND MAJESTIC´S DECK PLAN";
                        vm.morecruises = "MORE HIGH-END CRUISES";
                        break;
                    case "infinity":
                        vm.availab = "INFINITY´S AVAILABILITY";
                        vm.deckplan = "INFINITY´S DECK PLAN";
                        vm.morecruises = "MORE HIGH-END CRUISES";
                        break;
                    case "nemo-ii":
                        vm.availab = "NEMO II - AVAILABILITY";
                        vm.deckplan = "NEMO II - DECK PLAN";
                        vm.morecruises = "MORE SAILING CRUISES";
                        break;
                    case "ocean-spray":
                        vm.availab = "OCEAN SPRAY´S AVAILABILITY";
                        vm.deckplan = "OCEAN SPRAY´S DECK PLAN";
                        vm.morecruises = "MORE LUXURY CRUISES";
                        break;
                    case "theory":
                        vm.availab = "THEORY´S AVAILABILITY";
                        vm.deckplan = "THEORY´S DECK PLAN";
                        vm.morecruises = "MORE LUXURY CRUISES";
                        break;
                    case "alya":
                        vm.availab = "M/C ALYA AVAILABILITY";
                        vm.deckplan = "ALYA´S DECK PLAN";
                        vm.morecruises = "MORE LUXURY CRUISES";
                        break;
                    case "elite":
                        vm.availab = "ELITE´S AVAILABILITY";
                        vm.deckplan = "ELITE´S DECK PLAN";
                        break;
                    case "tip-top-ii":
                        vm.deckplan = "TIP TOP II - DECK PLAN ";
                        vm.availa = "TIP TOP II - AVAILABILITY";
                        $('#btnVideoLinkProd').css('display', 'none');
                        break;
                    case "odyssey":
                        vm.deckplan = "ODYSSEY´S DECK PLAN";
                        vm.availa = "ODYSSEY´S AVAILABILITY";
                        break;
                    case "nemo-iii":
                        vm.deckplan = "S/C NEMO III DECK PLAN";
                        vm.availa = "S/C NEMO III AVAILABILITY";
                        $('#btnVideoLinkProd').css('display', 'none');
                        break;
                    case "treasure":
                        vm.deckplan = "TREASURE´S DECK PLAN";
                        vm.availa = "TREASURE´S AVAILABILITY";
                        $('#btnVideoLinkProd').css('display', 'none');
                        break;
                    case "mary-anne":
                        vm.deckplan = "MARY ANNE DECK PLAN";
                        vm.availa = "MARY ANNE AVAILABILITY";
                        break;
                    case "archipel":
                        vm.deckplan = "ARCHIPEL´S DECK PLAN";
                        vm.availa = "ARCHIPEL´S AVAILABILITY";
                        $('#btnVideoLinkProd').css('display', 'none');
                        break;
                }
            }

        },

        getDispon: function () {
            var vistaUrl = window.location;
            var res = vistaUrl.pathname.split("/");
            var dataIdbarco = $('#idBarco').val();
            var vm = this;
            if (res[2] == "passion-yacht" || res[2] == "mary-anne") {
                $.when($.ajax({ url: "/Dispo", method: "GET" })).done(function (data) {
                    vm.dis = data;
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    if (console && console.log) {
                        dp.dispBarcosVerficarInf = "We couldn´t load the available departures. Please, try later";
                    }
                });
            } else {
                $.when($.ajax({ url: "/DispoOtrosBarcos", method: "GET" })).done(function (data) {
                    vm.dis = data;
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    if (console && console.log) {
                        dp.dispBarcosVerficarInf = "We couldn´t load the available departures. Please, try later";
                    }
                });
            }
        },
        //getDispoMod: function () {
        //    $('#avaiModal').modal('show');
        //},
        getservicio: function (event) {
            $("#itineraryModal").modal('show');
            var idBarcoSalida = event.currentTarget.id;
            this.cabinas = this.dis.filter(function (item) {
                if (item.idSalida == idBarcoSalida) {
                    return item;
                }
            });
        },

        getservicioPaMa: function (event) {
            $("#detailsCabPaMa").modal('show');
            var idSalidaBarco = event.currentTarget.id;

            this.cabinas = [];

            this.datBarcosSelect = idSalidaBarco;

            this.cabinas = this.dis.filter(function (item) {
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

            this.cabinas = this.dis.filter(function (item) {
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

        SelectPasseng: function () {

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
            console.log('llll');
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
            var miElto = document.getElementsByClassName("modal-backdrop in");

            miElto.className = "verde";
            //$('.modal-backdrop').removeClass("modal-backdrop").addClass("verde");
            document.querySelector('body').classList.remove('hiddenBody');
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
            document.querySelector('body').classList.remove('hiddenBody');
            $('#detailsCabOtrosBarcos').modal('hide');
        },

        //closeModalcloseModalCabina: function () {
        //    $('#itineraryModal').modal('hide');
        //    document.querySelector('body').classList.remove('hiddenBody');
        //},
        modalDispoImg: function () {
            //========================= MODAL DISPO============================//
            $('#modalImgDispo').addClass("imgClick");
            $('#dispo-display').addClass("imgClick");
            $('#blockSlide').addClass("imgClickSlide");
        },
        modalBlockDispo: function () {
            $("#modalImgDispo").removeClass("imgClick");
            $('#dispo-display').removeClass("imgClick");
            $('#blockSlide').removeClass("imgClickSlide");
        },
        getModalIti: function () {
            $("#gale-ItinerModal").modal('show');
        },
        getModalVisitor: function () {
            $("#visitorModal").modal('show');
        },
        resettleDate: function () {
            this.dateTrip = "Date";
            $('#datepickerProduct').datepicker('update');
        },
        applyDate: function (event) {
            $('.applyDateProduct').parents('.dropdown').find('button.dropdown-toggle').dropdown('toggle')
        },
    },
    computed: {
        filDispoBarcos: function () {
            var dataIdbarco = $('#idBarco').val();
            var date = this.dateTrip;
            var f, f1, f2, fechaInicio, fechaFin;
            if (this.dateTrip == "Select your travel dates" || this.dateTrip == "") {
                this.barcoFiltroFecha = this.dis.filter(function (item) {
                    if (item.idBarco == dataIdbarco) {

                        return item;
                    }
                });
                this.limitDisponibilidad = 20;
            }
            else {
                if (this.dateTrip.split(',').length == 1) {
                    f = this.dateTrip.split(',')[0].split("-");
                    fechaInicio = new Date(f[0] + "-" + "20" + f[1]);
                    this.barcoFiltroFecha = this.dis.filter(function (item) {
                        if (item.idBarco == dataIdbarco) {
                            if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime()) {
                                return item;
                            }
                        }
                    });
                    this.limitDisponibilidad = this.barcoFiltroFecha.length;
                }
                if (this.dateTrip.split(',').length == 2) {
                    f = this.dateTrip.split(',');
                    f1 = f[0].split("-");
                    f2 = f[1].split("-");
                    fechaInicio = new Date(f1[0] + "-" + "20" + f1[1]);
                    fechaFin = new Date(f2[0] + "-" + "20" + f2[1]);
                    fechaFin.setMonth(fechaFin.getMonth() + 1, 0);
                    this.barcoFiltroFecha = this.dis.filter(function (item) {
                        if (item.idBarco == dataIdbarco) {
                            if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(fechaFin).getTime()) {
                                return item;
                            }
                        }
                    });
                    this.limitDisponibilidad = this.barcoFiltroFecha.length;

                    if (this.barcoFiltroFecha.length == 0) {
                        this.dispBarcosVerficarInf = "Not available departures. Try again";

                    }
                }

            }

            return this.barcoFiltroFecha;
        },

    },
    mounted: function () {
        var self = this;
        var contdatePicker_1 = 0;
        var datePickerSelect = [];
        var selectDate = null;

        //DataPicker Cruises Producto Disponibiblidad
        $('#datepickerProduct').on('changeDate', function () {
            selectDate = $('#datepickerProduct').data('datepicker').getFormattedDate('M-yy')
            self.dateTrip = selectDate;

            if (selectDate.split(',')[contdatePicker_1] !== undefined) {
                datePickerSelect.push(selectDate.split(',')[contdatePicker_1]);
                contdatePicker_1++;
            }
            if (selectDate == '') {
                self.dateTrip = "Select your travel dates";
            }
            if (selectDate.split(',').length == 2) {
                var f = selectDate.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateTrip = f[1] + "," + f[0];
                }
            }
            if (datePickerSelect.length == 3) {
                $('#datepickerProduct').datepicker('update');
                var f = datePickerSelect[2].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#datepickerProduct').datepicker('update', new Date());
                } else {
                    $('#datepickerProduct').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                contdatePicker_1 = 1;
                datePickerSelect = [];
                datePickerSelect.push(f[0] + "-" + f[1]);
                self.dateTrip = datePickerSelect[0];
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