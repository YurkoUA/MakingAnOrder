var MainPage = MainPage || {};

(function MainPage() {
    var self = this;

    self.ProductVM = function (product) {
        var vm = this;

        vm.Id = ko.observable(product.Id);
        vm.Name = ko.observable(product.Name);
        vm.Description = ko.observable(product.Description);
        vm.Price = ko.observable(product.Price);

        vm.InOrder = ko.observable(false);
        vm.Discount = ko.observable(0);

        vm.TotalPrice = ko.computed(function () {
            if (vm.Discount() == undefined || isNaN(vm.Discount()) || !isFinite(vm.Discount()) || vm.Discount() >= vm.Price() || vm.Discount() < 0) {
                return vm.Price();
            }

            return vm.Price() - vm.Discount();
        });

        vm.Buy = function () {
            vm.InOrder(!vm.InOrder());
        };
    };

    self.viewModel = {
        productsList: ko.observableArray([]),
        orderProductsList: ko.observableArray([]),

        buyProduct: function (product) {
            product.Buy();

            if (product.InOrder()) {
                self.viewModel.orderProductsList.push(product);
            }
        },
        dropProduct: function (product) {
            product.Buy();
            self.viewModel.orderProductsList.splice(self.viewModel.orderProductsList.indexOf(product), 1);
        },
        purchase: function () {
            
        }
    };

    ko.applyBindings(self.viewModel);
}).apply(MainPage);