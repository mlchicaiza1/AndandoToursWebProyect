var thankYouPage = new Vue({
    el: '#thankYouPage',

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
            contTrip: "",
            cont: "",
            triptype: 'Trip type',
            checkColor: "#787778",
            checkedTrip: [],
            object: {
                
                GalapLand: 'Galapagos Land-based tours',
                ToursMainland: 'Tours in Mainland Ecuador'
            },
            maintripType: [{ labeltrip: 'Galapagos Land-based tours' }, { labeltrip: 'Tours in Mainland Ecuador' }],
            travelersTot: "Travelers",
            count: 2,
            count1: 0,
            price: "Price range",

            //Mensaje para filtros IslandHopping
            dispoIslandHopping:true,
            respuestaIslandHopping: '',
            results: "",

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
            salFechaSalida: null,
            PaqIslandEmail: [],


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


            //Almacenar id de  la card Barco seleccionada
            idBarcoCard: '',




            barcoSalida: [],
            idBarcoSalida: 0,
            cabinas: [],
            active: 'item active',
            noActivo: 'item',
            recaptchaScript: "",
            respuesta: "",
            dataApi: 0,
            counter: 1,
            counterEnd: 140,
        }
    },
    created: function () {
        this.getDisponibilidad();


    },
    methods: {
        checkTripType(event) {
            console.log(this.contTrip + "  " + this.cont);
            for (let listTrip of this.maintripType) {
                if (event.target.checked) {
                    if (listTrip.labeltrip == event.target.value) {
                        document.getElementById(event.target.id).style.color = "#398AC9";
                        this.cont++;
                    }
                } else {
                    if (listTrip.labeltrip == event.target.value) {
                        document.getElementById(event.target.id).style.color = "#787778";
                        this.triptype = "Trip type";
                        this.cont--;
                    }
                }
            }
            if (this.cont == 0) {
                this.contTrip = " ";
            } else if (this.cont == 1) {
                this.contTrip = "";
                this.triptype = this.checkedTrip[0].substring(9);
            } else {
                this.triptype = "Trip type";
                this.contTrip = " " + this.cont;
            }
        },
        priceRange: function (event) {
            //this.price = document.getElementById('amountPrice').value;
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
        },
        moreLenght: function (event) {
            if (this.countLen < 12) {
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

        applyTripPlanner: function () {

            $('.applyTravelers').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        resettleTripPlanner: function () {

            for (var i = 0; i < 4; i++) {
                document.getElementById(i).style.color = "#787778";
            }
            this.cont = 0;
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
            vm.listServices = [];
            vm.respuestaIslandHopping = ''
            vm.results=''
            document.getElementById("mySidenavMovile").style.width = "0";
            
            if (event == undefined) {
                this.cont = 0;
            } else {
               
                //this.dataTripPlanner = [this.checkedTrip, datosFiltro[0][1], datosFiltro[1], datosFiltro[2], vm.countLen, datosFiltro[3]];
            }
            this.updatePage(0)
            var days = vm.countLen
            var price
            if (vm.price == "Price range") {
                price = [300, 7500];
            } else {
                price = vm.price.replace(/[$]/gi, '').split('-');
            }



            $.ajax({ url: "/IslandHoppingPaquetes", method: "GET" })
                .done(function (data) {
                    var galapLanBase = [];


                    if (vm.checkedTrip.length == 0 || vm.checkedTrip.length == 2) {
                        data.forEach(function (item) {
                            if (item.islandHoppingYPaqueteTipo != 'BC') {
                                if (Number(item.precio.replace(",", ".")) >= price[0] && Number(item.precio.replace(",", ".")) <= price[1]) {
                                    
                                    if (item.numeroDias >= days) {
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
                    } else {
                        if (vm.checkedTrip[0] == "Galapagos Land-based tours") {
                            data.forEach(function (item) {
                                if (item.islandHoppingYPaqueteTipo == 'IH') {
                                    if (Number(item.precio.replace(",", ".")) >= price[0] && Number(item.precio.replace(",", ".")) <= price[1]) {
                                       
                                        if (item.numeroDias >= days) {
                                                galapLanBase.push(item);
                                            }
                                        }
                                    }
                            })

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

                        if (vm.checkedTrip[0] == "Tours in Mainland Ecuador") {

                            data.forEach(function (item) {
                                if (item.islandHoppingYPaqueteTipo == 'MD') {
                                    if (Number(item.precio.replace(",", ".")) >= price[0] && Number(item.precio.replace(",", ".")) <= price[1]) {

                                        if (item.numeroDias >= days) {
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

                    vm.listServices = galapLanBase

                });


            this.visibleTodos = this.listServices.slice(this.currentPage * this.pageSize, (this.currentPage * this.pageSize) + this.pageSize);
            if (this.visibleTodos.length == 0 && this.currentPage > 0) {
                this.updatePage(this.currentPage - 1);
            }

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

            $('#itinerarioModal').modal('show');
           

        },

        modalBlockIslandHop: async function () {
            document.getElementById('diplay-slide-trip').style.display = 'none';
            document.getElementById('dispo-displayIslandHopp').style.display = 'block';
            document.getElementById('modalImgIslandHopp').style.display = 'block';
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

            document.getElementById('diplay-slide-trip').style.display = 'none';
            document.getElementById('dispo-displayIslandHopp').style.display = 'block';


            if (window.innerWidth > 700) {

                document.getElementById('modalImgIslandHopp').style.display = 'block';

            } else {
                document.getElementById('modalImgIslandHopp').style.display = 'none';

            }

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

        closeModalTripEmail: function () {
            $('#itinerarioModal').modal('show');
            document.querySelector('body').classList.add('hiddenBody');
            $('#emailBarco').modal('hide');
        },
        validar_email: function (email) {
            var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return regex.test(email) ? true : false;
        },
        AprobarEmailTrip: function (nombrePaqueteTrip, Categoria) {
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
            var TipoTours = "TpoTours";

            var leadsBoars = new Object();
            leadsBoars.NombreBarco = nombrePaqueteTrip;
            leadsBoars.Itinerario = Categoria;
            leadsBoars.Noches = 0;
            leadsBoars.SalCodigo = fechaTripDesde;
            leadsBoars.Correo = Email;
            leadsBoars.Nombre = Name;
            leadsBoars.NummeroMax = NumeroPax;
            leadsBoars.Observacion = details;


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
        SendleadTrip: function (nombrePaqueteTrip, Categoria) {
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
                this.AprobarEmailTrip(nombrePaqueteTrip, Categoria);
            }

        },
    },
    computed: {
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
    },
    mounted() {
        var self = this;
        var recaptchaScript = document.createElement('script');
        recaptchaScript.setAttribute('src', '/js/funcionesCompVue.js');
        document.head.appendChild(recaptchaScript);
    }
})