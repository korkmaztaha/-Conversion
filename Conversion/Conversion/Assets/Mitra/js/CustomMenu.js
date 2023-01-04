function Iphone() {
    var ua = navigator.userAgent;
    var checker = {
        iphone: ua.match(/(iPhone|iPad)/),
        android: ua.match(/Android/)
    };
    if (checker.android) {
        $(".BigMenu_btn").hide();
        $("#slide-out").addClass("BigMenu");
        $("#slide-out .MyLogo").addClass("hidden");
        $("#slide-out").css("padding-top", "25px");

        var PTitleWidth = $(".PageTitle").width();
        $(".PageTitle").css("margin-left", "-" + PTitleWidth + "px");
    }
    else if (checker.iphone) {
        $(".BigMenu_btn").hide();
        $("#slide-out").addClass("BigMenu");
        $("#slide-out .MyLogo").addClass("hidden");
        $("#slide-out").css("padding-top", "25px");

        var PTitleWidth = $(".PageTitle").width();
        $(".PageTitle").css("margin-left", "-" + PTitleWidth + "px");
    }
    else {
        $("#slide-out").removeClass("BigMenu");
        $("#slide-out .MyLogo").removeClass("hidden");
        $("#slide-out").css("padding-top", "0");

        var PTitleWidth = $(".PageTitle").width();
        $(".PageTitle").css("margin-left", "-" + PTitleWidth / 2 + "px");
    }
}
$(document).ready(function () {
    if (window.matchMedia('(max-width: 1100px)').matches) {
        Iphone();
    }
    
});
$(window).load(function () {
    $("#loader").fadeOut(2000);
    $(".brand-logo-custom").fadeIn(2000);
});