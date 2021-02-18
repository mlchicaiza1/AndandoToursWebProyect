function limpiarDatos(travelersTot,price,dateTrip) {
    var priceRango, travelers;
    var date, f, f1, f2, fecha, dateMostrar;
    var fechaInicio, fechaFin;
    var datos = [];

    if (travelersTot.trim() == "Travelers") {
        travelers = [0, 2];
    } else {
        travelers = travelersTot.split(' ');
    }
    if (price == "Price range") {
        priceRango = [300, 7500];
    } else {
        priceRango = price.replace(/[$]/gi, '').split('-');
    }
    if (dateTrip == "" || dateTrip == "Date") {
        fechaInicio = new Date();
        fechaFin = new Date();
        fechaFin.setMonth(fechaFin.getMonth() + 9, 0)
        date = [fechaInicio, fechaFin];
        dateMostrar = dateTrip;
    } else {
        if (dateTrip.split(',')[1] == "") {
            dateMostrar = dateTrip;
            f = dateTrip.split(',')[0].split("-");
            fechaInicio = new Date(f[0] + "-" + "20" + f[1]);
            fechaFin = new Date(f[0] + "-" + "20" + f[1]);
            fechaFin.setMonth(fechaFin.getMonth() + 9, 0);
            date = [fechaInicio, fechaFin];
        }
        else {
            dateMostrar = dateTrip;
            f = dateTrip.split(',')[1].split("-");
            fechaInicio = new Date(f[0] + "-" + "20" + f[1]);
            fechaFin = new Date(f[0] + "-" + "20" + f[1]);
            fechaFin.setMonth(fechaFin.getMonth() + 9, 0);
            date = [fechaInicio, fechaFin];
        }
        if (dateTrip.split(',')[0] != "" && dateTrip.split(',')[1] != "") {
            dateMostrar = dateTrip;
            f = dateTrip.split(',');
            f1 = f[0].split("-");
            f2 = f[1].split("-");
            fechaInicio = new Date(f1[0] + "-" + "20" + f1[1]);
            fechaFin = new Date(f2[0] + "-" + "20" + f2[1]);
            fechaFin.setMonth(fechaFin.getMonth() + 1, 0);
            date = [fechaInicio, fechaFin];
           
        }
    }

    datos = [travelers, priceRango, date, dateMostrar];
    return datos ;
};

function limpiarDatosDipoCruceros(travelersTot, dateTrip) {
    var travelers;
    var date, f, f1, f2, fecha, dateShowFilter;
    var fechaInicio, fechaFin;
    var datos = [];

    if (travelersTot.trim() == "Travelers") {
        travelers = [0, 2];
    } else {
        travelers = travelersTot.split(' ');
    }
    if (dateTrip == "" || dateTrip == "Date") {
        fechaInicio = new Date();
        fechaFin = new Date();
        fechaFin.setMonth(fechaFin.getMonth() + 9, 0)
        date = [fechaInicio, fechaFin];
        dateShowFilter = dateTrip;

    } else {

        if (dateTrip.includes(',') == false) {
            dateShowFilter = dateTrip;
            f = dateTrip.split("-");
            fechaInicio = new Date(f[0] + "-" + "20" + f[1]);
            fechaFin = new Date(f[0] + "-" + "20" + f[1]);
            fechaFin.setMonth(fechaFin.getMonth() + 9, 0);
            date = [fechaInicio, fechaFin];
        }
    }
    if (dateTrip.split(',')[0] == "" && dateTrip.includes(',') == true) {
        dateShowFilter = dateTrip;
        f = dateTrip.split(',')[1].split("-");
        fechaInicio = new Date(f[0] + "-" + "20" + f[1]);
        fechaFin = new Date(f[0] + "-" + "20" + f[1]);
        fechaFin.setMonth(fechaFin.getMonth() + 9, 0);
        date = [fechaInicio, fechaFin];
    }
    if (dateTrip.split(',')[1] == "" && dateTrip.includes(',') == true) {
        dateShowFilter = dateTrip;
        f = dateTrip.split(',')[0].split("-");
        fechaInicio = new Date(f[0] + "-" + "20" + f[1]);
        fechaFin = new Date(f[0] + "-" + "20" + f[1]);
        fechaFin.setMonth(fechaFin.getMonth() + 9, 0);
        date = [fechaInicio, fechaFin];
    }

    

    if (dateTrip.split(',')[0] != "" && dateTrip.split(',')[1] != "" && dateTrip.includes(',') == true) {
        dateShowFilter = dateTrip;
        f = dateTrip.split(',');
        f1 = f[0].split("-");
        f2 = f[1].split("-");
        fechaInicio = new Date(f1[0] + "-" + "20" + f1[1]);
        fechaFin = new Date(f2[0] + "-" + "20" + f2[1]);
        fechaFin.setMonth(fechaFin.getMonth() + 1, 0);
        date = [fechaInicio, fechaFin];

    }

    datos = [travelers, date, dateShowFilter];
    return datos;
};

