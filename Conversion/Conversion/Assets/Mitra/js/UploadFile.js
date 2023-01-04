function CreateFileUpload(id, ftype, mTbl, upcontrol) {

    //$(".file-loading").fileinput("destroy");
    var zurl = "/Uploader.ashx?id=" + id + "&ftype=" + ftype + "&mTbl=" + mTbl + "&MyPath=" + getTimeForURL();
    $("#"+upcontrol).fileinput({
        uploadUrl:zurl, // server upload action
        uploadAsync: false,
        showCaption: false,
        dropZoneEnabled: false,
        browseClass: "xfile",
        showRemove: false,
        showUpload: false, //// file input uploaded fonksiyonu bunda çalışmadı 
        maxFileSize: "200000000",
        allowedFileExtensions: ["txt", "md", "ini", "image", "text", "img", "object", "html", "pdf", "xls", "csv", "doc", "docx", "one", "rar", "zip", "mp4", "ogg", "zip", "png", "jpg", "jpeg", "gif", "ppt", "pptx", "xlsx"],
        maxFileCount: 1,
        uploadExtraData: {
           
        }
    })
    $("#" + upcontrol + "").on('fileuploaded', function (event, data, previewId, index) {
        x = data
        var tempID = 1;

        formIdFileIdNumaraVer = data.response.filepath.replace("\"", "").replace("\"", "");


        $("#previewUpload").append("<div class='mahmut' id='" + formIdFileIdNumaraVer + "'><ul class='collection'><li class='collection-item avatar'><img src='../../img/FileIcons/doc.png' alt='' title='' class='circle'/><span class='title'>" + 'File' + "</span><p><a target='_blank' href='" + '/Documents/' + formIdFileIdNumaraVer + "'  aria-label='T'><span>" + formIdFileIdNumaraVer + "</span></a></p><button type='button' onclick=\"RemoveThisFile('" + formIdFileIdNumaraVer + "','" + tempID + "')\" id=\"clearThisFileForm\" fValue='" + '(' + formId + ')' + formIdFileIdNumaraVer + "' class='rkmd-btn btn-fab-mini btn-pink ripple-effect secondary-content'><i class='zmdi zmdi-delete'></i></button></li></ul></div>")
        tempID += 1;
    })
}
function CreateFileUploadBIA(id, ftype, mTbl, upcontrol) {
    alert(1);
    //$(".file-loading").fileinput("destroy");
    var zurl = "../Uploader.ashx?id=" + id + "&ftype=" + ftype + "&mTbl=" + mTbl + "&MyPath=" + getTimeForURL();// ftype direk BIA olabilir.
    $("#" + upcontrol).fileinput({
        uploadUrl: zurl, // server upload action
        uploadAsync: false,
        showCaption: false,
        dropZoneEnabled: false,
        browseClass: "xfile",
        showRemove: false,
        showUpload: false, //// file input uploaded fonksiyonu bunda çalışmadı 
        maxFileSize: "200000000",
        allowedFileExtensions: ["txt", "md", "ini", "image", "text", "img", "object", "html", "pdf", "xls", "csv", "doc", "docx", "one", "rar", "zip", "mp4", "ogg", "zip", "png", "jpg", "jpeg", "gif", "ppt", "pptx", "xlsx"],
        maxFileCount: 1,
        uploadExtraData: {

        }
    })
    $("#" + upcontrol + "").on('fileuploaded', function (event, data, previewId, index) {
        x = data
        var tempID = 1;
        
        formIdFileIdNumaraVer = data.response.filepath.replace("\"", "").replace("\"", "");
        
        
        $("#previewUpload").append("<div class='mahmut' id='" + formIdFileIdNumaraVer + "'><ul class='collection'><li class='collection-item avatar'><img src='../../img/FileIcons/doc.png' alt='' title='' class='circle'/><span class='title'>" + 'BIA' + "</span><p><a target='_blank' href='" + '/Documents/' + formIdFileIdNumaraVer + "'  aria-label='T'><span>" + formIdFileIdNumaraVer + "</span></a></p><button type='button' onclick=\"RemoveThisFile('" + formIdFileIdNumaraVer + "','" + tempID + "')\" id=\"clearThisFileForm\" fValue='" + '(' + formId + ')' + formIdFileIdNumaraVer + "' class='rkmd-btn btn-fab-mini btn-pink ripple-effect secondary-content'><i class='zmdi zmdi-delete'></i></button></li></ul></div>")
        tempID += 1;
    })
}
function CreateFileUploadSIA(id, ftype, mTbl, upcontrol) {

    //$(".file-loading").fileinput("destroy");
    var zurl = "/Uploader.ashx?id=" + id + "&ftype=" + ftype + "&mTbl=" + mTbl + "&MyPath=" + getTimeForURL();// ftype direk BIA olabilir.
    $("#" + upcontrol).fileinput({
        uploadUrl: zurl, // server upload action
        uploadAsync: false,
        showCaption: false,
        dropZoneEnabled: false,
        browseClass: "xfile",
        showRemove: false,
        showUpload: false, //// file input uploaded fonksiyonu bunda çalışmadı 
        maxFileSize: "200000000",
        allowedFileExtensions: ["txt", "md", "ini", "image", "text", "img", "object", "html", "pdf", "xls", "csv", "doc", "docx", "one", "rar", "zip", "mp4", "ogg", "zip", "png", "jpg", "jpeg", "gif", "ppt", "pptx", "xlsx"],
        maxFileCount: 1,
        uploadExtraData: {

        }
    })
    $("#"+upcontrol+"").on('fileuploaded', function (event, data, previewId, index) {
        x = data
        var tempID = 1;
        
        formIdFileIdNumaraVer = data.response.filepath.replace("\"", "").replace("\"", "");
        
        
        $("#previewUpload").append("<div class='mahmut' id='" + formIdFileIdNumaraVer + "'><ul class='collection'><li class='collection-item avatar'><img src='../../img/FileIcons/doc.png' alt='' title='' class='circle'/><span class='title'>" + 'SIA' + "</span><p><a target='_blank' href='" + '/Documents/' + formIdFileIdNumaraVer + "'  aria-label='T'><span>" + formIdFileIdNumaraVer + "</span></a></p><button type='button' onclick=\"RemoveThisFile('" + formIdFileIdNumaraVer + "','" + tempID + "')\" id=\"clearThisFileForm\" fValue='" + '(' + formId + ')' + formIdFileIdNumaraVer + "' class='rkmd-btn btn-fab-mini btn-pink ripple-effect secondary-content'><i class='zmdi zmdi-delete'></i></button></li></ul></div>")
        tempID += 1;
    })
}
function CreateFileUploadWhithDropZone(id) {
    $(".file-loading").fileinput({
        uploadUrl: "/Uploader.ashx", // server upload action
        uploadAsync: false,
        showCaption: false,
        dropZoneEnabled: true,
        browseClass: "xfile",
        //browseIcon: '<i class="glyphicon glyphicon-camera"></i> ',

        //browseLabel: 'Imagen',
        showRemove: false,
        showUpload: false, //// file input uploaded fonksiyonu bunda çalışmadı 
        maxFileSize: "200000000",
        allowedFileExtensions: ["txt", "md", "ini", "image", "text", "img", "object", "html", "pdf", "xls", "csv", "doc", "docx", "one", "rar", "zip", "mp4", "ogg", "zip", "png", "jpg", "jpeg", "gif", "ppt", "pptx", "xlsx"],
        maxFileCount: 5,
        uploadExtraData: {
            id:id
        },
            previewFileIconSettings: {
                'docx': '<i class="fa fa-file-word-o text-primary"></i>',
                'xlsx': '<i class="fa fa-file-excel-o text-success"></i>',
                'pptx': '<i class="fa fa-file-powerpoint-o text-danger"></i>',
                'jpg': '<i class="fa fa-file-photo-o text-warning"></i>',
                'pdf': '<i class="fa fa-file-pdf-o text-danger"></i>',
                'zip': '<i class="fa fa-file-archive-o text-muted"></i>',
            }
    })
}
var x;
  

