//====================================Actividad Usuarios==============================================//
var paginasAndando = new Vue({
    el: '#registroActCms',
    data: {
        listPage: [],
        dataTable: null,
        id: '',
        page: '',
        url: '',
        action: '',
    },
    created: function () {
        this.cargarVistasAndando();
    },
    methods: {
        cargarVistasAndando() {
            var vm = this;
            const url = "../ActividadUsuarios";
            fetch(url)
                .then(res => res.json())
                .then(data => {
                    data.forEach(item => {
                        vm.listPage.push(item);
                    });
                    vm.listPage.forEach(page => {
                        vm.dataTable.row.add([
                            page.userName,
                            page.fistName +" "+ page.lastName,
                            page.urlPagina,
                            page.pagina,
                            page.seccion,
                            page.titulo,
                            page.dateAct,
                           
                        ]).draw(false)
                    })
                });

        }
    },
    mounted() {
        var vm = this;
        vm.dataTable = $('#RegistroAndando').DataTable({

          
        });

        //$('#pagesAndando').on('click', '.verparrafo', function () {
        //    var data = vm.dataTable.row($(this).parents('tr')).data();
        //    localStorage.setItem('TextPag', JSON.stringify(data));
        //    window.open("/PaginasWeb/CmsText", "_self");

        //});
        //$('#pagesAndando').on('click', '.verImagen', function () {
        //    var data = vm.dataTable.row($(this).parents('tr')).data();
        //    localStorage.setItem('TextPag', JSON.stringify(data[0]));
        //    window.open("/PaginasWeb/CmsImagen", "_self");
        //});
    },

});