/*-----------Daili Tours---------*/
var DailiToursIsland = new Vue({
    el: "#DailiToursIsland",
    data: {
        submenu: [],
        link: false,
        urlPagina: "",
        linkIsland: '',
        nomIsland: '',
        linkIsland_1: '',
        nomIsland_1: '',
        marginleft: 30,
        widthMov: 0,
        marginleftMov: 0
    },
    created: function () {
        this.CargarInformacionVista();
    },
    methods: {
        CargarInformacionVista() {
            var vm = this;
            var vistaUrl = window.location;
            var res = vistaUrl.pathname.split("/");
            if (res.length == 3) {
                switch (res[2]) {
                    case "isabela":
                        vm.submenu = ["Top Catamarans", "", "The Experience"];
                        vm.nomIsland = 'Santa Cruz Tours';
                        vm.linkIsland = '/tours/santa-cruz';
                        vm.nomIsland_1 = 'San Cristobal Tours';
                        vm.linkIsland_1 = '/tours/san-cristobal';
                        break;
                    case "san-cristobal":
                        vm.submenu = ["High-End Cruises", "", "Comparison"];
                        vm.nomIsland = 'Santa Cruz Tours';
                        vm.linkIsland = '/tours/santa-cruz';
                        vm.nomIsland_1 = 'Isabela Tours';
                        vm.linkIsland_1 = '/tours/isabela';
                        break;
                    case "santa-cruz":
                        vm.submenu = ["Cruises", "More Options", "Comparison"];
                        vm.nomIsland = 'San Cristobal Tours';
                        vm.linkIsland = '/tours/san-cristobal';
                        vm.nomIsland_1 = 'Isabela Tours';
                        vm.linkIsland_1 = '/tours/isabela';
                        break;
                }
            }

        },
        select: function (event) {
            targetId = event.currentTarget.id;
            localStorage.setItem('infoBarco', JSON.stringify(targetId));
        },
    },
});
var island = new Vue({
    el: "#island",
    data: {
        selectedValue: 2,
        island: [],
        dailyTour: [],
        IdIsland: null,
        idDaily: null,
        Selectisland: 'Select an island',
        SelectTour: 'Select a daily tour',
        btnTextTour: 'Island Details',
        imgIsland: "../images/Home/slide.jpg",
        parrafoIsland: null,
        linkIsland: null,
        selected: undefined,
        checkColor: "#787778",
        paddingleft: 15,
        paddingright: 25,
        paddingtop: 0,
        paddingbottom: 0,
        colorDailyTour: "#33333380",
        displayIsabela: 'none',
        displaySanCristobal: 'none',
        displaySantaCruz: 'none',
        displayIsland: '',
        displayDailyTours: 'none',
    },
    created: function () {
        this.getIsland();
        this.getDailytour();
    },
    computed: {

    },
    methods: {
        getIsland: function () {
            var isl = this;
            $.ajax({ url: "/Island", method: "GET" }).
                done(function (data) {
                    isl.island = data;
                });
        },
        getDailytour: function () {
            var daily = this;
            $.ajax({ url: "/DailyTour/" + daily.IdIsland, method: "GET" })
                .done(function (data) {
                    daily.dailyTour = data;
                });
        },
        onClickIsland: function (event) {
            var isl = this;
            var idIsland = event.currentTarget.id;
            this.colorDailyTour = "#000000";
            this.displayIsland = 'block';
            this.displayDailyTours = 'none';
            this.SelectTour = 'Select a daily tour';
            this.btnTextTour = 'Island Details';
            $('#menuDailytours').removeAttr('disabled');

            var valIsland = isl.island.filter(function (elem) {
                if (elem.idIsland == idIsland)
                    return elem;
            });
            switch (idIsland) {
                case "1":
                    isl.displayIsabela = 'inline-flex';
                    isl.Selectisland = 'Selected ' + valIsland[0].nombreIsland;
                    isl.displaySanCristobal = 'none';
                    isl.displaySantaCruz = 'none';
                    break;
                case "2":
                    isl.displaySanCristobal = 'inline-flex';
                    isl.Selectisland = ' ' + valIsland[0].nombreIsland;
                    isl.displaySantaCruz = 'none';
                    isl.displayIsabela = 'none';
                    break;
                case "3":
                    isl.displaySantaCruz = 'inline-flex';
                    isl.Selectisland = 'Selec ' + valIsland[0].nombreIsland;
                    isl.displaySanCristobal = 'none';
                    isl.displayIsabela = 'none';
                    break;

            }
            isl.imgIsland = valIsland[0].imagenIsland;
            isl.parrafoIsland = valIsland[0].descripcionIsland;
            isl.linkIsland = valIsland[0].linkIsland;
            isl.IdIsland = valIsland[0].idIsland;
            isl.paddingtop = 10;
            isl.paddingbottom = 10;
            this.selected = undefined;
            this.getDailytour();
            $('.applyIsland').parents('.dropdown').find('button.dropdown-toggle').dropdown('toggle')
        },
        onClickDailyTours: function (event) {
            var daily = this;
            this.displayIsland = 'none';

            if (window.innerWidth > 700) {

                this.displayDailyTours = 'block';
            } else {
                this.displayDailyTours = 'none';
            }

           
            this.SelectTour = event.currentTarget.id;
            this.btnTextTour = ' View Tour';
            var valDaily = daily.dailyTour.filter(function (elem) {
                if (elem.nombreDailyTour == event.currentTarget.id)
                    return elem;
            });
            daily.imgIsland = valDaily[0].imagenDailyTour;
            daily.parrafoIsland = valDaily[0].descripcionDailyTour;
            daily.linkIsland = valDaily[0].linkDailytour;
            daily.paddingtop = 10;
            daily.paddingbottom = 10;
            $('.applyDailyTours').parents('.dropdown').find('button.dropdown-toggle').dropdown('toggle')
        },
    },
}); 