function RemoveThisFile(fileName,x) {

    $.ajax({
        url: "/BITS/Home/Index.aspx/FormAttachments_Delete",
        method: "POST",
        data: JSON.stringify({ fileName:fileName}),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: false,
        datatype: "json",
        success: function (data) {
            {
                if (data != "0") {
                    console.log(""+fileName+"")
                    document.getElementById(""+fileName+"").remove()
                }
                else {
                    //$("#errorModal").show();
                    //$("#errorMesagge").text("Attachment Delete Error")
                    //GetNotWithMessage(data, btnDelete, 'Attachment Delete Error')
                }
            }
        }
    })
}




function CreateFileUploadValidation(id, ftype, mTbl, upcontrol) {

    //$(".file-loading").fileinput("destroy");
    var zurl = "/Uploader.ashx?id=" + id + "&ftype=" + ftype + "&mTbl=" + mTbl + "&MyPath=" + getTimeForURL();// ftype direk BIA olabilir.
    $("#" + upcontrol).fileinput({
        uploadUrl: zurl, // server upload action
        uploadAsync: false,
        showCaption: false,
        dropZoneEnabled: false,
        browseClass: "xfile",
        showRemove: false,
        showUpload: false, //// file input uploaded fonksiyonu bunda çalışmadı 
        maxFileSize: "200000000",
        allowedFileExtensions: ["txt", "md", "ini", "image", "text", "img", "object", "html", "pdf", "xls", "csv", "doc", "docx", "one", "rar", "zip", "mp4", "ogg", "zip", "png", "jpg", "jpeg", "gif", "ppt", "pptx", "xlsx"],
        maxFileCount: 1,
        uploadExtraData: {

        }
    })
    $("#" + upcontrol + "").on('fileuploaded', function (event, data, previewId, index) {
        x = data
        var tempID = 1;
        formIdFileIdNumaraVer = data.response.filepath.replace("\"", "").replace("\"", "");
        $("#previewUpload").append("<div class='mahmut' id='" + formIdFileIdNumaraVer + "'><ul class='collection'><li class='collection-item avatar'><img src='../../img/FileIcons/doc.png' alt='' title='' class='circle'/><span class='title'>" + 'Validation' + "</span><p><a target='_blank' href='" + '/Documents/' + formIdFileIdNumaraVer + "'  aria-label='T'><span>" + formIdFileIdNumaraVer + "</span></a></p><button type='button' onclick=\"RemoveThisFile('" + formIdFileIdNumaraVer + "','" + tempID + "')\" id=\"clearThisFileForm\" fValue='" + '(' + formId + ')' + formIdFileIdNumaraVer + "' class='rkmd-btn btn-fab-mini btn-pink ripple-effect secondary-content'><i class='zmdi zmdi-delete'></i></button></li></ul></div>")
        tempID += 1;
    })
}


