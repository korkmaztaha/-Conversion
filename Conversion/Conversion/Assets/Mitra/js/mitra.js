//Created by Mitra Bilgisayar
//may contain some open source code from different resources

function isnull(oval) {
    
    if (oval == "0" || oval == "" || oval == null || oval == undefined || oval == 'undefined' || oval == 'null')
        return true; else return false;
}

function queryString(sURL, Deger) {
    if (Deger != null) {
        var regEx = new RegExp("(\\?|&)(" + Deger + "=)(.*?)(&|$|#)", "i")
        var exec = regEx.exec(sURL)
        var Sonuc = RegExp.$3
    } else {
        var regEx = new RegExp("(\\?)(.*?)($)", "i")
        var exec = regEx.exec(sURL)
        var Sonuc = RegExp.$2
    }

    return (Sonuc)
}

function UrlCorePart(surl) {
    var is_input = surl.indexOf('?');
    if (is_input == -1) {
        return surl
    } else {
        return surl.substring(0, is_input);
    }
}

function getTimeForURL() {
    var dt = new Date();
    var strOutput = "";
    strOutput = dt.getHours() + "_" + dt.getMinutes() + "_" + dt.getSeconds() + "_" + dt.getMilliseconds();
    return strOutput;
}

function jsonhasvalue(jsonobj, jsonfield, jsonvalue) {
    var returnval = false;
    $.each(jsonobj, function (key, value) {
        if (key == jsonfield && value == jsonvalue) { returnval = true; return returnval; };
        $.each(value, function (xkey, xvalue) {
            if (xkey == jsonfield && xvalue == jsonvalue) { returnval = true; return returnval; };
        });
    });
    return returnval;
}

function jsonhas(jsonobj, jsonfield) {
    var returnval = false;
    $.each(jsonobj, function (key, value) {
        if (key == jsonfield) { returnval = true; return returnval; };
    });
    return returnval;
}

function TContains(str, spl, checkval) {
    var c;
    c = str.split(spl);
    for (i = 0; i <= c.length - 1; i++) {
        if (c[i] == checkval) { return true; }
    }
    return false;
}

function IsNumeric(strString)
    //  check for valid numeric strings	
{
    var strValidChars = "0123456789.,-";
    var strChar;
    var blnResult = true;

    if (strString.length == 0) return false;

    //  test strString consists of valid characters listed above
    for (i = 0; i < strString.length && blnResult == true; i++) {
        strChar = strString.charAt(i);
        if (strValidChars.indexOf(strChar) == -1) {
            blnResult = false;
        }
    }
    return blnResult;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode > 47 && charCode < 58) || (charCode == 44) || (charCode == 46))
        return true;

    return false;
}

function copyToClipboard(text) {
    if (window.clipboardData) {
        window.clipboardData.setData("Text", text);
        //alert("Copied to clipboard");
    }
    else {
        alert("Error Occurred");
    }
}

//Attachment handling begin
function attachmentContainerstyle() {
    $("i.mbbc.mbbc-addC").addClass("fa-4x mhc-cpointer"); //dosya ikonlarına eklenen classlar
    if ($("#myFileDiv .row").length > 0) {
        $("#myFileDiv").addClass("myFileDivbgc");
    } else {
        $("#myFileDiv").removeClass("myFileDivbgc");
    }
}

//function DelAttach(FormFileID, delAsk,MainTbl) {
//    $("#file_uploadResult").html("<img src='../Images/indicator.gif' alt='loading'/>");
//    $(this).html("<img src='../Images/indicator.gif' alt='loading'/>");
//    if (confirm(delAsk)) {
//        $("#myFileDiv").load("Processes.ashx?Step=FormAttachDel&RO=2&FormID=" + FormID + "&FormFileID=" + FormFileID + "&MT=" + MainTbl + "&SiCem=" + getTimeForURL(), function () {
//            attachmentContainerstyle(); //dosya ikonları ilgili
//        });            
//    }
//    $("#file_uploadResult").html("")
//}

