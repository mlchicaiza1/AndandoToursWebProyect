var paginacion = new Vue({
    el: '#tripPlanner',
    data() {
        return {
            cargaDatos: {
                imgIsland: "loading...",
                imgIsland1: "loading...",
                imgIsland2: "loading...",
                imgIsland3: "loading...",
                imgIsland4: "loading...",
                imgIsland5: "loading...",
            },
            category: {
                firstClass: 'First Class',
                Luxury: 'Luxury',
                Tourist: 'Tourist Superior'
            },
            contTrip: "",
            contCheckTrip: 0,
            triptype: 'Trip type',
            checkColor: "#787778",
            checkedTrip: [],
            object: {
                GalapagosCruises: 'Galapagos Cruises',
                GalapagosLandbasedtours: 'Galapagos Land-based tours',
                ToursinMainlandEcuador: 'Tours in Mainland Ecuador'
            },
            maintripType: [{ labeltrip: 'Galapagos Cruises' }
                , { labeltrip: 'Galapagos Land-based tours' }, { labeltrip: 'Tours in Mainland Ecuador' }],
            travelersTot: "Travelers",
            count: 2,
            count1: 0,
            price: "Price range",

            //DataPcker Pagina TripPlanner y DataPickerModal
            dateTrip: 'Date',
            dateModal: 'Select your travel dates',
            //Resettle date
            selectDate_1: null,
            selectDate: null,
            selectDateModal: null,
            datePickerSelect: [],
            datePickerSelect_1: [],
            contdatePicker_1: 0,
            contdatePicker_2: 0,


            countLen: 0,

            trip: [],
            menu: '',
            tripPanner: [],
            listCruises: [],
            listServices: [],
            classObject: 'col-md-4',
            nexid: 13,
            currentPage: 0,
            pageSize: 9,
            visibleTodos: [],
            dataTripPlanner: [],
            dis: [],
            IslandHoppingPaq: [],
            PaqIslandEmail: [],
            salFechaSalida: null,

            //Lista Disponibilidad de Barcos
            disponibilidadBarcosPaMa: [],
            disponibilidadOtrosBarcos: [],
            listDisponibilidadBarcosPaMa: [],
            listDisponibilidadOtrosBarcos: [],

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

            //Lista de Barcos
            ListBarcoCards: [],
            //Descripcion barcos
            desBarco: [],
            //Ver disponibilidad con filtros
            dispoIslandHopping: true,
            dispoBarcosFiltros: true,

            //Detectar datos en la diponibilidad de barcos
            dispBarcosVerficarInf: 'Loading information…',
            dispVerficarOtrosBarcos: 'Loading information…',
            //Almacenar id de  la card Barco seleccionada
            idBarcoCard: '',
            //Almacenar datos del barco: imagen, descripcion
            datoCardBarco: [],

            //Alamcenar Disponibilidad de los barcos seleccionados
            DispSelectBarcoPaMa: [],
            DispSelectOtrosBarco: [],
            cabinas: [],

            //Seleccionar cabinas
            passengSelect: 'passengers',
            passengSelectCab2: 'passengers',

            passengCantCab1: 0,
            passengCantCab2: 0,

            //mensaje de validacion email
            email: '',
            colorEmailVal: '',
            show: '',


            barcoSalida: [],
            idBarcoSalida: 0,
            cabinas: [],
            active: 'item active',
            noActivo: 'item',
            recaptchaScript: "",

            //Mensaje para filtros Barcos
            respuestaBarcos: "",
            //Mensaje para filtros IslandHopping
            respuestaIslandHopping: "",
            results: "",
            dataApi: 0,
            counter: 1,
            counterEnd: 140,
        }
    },
    created: function () {
        this.getDisponibilidad();
        

    },
    methods: {
        progressBar: function () {
            var elem = document.getElementById("myBar");
            document.getElementById("myProgress").style.height = '6px';
            var width = 1;
            var id = setInterval(frame, 150);
            function frame() {
                if (width >= 100) {
                    clearInterval(id);
                    document.getElementById("myProgress").style.height = 0;
                } else {
                    width++;
                    elem.style.width = width + '%';

                }
            }
        },
        checkTripType(event) {
            console.log(this.contTrip + "  " + this.contCheckTrip);
            for (let listTrip of this.maintripType) {
                if (event.target.checked) {
                    if (listTrip.labeltrip == event.target.value) {
                        document.getElementById(event.target.id).style.color = "#398AC9";
                        document.getElementById(event.target.id + 'Mov').style.color = "#398AC9";
                        this.contCheckTrip++;
                    }
                } else {
                    if (listTrip.labeltrip == event.target.value) {
                        document.getElementById(event.target.id + 'Mov').style.color = "#787778";
                        document.getElementById(event.target.id).style.color = "#787778";
                        this.triptype = "Trip type";
                        this.contCheckTrip--;
                    }
                }
            }
            if (this.contCheckTrip == 0) {
                this.contTrip = " ";
            } else if (this.contCheckTrip == 1) {
                this.contTrip = "";
                this.triptype = this.checkedTrip[0].substring(9);
            } else {
                this.triptype = "Trip type";
                this.contTrip = " " + this.contCheckTrip;
            }
        },
        moreTravelersAdu: function (event) {
            this.count++;
            this.travelersTot = "Travelers " + (this.count + this.count1);
        },
        minusTravelersAdu: function (event) {
            if (this.count > 0) {
                this.count--;
                this.travelersTot = "Travelers " + (this.count + this.count1);
            }
        },
        moreTravelersChild: function (event) {
            this.count1++;
            this.travelersTot = "Travelers " + (this.count + this.count1);
        },
        minusTravelersChild: function (event) {
            if (this.count1 > 0) {
                this.count1--;
                this.travelersTot = "Travelers " + (this.count + this.count1);
            }
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
            $('.applyTravelerPlanner').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')

        },
        priceRange: function (event) {
            this.price = document.getElementsByClassName('amountPrice')[0].value;
        },
        price: function () {
            this.price = document.getElementsByClassName('amountPrice')[0].value;
        },
        resettlePric: function () {
            this.price = "Price range";
        },
        applyPrice: function (event) {
            this.price = document.getElementsByClassName('amountPrice')[0].value;
            $('.applyPricePlanner').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
            this.getDisponibilidad(event);
        },
        moreLenght: function (event) {
            if (this.countLen < 20) {
                this.countLen++;
            }

        },
        minusLenght: function (event) {
            if (this.countLen > 0) {
                this.countLen--;
            }
        },
        resettlelenght: function () {
            this.countLen = 0;
        },
        applyLenght: function (event) {
            $('.applyLenghtPlanner').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
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

        },
        applyDate: function (event) {
            $('.applyDatePlanner').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        applyTripPlanner: function () {

            $('.applyTravelers').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        resettleTripPlanner: function () {

            for (var i = 0; i < 4; i++) {
                document.getElementById(i).style.color = "#787778";
            }
            this.contCheckTrip = 0;
            this.contTrip = "";
            this.checkedTrip = [];
            this.triptype = "Trip type";
        },
        beforeMount: function () {
            this.getDisponibilidad();
        },
        updatePage(pageNumber) {
            this.currentPage = pageNumber;
        },
        getDisponibilidad(event) {
            var vm = this;
            document.getElementById("mySidenavMovile").style.width = "0";
            vm.disponibilidadBarcosPaMa = []
            vm.disponibilidadOtrosBarcos = []
            vm.listDisponibilidadBarcosPaMa = []
            vm.listDisponibilidadOtrosBarcos = []
            vm.respuestaBarcos = ''
            vm.respuestaIslandHopping = ""
            vm.results = ''

            var travelers, days;
            var price = [];
            var date = [];
            var idBarcofiltro = [];
            var idOtrosBarcofiltro = [];

            if (event == undefined) {
                this.dataTripPlanner = JSON.parse(localStorage.getItem('datosTrip'));
                if (this.dataTripPlanner[0].length == 1) {
                    this.triptype = this.dataTripPlanner[0][0].substring(9);
                }

               

                this.travelersTot = "Travelers " + this.dataTripPlanner[1];
                this.price = "$ " + this.dataTripPlanner[2][0] + "- " + "$" + this.dataTripPlanner[2][1];
                this.countLen = this.dataTripPlanner[4];
                this.dataTripPlanner[5] == "Date" ? this.dateTrip = "Date" : this.dateTrip = this.dataTripPlanner[5]
            } else {
                this.updatePage(0)
                var datosFiltro = limpiarDatos(vm.travelersTot, vm.price, vm.dateTrip);

                this.dataTripPlanner = [this.checkedTrip, datosFiltro[0][1], datosFiltro[1], datosFiltro[2], vm.countLen, datosFiltro[3]];

                localStorage.setItem('datosTrip', JSON.stringify(this.dataTripPlanner));
            }

           


            $.ajax({
                url: "/IslandHoppingPaquetes", method: "POST",
                success: function (data) {
                    var galapLanBase = [];
                    var listaCardsDispo = [];

                    if (vm.dataTripPlanner[0].length == 0 || vm.dataTripPlanner[0].length == 3) {
                        data.forEach(function (item) {

                            travelers = vm.dataTripPlanner[1];
                            price = vm.dataTripPlanner[2];
                            date = vm.dataTripPlanner[3];
                            days = vm.dataTripPlanner[4];

                            if (Number(item.precio.replace(",", ".")) >= price[0] && Number(item.precio.replace(",", ".")) <= price[1]) {
                                if (item.numeroDias >= days) {
                                    galapLanBase.push(item);
                                }
                            }


                            if (item.islandHoppingYPaqueteTipo == 'BC') {

                                //Cargar datos de la  Api disponibilidad de los barcos, del controlador asi la vista 
                                $.ajax({ url: "/DisponibilidadBarcoPaMa", method: "GET" }).done(function (data) {
                                    if (vm.disponibilidadBarcosPaMa.length == 0) {

                                        vm.disponibilidadBarcosPaMa = data;

                                        //Verificar disponobilidad de los barcos
                                        for (let filBarco of vm.disponibilidadBarcosPaMa) {
                                            if (new Date(filBarco.salFechaSalida).getTime() >= new Date(date[0]).getTime() && new Date(filBarco.salFechaSalida).getTime() <= new Date(date[1]).getTime()) {
                                                if (filBarco.cabinaPrecio1.replace(',', '.') >= parseFloat(price[0]) && filBarco.cabinaPrecio1.replace(',', '.') <= parseFloat(price[1])) {


                                                    if (parseInt(filBarco.totalDisponibilidad) >= travelers) {


                                                        if (parseInt(filBarco.noches) >= days) {

                                                            vm.listDisponibilidadBarcosPaMa.push(filBarco);


                                                        } else {
                                                            vm.dispoBarcosMaPaFiltros = false

                                                        }

                                                    }

                                                }

                                            }
                                        }
                                    }

                                    for (let dat of vm.listDisponibilidadBarcosPaMa) {
                                        idBarcofiltro.push(dat.idBarco)

                                    }
                                    //Eliminar id´s repetidos de los barcos
                                    listaCardsDispo = idBarcofiltro.filter(function (value, index, self) {
                                        return self.indexOf(value) === index;
                                    });

                                    for (let idBarcoDispo of listaCardsDispo) {

                                        if (idBarcoDispo == item.idItinerario) {

                                            if (galapLanBase.length >= 1) {
                                                const found = galapLanBase.find(element => element.idItinerario == idBarcoDispo);
                                                if (found == undefined) {
                                                    galapLanBase.push(item);
                                                }
                                            } else {
                                                //agregar barcos filtrados a la lista
                                                galapLanBase.push(item);
                                            }

                                        }
                                    }


                                }).fail(function (jqXHR, textStatus, errorThrown) {
                                    if (console && console.log) {
                                        vm.dispBarcosVerficarInf = "We couldn´t load the available departures. Please, try later";
                                    }
                                });

                                $.ajax({ url: "/DispoOtrosBarcos", method: "GET" }).done(function (data) {

                                    if (vm.disponibilidadOtrosBarcos.length == 0) {
                                        vm.disponibilidadOtrosBarcos = data;
                                        for (let filBarco of vm.disponibilidadOtrosBarcos) {
                                            if (new Date(filBarco.salFechaSalida).getTime() >= new Date(date[0]).getTime() && new Date(filBarco.salFechaSalida).getTime() <= new Date(date[1]).getTime()) {
                                                if (filBarco.cabinaPrecio1.replace(',', '.') >= parseFloat(price[0]) && filBarco.cabinaPrecio1.replace(',', '.') <= parseFloat(price[1])) {


                                                    if (parseInt(filBarco.salDispoTotalOtrosBarcos) >= travelers) {


                                                        if (parseInt(filBarco.noches) >= days) {

                                                            vm.listDisponibilidadOtrosBarcos.push(filBarco);

                                                        }

                                                    }

                                                }

                                            }
                                        }
                                    }



                                    for (let dat of vm.listDisponibilidadOtrosBarcos) {
                                        idOtrosBarcofiltro.push(dat.idBarco)
                                    }

                                    //Eliminar id´s repetidos de los barcos
                                    listaCardsDispo = idOtrosBarcofiltro.filter(function (value, index, self) {
                                        return self.indexOf(value) === index;
                                    });

                                    for (let idBarcoDispo of listaCardsDispo) {

                                        if (idBarcoDispo == item.idItinerario) {

                                            if (galapLanBase.length >= 1) {
                                                const found = galapLanBase.find(element => element.idItinerario == idBarcoDispo);
                                                if (found == undefined) {
                                                    galapLanBase.push(item);
                                                }
                                            } else {
                                                //agregar barcos filtrados a la lista
                                                galapLanBase.push(item);
                                            }

                                        }
                                    }

                                    if (galapLanBase.length === 0) {
                                        vm.respuestaBarcos = "To get more results, try adjusting your search"
                                        vm.results = "No results"

                                        var listaBarcos = vm.disponibilidadBarcosPaMa.concat(vm.disponibilidadOtrosBarcos)
                                        vm.listDisponibilidadBarcosPaMa = vm.disponibilidadBarcosPaMa
                                        vm.listDisponibilidadOtrosBarcos = vm.disponibilidadOtrosBarcos

                                        for (let dat of listaBarcos) {
                                            idOtrosBarcofiltro.push(dat.idBarco)
                                        }

                                        //Eliminar id´s repetidos de los barcos
                                        var listaCardsDispo = idOtrosBarcofiltro.filter(function (value, index, self) {
                                            return self.indexOf(value) === index;
                                        });

                                        for (let idBarcoDispo of listaCardsDispo) {

                                            if (idBarcoDispo == item.idItinerario) {

                                                //agregar barcos filtrados a la lista
                                                galapLanBase.push(item);

                                            }
                                            vm.dispoBarcosFiltros = false
                                        }

                                    } else {
                                        vm.dispoBarcosFiltros = true

                                    }

                                }).fail(function (jqXHR, textStatus, errorThrown) {
                                    if (console && console.log) {
                                        vm.dispVerficarOtrosBarcos = "We couldn´t load the available departures. Please, try later";

                                    }
                                });

                            }


                        });

                        vm.listServices = galapLanBase

                        
                        Promise.all([galapLanBase]).then(values => {
                            vm.progressBar();
                        });


                    } else {
                        

                        for (let tripType of vm.dataTripPlanner[0]) {

                            if (tripType == "Galapagos Cruises") {
                                data.forEach(function (item) {
                                    travelers = vm.dataTripPlanner[1];
                                    price = vm.dataTripPlanner[2];
                                    date = vm.dataTripPlanner[3];
                                    days = vm.dataTripPlanner[4];

                                    if (item.islandHoppingYPaqueteTipo == '' || item.islandHoppingYPaqueteTipo == 'BC') {

                                      

                                        $.when(

                                            //Cargar datos de la  Api disponibilidad de los barcos, del controlador asi la vista 
                                            $.ajax({ url: "/DisponibilidadBarcoPaMa", method: "GET" }).done(function (data) {
                                                if (vm.disponibilidadBarcosPaMa.length == 0) {

                                                    vm.disponibilidadBarcosPaMa = data;

                                                    //Verificar disponobilidad de los barcos
                                                    for (let filBarco of vm.disponibilidadBarcosPaMa) {
                                                        if (new Date(filBarco.salFechaSalida).getTime() >= new Date(date[0]).getTime() && new Date(filBarco.salFechaSalida).getTime() <= new Date(date[1]).getTime()) {
                                                            if (filBarco.cabinaPrecio1.replace(',', '.') >= parseFloat(price[0]) && filBarco.cabinaPrecio1.replace(',', '.') <= parseFloat(price[1])) {


                                                                if (parseInt(filBarco.totalDisponibilidad) >= travelers) {


                                                                    if (parseInt(filBarco.noches) >= days) {

                                                                        vm.listDisponibilidadBarcosPaMa.push(filBarco);


                                                                    }

                                                                }

                                                            }

                                                        }
                                                    }
                                                }

                                                for (let dat of vm.listDisponibilidadBarcosPaMa) {
                                                    idBarcofiltro.push(dat.idBarco)

                                                }
                                                //Eliminar id´s repetidos de los barcos
                                                var listaCardsDispo = idBarcofiltro.filter(function (value, index, self) {
                                                    return self.indexOf(value) === index;
                                                });
                                                for (let idBarcoDispo of listaCardsDispo) {

                                                    if (idBarcoDispo == item.idItinerario) {
                                                        //agregar barcos filtrados a la lista
                                                        galapLanBase.push(item);

                                                    }
                                                }

                                            }).fail(function (jqXHR, textStatus, errorThrown) {
                                                if (console && console.log) {
                                                    vm.dispBarcosVerficarInf = "We couldn´t load the available departures. Please, try later";

                                                }
                                            }),

                                            $.ajax({ url: "/DispoOtrosBarcos", method: "GET" }).done(function (data) {
                                                if (vm.disponibilidadOtrosBarcos.length == 0) {
                                                    vm.disponibilidadOtrosBarcos = data;
                                                    for (let filBarco of vm.disponibilidadOtrosBarcos) {
                                                        if (new Date(filBarco.salFechaSalida).getTime() >= new Date(date[0]).getTime() && new Date(filBarco.salFechaSalida).getTime() <= new Date(date[1]).getTime()) {
                                                            if (filBarco.cabinaPrecio1.replace(',', '.') >= parseFloat(price[0]) && filBarco.cabinaPrecio1.replace(',', '.') <= parseFloat(price[1])) {


                                                                if (parseInt(filBarco.salDispoTotalOtrosBarcos) >= travelers) {


                                                                    if (parseInt(filBarco.noches) >= days) {

                                                                        vm.listDisponibilidadOtrosBarcos.push(filBarco);

                                                                    }

                                                                }

                                                            }

                                                        }
                                                    }
                                                }

                                                for (let dat of vm.listDisponibilidadOtrosBarcos) {

                                                    idOtrosBarcofiltro.push(dat.idBarco)

                                                }

                                                //Eliminar id´s repetidos de los barcos
                                                var listaCardsDispo = idOtrosBarcofiltro.filter(function (value, index, self) {
                                                    return self.indexOf(value) === index;
                                                });
                                                for (let idBarcoDispo of listaCardsDispo) {

                                                    if (idBarcoDispo == item.idItinerario) {
                                                        //agregar barcos filtrados a la lista
                                                        galapLanBase.push(item);

                                                    }
                                                }

                                                if (galapLanBase.length === 0) {
                                                    vm.respuestaBarcos = "To get more results, try adjusting your search"
                                                    vm.results = "No results"
                                                    vm.dispoBarcosFiltros = false
                                                    var listaBarcos = vm.disponibilidadBarcosPaMa.concat(vm.disponibilidadOtrosBarcos)
                                                    vm.listDisponibilidadBarcosPaMa = vm.disponibilidadBarcosPaMa
                                                    vm.listDisponibilidadOtrosBarcos = vm.disponibilidadOtrosBarcos

                                                    for (let dat of listaBarcos) {
                                                        idOtrosBarcofiltro.push(dat.idBarco)
                                                    }

                                                    //Eliminar id´s repetidos de los barcos
                                                    var listaCardsDispo = idOtrosBarcofiltro.filter(function (value, index, self) {
                                                        return self.indexOf(value) === index;
                                                    });

                                                    for (let idBarcoDispo of listaCardsDispo) {

                                                        if (idBarcoDispo == item.idItinerario) {

                                                            //agregar barcos filtrados a la lista
                                                            galapLanBase.push(item);

                                                        }
                                                    }

                                                } else {
                                                    vm.dispoBarcosFiltros = true

                                                }

                                            }).fail(function (jqXHR, textStatus, errorThrown) {
                                                if (console && console.log) {
                                                    vm.dispVerficarOtrosBarcos = "We couldn´t load the available departures. Please, try later";

                                                }
                                            })

                                        ).then(
                                            
                                            
                                        );

                                        

                                        


                                        
                                    }
                                   
                                });
                            }

                            if (tripType == "Galapagos Land-based tours") {

                                data.forEach(function (item) {
                                    if (item.islandHoppingYPaqueteTipo == 'IH') {
                                        if (Number(item.precio.replace(",", ".")) >= vm.dataTripPlanner[2][0] && Number(item.precio.replace(",", ".")) <= vm.dataTripPlanner[2][1]) {
                                            //lisBarco.length == 0 ? vm.respuesta = "No existe Cruceros para esos dias" : vm.respuesta = "Ex";
                                            if (item.numeroDias >= vm.dataTripPlanner[4]) {
                                                galapLanBase.push(item);
                                            }
                                        }
                                    }

                                });

                                var ListaIlslandHopping = galapLanBase.filter(function (item) {
                                    return item.islandHoppingYPaqueteTipo == 'IH' || item.islandHoppingYPaqueteTipo == 'MD';
                                });
                                if (ListaIlslandHopping.length === 0) {
                                    vm.dispoIslandHopping = false
                                    vm.respuestaIslandHopping = "To get more results, try adjusting your search"
                                    vm.results = "No results"
                                    data.forEach(function (item) {
                                        if (item.islandHoppingYPaqueteTipo == 'IH' || item.islandHoppingYPaqueteTipo == 'MD') {
                                            galapLanBase.push(item);
                                        }
                                    });
                                } else {
                                    vm.dispoIslandHopping = true
                                }
                            }
                            if (tripType == "Tours in Mainland Ecuador") {

                                data.forEach(function (item) {
                                    if (item.islandHoppingYPaqueteTipo == 'MD') {
                                        if (Number(item.precio.replace(",", ".")) >= vm.dataTripPlanner[2][0] && Number(item.precio.replace(",", ".")) <= vm.dataTripPlanner[2][1]) {
                                            if (item.numeroDias >= vm.dataTripPlanner[4]) {
                                                galapLanBase.push(item);
                                            }
                                        }
                                    }

                                });
                                var ListaIlslandHopping = galapLanBase.filter(function (item) {
                                    return item.islandHoppingYPaqueteTipo == 'IH' || item.islandHoppingYPaqueteTipo == 'MD';
                                });
                                if (ListaIlslandHopping.length === 0) {
                                    vm.dispoIslandHopping = false
                                    vm.respuestaIslandHopping = "To get more results, try adjusting your search"
                                    vm.results = "No results"
                                    data.forEach(function (item) {
                                        if (item.islandHoppingYPaqueteTipo == 'IH' || item.islandHoppingYPaqueteTipo == 'MD') {
                                            galapLanBase.push(item);
                                        }
                                    });
                                } else {
                                    vm.dispoIslandHopping = true
                                }

                            }

                        }

                        vm.listServices = galapLanBase;

                        Promise.all([galapLanBase]).then(values => {
                            vm.progressBar();
                        });
                    }
                }
            });



            //Cargar datos en las cards desde la  sp getBarcosWeb, del controlador asi la vista 
            $.ajax({ url: "/BarcoBD", method: "GET" }).done(function (data) {
                vm.ListBarcoCards = data;
                console.log(vm.ListBarcoCards)
                for (let dat of data) {
                    var cadena = dat.barcoDescripcionEn;
                    var temporal = document.createElement("div");
                    temporal.innerHTML = cadena;
                    var texto = temporal.textContent || temporal.innerText || "";
                    vm.desBarco.push({ id: dat.idBarco, barcoDesp: texto });

                }
                
            });

           


        },
        totalPages() {
            return Math.ceil(this.listServices.length / this.pageSize);
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
        getIslandHoppingPaq: function (event) {
            var vm = this;
            var idItinerario = event.currentTarget.id;
            this.idBarcoSalida = event.currentTarget.id;
            $.ajax({ url: "/GetIslandHoppPaqFindIDItinerario/" + idItinerario, method: "GET" }).done(function (data) {
                vm.IslandHoppingPaq = data;
            });

            //tomar id de la card del barco en una variable para enviarla a una funcion (filtroDispoBarcosPaMa y filDispoBarcos) del computed
            this.idBarcoCard = event.currentTarget.id;

            //Obtner descripcion barco e imagen para el modal availability
            var idCard = event.currentTarget.id;



            this.datoCardBarco = this.listServices.filter(function (item) {
                if (item.idItinerario == idCard) {
                    return item;
                }
            });


            for (let dat of this.desBarco) {
                if (dat.id == idCard) {
                    this.datoCardBarco.push(dat.barcoDesp)
                }
            }



            if (this.dateTrip == "Date" || this.dateTrip == "") {
                this.dateModal = "Select your travel dates";
            } else {
                if (this.dateTrip.split(',')[0] == "" || this.dateTrip.split(',')[1] == "") {
                    this.dateModal = this.dateTrip.replace(",", "")

                } else {
                    this.dateModal = this.dateTrip;
                }

            }
            //Abrir Modal availabilityModal.cshtml y guardar id de Barco Seleccionado
            if (this.datoCardBarco[0].islandHoppingYPaqueteTipo == 'BC') {
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

            } else {
                $('#itinerarioModal').modal('show');
            }


        },




        getservicioPaMa: function (event) {
            $("#detailsCabPaMa").modal('show');
            var idSalidaBarco = event.currentTarget.id;

            this.cabinas = [];

            this.datBarcosSelect = idSalidaBarco;

            this.cabinas = this.DispSelectBarcoPaMa.filter(function (item) {
                if (item.idSalida == idSalidaBarco) {
                    return item;
                }
            });
            console.log(this.cabinas)

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

            var datosStorage = [];
            datosStorage = leadsBoars;
            localStorage.setItem('datosTripEmail', JSON.stringify(datosStorage));


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

            var datosStorage = [];
            datosStorage = leadsBoars;
            localStorage.setItem('datosTripEmail', JSON.stringify(datosStorage));


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

        closeModalIslandHopping() {
            document.querySelector('body').classList.remove('hiddenBody');

            document.getElementById('diplay-slide-trip').style.display = 'none';
            document.getElementById('dispo-displayIslandHopp').style.display = 'block';


            if (window.innerWidth > 700) {

                document.getElementById('modalImgIslandHopp').style.display = 'block';

            } else {
                document.getElementById('modalImgIslandHopp').style.display = 'none';

            }
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

        //Email trip
        getEmail: async function (idItinerario, idPaquete) {
            var em = this;
            $.ajax({ url: "/GetIslandHoppPaqFindIDItinerario/" + idItinerario, method: "GET" })
                .done(function (data) {
                    for (let dat of data) {
                        if (idPaquete == dat.idWebIslandHoppingYPaquete) {
                            em.PaqIslandEmail = dat;
                        }
                    }
                });
        },
        //Itiner Isalnd
        getItinerIsland: async function (idItinerario) {
            var em = this;
            em.itiBarcoBtn = [];
            console.log(idItinerario);
            document.getElementById('diplay-slide-trip').style.display = 'block';
            document.getElementById('dispo-displayIslandHopp').style.display = 'none';
            document.getElementById('modalImgIslandHopp').style.display = 'none';
            $.ajax({ url: "/GetIslandIDItinerarioDetallado/" + idItinerario, method: "GET" })
                .done(function (data) {
                    em.itiBarcoBtn = data;
                    console.log(data);
                });
        },
        modalBlockIslandHop: async function () {
            document.getElementById('diplay-slide-trip').style.display = 'none';
            document.getElementById('dispo-displayIslandHopp').style.display = 'block';
            document.getElementById('modalImgIslandHopp').style.display = 'block';
        },
        closeModalTripEmail: function () {
            var Email = document.getElementById('emailTrip');
            var Name = document.getElementById('nombreTrip');
            var fechaTripDesde = document.getElementById('fechaTrip');
            var NumeroPax = document.getElementById('travelersEcItin');
            var details = document.getElementById('tripdetails');
            Email.value = "";
            Name.value = "";
            fechaTripDesde.value = "";
            NumeroPax.value = "";
            details.value = "";
            //Quitar Clases de css
            $("#emailTrip").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#emailTrip').addClass("form-control");

            $("#nombreTrip").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#nombreTrip').addClass("form-control");
            $("#fechaTrip").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#fechaTrip').addClass("form-control");
            $("#travelersEcItin").removeClass("ValidTInyp input-iconoError  input-icono");
            $('#travelersEcItin').addClass("form-control");
            $('#itinerarioModal').modal('show');
            document.querySelector('body').classList.add('hiddenBody');
            $('#emailBarco').modal('hide');
        },
        AprobarEmailTrip: function (nombrePaqueteTrip, Categoria, numDias) {
            var Email = document.getElementById('emailTrip').value;
            var Name = document.getElementById('nombreTrip').value;
            var fechaTripDesde = document.getElementById('fechaTrip').value;
            var NumeroPax = document.getElementById('travelersEcItin').value;
            var details = document.getElementById('tripdetails').value;
            var formTrip = document.getElementById('formTripDeter').value;
            //IP
            var IP = document.getElementById('ipAddress1').innerHTML;
            var CountryCode = document.getElementById('countryCode1').innerHTML;
            var CityName = document.getElementById('cityName1').innerHTML;
            var TipoTours = "TripTours";

            var leadsBoars = new Object();
            leadsBoars.NombreBarco = nombrePaqueteTrip;
            leadsBoars.Itinerario = Categoria;
            leadsBoars.Noches = numDias;
            leadsBoars.SalCodigo = fechaTripDesde;
            leadsBoars.Correo = Email;
            leadsBoars.Nombre = Name;
            leadsBoars.NummeroMax = NumeroPax;
            leadsBoars.Observacion = details;
            var datosStorage = [];
            datosStorage = leadsBoars;
            localStorage.setItem('datosTripEmail', JSON.stringify(datosStorage));
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
        SendleadTrip: function (nombrePaqueteTrip, Categoria, numDias) {
            //validar email
            var EmailTxt = document.getElementById("emailTrip");
            if ($(EmailTxt).val().length == 0) {
                EmailTxt.className = "ValidTInyp input-iconoError";
            } else {
                EmailTxt.className = "form-control input-icono";
            }

            //Validar Nombre
            var NombreTxt = document.getElementById("nombreTrip");
            if ($(NombreTxt).val().length == 0) {
                NombreTxt.className = "ValidTInyp input-iconoError";
            } else {
                NombreTxt.className = "form-control input-icono";
            }
            //validar fecha
            var TXtstart = document.getElementById("fechaTrip");
            if ($(TXtstart).val().length == 0) {
                TXtstart.className = "ValidTInyp input-iconoError";
            } else {
                TXtstart.className = "form-control input-icono";
            }
            //Validar pasajeros 
            var travelers = document.getElementById("travelersEcItin");
            if ($(travelers).val().length == 0) {
                travelers.className = "ValidTInyp input-iconoError";
            } else {
                travelers.className = "form-control input-icono";
            }

            if (this.validar_email($(EmailTxt).val()) && ($(NombreTxt).val().length != 0) && ($(TXtstart).val().length != 0) && ($(travelers).val().length != 0)) {
                this.AprobarEmailTrip(nombrePaqueteTrip, Categoria, numDias);
            }

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
        ShowCardsIslandHopping() {

            this.visibleTodos = this.listServices.slice(this.currentPage * this.pageSize, (this.currentPage * this.pageSize) + this.pageSize);
            if (this.visibleTodos.length == 1 && this.listServices.length == 1) {
                this.classObject = 'col-md-4';
            }
            //Verificar cantidad de  Barcos del sp GetBarcosWeb y acomodar diseño
            if (this.visibleTodos.length > 1 && this.listServices.length > 1) {
                this.classObject = 'col-md-4';
            }



            return this.visibleTodos;
        },

        //Filtros para los barcos Passion y Mary Ann
        filtroDispoBarcosPaMa() {

            var idBarcoSelectCard = this.idBarcoCard;
            var f, f1, f2, fechaInicio, fechaFin;

            var travelers = this.dataTripPlanner[1];
            var price = this.dataTripPlanner[2];
            var date = this.dataTripPlanner[3];
            var days = this.dataTripPlanner[4];



            this.DispSelectBarcoPaMa = this.listDisponibilidadBarcosPaMa.filter(function (item) {
                if (item.idBarco == idBarcoSelectCard) {
                    return item;
                }
            });

            //Cargar pagina disponibilidad-Cruceros con toda la diponibilidad de los barcos
            if (this.dateModal != "Select your travel dates") {
                if (this.dateModal.split(',').length == 1) {
                    f = this.dateModal.split(',')[0].split("-");
                    fechaInicio = new Date(f[0] + "-" + "20" + f[1]);

                    this.DispSelectBarcoPaMa = this.disponibilidadBarcosPaMa.filter(function (item) {
                        if (item.idBarco == idBarcoSelectCard) {
                            if (parseInt(item.totalDisponibilidad) >= travelers) {
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

                    this.DispSelectBarcoPaMa = this.disponibilidadBarcosPaMa.filter(function (item) {
                        if (item.idBarco == idBarcoSelectCard) {
                            if (parseInt(item.totalDisponibilidad) >= travelers) {
                                if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(fechaFin).getTime()) {

                                    return item;
                                }
                            }

                        }
                    });

                }

                if (this.DispSelectBarcoPaMa.length == 0) {
                    this.dispBarcosVerficarInf = "Not available departures. Try again";

                }

            }



            return this.DispSelectBarcoPaMa;
        },

        //Ver Disponibilidad al seleccionar cada card de barco
        filDispoBarcos() {

            var idBarcoSelectCard = this.idBarcoCard;
            var f, f1, f2, fechaInicio, fechaFin;


            var travelers = this.dataTripPlanner[1];
            var price = this.dataTripPlanner[2];
            var date = this.dataTripPlanner[3];
            var days = this.dataTripPlanner[4];

            this.DispSelectOtrosBarco = this.listDisponibilidadOtrosBarcos.filter(function (item) {
                if (item.idBarco == idBarcoSelectCard) {
                    return item;
                }
            });

            if (this.DispSelectOtrosBarco.length == 0) {
                this.dispVerficarOtrosBarcos = "Not available information. Please, try later";
                console.log(this.dispVerficarOtrosBarcos)
            }

            //Cargar disponibilidadCruceros con filtros.
            if (this.dateModal != "Select your travel dates") {

                if (this.dateModal.split(',').length == 1) {
                    f = this.dateModal.split(',')[0].split("-");
                    fechaInicio = new Date(f[0] + "-" + "20" + f[1]);


                    this.DispSelectOtrosBarco = this.disponibilidadOtrosBarcos.filter(function (item) {
                        if (item.idBarco == idBarcoSelectCard) {
                            if (parseInt(item.salDispoTotalOtrosBarcos) >= travelers) {
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


                    this.DispSelectOtrosBarco = this.disponibilidadOtrosBarcos.filter(function (item) {
                        if (item.idBarco == idBarcoSelectCard) {
                            if (parseInt(item.salDispoTotalOtrosBarcos) >= travelers) {
                                if (new Date(item.salFechaSalida).getTime() >= new Date(fechaInicio).getTime() && new Date(item.salFechaSalida).getTime() <= new Date(fechaFin).getTime()) {

                                    return item;
                                }
                            }

                        }
                    });

                }

                if (this.DispSelectOtrosBarco.length == 0) {
                    this.dispVerficarOtrosBarcos = "Not available departures. Try again";
                    console.log(this.dispVerficarOtrosBarcos)
                }
            }


            return this.DispSelectOtrosBarco;
        },
    },
    mounted() {
        var self = this;
        this.show = true;

        for (let listTrip of this.maintripType) {
            for (let dataTrip of this.dataTripPlanner[0]) {
                if (listTrip.labeltrip == dataTrip) {
                    this.checkedTrip.push(listTrip.labeltrip)
                    var tripType = listTrip.labeltrip.replace(/[\W_]/g, "");
                    document.getElementById(tripType).style.color = "#398AC9";
                    document.getElementById(tripType + 'Mov').style.color = "#398AC9";
                    this.contCheckTrip++
                }
            }


        }
        if (this.contCheckTrip > 1) {
            this.contTrip = this.contCheckTrip
        }

        var contdatePickerModal = 0;
        var datePickerSelectModal = [];



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
            self.selectDateModal = $('#dataPickerPaMa').data('datepicker').getFormattedDate('M-yy')
            self.dateModal = self.selectDateModal;


            if (self.selectDateModal.split(',')[contdatePickerModal] !== undefined) {
                datePickerSelectModal.push(self.selectDateModal.split(',')[contdatePickerModal]);
                contdatePickerModal++;
            }
            if (self.selectDateModal == '') {
                self.dateModal = "Select your travel dates";
            }
            if (self.selectDateModal.split(',').length == 2) {
                var f = self.selectDateModal.split(',');
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
            self.selectDateModal = $('#dataPickerOtrosBarcos').data('datepicker').getFormattedDate('M-yy')
            self.dateModal = self.selectDateModal;

            if (self.selectDateModal.split(',')[contdatePickerModal] !== undefined) {
                datePickerSelectModal.push(self.selectDateModal.split(',')[contdatePickerModal]);
                contdatePickerModal++;

            }
            if (self.selectDateModal == '') {
                self.dateModal = "Select your travel dates";
            }
            if (self.selectDateModal.split(',').length == 2) {
                var f = self.selectDateModal.split(',');
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

        $('#datePickerBarcoInfinity').on('changeDate', function () {
            self.selectDateModal = $('#datePickerBarcoInfinity').data('datepicker').getFormattedDate('M-yy')
            self.dateModal = self.selectDateModal;

            if (self.selectDateModal.split(',')[contdatePickerModal] !== undefined) {
                datePickerSelectModal.push(self.selectDateModal.split(',')[contdatePickerModal]);
                contdatePickerModal++;

            }
            if (self.selectDateModal == '') {
                self.dateModal = "Select your travel dates";
            }
            if (self.selectDateModal.split(',').length == 2) {
                var f = self.selectDateModal.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateModal = f[1] + "," + f[0];
                }
            }
            if (datePickerSelectModal.length == 3) {
                $('#datePickerBarcoInfinity').datepicker('update');
                var f = datePickerSelectModal[2].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#datePickerBarcoInfinity').datepicker('update', new Date());
                } else {
                    $('#datePickerBarcoInfinity').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                contdatePickerModal = 1;
                datePickerSelectModal = [];
                datePickerSelectModal.push(f[0] + "-" + f[1]);
                self.dateModal = datePickerSelectModal[0];
            }
        });


        $('#datePickerBarcoGranMajestic').on('changeDate', function () {
            self.selectDateModal = $('#datePickerBarcoGranMajestic').data('datepicker').getFormattedDate('M-yy')
            self.dateModal = self.selectDateModal;

            if (self.selectDateModal.split(',')[contdatePickerModal] !== undefined) {
                datePickerSelectModal.push(self.selectDateModal.split(',')[contdatePickerModal]);
                contdatePickerModal++;

            }
            if (self.selectDateModal == '') {
                self.dateModal = "Select your travel dates";
            }
            if (self.selectDateModal.split(',').length == 2) {
                var f = self.selectDateModal.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateModal = f[1] + "," + f[0];
                }
            }
            if (datePickerSelectModal.length == 3) {
                $('#datePickerBarcoGranMajestic').datepicker('update');
                var f = datePickerSelectModal[2].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#datePickerBarcoGranMajestic').datepicker('update', new Date());
                } else {
                    $('#datePickerBarcoGranMajestic').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                contdatePickerModal = 1;
                datePickerSelectModal = [];
                datePickerSelectModal.push(f[0] + "-" + f[1]);
                self.dateModal = datePickerSelectModal[0];
            }
        });

        $('#datepickerDispMovile').on('changeDate', function () {
            self.selectDateModal = $('#datepickerDispMovile').data('datepicker').getFormattedDate('M-yy')
            self.dateTrip = self.selectDateModal;

            if (self.selectDateModal.split(',')[contdatePickerModal] !== undefined) {
                datePickerSelectModal.push(self.selectDateModal.split(',')[contdatePickerModal]);
                contdatePickerModal++;

            }
            if (self.selectDateModal == '') {
                self.dateTrip = "Date";
            }
            if (self.selectDateModal.split(',').length == 2) {
                var f = self.selectDateModal.split(',');
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