function limpiarDatoPrecio(price) {
    var priceRango
    var datos = [];

  
    if (price == "Price range") {
        priceRango = [300, 7500];
    } else {
        priceRango = price.replace(/[$]/gi, '').split('-');
    }
    return priceRango;
};

function RangeMonth(datepickerFilter,) {
    var contdatePicker_1 = 0;
    var contdatePicker_2 = 0;
    var datePickerSelect = [];
    var datePickerSelect_1 = [];
    var selectDate_1, selectDate = null;

    selectDate = $('#' + datepickerFilter).data('datepicker').getFormattedDate('M-yy');


    if (selectDate.split(',')[contdatePicker_1] !== undefined) {
        datePickerSelect.push(selectDate.split(',')[contdatePicker_1]);
        contdatePicker_1++;
    }

    if (datePickerSelect.length == 2 && datePickerSelect_1.length == 1) {
        $('#datepickerFilter').datepicker('update');
        $('#datepickerFilter1').datepicker('update');
        datePickerSelect_1 = [];
        contdatePicker_2 = 0;
        datePickerSelect.splice(1, 0, datePickerSelect[1]);
        var f = datePickerSelect[1].split("-");
        $('#datepickerFilter').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
    }
    if (datePickerSelect.length == 1 && datePickerSelect_1.length == 2) {
        $('#datepickerFilter').datepicker('update');
        $('#datepickerFilter1').datepicker('update');
        datePickerSelect_1 = [];
        contdatePicker_2 = 0;
        var f = datePickerSelect[0].split("-");
        if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
            $('#datepickerFilter').datepicker('update', new Date());
        } else {
            $('#datepickerFilter').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
        }
    }
    if (datePickerSelect.length == 0 && datePickerSelect_1.length == 2) {
        $('#datepickerFilter1').datepicker('update');
        datePickerSelect_1 = [];
        contdatePicker_2 = 0;
        return  selectDate;
    }
    if (datePickerSelect.length == 1 && datePickerSelect_1.length == 1) {
        if (selectDate_1.split(',').length == 2) {
            return  selectDate + "," + selectDate_1.split(',')[1];
        } else {
            return selectDate + "," + selectDate_1;
        }
        if (selectDate_1.split(',').length == 3) {
            return  selectDate + "," + selectDate_1.split(',')[2];
        }
    }
    if (selectDate_1 == '' && selectDate == '') {
        return  "Date";

    }
    if (selectDate.split(',').length == 2) {
        var f = selectDate.split(',');
        var f1 = f[0].split("-");
        var f2 = f[1].split("-");
        if (new Date(f1[0] + "-" + "20" + f1[1]) > new Date(f2[0] + "-" + "20" + f2[1])) {
            return  f[1] + "," + f[0];
        }
    }
    if (datePickerSelect.length == 3) {
        $('#datepickerFilter').datepicker('update');
        var f = datePickerSelect[2].split("-");
        if (new Date(f[0] + "-" + "20" + f[1]) < new Date()) {
            $('#datepickerFilter').datepicker('update', new Date());
        } else {
            $('#datepickerFilter').datepicker('update', new Date(f[0] + "-" + "20" + f[1]));
        }
        contdatePicker_1 = 1;
        datePickerSelect = [];
        datePickerSelect.push(f[0] + "-" + f[1]);
        return  datePickerSelect[0];
    }


    

    

}


