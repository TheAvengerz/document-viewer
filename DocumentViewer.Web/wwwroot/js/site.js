// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ViewDocument(file) {
    var data = { filename: file };
    doAjax("POST", "/Home/ViewDocument", data, function (result) {
        if (result.success) {
            $("#contentPreview").empty();
            var folderName = file.substr(0, file.lastIndexOf('.')) || file;
            for (var i = 1; i <= result.data; i++) {
                $('#contentPreview').append('<img src="../PreviewFiles/' + folderName + '/page-' + i + '.png" class="img-fluid" />');
            }
        } else {
            msgError(result.msg);
        }
    });
}

// Write your JavaScript code.
$(document).ready(function () {
    var fileName = 'PKB.pdf';
    ViewDocument(fileName);
});
