function doAjax(method, url, data, success) {
    $.ajax({
        method: method,
        url: url,
        data: data,
        dataType: 'json',
        cache: false,
        beforeSend: function () { $('#loadeux').css('display', ''); },
        complete: function () { $('#loadeux').css('display', 'none'); },
        success: function (result) {
            success(result);
        },
        error: function (err) {
            switch (method) {
                case "POST": msgError("Failed to submit data with error: " + err); break;
                case "GET": msgError("Failed to retrieve data with error:" + err); break;
            }
        }
    });
}