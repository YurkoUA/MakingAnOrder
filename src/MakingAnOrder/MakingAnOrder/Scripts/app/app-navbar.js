var AppNavbar = AppNavbar || {};

(function () {
    var self = this;

    self.initialize = function () {
        ko.applyBindings(self, document.getElementById('app-navbar'));
    }

    self.openOrderHistory = function () {
        var modalId = 'order-history-modal';
        ModalService.show(modalId);
        orderHistory.initialize();

        ModalService.onClosed(modalId, function () {
            orderHistory.reset();
        });
    };
}).apply(AppNavbar);