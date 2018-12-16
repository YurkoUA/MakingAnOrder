var AppNavbar = AppNavbar || {};

(function () {
    var self = this;

    self.initialize = function () {
        ko.applyBindings(self, document.getElementById('app-navbar'));
    }

    self.openOrderHistory = function () {
        var modalId = 'order-history-modal';
        ModalService.show(modalId);
        OrderHistory.initialize();

        ModalService.onClosed(modalId, function () {
            OrderHistory.reset();
        });
    };
}).apply(AppNavbar);