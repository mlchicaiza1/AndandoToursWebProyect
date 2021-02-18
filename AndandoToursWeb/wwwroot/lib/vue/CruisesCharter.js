var CruisesCharter = new Vue({
    el: "#CruisesCharter",
    data: {
        cabinas: [],
        disponibilidadBarcosPaMa: [],
        dispoOtrosBarcos: [],



        disApiRoyalInfinity: [],//disponibilidad api royal Barco Infinity
        disApiRoyalGranMajestic: [],//disponibilidad api royal Barco Gran Majestic

        limitDisponibilidad: 720,
        dateTrip: 'Select your travel dates',
        barcoFiltroFecha: null,
        barcosCapacidad: [{ idBarco: 73, nombreBarco: 'Passion', capacidad: 14 },
        { idBarco: 85, nombreBarco: 'Mary Anne', capacidad: 16 },
        { idBarco: 87, nombreBarco: 'TREASURE OF GALAPAGOS', capacidad: 16 },
        { idBarco: 88, nombreBarco: 'ODYSSEY', capacidad: 16 },
        { idBarco: 90, nombreBarco: 'GOLONDRINA', capacidad: 16 },
        { idBarco: 92, nombreBarco: 'OCEAN SPRAY', capacidad: 16 },
        { idBarco: 93, nombreBarco: 'NEMO II', capacidad: 14 },
        { idBarco: 96, nombreBarco: 'ARCHIPEL II', capacidad: 16 },
        { idBarco: 98, nombreBarco: 'FRAGATA', capacidad: 16 },
        { idBarco: 103, nombreBarco: 'ALYA', capacidad: 16 },
        { idBarco: 105, nombreBarco: 'NEMO III', capacidad: 16 },
        { idBarco: 115, nombreBarco: 'THEORY', capacidad: 20 },
        { idBarco: 110, nombreBarco: 'ENDEMIC', capacidad: 16 },
        { idBarco: 111, nombreBarco: 'ELITE', capacidad: 16 },
        { idBarco: 122, nombreBarco: 'INFINITY', capacidad: 20 },
        { idBarco: 125, nombreBarco: 'GRAND MAJESTIC', capacidad: 16 }],

        //Seleccionar cabinas
        passengSelect: 'passengers',
        passengSelectCab2: 'passengers',

        barcoCharter: [],
        disponibilidadToTalBarcos: '',
        email: '',
        colorEmailVal: '',

        messagLoadDispo:'Loading information…',

    },
    created: function () {
        this.getDispon();
    },
    methods: {
        getDispon: function () {
            var vm = this;
            $.ajax({ url: "/Dispo", method: "GET" }).done(function (data) {
                vm.disponibilidadBarcosPaMa = data;
            });
            $.ajax({ url: "/DispoOtrosBarcos", method: "GET" }).done(function (data) {
                vm.dispoOtrosBarcos = data;
            });

            var dateApiRoyal = ["2021", "1"]

            //Disponibilidad de la Api Royal: Barco Infinity
            $.ajax({ url: "/DisponibilidadApiRoyalInfinity/" + dateApiRoyal + "/" + null, method: "GET" }).done(function (data) {
                vm.disApiRoyalInfinity = data;



            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (console && console.log) {
                    console.log("La solicitud a fallado: " + textStatus);
                }


            });

            //Disponibilidad de la Api Royal: Barco Gran Majestic
            $.ajax({ url: "/DisponibilidadApiRoyalGrandMajestic/" + dateApiRoyal + "/" + null, method: "GET" }).done(function (data) {
                vm.disApiRoyalGranMajestic = data;


            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (console && console.log) {
                    console.log("La solicitud a fallado: " + textStatus);
                }

            });

        },

        applyDate: function (event) {
            $('.applyDateProduct').parents('.dropdown').find('button.dropdown-toggle').dropdown('toggle')
        },

        //Abrir Modal availabilityModal.cshtml y guardar id de Barco Seleccionado
        openTailorMadeCharter: function (event) {
            var vm = this;

            $("#TailorMadeCharter").modal('show');
            var idSalidaBarco = event.currentTarget.id;

            this.barcoCharter = [];
            //this.datBarcosSelect = idSalidaBarco;

            this.cabinas = this.barcoFiltroFecha.filter(function (item) {
                if (item.idSalida == idSalidaBarco) {
                    return item;
                }
            });
            this.disponibilidadToTalBarcos = this.barcosCapacidad.filter(function (item) {
                for (let itemBarcoCap of vm.barcosCapacidad) {
                    if (itemBarcoCap.idBarco == idSalidaBarco) {
                        return item
                    }
                }
            });

            
        },
        closeTailorMadeCharter: function () {
            var EmailTxt = document.getElementById("emailCharter");
            var NameTxt = document.getElementById("nameCharter");
            var ObservTxt = document.getElementById("obserCharter");
            EmailTxt.value = "";
            NameTxt.value = "";
            ObservTxt.value = "";

            //Quitar Clases de css

            $("#emailCharter").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#emailCharter').addClass("form-control");
            $("#nameCharter").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#nameCharter').addClass("form-control");
            this.email = "";

        },

        validar_email: function (email) {
            var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return regex.test(email) ? true : false;
        },
        writeTextValidacionEmail: function () {
            $("#emailCharter").removeClass("ValidTInyp input-iconoError ");
            $('#emailCharter').addClass("form-control");
            this.email = "";
        },
        writeTextValidacionName: function () {
            $("#nameCharter").removeClass("ValidTInyp input-iconoError ");
            $('#nameCharter').addClass("form-control");
        },

        loadDataSendleadBoat: function () {

            var quitarNull = /null/g;
            

            var leadsBoars = new Object();
            leadsBoars.NombreBarco = this.cabinas[0].barcoNombre;
            leadsBoars.Itinerario = this.cabinas[0].itinNombre;
            leadsBoars.Noches = this.cabinas[0].noches;
            leadsBoars.SalCodigo = this.cabinas[0].idSalida;
            leadsBoars.Correo = document.getElementById("emailCharter").value;
            leadsBoars.Nombre = document.getElementById("nameCharter").value;
            leadsBoars.NummeroMax = this.cabinas[0].totalDisponibilidad + this.cabinas[0].salDispoTotalOtrosBarcos;
            leadsBoars.NummeroMax = leadsBoars.NummeroMax.replace(quitarNull, '');
            leadsBoars.Observacion = document.getElementById("obserCharter").value;

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

            document.getElementById("emailCharter").value="";
            document.getElementById("nameCharter").value="";
            document.getElementById("obserCharter").value = "";

           
            $("#emailCharter").removeClass("input-icono");
            $('#emailCharter').addClass("form-control");
            $("#nameCharter").removeClass("input-icono");
            $('#nameCharter').addClass("form-control");
            $("#TailorMadeCharter").modal('hide');

            window.location.href = "../thank-you-page-availability/";
        },

        SendleadBoat: function () {

            var EmailTxt = document.getElementById("emailCharter");
            var NameTxt = document.getElementById("nameCharter");


            if (this.validar_email($(EmailTxt).val()) ) {
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

            if (this.validar_email($(EmailTxt).val()) && $(NameTxt).val().length != 0) {
                this.loadDataSendleadBoat();
            }
          
        },
    },
    computed: {

        validacionText: function () {
            
            console.log(this.email);
        },

        filDispoBarcos: function () {
            var dataIdbarco = $('#idBarco').val();
            var date = this.dateTrip;
            var vm = this;
            //var dispoBarcosTotal = vm.disponibilidadBarcos.concat(vm.dispoOtrosBarcos);
            var dispoBarcosMaPa = [];
            var dispoOtrosBarcos = [];
            var dispoBarcoGranMajestic = [];
            var dispoBarcoInfinity = [];
            var f, f1, f2, fechaInicio, fechaFin;


            if (this.dateTrip == "Select your travel dates" || this.dateTrip == "") {

                dispoBarcosMaPa = vm.disponibilidadBarcosPaMa.filter(function (item) {
                    for (let itemBarcoCap of vm.barcosCapacidad) {
                        if (itemBarcoCap.idBarco == item.idBarco) {
                            if (itemBarcoCap.capacidad == item.totalDisponibilidad) {
                                return item;
                            }
                           
                        }
                    }
                    
                });
                dispoOtrosBarcos = vm.dispoOtrosBarcos.filter(function (item) {
                    for (let itemBarcoCap of vm.barcosCapacidad) {
                        if (itemBarcoCap.idBarco == item.idBarco) {
                            if (itemBarcoCap.capacidad == item.salDispoTotalOtrosBarcos) {
                                return item;
                            }

                        }
                    }
                });


                this.disApiRoyalGranMajestic.forEach(function (elem) {

                    elem.availability.forEach(function (item) {
                        if (item.avail >= 16) {

                            dispoBarcoGranMajestic.push(item);

                        }


                    });

                });

                this.disApiRoyalInfinity.forEach(function (elem) {

                    elem.availability.forEach(function (item) {
                        if (item.avail >= 20) {

                            dispoBarcoInfinity.push(item);

                        }


                    });

                });

                this.barcoFiltroFecha = dispoBarcosMaPa.slice(0, 15).concat(dispoOtrosBarcos.slice(0, 30));
                //this.barcoFiltroFecha = dispoBarcosMaPa.concat(dispoOtrosBarcos);
                //dato = dispoBarcosMaPa.concat(dispoOtrosBarcos);
                //console.log(dato);
            } else {
                if (this.dateTrip.split(',').length == 1) {
                    f = this.dateTrip.split(',')[0].split("-");
                    fechaInicio = new Date(f[0] + "-" + "20" + f[1]);
                    dispoBarcosMaPa = vm.disponibilidadBarcosPaMa.filter(function (item) {
                        for (let itemBarcoCap of vm.barcosCapacidad) {
                            if (itemBarcoCap.idBarco == item.idBarco) {
                                if (itemBarcoCap.capacidad == item.totalDisponibilidad) {
                                    if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime()) {
                                        return item;
                                    }
                                }

                            }
                        }

                    });
                    dispoOtrosBarcos = vm.dispoOtrosBarcos.filter(function (item) {
                        for (let itemBarcoCap of vm.barcosCapacidad) {
                            if (itemBarcoCap.idBarco == item.idBarco) {
                                if (itemBarcoCap.capacidad == item.salDispoTotalOtrosBarcos) {
                                    if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime()) {
                                        return item;
                                    }
                                }
                            }
                        }
                    });
                }

                this.barcoFiltroFecha = dispoBarcosMaPa.concat(dispoOtrosBarcos);

                if (this.dateTrip.split(',').length == 2) {
                    f = this.dateTrip.split(',');
                    f1 = f[0].split("-");
                    f2 = f[1].split("-");
                    fechaInicio = new Date(f1[0] + "-" + "20" + f1[1]);
                    fechaFin = new Date(f2[0] + "-" + "20" + f2[1]);
                    fechaFin.setMonth(fechaFin.getMonth() + 1, 0);
                    dispoBarcosMaPa = vm.disponibilidadBarcosPaMa.filter(function (item) {
                        for (let itemBarcoCap of vm.barcosCapacidad) {
                            if (itemBarcoCap.idBarco == item.idBarco) {
                                if (itemBarcoCap.capacidad == item.totalDisponibilidad) {
                                    if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(fechaFin).getTime()) {
                                        return item;
                                    }
                                }

                            }
                        }

                    });
                    dispoOtrosBarcos = vm.dispoOtrosBarcos.filter(function (item) {
                        for (let itemBarcoCap of vm.barcosCapacidad) {
                            if (itemBarcoCap.idBarco == item.idBarco) {
                                if (itemBarcoCap.capacidad == item.salDispoTotalOtrosBarcos) {
                                    if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(fechaFin).getTime()) {
                                        return item;
                                    }
                                }

                            }
                        }
                    });
                    this.barcoFiltroFecha = dispoBarcosMaPa.slice(0, 30).concat(dispoOtrosBarcos.slice(0, 30));
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