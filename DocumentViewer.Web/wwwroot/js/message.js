'use strict';

function msgError(s) {
    BootstrapDialog.show({
        title: 'ERROR',
        message: s,
        type: BootstrapDialog.TYPE_DANGER,
        closable: true,
        draggable: true,
        buttons: [{
            label: '<span class="glyphicon glyphicon-ok"></span>&nbsp;&nbsp;OK',
            cssClass: 'btn-default btn-sm',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }],
        callback: function (result) {
            // result will be true if button was click, while it will be false if users close the dialog directly.
        }
    });
}