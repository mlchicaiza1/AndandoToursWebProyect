//====================================Texto==============================================//

var cargarDatos = new Vue({
    el: '#CargarDatos',
    data: {
        listaContenidoVista: [],
        idVista: null,
        listaMetadata: [],
        listaTitulo: [],
        listaParrafo: [],
        canTitulo: [],
        active: 'active',
        show: 'active show',
        faedit: 'fa-edit',
        count: 1,
        titulometa: null,
        descripMeta: null,
        urlCanonica: null,
        idMeta: null,
    },
    created: function () {
        this.cargarContedidoTituloParrafo();
        this.cargarMetaDatos();
    },
    methods: {
        cargarContedidoTituloParrafo() {
            var vm = this;
            var hash = {};
            if (this.count > 1) {
                for (let t of vm.listaContenidoVista) {
                    CKEDITOR.instances['parrafo-' + t.idParrafo].destroy();
                    CKEDITOR.remove('parrafo-' + t.idParrafo);

                }
            }
            vm.idVista = document.getElementById('idCategoria').value;

            $.ajax({ url: "../ContenidoVistaCMS/" + vm.idVista, method: "GET" }).done(function (data) {
                vm.listaContenidoVista = data;
                for (let t of vm.listaContenidoVista) {
                    vm.listaTitulo.push({ 'titulo': t.titulo, 'id': t.idTitulo })

                }
                vm.listaTitulo = vm.listaTitulo.filter(function (current) {
                    var exists = !hash[current.id] || false;
                    hash[current.id] = true;
                    return exists;
                });


            });
            this.count++;


        },
        cargarMetaDatos() {
            var vm = this;
            //vm.idVista = JSON.parse(localStorage.getItem('TextPag'));
            vm.idVista = document.getElementById('idCategoria').value;
            $.ajax({ url: "../ContenidoMetaDatos/" + vm.idVista, method: "GET" })
                .done(function (data) {
                    vm.listaMetadata = data;
                    vm.titulometa = data[0].metaTitulo;
                    vm.descripMeta = data[0].metaDescripcion;
                    vm.urlCanonica = data[0].metaURL;
                });
            this.count++;
        },

        modificarTititulo(idTitulo, idbtnTitulo, btnguardar, btncancelar) {
            console.log(idbtnTitulo);
            $("#" + idTitulo).prop('disabled', false);
            $("#" + idbtnTitulo).removeClass('fa-edit');
            $("#" + idbtnTitulo).addClass('fa-save');
            $("#" + btnguardar).removeClass('btnGuadarCancelar');
            $("#" + btncancelar).removeClass('btnGuadarCancelar');
        },
        guardarCambioTitulo(btnguardar, btncancelar, btnTitulo, idTitulo) {
            var tituloText = $("#" + idTitulo).val();
            var titulo = new Object();
            titulo.idTitulo = idTitulo;
            titulo.contenidoTitulo = tituloText;
            $.ajax({
                type: "POST",
                url: "../CmsWebAndando/UpdateTitulo",
                data: JSON.stringify(titulo),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) { },

            });

            var RegActividad = new Object();
            RegActividad.UrlPagina = $("#url").val();
            RegActividad.Pagina = this.listaContenidoVista[0].nombreVista;
            RegActividad.Seccion = "Titulo";
            RegActividad.Titulo = tituloText;
            RegActividad.ImagenNombre = "null";
            RegActividad.Texto = true;
            RegActividad.Imagen = false;

            $.ajax({
                type: "POST",
                url: "../CmsWebAndando/RegistroActividad",
                data: JSON.stringify(RegActividad),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) { },
            });
            this.cambiarIconos(btnguardar, btncancelar, btnTitulo, idTitulo);
        },
        guardarMetaData() {
            var vm = this;
            var metaDatos = new Object();
            metaDatos.idVista = vm.idVista;
            metaDatos.metaTitulo = $("#tituloMeta").val();
            metaDatos.metaDescripcion = $("#descrMeta").val()
            metaDatos.metaURL = $("#url").val();
            console.log(metaDatos);
            $.ajax({
                type: "POST",
                url: "../CmsWebAndando/UpdateMetadata",
                data: JSON.stringify(metaDatos),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) { },

            });

            var RegActividad = new Object();
            RegActividad.UrlPagina = $("#url").val();
            RegActividad.Pagina = this.listaContenidoVista[0].nombreVista;
            RegActividad.Seccion = "MetaDatos";
            RegActividad.Titulo = $("#tituloMeta").val();
            RegActividad.ImagenNombre = "null";
            RegActividad.Texto = true;
            RegActividad.Imagen = false;

            $.ajax({
                type: "POST",
                url: "../CmsWebAndando/RegistroActividad",
                data: JSON.stringify(RegActividad),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) { },

            });
        },
        cancelarCambios(btnguardar, btncancelar, btnTitulo, idTitulo) {
            this.cambiarIconos(btnguardar, btncancelar, btnTitulo, idTitulo);
            this.cargarContedidoTituloParrafo();

        },
        guardarParrafo(idParrafo, idTitulo) {
            var vm = this;
            var field_value = CKEDITOR.instances[idParrafo].getData();
            var idparrafo = idParrafo.split('-');
            var parrafo = new Object();
            parrafo.idTitulo = idTitulo;
            parrafo.idParrafo = idparrafo[1];
            parrafo.contenidoParrafo = field_value;

            $.ajax({
                type: "POST",
                url: "../CmsWebAndando/UpdateParrafo",
                data: JSON.stringify(parrafo),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) { },
            });

            var titulo = this.listaTitulo.filter(function (item) {
                if (item.id == idTitulo) {
                    return item.titulo;
                }
            });
            var RegActividad = new Object();
            RegActividad.UrlPagina = $("#url").val();
            RegActividad.Pagina = this.listaContenidoVista[0].nombreVista;
            RegActividad.Seccion = "Parrafo";
            RegActividad.Titulo = titulo[0].titulo;
            RegActividad.ImagenNombre = "null";
            RegActividad.Texto = true;
            RegActividad.Imagen = false;


            $.ajax({
                type: "POST",
                url: "../CmsWebAndando/RegistroActividad",
                data: JSON.stringify(RegActividad),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                }
            });
        },


        cancelarParrafo() {
            this.cargarContedidoTituloParrafo();

        },
        cambiarIconos(btnguardar, btncancelar, btnTitulo, idTitulo) {
            $("#" + idTitulo).prop('disabled', true);
            $("#" + btnguardar).addClass('btnGuadarCancelar');
            $("#" + btncancelar).addClass('btnGuadarCancelar');
            $("#" + btnTitulo).removeClass('fa-save');
            $("#" + btnTitulo).addClass('fa-edit');
        }

    },

    mounted: function () {
    },
    updated() {
        var vm = this;
        for (let t of vm.listaContenidoVista) {
            CKEDITOR.replace('parrafo-' + t.idParrafo);
        }

    }
});