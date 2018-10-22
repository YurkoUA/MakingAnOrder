var AppNavbar = AppNavbar || {};

(function () {
    var self = this;

    self.openOrderHistory = function () {
        var modalId = 'order-history-modal';
        ModalService.show(modalId);
        OrderHistory.viewModel.getOrders();

        ModalService.onClosed(modalId, function () {
            OrderHistory.viewModel.resetFilter();
        });
    };

    ko.applyBindings(self, document.getElementById('app-navbar'));
}).apply(AppNavbar);