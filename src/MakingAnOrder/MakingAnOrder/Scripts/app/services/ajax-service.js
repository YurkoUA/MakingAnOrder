var AjaxService = AjaxService || {};

(function AjaxService() {
    var self = this;

    self.get = function (url, success) {
        $.ajax({
            url: url,
            type: 'GET',
            success: function (data, textStatus, jqXHR) {
                success(data);
            },
            error: OnError
        });
    };

    self.post = function (url, data, success) {
        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(data),
            dataType: 'json',
            contentType: 'application/json',
            success: function (data, textStatus, jqXHR) {
                success(data);
            },
            error: OnError
        })
    };

    function OnError(jqXHR, textStatus, errorThrown) {
        var errors;

        if (jqXHR.responseText.length > 0) {
            errors = JSON.parse(jqXHR.responseText).join('\n');
        }

        ToastrService.error(errors);
    }

    function ErrorToast(errors) {
        if (!errors) {
            errors = 'Something happened. Try to reload the page.';
        }
        ToastrService.error(errors);
    }
}).apply(AjaxService);