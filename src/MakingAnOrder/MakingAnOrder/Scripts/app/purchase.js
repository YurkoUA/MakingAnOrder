var Purchase = Purchase || {};

(function () {
    var self = this;
    var modalId = 'purchase-modal';
    var submitUrl = '';

    self.initialize = function (url) {
        submitUrl = url;
        ko.applyBindings(self, document.getElementById(modalId));
    }

    self.products = ko.observableArray([]);

    self.totalSum = ko.computed(function () {
        var sum = 0;

        for (var i in self.products()) {
            sum += self.products()[i].TotalPrice();
        }

        return sum;
    });

    self.purchase = function () {
        AjaxService.post(submitUrl, self.getModel(), function (data) {
            toastr.success('The order has been purchased successfully!');
            ModalService.close(modalId);
        });
    };

    self.getModel = function () {
        return self.products().map(function (p) {
            return {
                Id: p.Id(),
                Discount: p.Discount()
            }
        });
    };
}).apply(Purchase);