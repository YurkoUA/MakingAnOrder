var Purchase = Purchase || {};

(function () {
    var self = this;

    self.products = ko.observableArray([]);

    self.totalSum = ko.computed(function () {
        var sum = 0;

        for (var i in self.products()) {
            sum += self.products()[i].TotalPrice();
        }

        return sum;
    });

    self.purchase = function () {
        AjaxService.post('/Home/Purchase', self.getModel(), function (data) {
            toastr.success('The order has been purchased successfully!');
            ModalService.close('purchase-modal');
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

    ko.applyBindings(self, document.getElementById('purchase-modal'));
}).apply(Purchase);