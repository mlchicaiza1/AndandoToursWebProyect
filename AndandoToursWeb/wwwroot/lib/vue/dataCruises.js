var tripFinderMainMenu = new Vue( {
    el: "#tripFinder",
    data: {
        contTrip: "",
        cont: "",
        triptype: 'Trip type',
        checkColor: "#787778",
        checkedTrip: [],
        object: {
            GalapCruisesType: 'Galapagos Cruises',
            GalapLandType: 'Galapagos Land-based tours',
            ToursMainlandType: 'Tours in Mainland Ecuador'
        },
        maintripType: [{ labeltrip: 'Galapagos Cruises' }
            , { labeltrip: 'Galapagos Land-based tours' }, { labeltrip: 'Tours in Mainland Ecuador' }],
        travelersTot: "Travelers",
        count: 2,
        count1: 0,
        price: "Price range",
        dateTrip: 'Date',
        
        countLen: 0,
        trip: [],
        menu: '',

        //Resettle date
        selectDate_1: null,
        selectDate: null,
        selectDateModal: null,
        datePickerSelect: [],
        datePickerSelect_1: [],
        contdatePicker_1: 0,
        contdatePicker_2: 0,

    },
    created: function() {

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
        filterDate() {
            if (this.dateTrip == "") {
                return "Date";
            } else {
                return this.dateTrip;
            }
        },
    },
    methods: {
        checkTripType(event) {
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
            console.log (this.checkedTrip)
        },
        moreTravelersAdu: function (event) {
            this.count++;
            this.travelersTot = "Travelers " + (this.count + this.count1);
        },
        minusTravelersAdu: function (event) {
            if (this.count > 0) {
                this.count--;
                this.travelersTot = "Travelers " + (this.count + this.count1);
            }
        },
        moreTravelersChild: function (event) {
            this.count1++;
            this.travelersTot = "Travelers " + (this.count + this.count1);
        },
        minusTravelersChild: function (event) {
            if (this.count1 > 0) {
                this.count1--;
                this.travelersTot = "Travelers " + (this.count + this.count1);
            }
        },
        resettleTravel: function () {
            this.count = 2;
            this.count1 = 0;
            this.travelersTot = "Travelers ";
        },
        applyTravel: function () {
            if (this.travelersTot == "Travelers") {
                
                this.travelersTot = "Travelers " + (this.count);
            }
            $('.applyTravelers').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        priceRange: function (event) {
            this.price = document.getElementById('amount').value;
        },
        price: function () {
            this.price = document.getElementById('amount').value;
        },
        resettlePric: function () {
            this.price = "Price range";
        },
        applyPrice: function (event) {
            this.price = document.getElementById('amount').value;
            $('.applyPrice').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        moreLenght: function (event) {
            this.countLen++;
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
            $('.applyLenght').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        resettleDate: function () {
            this.dateTrip = "Date";
            this.selectDate_1 = null
            this.selectDate = null
            this.datePickerSelect = []
            this.datePickerSelect_1 = []
            this.contdatePicker_1 = 0;
            this.contdatePicker_2 = 0;
            $('#datepickerFilter').datepicker('update');
            $('#datepickerFilter1').datepicker('update');
        },
        applyDate: function (event) {
            $('.applyDate').parents('.btn-group').find('button.dropdown-toggle').dropdown('toggle')
        },
        getDisponibilidad: function () {
            var vm = this;
            var datosFiltro = limpiarDatos(vm.travelersTot, vm.price, vm.dateTrip);
            vm.trip = [this.checkedTrip, datosFiltro[0][1], datosFiltro[1], datosFiltro[2], vm.countLen, datosFiltro[3]];
            localStorage.setItem('datosTrip', JSON.stringify(vm.trip));
        },
        getmonth: function() {
           
        }

    },
    mounted: function () {
        var self = this;

        var recaptchaScript = document.createElement('script');
        recaptchaScript.setAttribute('src', '/js/funcionesCompVue.js');
        document.head.appendChild(recaptchaScript);


        $('#datepickerFilter').on('changeDate', function () {
            self.selectDate = $('#datepickerFilter').data('datepicker').getFormattedDate('M-yy')
            self.dateTrip = self.selectDate;

            if (self.selectDate.split(',')[self.contdatePicker_1] !== undefined) {
                self.datePickerSelect.push(self.selectDate.split(',')[self.contdatePicker_1]);
                self.contdatePicker_1++;
            }
            
            if (self.datePickerSelect.length == 2 && self.datePickerSelect_1.length==1) {
                $('#datepickerFilter').datepicker('update');
                $('#datepickerFilter1').datepicker('update');
                self.datePickerSelect_1 = [];
                self.contdatePicker_2 = 0;
                self.datePickerSelect.splice(1, 0, self.datePickerSelect[1]);
                var f = self.datePickerSelect[1].split("-");
                $('#datepickerFilter').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
            }
            if (self.datePickerSelect.length == 1 && self.datePickerSelect_1.length == 2) {
                $('#datepickerFilter').datepicker('update');
                $('#datepickerFilter1').datepicker('update');
                self.datePickerSelect_1 = [];
                self.contdatePicker_2 = 0;
                var f = self.datePickerSelect[0].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#datepickerFilter').datepicker('update', new Date());
                } else {
                    $('#datepickerFilter').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
            }
            if (self.datePickerSelect.length == 0 && self.datePickerSelect_1.length == 2) {
                $('#datepickerFilter1').datepicker('update');
                self.datePickerSelect_1 = [];
                self.contdatePicker_2 = 0;
                self.dateTrip = self.selectDate;
            }
            if (self.datePickerSelect.length == 1 && self.datePickerSelect_1.length == 1) {
                if (self.selectDate_1.split(',').length == 2) {
                    self.dateTrip = self.selectDate + "," + self.selectDate_1.split(',')[1];
                } else {
                    self.dateTrip = self.selectDate + "," + self.selectDate_1;
                } 
                if (self.selectDate_1.split(',').length ==3) {
                    self.dateTrip = self.selectDate + "," + self.selectDate_1.split(',')[2];
                }    
            }
            if (self.selectDate_1 == '' && self.selectDate=='') {
                self.dateTrip = "Date";

            }
            if (self.selectDate.split(',').length == 2) {
                var f = self.selectDate.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateTrip = f[1] + "," + f[0];
                }  
            }
            if (self.datePickerSelect.length == 3) {
                $('#datepickerFilter').datepicker('update');
                var f = self.datePickerSelect[2].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#datepickerFilter').datepicker('update', new Date());
                } else {
                    $('#datepickerFilter').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                self.contdatePicker_1 = 1;
                self.datePickerSelect = [];
                self.datePickerSelect.push(f[0] + "-" + f[1]);
                self.dateTrip = self.datePickerSelect[0];
            }
        });

        $('#datepickerFilter1').on('changeDate', function () {
             self.selectDate_1 = $('#datepickerFilter1').data('datepicker').getFormattedDate('M-yy')
            self.dateTrip = self.selectDate_1;
            //Meses repetidos en array
            if (self.selectDate_1.split(',')[0] == self.selectDate_1.split(',')[1]) {
                $('#datepickerFilter1').datepicker('update');
                self.dateTrip = "Date";
            }
            if (self.selectDate_1.split(',')[self.contdatePicker_2] !== undefined) {
                self.datePickerSelect_1.push(self.selectDate_1.split(',')[self.contdatePicker_2]);
                self.contdatePicker_2++;
            }
            if (self.datePickerSelect_1.length == 2 && self.datePickerSelect.length == 1) {
                $('#datepickerFilter').datepicker('update');
                $('#datepickerFilter1').datepicker('update');
                self.datePickerSelect = [];
                self.contdatePicker_1 = 0;
                self.datePickerSelect_1.splice(1, 0, self.datePickerSelect_1[1]);
                var f = self.datePickerSelect_1[1].split("-");
                $('#datepickerFilter1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
            }
            if (self.datePickerSelect_1.length == 1 && self.datePickerSelect.length == 2) {
                $('#datepickerFilter').datepicker('update');
                $('#datepickerFilter1').datepicker('update');
                self.datePickerSelect = [];
                self.contdatePicker_1 = 0;
                var f = self.datePickerSelect_1[0].split("-");
                if (f[0] == 'Jan') {
                    $('#datepickerFilter1').datepicker('update', '01-20' + f[1]);
                } else {
                    $('#datepickerFilter1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
               
            }
            if (self.datePickerSelect_1.length == 2 && self.datePickerSelect.length == 0) {
                $('#datepickerFilter').datepicker('update');
                self.datePickerSelect = [];
                self.contdatePicker_1 = 0;
                self.dateTrip = self.selectDate_1;
            }
            if (self.datePickerSelect.length == 1 && self.datePickerSelect_1.length == 1) {
                if (self.selectDate.split(',').length == 2) {
                    self.dateTrip = self.selectDate.split(',')[1] + "," + self.selectDate_1;
                } else {
                    self.dateTrip = self.selectDate + "," + self.selectDate_1;
                }
                if (self.selectDate.split(',').length == 3) {
                    self.dateTrip = self.selectDate.split(',')[2] + "," + self.selectDate_1;
                }  
            }
            if (self.selectDate_1 == '' && self.selectDate == '') {
                self.dateTrip = "Date";

            }
            if (self.selectDate_1.split(',').length == 2) {
                var f = self.selectDate_1.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateTrip = f[1] + "," + f[0];
                }
            }
            if (self.datePickerSelect_1.length == 3) {
                var f = self.datePickerSelect_1[2].split("-");
                if (f[0] == 'Jan') {
                    $('#datepickerFilter1').datepicker('update', '01-20' + f[1]);
                } else {
                    $('#datepickerFilter1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                self.contdatePicker_2 = 1;
                self.datePickerSelect_1 = [];
                self.datePickerSelect_1.push(f[0] + "-" + f[1]);
                self.dateTrip = self.datePickerSelect_1[0];
            }

           
            
        });
        
    },
    updated: function () {

        
    }
});

var tripFinderMobile = new Vue({
    el: "#tripFinderMobile",
    data: {
        contTrip: "",
        cont: "",
        triptype: 'Trip type',
        checkColor: "#787778",
        checkedTrip: [],
        maintripType: [{ labeltrip: 'Galapagos Cruises' }
            , { labeltrip: 'Galapagos Land-based tours' }, { labeltrip: 'Tours in Mainland Ecuador' }],
        travelersTot: "Travelers",
        count: 2,
        count1: 0,
        price: "Price range",
        dateTrip: "",

        dateRange1: null,
        dateRange2: null,

        countLen: 0,
        trip: [],

        tripFinder1: [],
    },
    created: function () {
    },
    computed: {
        colorAdu() {
            return { 'disabled': this.count < 1 }
        },
        colorChild() {
            return { 'disabled': this.count1 < 1 }
        },
        lenghtDay() {
            if (this.countLen < 1) {
                return "";
            } else {
                return " " + this.countLen;
            }
        },
        colorLenght() {
            return { 'disabled': this.countLen < 1 }
        },

        filterDate() {
            if (this.dateTrip == "") {
                return "Date";
            } else {
                return this.dateTrip;
            }
        },
    },
    methods: {
        checkTripType(event) {
            for (let listTrip of this.maintripType) {
                if (event.target.checked) {
                    if (listTrip.labeltrip == event.target.value) {
                        document.getElementById(event.target.value).style.color = "#398AC9";
                        if (event.target.value == 'Galapagos cruises') {
                            document.querySelectorAll('#subcategoria .enlace-subcategoria .containe .cruises').forEach((check) => {
                                check.classList.remove('checkmark1');
                            });
                        }
                        if (event.target.value == 'Galapagos Land-based tours') {
                            document.querySelectorAll('#subcategoria .enlace-subcategoria .containe .Land-based').forEach((check) => {
                                check.classList.remove('checkmark1');
                            });
                        }
                        if (event.target.value == 'Tours in mainland Ecuador') {
                            document.querySelectorAll('#subcategoria .enlace-subcategoria .containe .mainland').forEach((check) => {
                                check.classList.remove('checkmark1');
                            });
                        }
                        this.cont++;
                    }
                } else {
                    if (listTrip.labeltrip == event.target.value) {
                        document.getElementById(event.target.value).style.color = "#787778";
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
        resettleTripType: function () {
            
            for (let listTrip of this.maintripType) {
                document.getElementById(listTrip.labeltrip).style.color = "#787778";
            }
            
            this.checkedTrip = []
            this.contTrip = '';
            this.cont = 0
        },
        moreTravelersAdu: function () {
            this.count++;
            this.travelersTot = "Travelers " + (this.count + this.count1);
        },
        minusTravelersAdu: function () {
            if (this.count > 0) {
                this.count--;
                this.travelersTot = "Travelers " + (this.count + this.count1);
            }
        },
        moreTravelersChild: function () {
            this.count1++;
            this.travelersTot = "Travelers " + (this.count + this.count1);
        },
        minusTravelersChild: function (e) {
            if (this.count1 > 0) {
                this.count1--;
                this.travelersTot = "Travelers " + (this.count + this.count1);
            }
        },
        resettleTravel: function () {
            this.count = 2;
            this.count1 = 0;
            this.travelersTot = "Travelers ";
        },
        priceIni: function () {
            this.price = document.getElementById('amount1').value;
        },
        resettlePric: function () {
            this.price = "Price range";
        },
        moreLenght: function () {
            this.countLen++;
        },
        minusLenght: function () {
            if (this.countLen > 0) {
                this.countLen--;
            }
        },
        resettlelenght: function () {
            this.countLen = 0;
        },
        getDisponibilidad: function () {
            var vm = this;
            var datosFiltro = limpiarDatos(vm.travelersTot, vm.price, vm.dateTrip);
            vm.trip = [this.checkedTrip, datosFiltro[0][1], datosFiltro[1], datosFiltro[2], vm.countLen, datosFiltro[3]];
            localStorage.setItem('datosTrip', JSON.stringify(vm.trip));
        },
    },
    mounted: function () {
        var self = this;
        var contdatePicker_1 = 0;
        var contdatePicker_2 = 0;
        var datePickerSelect = [];
        var datePickerSelect_1 = [];
        var selectDate_1, selectDate = null;
        let recaptchaScript = document.createElement('script');
        recaptchaScript.setAttribute('src', '/js/site.js');
        document.head.appendChild(recaptchaScript);
        var recaptchaScript_1 = document.createElement('script');
        recaptchaScript.setAttribute('src', '/js/funcionesCompVue.js');
        document.head.appendChild(recaptchaScript);


       

        $('#datepickerMovil').on('changeDate', function () {
            selectDate = $('#datepickerMovil').data('datepicker').getFormattedDate('M-yy')
            self.dateTrip = selectDate;

            if (selectDate.split(',')[contdatePicker_1] !== undefined) {
                datePickerSelect.push(selectDate.split(',')[contdatePicker_1]);
                contdatePicker_1++;
            }

            if (datePickerSelect.length == 2 && datePickerSelect_1.length == 1) {
                $('#datepickerMovil').datepicker('update');
                $('#datepickerMovil1').datepicker('update');
                datePickerSelect_1 = [];
                contdatePicker_2 = 0;
                datePickerSelect.splice(1, 0, datePickerSelect[1]);
                var f = datePickerSelect[1].split("-");
                $('#datepickerMovil').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
            }
            if (datePickerSelect.length == 1 && datePickerSelect_1.length == 2) {
                $('#datepickerMovil').datepicker('update');
                $('#datepickerMovil1').datepicker('update');
                datePickerSelect_1 = [];
                contdatePicker_2 = 0;
                var f = datePickerSelect[0].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#datepickerMovil').datepicker('update', new Date());
                } else {
                    $('#datepickerMovil').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
            }
            if (datePickerSelect.length == 0 && datePickerSelect_1.length == 2) {
                $('#datepickerMovil1').datepicker('update');
                datePickerSelect_1 = [];
                contdatePicker_2 = 0;
                self.dateTrip = selectDate;
            }
            if (datePickerSelect.length == 1 && datePickerSelect_1.length == 1) {
                if (selectDate_1.split(',').length == 2) {
                    self.dateTrip = selectDate + "," + selectDate_1.split(',')[1];
                } else {
                    self.dateTrip = selectDate + "," + selectDate_1;
                }
                if (selectDate_1.split(',').length == 3) {
                    self.dateTrip = selectDate + "," + selectDate_1.split(',')[2];
                }
            }
            if (selectDate_1 == '' && selectDate == '') {
                self.dateTrip = "Date";

            }
            if (selectDate.split(',').length == 2) {
                var f = selectDate.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateTrip = f[1] + "," + f[0];
                }
            }
            if (datePickerSelect.length == 3) {
                $('#datepickerMovil').datepicker('update');
                var f = datePickerSelect[2].split("-");
                if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
                    $('#datepickerMovil').datepicker('update', new Date());
                } else {
                    $('#datepickerMovil').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                contdatePicker_1 = 1;
                datePickerSelect = [];
                datePickerSelect.push(f[0] + "-" + f[1]);
                self.dateTrip = datePickerSelect[0];
            }
        });

        $('#datepickerMovil1').on('changeDate', function () {
            selectDate_1 = $('#datepickerMovil1').data('datepicker').getFormattedDate('M-yy')
            self.dateTrip = selectDate_1;
            //Meses repetidos en array
            if (selectDate_1.split(',')[0] == selectDate_1.split(',')[1]) {
                $('#datepickerMovil1').datepicker('update');
                self.dateTrip = "Date";
            }
            if (selectDate_1.split(',')[contdatePicker_2] !== undefined) {
                datePickerSelect_1.push(selectDate_1.split(',')[contdatePicker_2]);
                contdatePicker_2++;
            }
            if (datePickerSelect_1.length == 2 && datePickerSelect.length == 1) {
                $('#datepickerMovil').datepicker('update');
                $('#datepickerMovil1').datepicker('update');
                datePickerSelect = [];
                contdatePicker_1 = 0;
                datePickerSelect_1.splice(1, 0, datePickerSelect_1[1]);
                var f = datePickerSelect_1[1].split("-");
                $('#datepickerMovil1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
            }
            if (datePickerSelect_1.length == 1 && datePickerSelect.length == 2) {
                $('#datepickerMovil').datepicker('update');
                $('#datepickerMovil1').datepicker('update');
                datePickerSelect = [];
                contdatePicker_1 = 0;
                var f = datePickerSelect_1[0].split("-");
                if (f[0] == 'Jan') {
                    $('#datepickerMovil1').datepicker('update', '01-20' + f[1]);
                } else {
                    $('#datepickerMovil1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }

            }
            if (datePickerSelect_1.length == 2 && datePickerSelect.length == 0) {
                $('#datepickerMovil').datepicker('update');
                datePickerSelect = [];
                contdatePicker_1 = 0;
                self.dateTrip = selectDate_1;
            }
            if (datePickerSelect.length == 1 && datePickerSelect_1.length == 1) {
                if (selectDate.split(',').length == 2) {
                    self.dateTrip = selectDate.split(',')[1] + "," + selectDate_1;
                } else {
                    self.dateTrip = selectDate + "," + selectDate_1;
                }
                if (selectDate.split(',').length == 3) {
                    self.dateTrip = selectDate.split(',')[2] + "," + selectDate_1;
                }
            }
            if (selectDate_1 == '' && selectDate == '') {
                self.dateTrip = "Date";

            }
            if (selectDate_1.split(',').length == 2) {
                var f = selectDate_1.split(',');
                var f1 = f[0].split("-");
                var f2 = f[1].split("-");
                if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
                    self.dateTrip = f[1] + "," + f[0];
                }
            }
            if (datePickerSelect_1.length == 3) {
                var f = datePickerSelect_1[2].split("-");
                if (f[0] == 'Jan') {
                    $('#datepickerMovil1').datepicker('update', '01-20' + f[1]);
                } else {
                    $('#datepickerMovil1').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
                }
                contdatePicker_2 = 1;
                datePickerSelect_1 = [];
                datePickerSelect_1.push(f[0] + "-" + f[1]);
                self.dateTrip = datePickerSelect_1[0];
            }



        });

        document.querySelector('#btn-menu-barras').addEventListener('click', (e) => {
            e.preventDefault();
            if (contenedorEnlaceNav.classList.contains('activo')) {
                contenedorEnlaceNav.classList.remove('activo');
                document.querySelector('body').style.overflow = 'visible';
            } else {
                contenedorEnlaceNav.classList.add('activo');
                document.querySelector('body').style.overflow = 'hidden';
            }
        });
    },
});





//========FORM DAYLI TOURS==============
var dayliForm = new Vue({
    el: "#dayliModal",
    data: {
        dayliForm: [],
        errors: [],
        email: null,
        passengers: null,
    },
    created: function () {
        //this.getDayli();
    },
    methods: {       
        getDayliForm: function () {
            $('#dayModal').modal('show');
        }
    },

});
//=================FILTRO FECHA==========================//
//Vue.filter('format_date', function fmt(date = '') {
//    var options = { weekday: 'short', year: 'numeric', month: 'short', day: 'numeric' };
//    var dateformat = new Date(date);
//    return dateformat.toLocaleDateString('en-GB', options);
//    //let date_parts = date.match(/^(\d{4})-(\d+)-(\d+)(.*)$/);
//    //let year;
//    //let month;
//    //let day;
//    //if (date_parts) {
//    //    year = ('00' + date_parts[1]).slice(-4);
//    //    month = ('0' + date_parts[2]).slice(-2);
//    //    day = ('0' + date_parts[3]).slice(-2);

//    //    var dateformat = new Date(date);

//    //    return dateformat.toLocaleDateString('en-GB', options);
//    //} else {
//    //    return date;
//    //}
    
//});
//Vue.component('date-picker', {
//    template: '<input/>',
//    props: ['dateFormat'],
//    mounted: function () {
//        var self = this;
//        $(this.$el).datepicker({
//            dateFormat: this.dateFormat,
//            onSelect: function (date) {
//                self.$emit('update-date', date);
//            }
//        });
//    },
//    beforeDestroy: function () {
//        $(this.$el).datepicker('hide').datepicker('destroy');
//    }
//});
