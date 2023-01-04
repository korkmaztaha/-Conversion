
function getMonday(d) {
    d = new Date(d);
    var day = d.getDay(),
        diff = d.getDate() - day + (day == 0 ? -6 : 1); // adjust when day is sunday
    var vc = moment(d.setDate(diff + 7));
    var day = ('0' + (vc.date())).slice(-2);
    var month = ('0' + (vc.month() + 1)).slice(-2);
    var year = vc.year();
    return valD = day + "." + month + "." + year;
}   

function xgetMonday(Which) {
    
    var valD;
    var vc = moment().day(Which);
    var mDateOfMonday = new Date();
    var day = ('0' + (vc.date())).slice(-2);
    var month = ('0' + (vc.month() + 1)).slice(-2);
    var year = vc.year();
    return valD =  day + "." + month + "." + year;
}


function GetNextTuesday() {
    var valD;
    var vc = moment().day(+9);
    var mDateOfMonday = new Date();
    var day = vc.date();
    var month = vc.month() + 1;
    var year = vc.year();

    if (day < 10) {
        if (month < 10) {
            return valD = year + "-" + "0" + month + "-" + "0" + day;
        }
        else {
            return valD = year + "-" + month + "-" + "0" + day;
        }
    }
    else {
        if (month < 10) {
            return valD = year + "-" + "0" + month + "-" + day;
        }
        else {
            return valD = year + "-" + month + "-" + day;
        }
    }
}
function ParseDate(day) {

    var value = new Date
               (
                    parseInt(day.replace(/(^.*\()|([+-].*$)/g, ''))
               );
    var dat;
    if (value.getDate() < 10) {
        var dat =
               value.getFullYear() + "/" + (parseFloat(value.getMonth()) + 1) + "/" + "0" + value.getDate();
    }
    else {
        var dat =
        value.getFullYear() + "/" + (parseFloat(value.getMonth()) + 1) + "/" + value.getDate();
    }
    return dat;
}
function DateTimeNow() {
    var valD;
    var day = moment().date();
    var month = moment().month() + 1;
    var year = moment().year();

    if (day < 10) {
        if (month < 10) {
            //return valD = year + "-" + "0" + month + "-" + "0" + day;
            return valD = "0" + day + "-" + "0" + month + "-" + year;
        }
        else {
            //return valD = year + "-" + month + "-" + "0" + day;
            return valD = "0" + day + "-" + month + "-" + year;
        }
    }
    else {
        if (month < 10) {
            //return valD = year + "-" + "0" + month + "-" + day;
            return valD = day + "-" + "0" + month + "-" + year;
        }
        else {
            //return valD = year + "-" + month + "-" + day;
            return valD = day + "-" + month + "-" + year;
        }
    }
}
