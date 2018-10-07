var ModalService = ModalService || {};

(function () {
    var self = this;

    self.show = function (modalId) {
        $('#' + modalId).modal('show');
    };

    self.close = function (modalId) {
        $('#' + modalId).modal('hide');
    };

    self.onClosed = function (modalId, onClosed) {
        $('#' + modalId).on('hidden.bs.modal', function (e) {
            onClosed();
        });
    };
}).apply(ModalService);