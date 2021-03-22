var paginasAndando = new Vue({
    el: '#paginasAndandoWeb',
    data: {
        listPage: [],
        dataTable: null,
        id: '',
        page: '',
        url: '',
        action: '',
        categoria: '',
    },
    created: function () {
        this.cargarVistasAndando();
    },
    methods: {

        //getIdPage: function (event) {
        //    var id = event.target.id;
        //    console.log(id);
        //    localStorage.setItem('TextPag', id);
        //},
        //getCategoria: function (event) {
        //    var id = [];
        //    id.push(event.target.id);
        //    localStorage.setItem('categoria', JSON.stringify(id));
        //},

        cargarVistasAndando() {
            var vm = this;

            vm.categoria = document.getElementById('categoria').value;


            const url = "../VistaAndando/" + vm.categoria;
            fetch(url)
                .then(res => res.json())
                .then(data => {
                    data.forEach(item => {
                        vm.listPage.push(item);
                    });
                    vm.listPage.forEach(page => {
                        vm.dataTable.row.add([
                            page.idVista,
                            page.nombreVista,
                            page.urlVista,
                            '<button  type="button" class="verparrafo btn btn-block btn-outline-primary" style="width:62px;display:inline;margin-top:0;margin-right:10px" >Text</button>'
                            + '<button  type="button" class="verImagen btn btn-block btn-outline-primary" style="width:77px;display:inline;margin-top:0" >Image</button>',
                        ]).draw(false)
                    })
                });

        }
    },
    mounted() {
        var vm = this;
        vm.dataTable = $('#pagesAndando').DataTable({});

        $('#pagesAndando').on('click', '.verparrafo', function () {
            var data = vm.dataTable.row($(this).parents('tr')).data();
            window.open("../PaginasWeb/CmsText?id=" + data[0], "_self");

        });
        $('#pagesAndando').on('click', '.verImagen', function () {
            var data = vm.dataTable.row($(this).parents('tr')).data();
            window.open("../PaginasWeb/CmsImagen?id=" + data[0], "_self");
        });
    },

});