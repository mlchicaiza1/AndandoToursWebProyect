//=================FILTRO VISITOR SITE===================//
var filtroVisitorIsland = new Vue({
    el: "#filtroVisitor",
    data: {
        island: [],
        allVisitor: [],
        visit: [],
        VisitorIsland: [],
        visitWild: [],
        IdIsland: null,
        IdAnimal: null,
        filtroWildLife: [],
        idIslandSelect: null,
    },
    created: function () {
        this.getIsland();
        this.getAllVisitor();
    },
    methods: {
        getAllVisitor: function () {
            var isl = this;
            $.ajax({ url: "/AllVisitor", method: "GET" }).
                done(function (data) {
                    isl.allVisitor = data;
                });
        },
        getIsland: function () {
            var isl = this;
            $.ajax({ url: "/Island1", method: "GET" }).
                done(function (data) {
                    isl.island = data;
                });
        },
        getIsld: function (event) {
            var isl = this;
            isl.idIslandSelect = event.currentTarget.id;
            $.ajax({ url: "/VisitSiteIsland/" + event.currentTarget.id, method: "GET" })
                .done(function (data) {
                    isl.VisitorIsland = data;

                    var valIsland = isl.island.filter(function (elem) {
                        if (elem.idIsland == isl.idIslandSelect)
                            return elem;
                    });
                    isl.IdIsland = valIsland[0].idIsland;
                    isl.getWildlife();
                });
            $('.applyIsland').parents('.dropdown').find('button.dropdown-toggle').dropdown('toggle')
        },

        getWildlife: function () {
            var wild = this;
            $.ajax({ url: "/Wildlife/" + wild.IdIsland, method: "GET" })
                .done(function (data) {
                    wild.filtroWildLife = data;
                });
        },
        onClickWildlife: function (event) {
            var wild = this;
            var idWildlifeSelect = event.currentTarget.id;
            this.VisitorIsland = [];
            this.allVisitor = [];
            console.log("wildlife: " + idWildlifeSelect);
            $.ajax({ url: "/Animals/" + event.currentTarget.id + "/" + wild.idIslandSelect, method: "GET" })
                .done(function (data) {
                    wild.visitWild = data;
                    console.log("visitor: " + data);
                });
            $('.applyWildLife').parents('.dropdown').find('button.dropdown-toggle').dropdown('toggle')
        },

    }
});