function DelAttach(FormFileID, delAsk, FormID, FormType, MainTbl) {
    $("#file_uploadResult").html("<img src='../Images/indicator.gif' alt='loading'/>");
    $(this).html("<img src='../Images/indicator.gif' alt='loading'/>");
    if (confirm(delAsk)) {
        $("#" + MainTbl).load("Processes.ashx?Step=FormAttachDel&RO=2&FormID=" + FormID + "&FormFileID=" + FormFileID + "&FormType=" + FormType + "&MT=" + MainTbl + "&SiCem=" + getTimeForURL(), function () {
            attachmentContainerstyle(); //dosya ikonları ilgili
        });
    }
    $("#file_uploadResult").html("");
}
function passUploadedList(ro, FormID, MainTbl, FormType, MyCustomCase, MyPosition) {
    $("#" + MainTbl).load("Processes.ashx?Step=FormAttachList&FormID=" + FormID + "&FormType=" + FormType + "&MT=" + MainTbl + "&RO=" + ro + "&MyCustomCase=" + nullif(MyCustomCase, "-x") + "&MyPosition=" + MyPosition + "&SiCem=" + getTimeForURL(), function () {
        attachmentContainerstyle(); //dosya ikonları ilgili
    });
}
function xpassUploadedList(ro, FormID, MainTbl) {
    
    $("#MF"+FormID).load("Processes.ashx?Step=FormAttachList&FormID=" + FormID + "&MT=" + MainTbl + "&RO=" + ro + "&SiCem=" + getTimeForURL(), function () {
        attachmentContainerstyle(); //dosya ikonları ilgili
    });
}
//Attachment handling end

function nullif(oval, rtrn) {
    if (oval == "0" || oval == "" || oval == " " || oval == null || oval == undefined || oval == "undefined")
        return rtrn; else return oval;
}

function GiveMyAttribute(htmlString, attrtxt) {
    var setCookieMetaRegExp = /data-tooltip=\"(.*?)\"/gi;
    var matches = [];
    var Gata = "";
    while (setCookieMetaRegExp.exec(htmlString)) {
        Gata = RegExp.$1;
    }
    if (Gata === "") {
        if (!isnull((/class=\"(.*?)\"/gi).exec(htmlString))) { return ""; }
        else {
            return htmlString;
        }
    } else { return Gata; }

}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)", "i"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}
function NavPage(newLink) {
    location.href = newLink;
}

//For only Lobibox confirm begin
//to use only with tables
// to call the function in repeater or gridview command butttons use the following command
// OnClientClick="DeleteConfirm(this.id,'0|1'); return false;"
// the second argument of the function is an index based (beginning with 0) col numbers of the record to display in the confirmation message
function DeleteConfirm(uniqueID, myarraystr) {
    var mybutton = $("#" + uniqueID);
    var mytr = mybutton.parent().parent();
    var str = myarraystr;
    var myarray = str.split("|");
    var mymsg = "<br/>"
    for (i = 0; i < myarray.length; i++) {

        if (i == myarray.length - 1) {
            mymsg = mymsg + mytr.find("td:eq(" + myarray[i] + ")").html();
        } else {
            mymsg = mymsg + mytr.find("td:eq(" + myarray[i] + ")").html() + " - ";
        }
        //console.log(mytr.find("td:eq(" + myarray[i] + ")").html());
    }
    Lobibox.confirm({
        title: "Delete confirmation!",
        msg: "Are you sure you want to delete the following record?" + mymsg,
        callback: function ($this, type) {
            if (type === 'yes') {
                eval(mybutton.attr("href"));
            } else if (type === 'no') {
                aaa = 1;
            }
        }
    });
}




function Kurgetir(FromCur, ToCur) {
    var MyData;
    var url = "autocomplete.ashx?Step=CurrencyConvert&rFrom=" + FromCur + "&rTo=" + ToCur + "&SiCem=" + getTimeForURL();
    $.ajax({
        url: url,
        async: false,
        success: function (data) {
            MyData = data;
            
        }
    });
    return MyData.replace(",", "");
}


//For only Lobibox confirm end