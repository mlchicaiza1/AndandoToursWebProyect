var paginasAndandoMenu = new Vue({
    el: '#menu1',
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
        
    },
    methods: {

        getIdPageMenu: function (event) {
            var id = [];
            id.push(event.target.id);
            console.log(event.target.id);
            localStorage.setItem('TextPag', JSON.stringify(id));
        },
        getCategoriaMenu: function (event) {
            var id = [];
            id.push(event.target.id);
            console.log(event.target.id);
            localStorage.setItem('categoria', JSON.stringify(id));
        },

       
    },
   

});

var paginasAndando = new Vue({
    el: '#paginasAndandoWeb',
    data: {
        listPage: [],
        dataTable: null,
        id:'',
        page: '',
        url: '',
        action: '',
        categoria:'',
    },
    created: function () {
        this.cargarVistasAndando();
    },
    methods: {
       
        getIdPage: function (event) {
            var id = event.target.id;
            console.log(id);
            localStorage.setItem('TextPag', id);
        },
        getCategoria: function (event) {
            var id = [];
            id.push(event.target.id);
            localStorage.setItem('categoria', JSON.stringify(id));
        },

        cargarVistasAndando() {
            var vm = this;
            
            vm.categoria = JSON.parse(localStorage.getItem('categoria'));
            
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
                            '<button  type="button" class="verparrafo btn btn-block btn-outline-primary" style="width:62px;display:inline;margin-top:0;margin-right:10px" >Texto</button>'
                            + '<button  type="button" class="verImagen btn btn-block btn-outline-primary" style="width:77px;display:inline;margin-top:0" >Imagen</button>',
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
            localStorage.setItem('TextPag', JSON.stringify(data[0]));
            window.open("../PaginasWeb/CmsText", "_self");
            
        });
        $('#pagesAndando').on('click', '.verImagen', function () {
            var data = vm.dataTable.row($(this).parents('tr')).data();
            localStorage.setItem('TextPag', JSON.stringify(data[0]));
            window.open("../PaginasWeb/CmsImagen", "_self");
        });
    },

});


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
            vm.idVista = JSON.parse(localStorage.getItem('TextPag'));
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
                console.log(vm.listaTitulo);
            });
            this.count++;
        },
        cargarMetaDatos() {
            var vm = this;
            vm.idVista = JSON.parse(localStorage.getItem('TextPag'));
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
                success: function (response) {
                    if (response != null) {
                        alert("Name : " + response.idparrafo);
                    } else {
                        alert("Something went wrong");
                    }
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
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
                success: function (response) {

                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
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
                success: function (response) {
                    if (response != null) {
                        alert("Name : ");
                    } else {
                        alert("Something went wrong");
                    }
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
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
                success: function (response) {

                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
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
                success: function (response) {
                    if (response != null) {
                        alert("Name : " + response.idparrafo);
                    } else {
                        alert("Something went wrong");
                    }
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });

            //IdUsuario,UrlPagina,Pagina,Seccion,Titulo,ImagenNombre,Texto,Imagen
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
                   
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
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
        var recaptchaScript = document.createElement('script');
        recaptchaScript.setAttribute('src', '../ckeditor/ckeditor.js');
        document.head.appendChild(recaptchaScript);
        
    },
    updated() {
        var vm = this;
            for (let t of vm.listaContenidoVista) {
                CKEDITOR.replace('parrafo-' + t.idParrafo);
            }
        
        
    }
});
//====================================IMAGENES==============================================//
var imagen = new Vue({
    el: "#cmsImagenes",
    data: {
        imgGestion: [],
        caruActivo: 'owl-item active',
        caruNoActiv: 'owl-item',
        selectFile: null,
        files: new FormData(),
        nuevaImage: null,
        nombreImg: [],
        nombre: "",
        tamanoImg: "",
        extencion: "",
        ruta: "",
        idImg: 0,
        urlPrev: null,
        urlCompleto: [],
        urlUnida: "",
        faedit: 'fa-edit',
    },
    created: function () {
        this.getImgVista();
    },
    methods: {
        getImgVista: function () {
            var vm = this;
            var idVista = localStorage.getItem('TextPag');
            
            
            console.log( idVista);
            var owl = $('.owl-carousel');
            owl.trigger('destroy.owl.carousel');
            $.ajax({ url: "../ContenidoImagenes/" + idVista, method: "GET" }).done(function (data) {
                vm.imgGestion = data;
                console.log(data);
            });
        },
        getNombre: function () {
            var vm = this;
            var idVista = localStorage.getItem('TextPag');
            $.ajax({ url: "../ContenidoImagenes/" + idVista, method: "GET" }).done(function (data) {
                vm.imgGestion = data;
            });
        },
        subirImagen: function () {
            var files = $("#files").val();
            if (files != "") {
                alert("Agregado Correctamente");
            }
            var ruta = $("#ruta").val();
            var nombreDefecto = $("#nombreDefecto").val();
            var name = $("#name").val();
            var status = "";
            //$.ajax({ url: "/CmsWebAndando/ImageUploadInsert/" + files + name + ruta + nombreDefecto, method: "GET" }).done(function (data) {
                 
            //});
            console.log(files);
        },
        onFileSelected(event) {
            const file = event.target.files[0];
            this.urlPrev = URL.createObjectURL(file);
           
        },
        modificarNombre(idImagen, idbtnNombre, btnguardar, btncancelar) {
            console.log(idbtnNombre);
            $("#" + idImagen).prop('disabled', false);
            $("#" + idbtnNombre).removeClass('fa-edit');
            $("#" + idbtnNombre).addClass('fa-save');
            $("#" + btnguardar).removeClass('btnGuadarCancelar');
            $("#" + btncancelar).removeClass('btnGuadarCancelar');
        },
        guardarCambioNombre(btnguardar, btncancelar, btnNombre, idImagen) {
            var nombreText = $("#" + idImagen).val();
            console.log(nombreText);
            console.log(idImagen);
            $.post("../CmsWebAndando/UpdateNombreImg", { nombreImagen : nombreText, idImagen : idImagen }, 
                function (returnedData) {
                    alert("Nombre cambiado correctamente");
                }).fail(function () {
                    console.log("error");
             });
            var URLactual = window.location.href;
            var RegActividad = new Object();
            RegActividad.UrlPagina = URLactual;
            RegActividad.Pagina = nombreText;
            RegActividad.Seccion = "Imagen Nombre";
            RegActividad.Titulo = "null";
            RegActividad.ImagenNombre = nombreText;
            RegActividad.Texto = true;
            RegActividad.Imagen = false;

            $.ajax({
                type: "POST",
                url: "../CmsWebAndando/RegistroActividad",
                data: JSON.stringify(RegActividad),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
            this.cambiarIconos(btnguardar, btncancelar, btnNombre, idImagen);
        },
        cancelarCambios(btnguardar, btncancelar, btnNombre, idImagen) {
            this.cambiarIconos(btnguardar, btncancelar, btnNombre, idImagen);
            this.getNombre();

        },
        cambiarIconos(btnguardar, btncancelar, btnNombre, idImagen) {
            $("#" + idImagen).prop('disabled', true);
            $("#" + btnguardar).addClass('btnGuadarCancelar');
            $("#" + btncancelar).addClass('btnGuadarCancelar');
            $("#" + btnNombre).removeClass('fa-save');
            $("#" + btnNombre).addClass('fa-edit');
        },
        getModal: function (event) {
            var vm = this;
            var idVista = localStorage.getItem('TextPag');
            var datos = [];
            var imgSelect = event.target.id;
            vm.urlUnida = "";
            vm.urlCompleto.length = 0;
            $.ajax({ url: "../ContenidoImagenes/" + idVista, method: "GET" }).done(function (data) {
                datos = data;
                for (let dat of datos) {
                    if (dat.idImagen == imgSelect) {
                        vm.nombreImg.push(dat);
                        vm.nombre = dat.nombreImagen;
                        vm.tamanoImg = dat.tamanoImagen;
                        vm.idImg = dat.idImagen;
                        var url = dat.urlImagen.split("/");
                        console.log(url);
                        for (var i = 0; i < url.length - 1; i++) {
                            if (url[i] != "..") { 
                                vm.urlUnida = vm.urlUnida + "\\" + url[i];
                            }
                        }
                        vm.urlCompleto.push(vm.urlUnida);
                        console.log(vm.urlCompleto);
                    }
                }
            });
            $('#imagenModal').modal('show');
        },
        fileChange(event) {
            var img = this;
            img.selectFile = event.target.files[0];
            const fd = new FormData();
            fd.onload = event => {
                img.nuevaImage = event.target.result;
                console.log(img.nuevaImage);
            }
        },
        async startUpload() {
            const fd = new FormData();
            fd.append('image', this.selectFile, this.selectFile.name);
            await axios.post('../CmsWebAndando/ImageUploadInsert/', fd).then(res => {
                console.log(res);
            });
        },
    },
    mounted: function () {
        let recaptch = document.createElement('script');
        recaptch.setAttribute('src', '../lib/owl.carousel.js');
        document.head.appendChild(recaptch);
        var owl1 = $('#myCarousel5');
        // Go to the next item
        $('.owl-next').click(function () {
            owl1.trigger('next.owl.carousel');
        });
        // Go to the previous item
        $('.owl-prev').click(function () {
            owl1.trigger('prev.owl.carousel', [300]);
        });
    },
    updated() {
        var vm = this;
        if (vm.imgGestion.length) {
            console.log(vm.imgGestion);
            vm.$nextTick(() => {
                var owl = $('.owl-carousel');
                owl.owlCarousel({
                    items: 4,
                    loop: true,
                    margin: 10,
                    rewind: true,
                    autoplay: true,
                    autoplayTimeout: 900,
                    autoplayHoverPause: true,
                    URLhashListener: true,
                    startPosition: 'URLHash',
                    responsiveClass: true,
                    responsive: {
                        0: {
                            items: 2,
                            slideBy: 3,
                            nav: true
                        },
                        600: {
                            items: 2,
                            nav: false
                        },
                        1000: {
                            items: 3,
                            nav: true,
                            loop: false,
                            margin: 50
                        }
                    }
                });
            });
        }
    },
});
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