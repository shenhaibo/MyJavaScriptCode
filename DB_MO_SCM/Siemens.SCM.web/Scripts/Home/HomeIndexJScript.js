/// <reference path="../jquery.validate-vsdoc.js" />
$(document).ready(function () {


    $("#Filedata").uploadify({
        swf: '/Scripts/uploadify/uploadify.swf',
        uploader: '/Home/UploadFile',
        multi: false,
        auto: true,
        fileObjName: 'Filedata'
    });

    $("#ShowText").click(function () {
        $("#div").html("Test");
    });
});