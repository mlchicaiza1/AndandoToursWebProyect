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
            //var idVista = localStorage.getItem('TextPag');

            var idVista = document.getElementById('idImage').value;
            console.log(idVista)
            var owl = $('.owl-carousel');
            owl.trigger('destroy.owl.carousel');
            $.ajax({ url: "../ContenidoImagenes/" + idVista, method: "GET" }).done(function (data) {
                vm.imgGestion = data;

            });
        },
        getNombre: function () {
            var vm = this;
            var idVista = document.getElementById('idImage').value;
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
            $.post("../CmsWebAndando/UpdateNombreImg", { nombreImagen: nombreText, idImagen: idImagen },
                function (returnedData) {
                    //alert("Nombre cambiado correctamente");
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
            var idVista = document.getElementById('idImage').value;
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
        //async startUpload() {
        //    const fd = new FormData();
        //    fd.append('image', this.selectFile, this.selectFile.name);
        //    await axios.post('../CmsWebAndando/ImageUploadInsert/', fd).then(res => {
        //        console.log(res);
        //    });
        //},
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