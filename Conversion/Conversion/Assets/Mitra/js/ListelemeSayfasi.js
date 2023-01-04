// ************** BURASI SADECE LİSTELEME SAYFALARI İÇİN KULLANILMAKTADIR SADECE LİSTELEME SAYFALARINA REFERANS VERMEK GEREKİR


//Tablet cihazlarda sağ daki info panelin modal şekilnde gösterilmesi
function MobileInfoPanel() {
    $("#example tbody tr").click(function () {
        $(".col-sag").addClass("col-sag-active");
        $(".listBackdrop").fadeIn(400);
    })
    $(".listBackdrop").click(function () {
        $(".listBackdrop").fadeOut(400);
        $(".col-sag").removeClass("col-sag-active");
    });
}
//End

$(document).ready(function () {
    $('#example').DataTable();
    if ($(window).width() < 1200) {
        MobileInfoPanel();
       
    }
});