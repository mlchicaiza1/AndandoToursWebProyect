window.onload = Linkgalapagos();
function videoOpenHome() {
    var modalVideo = document.getElementById("videostory");
    // When the user clicks the button, open the modal
    modalVideo.style.display = "block";
    $('body').addClass('modal-open');
}

// When the user clicks on <span> (x), closeVideo the modal
function cerrarVideoHome() {
    var modalVideo = document.getElementById("videostory");
    // When the user clicks the button, open the modal
    $("iframe").each(function () {
        var src = $(this).attr('src');
        $(this).attr('src', src);
    });
    modalVideo.style.display = "none";
    $('body').removeClass('modal-open');
}
function Linkgalapagos() {
    document.getElementById('galapagos').style.display = 'block';
    //document.getElementById('minland').style.display = 'none';
    //document.getElementById('peru').style.display = 'none';
    //document.getElementById('link-galapagos').style.borderBottom = '2px';
    //document.getElementById('link-galapagos').style.paddingBottom = '8px';
    //document.getElementById('link-galapagos').style.borderBottomStyle = 'solid';
    //document.getElementById('link-galapagos').style.borderBottomColor = '#398AC9';
    //document.getElementById('link-minland').style.borderBottom = 'none';
    //document.getElementById('link-peru').style.borderBottom = 'none';
}
//function Linkminland() {
//    document.getElementById('galapagos').style.display = 'none';
//    document.getElementById('minland').style.display = 'block';
//    document.getElementById('peru').style.display = 'none';
//    document.getElementById('link-minland').style.borderBottom = '2px';
//    document.getElementById('link-minland').style.paddingBottom = '8px';
//    document.getElementById('link-minland').style.borderBottomStyle = 'solid';
//    document.getElementById('link-minland').style.borderBottomColor = '#398AC9';
//    document.getElementById('link-galapagos').style.borderBottom = 'none';
//    document.getElementById('link-peru').style.borderBottom = 'none';
//}
//function Linkperu() {
//    document.getElementById('galapagos').style.display = 'none';
//    document.getElementById('minland').style.display = 'none';
//    document.getElementById('peru').style.display = 'block';
//    document.getElementById('link-peru').style.borderBottom = '2px';
//    document.getElementById('link-peru').style.paddingBottom = '8px';
//    document.getElementById('link-peru').style.borderBottomStyle = 'solid';
//    document.getElementById('link-peru').style.borderBottomColor = '#398AC9';
//    document.getElementById('link-galapagos').style.borderBottom = 'none';
//    document.getElementById('link-minland').style.borderBottom = 'none';
//}