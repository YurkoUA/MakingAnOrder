var AppNavbar = AppNavbar || {};

(function () {
    var self = this;

    self.openOrderHistory = function () {
        var modalId = 'order-history-modal';
        ModalService.show(modalId);
        //OrderHistory.initialize();

        ModalService.onClosed(modalId, function () {
            OrderHistory.clear();
        });
    };

    ko.applyBindings(self, document.getElementById('app-navbar'));
}).apply(AppNavbar);