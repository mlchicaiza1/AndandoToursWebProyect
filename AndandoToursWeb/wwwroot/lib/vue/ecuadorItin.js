var mapaDatos = new Vue({
    el: "#mapaFiltros",
    data: {
        mapaData: [],
        mapaGale: [],
        datosModal: [],
    },
    created: function () {
        this.getMapa();
    },
    methods: {
        getMapa: function () {
            var vm = this;
        },
        onClickMap: function (event) {
            var fil = this;
            var select = event.target.value;
            fil.mapaData = [];
            $.ajax({ url: "/GetMapaEcItiner", method: "GET" }).done(function (data) {
                for (let elem of data) {
                    if (elem.region == select) {
                        fil.mapaData.push(elem);
                    }
                    if (select == "All") {
                        fil.mapaData = data;
                    }
                }
            });
            document.getElementById('filtroHoteles').style.display = 'block';
            document.getElementById('descripcionHoteles').style.display = 'none';
        },
        getGaleriaEc: function (event) {
            var fil = this;
            var select = event.currentTarget.id;
            fil.mapaGale = [];
            $.ajax({ url: "/GetMapaEcItiner", method: "GET" }).done(function (data) {
                for (let elem of data) {
                    if (elem.idMapaHotel == select) {
                        fil.mapaGale.push(elem);
                    }
                }
            });
            $('#galeEcModal').modal('show');
        },
        closeModalgaleEc() {
            console.log("MODAL GALERIA")
            $('#galeEcModal').modal('hide');
            document.querySelector('body').classList.remove('hiddenBody');

        },
        mostrarLinkFiltros() {
            document.getElementById('filtrosHotel').style.display = 'block';
            document.getElementById('linkMapa').style.display = 'block';
            document.getElementById('mapa').style.display = 'none';
            document.getElementById('linkfiltro').style.display = 'none';
        },
        mostrarLinkMapa() {
            document.getElementById('filtrosHotel').style.display = 'none';
            document.getElementById('linkMapa').style.display = 'none';
            document.getElementById('mapa').style.display = 'block';
            document.getElementById('linkfiltro').style.display = 'block';
        },
    },
    mounted: function () {
        let recaptch = document.createElement('script');
        recaptch.setAttribute('src', '/js/mapa.js');
        document.head.appendChild(recaptch);
    },
    computed: {

        datModal: function() {
            var dim = this;
            var idHotelMapLocal = localstorage.getItem("idHotelMap");
            console.log(idHotelMapLocal);
            $.ajax({ url: "/GetMapaEcItiner", method: "GET" }).done(function (data) {
                for (let elem of data) {
                    if (elem.idMapaHotel == idHotelMapLocal) {
                        dim.datosModal.push(elem);

                        return this.datosModal;
                    }
                }
                console.log(dim.datosModal);
            });
        },
    },
});

var datosSelect = new Vue({
    el: "#datosSelect",
    data: {
        mapaData: [],
        mapaGale: [],
        datosModal: [],
        selectCategoria:[],
        select: [],
        titulo: "",
        tituloItinerario: "",
    },
    created: function () {
        this.loadCategoria
    },
    methods: {
        onClickCategoria: function (event,idVista) {
            var fil = this;
            var vista = idVista;
            
            switch (vista) {
                case 2050:
                    fil.titulo = "Amazon Tours Ecuador"
                    
                    fil.select = event;
                    break;
                case 2051:
                    fil.titulo = "Cloud Forest"
                    fil.select = event;
                    break;
                case 3052:
                    fil.titulo = "Avenue of Volcanoes"
                    fil.select = event;
                    break;
                case 3053:
                    fil.titulo = "Austral paths"
                    fil.select = event;
                    break;
                case 3054:
                    fil.titulo = "North of Ecuador"
                    fil.select = event;
                    break;
            }
            document.getElementById("BugetDetermi").disabled = true;     
            $("#formEcModal").modal('show');
        },

        loadCategoria: function(idVista) {
            var fil = this;
            var vista = idVista;
            switch (vista) {
                case 2050:
                    fil.titulo = "Amazon Tours Ecuador"
                    fil.selectCategoria = [{ categoria: "Hamadryade" }, { categoria: "Sacha: 4 Days" }, { categoria: "Sacha: 5 Days" }, { categoria: "Napo: 4 Days" }, { categoria: "Napo: 5 Days" }];
                    console.log(fil.titulo);
                    break;
                case 2051:
                    fil.titulo = "Cloud Forest"
                    fil.selectCategoria = [{ categoria: "Maquipucuna" }, { categoria: "Adventure Tour" }];
                    break;
                case 3052:
                    fil.titulo = "Avenue of Volcanoes"
                    fil.selectCategoria = [{ categoria: "3-Day Itinerary" }, { categoria: "4-Day Itinerary" }, { categoria: "6-Day Itinerary" }];
                    break;
                case 3053:
                    fil.titulo = "Austral paths"
                    fil.selectCategoria = [{ categoria: "3-Day Itinerary" }, { categoria: "4-Day Itinerary A" }, { categoria: "4-Day Itinerary B" }];
                    break;
                case 3054:
                    fil.titulo = "North of Ecuador"
                    fil.selectCategoria = [{ categoria: "Magical North: 3 Days" }, { categoria: "Magical North: 4 Days" }, { categoria: "Hidden Jewels: 4 Days" }];
                    break;
            }
        },

        onClickCategoriaForm1(idVista){

            this.loadCategoria(idVista)
            $("#formEcModalCabecera").modal('show');
        },
    }
});