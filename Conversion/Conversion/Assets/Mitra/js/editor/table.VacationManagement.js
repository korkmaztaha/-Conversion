
/*
 * Editor client script for DB table CongressBudgets
 * Created by http://editor.datatables.net/generator
 */

(function ($) {
       $(document).ready(function () {
        //var editor = new $.fn.dataTable.Editor({
        //    ajax: 'Processes.ashx?Step=VMSave&WERKS=' + $("#CountryName").val() +'&Y=' + $("#FilterYear").val(),
        //    table: '#VacationManagement',
        //    buttons: '_basic',
        //    fields: [
        //        {
        //            "label": "Employee",
        //            "name": "Initial"
        //        },
        //        {
        //            "label": "Employment Date",
        //            "name": "EmploymentDate",
        //            "type": "readonly"
        //            //,"opts": {
        //            //    showOn: 'focus',
        //            //    format: 'dd.mm.yyyy'
        //            //    //,language: "tr"
        //            //}
        //        },
        //        {
        //            "label": "Day Count:",
        //            "name": "DayCount"
        //        },

        //        {
        //            "label": "Year:",
        //            "name": "Y"
        //        },
        //        {
        //            "label": "Month",
        //            "name": "M"
        //        }
        //    ]
        //});

        //$('#VacationManagement').on('click', 'tbody td.editable', function (e) {
        //    editor.inline(this);
        //});
        table = $('#VacationManagement').DataTable({
            //"ordering": false,
            //"dom": '<"top"i>Brt<"bottom"flp><"clear">',
            
            ajax: 'Processes.ashx?Step=VMList&WERKS=' + $("#CountryName").val() + '&Y=' + $("#FilterYear").val(),
            columns: [
                {
                    "data": "Initial"
                },
                {
                    "data": "EmploymentDate",
                    "bSortable": true 
                },
                {
                    "data": "DayCount"
                },
                {
                    "data": "Y"
                },
                {
                    "data": "M"
                } 
            ],
            //keys: {
            //    columns: ':not(:first-child)',
            //    editor: editor
            //},
            //select: {
            //    style: 'os',
            //    selector: 'td:first-child',
            //    blurable: true
            //},
            //buttons: [
            //    { extend: "remove", editor: editor },
            //    {
            //        text: 'New',
            //        action: function (e, dt, node, config) {
            //            var menuId = $("ul.nav").first().attr("id");
            //            var request = $.ajax({
            //                url: 'Processes.ashx?Step=VMNewRow&WERKS=' + $("#CountryName").val() + '&Y=' + $("#FilterYear").val(),
            //                cache: false,
            //                method: "POST",
            //                data: { WERKS: $("#CountryName").val() , Y : $("#FilterYear").val()},
            //                dataType: "json"
            //            });

            //            request.done(function (msg) {
            //                table.ajax.reload(null, false);
            //            });

            //            request.fail(function (jqXHR, textStatus) {
            //                alert("Request failed: " + textStatus);
            //            });
            //        }
            //    }
            //],
            dom: 'Bfrtip',
            buttons: [{
                extend: 'excelHtml5',
                filename: 'VacationManagement_Report'
            }],
            language: {
                "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Turkish.json"
                //, buttons: {
                //    remove: 'Delete'
                //}
            }
        });
    });

}(jQuery));
