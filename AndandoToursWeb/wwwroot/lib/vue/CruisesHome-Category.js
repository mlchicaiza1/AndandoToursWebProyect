var CruisesCategoria = new Vue({
    el: "#CruisesCategoria",
    data: {
        submenu: [],
        link: false,
        urlPagina: "",
        comparison: true,
        comparisonTit: null,
        privateChartersTex: "Private Charters",
        luxuryCruisesText: "Luxury Cruises",
        privateChartersBtn: true,
        luxuryCruisesbtn: true,
        urlBtnCategoria: "../cruises/yacht-charters",
        linkExpe: "",
        linkcomparison: "",
        parrafoLuxury: false,
        parraforCategoria: true,
        parraforCategoriaLuxuryBudget: true,
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
            if (res.length == 2) {
                switch (res[1]) {
                    case "galapagos-cruises":
                        vm.submenu = ["Ship Types", "9 Best Cruises", "Cruise Info"];
                        break;
                    case "galapagos-luxury-cruise":
                        vm.submenu = ["Luxury Boats", "Luxury Experience", "Comparison"];
                        vm.luxuryCruisesbtn = false;
                        vm.linkExpe = "Experience";
                        vm.linkcomparison = "luxuryComp";
                        vm.parrafoLuxury = true;
                        vm.parraforCategoria = false;
                        vm.parraforCategoriaLuxuryBudget = false;
                        break;
                    case "sailing-cruises":
                        vm.submenu = ["Sailing Boats", " Private Charters", "The Experience"];
                        vm.luxuryCruisesbtn = false;
                        vm.linkExpe = "ShipTypes-105";
                        vm.linkcomparison = "Experience";
                        vm.widthMov = 78.08;
                        break;

                }
            }

            if (res.length == 3) {
                switch (res[2]) {
                    case "galapagos-catamarans":
                        vm.submenu = ["Top Catamarans", "", "The Experience"];
                        vm.linkcomparison = "comparison";
                        vm.marginleft = 27;
                        vm.widthMov = 73;
                        vm.marginleftMov = 40;
                        break;
                    case "high-end":
                        vm.submenu = ["High-End Cruises", "", "Comparison"];
                        vm.luxuryCruisesbtn = false;
                        vm.linkcomparison = "comparison";
                        vm.marginleft = 27;
                        vm.widthMov = 150;
                        vm.marginleftMov = 15;
                        break;
                    case "mid-range-cruises":
                        vm.submenu = ["Cruises", "More Options", "Comparison"];
                        vm.privateChartersTex = "Best way to travel";
                        vm.urlBtnCategoria = "../blog/best-way-to-travel-galapagos";
                        vm.luxuryCruisesbtn = false;
                        vm.linkExpe = "ShipTypes-105";
                        vm.linkcomparison = "Experience";
                        vm.widthMov = 61;
                        break;
                    case "budget":
                        vm.submenu = ["Top budget ships", "The Experience", "Comparison"];
                        vm.privateChartersTex = "Check out our Land-Based Tours";
                        vm.urlBtnCategoria = "../tours/island-hopping/";
                        vm.luxuryCruisesbtn = false;
                        vm.linkExpe = "Experience";
                        vm.linkcomparison = "comparisonbudget";
                        vm.parraforCategoriaLuxuryBudget = false;
                        vm.comparison = false;
                        vm.widthMov = 90;
                        break;
                    case "galapagos-yachts":
                        vm.submenu = ["Top 3 Yachts", "Yacht Charters", "The Experience"];
                        vm.linkExpe = "ShipTypes-88";
                        vm.linkcomparison = "YachExperience";
                        vm.widthMov = 76;
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