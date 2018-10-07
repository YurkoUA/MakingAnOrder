var ToastrService = ToastrService || {};

(function () {
    var self = this;

    self.error = function (text) {
        toastr.error(text, 'Error', { positionClass: 'toast-top-right' });
    };
}).apply(ToastrService);