function CreateFileUploadVMA(id, ftype, mTbl, upcontrol) {

    //$(".file-loading").fileinput("destroy");
    var zurl = "/Uploader.ashx?id=" + id + "&ftype=" + ftype + "&mTbl=" + mTbl + "&MyPath=" + getTimeForURL();// ftype direk BIA olabilir.
    $("#" + upcontrol).fileinput({
        uploadUrl: zurl, // server upload action
        uploadAsync: false,
        showCaption: false,
        dropZoneEnabled: false,
        browseClass: "xfile",
        showRemove: false,
        showUpload: false, //// file input uploaded fonksiyonu bunda çalışmadı 
        maxFileSize: "200000000",
        allowedFileExtensions: ["txt", "md", "ini", "image", "text", "img", "object", "html", "pdf", "xls", "csv", "doc", "docx", "one", "rar", "zip", "mp4", "ogg", "zip", "png", "jpg", "jpeg", "gif", "ppt", "pptx", "xlsx"],
        maxFileCount: 1,
        uploadExtraData: {

        }
    })
    $("#" + upcontrol + "").on('fileuploaded', function (event, data, previewId, index) {
        x = data
        var tempID = 1;
        formIdFileIdNumaraVer = data.response.filepath.replace("\"", "").replace("\"", "");       
        $("#previewUpload").append("<div class='mahmut' id='" + formIdFileIdNumaraVer + "'><ul class='collection'><li class='collection-item avatar'><img src='../../img/FileIcons/doc.png' alt='' title='' class='circle'/><span class='title'>" + 'Vendor Maintenance Agrement' + "</span><p><a target='_blank' href='" + '/Documents/' + formIdFileIdNumaraVer + "'  aria-label='T'><span>" + formIdFileIdNumaraVer + "</span></a></p><button type='button' onclick=\"RemoveThisFile('" + formIdFileIdNumaraVer + "','" + tempID + "')\" id=\"clearThisFileForm\" fValue='" + '(' + formId + ')' + formIdFileIdNumaraVer + "' class='rkmd-btn btn-fab-mini btn-pink ripple-effect secondary-content'><i class='zmdi zmdi-delete'></i></button></li></ul></div>")
        tempID += 1;
    })
}