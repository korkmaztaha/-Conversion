function PaymentTerms() {
    $.ajax({
        type: "POST",
        url: "NovoPOService.aspx/LoVList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: '{Affiliate: "' + $("#hfAffiliate").val() + '","LovType": "Payment terms"}',
        success: function (msg) {
            var t = $.parseJSON(msg.d);
            $("#PaymentTerms").append($("<option></option>").val("").html(""));
            $.each(t.Table, function (i, item) {
                $("#PaymentTerms").append($("<option></option>").val(item.FID).html(item.LoVDesc));
            });
        },
        error: function () {
            Lobibox.notify('error', {
                msg: '"An error has occurred during processing your request.'
            });
        }
    });
}
function CurrencyList() {
    $.ajax({
        type: "POST",
        url: "NovoPOService.aspx/LoVList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: '{Affiliate: "' + $("#hfAffiliate").val() + '","LovType": "Currency"}',
        success: function (msg) {
            var t = $.parseJSON(msg.d);
            $("#Currency").append($("<option></option>").val("").html(""));
            $.each(t.Table, function (i, item) {
                $("#Currency").append($("<option></option>").val(item.FID).html(item.LoVDesc));
            });
        },
        error: function () {
            Lobibox.notify('error', {
                msg: '"An error has occurred during processing your request.'
            });
        }
    });
}
function VendorType_List() {
    $.ajax({
        type: "POST",
        url: "NovoPOService.aspx/LoVList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: '{Affiliate: "' + $("#hfAffiliate").val() + '","LovType": "Vendor Type"}',
        success: function (msg) {
            var t = $.parseJSON(msg.d);
            $("#VendorType").append($("<option></option>").val("").html(""));
            $.each(t.Table, function (i, item) {
                $("#VendorType").append($("<option></option>").val(item.FID).html(item.LoVDesc));
            });
        },
        error: function () {
            Lobibox.notify('error', {
                msg: '"An error has occurred during processing your request.'
            });
        }
    });
}
function Vendors_List() {
    $.ajax({
        type: "POST",
        url: "NovoPOService.aspx/Vendors_List",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: '{Affiliate: "' + $("#hfAffiliate").val() + '"}',
        success: function (msg) {
            var t = $.parseJSON(msg.d);
            $("#VendorName").append($("<option></option>").val("").html(""));
            $.each(t.Table, function (i, item) {
                $("#VendorName").append($("<option></option>").val(item.RowID).html(item.VendorName));
            });
        },
        error: function () {
            Lobibox.notify('error', {
                msg: '"An error has occurred during processing your request.'
            });
        }
    });
}
function CostCentres_List() {
    $.ajax({
        type: "POST",
        url: "NovoPOService.aspx/CostCentres_List",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: '{Affiliate: "' + $("#hfAffiliate").val() + '"}',
        success: function (msg) {
            var t = $.parseJSON(msg.d);
            $("#Budget").append($("<option></option>").val("").html(""));
            $.each(t.Table, function (i, item) {
                $("#Budget").append($("<option></option>").val(item.CCID).html(item.CCName));
            });
        },
        error: function () {
            Lobibox.notify('error', {
                msg: '"An error has occurred during processing your request.'
            });
        }
    });
}
function Projects_List() {
    $.ajax({
        type: "POST",
        url: "NovoPOService.aspx/Projects_List",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: '{Affiliate: "' + $("#hfAffiliate").val() + '"}',
        success: function (msg) {
            var t = $.parseJSON(msg.d);
            $("#Project").append($("<option></option>").val("").html(""));
            $.each(t.Table, function (i, item) {
                $("#Project").append($("<option></option>").val(item.ProjectNo).html(item.ProjectName));
            });
        },
        error: function () {
            Lobibox.notify('error', {
                msg: '"An error has occurred during processing your request.'
            });
        }
    });
}
function GLAccounts_List() {
    $.ajax({
        type: "POST",
        url: "NovoPOService.aspx/GLAccounts_List",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: '{Affiliate: "' + $("#hfAffiliate").val() + '"}',
        success: function (msg) {
            var t = $.parseJSON(msg.d);
            $("#ServiceType").append($("<option></option>").val("").html(""));
            $.each(t.Table, function (i, item) {
                $("#ServiceType").append($("<option></option>").val(item.GLNo).html(item.GLName));
            });
        },
        error: function () {
            Lobibox.notify('error', {
                msg: '"An error has occurred during processing your request.'
            });
        }
    });
}
function WBS_List() {
    $.ajax({
        type: "POST",
        url: "NovoPOService.aspx/WBS_List",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: '{Affiliate: "' + $("#hfAffiliate").val() + '"}',
        success: function (msg) {
            var t = $.parseJSON(msg.d);
            $("#WBS").append($("<option></option>").val("").html(""));
            $.each(t.Table, function (i, item) {
                $("#WBS").append($("<option></option>").val(item.RowID).html(item.WBS));
            });
        },
        error: function () {
            Lobibox.notify('error', {
                msg: '"An error has occurred during processing your request.'
            });
        }
    });
}
