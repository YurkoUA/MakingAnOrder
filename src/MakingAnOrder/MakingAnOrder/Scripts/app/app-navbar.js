var AppNavbar = AppNavbar || {};

(function () {
    var self = this;

    self.initialize = function () {
        ko.applyBindings(self, document.getElementById('app-navbar'));
    }

    self.openOrderHistory = function () {
        var modal = new ModalWindow('#order-history-modal');
        modal.onShow(() => orderHistory.initialize());
        modal.onHide(() => orderHistory.reset());
        modal.show();
    };
}).apply(AppNavbar);