// ************** BİRDEN FAZLA SAYFADA ÇALIŞAN ANCAK PROJEYE ÖZEL YA DA SAYFAYA ÖZEL OLMASI NEDENİ İLE
// ************** KÜTÜPHANEYE GİRMESİ GEREKMEYEN FUNCTIONLAR DA BURADA
// **** Önemli Not Begin
// **** Burası projenin her sayfasında yüklenecek olan document.ready scriptlerini içerir / içerebilir.
// **** Burayı dikkatli kullanmak gerekiyor. çünkü her sayfada çalışır.
// **** Bu dosya projenin masterpage'inde refere edilmiş bir dosyadır ve referansı mutlaka jQuery'nin refere edildiği satırdan sonra olmalı, şu anda öyle zaten.
// **** Bu durumda çalışma hızı önemli olabilir kodun. Dikkat!
// **** Önemli Not End

//functions begin
// Liste sayfalarında (...List.aspx) viewport yüksekliğine göre sayfayı resize eder begin
function boyutlandir() {
    var winheight = $(window).height();
    $(".ListelemeSolBolum, .ListelemeSagBolum").css({ 'height': winheight + -150 });
}

//Bu fonksiyon mobil cihazlarda datePicker değişimi. Bu datepicker mobil cihazlar için daha uygun gibi. (ENVER)
function Phone() {   
    //if ($(window).width() < 800) {
    //    $(".SmartDate").removeClass('datepicker');
    //    $(".SmartDate").addClass('Mdatepicker');        
    //}
    //$('.datepicker').datepicker({
    //    dateFormat: 'dd.mm.yy',
    //    changeMonth: true,
    //    changeYear: true,        
    //});
    //$('.Mdatepicker').pickadate();
}

function Iphone() {
    var ua = navigator.userAgent;
    var checker = {
        iphone: ua.match(/(iPhone|iPod|iPad)/),
        android: ua.match(/Android/)
    };
    if (checker.android) {
        $(".BigMenu_btn").hide();
    }
    else if (checker.iphone) {
        $(".BigMenu_btn").hide();
        $('select').on('select2:open', function () {
            $('.select2-search input').prop('focus', 0);
        });
    }
    
}
