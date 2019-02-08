var MainPage = MainPage || {};

(function MainPage() {
    var self = this;

    self.initialize = function () {
        initEvents();
        ko.applyBindings(self.viewModel, document.getElementById('main-grid'));
    }

    self.ProductVM = function (product) {
        var vm = this;

        vm.Id = ko.observable(product.Id);
        vm.Name = ko.observable(product.Name);
        vm.Description = ko.observable(product.Description);
        vm.Price = ko.observable(product.Price);

        vm.InOrder = ko.observable(false);
        vm.Discount = ko.observable(0);

        vm.TotalPrice = ko.computed(function () {
            return self.calculateProductTotalPrice(vm.Price(), vm.Discount());
        });
    };

    self.calculateProductTotalPrice = function (price, discount) {
        if (isNaN(price) || !isFinite(price)) {
            return 0;
        }

        if (isNaN(discount) || !isFinite(discount) || discount < 0 || discount >= price) {
            return price;
        }

        return price - discount;
    }

    self.buyProduct = function (product) {
        product.InOrder(true);
        self.viewModel.orderProductsList.push(product);
    }

    self.dropProduct = function (product) {
        product.InOrder(false);
        self.viewModel.orderProductsList.splice(self.viewModel.orderProductsList.indexOf(product), 1);
    }

    self.viewModel = {
        productsList: ko.observableArray([]),
        orderProductsList: ko.observableArray([]),

        buyProduct: function (product) {
            self.buyProduct(product);
        },
        dropProduct: function (product) {
            self.dropProduct(product);
        },
        handleProduct: function (product) {
            if (product.InOrder()) {
                self.viewModel.dropProduct(product);
            } else {
                self.viewModel.buyProduct(product);
            }
        },
        purchase: function () {
            Purchase.products(self.viewModel.orderProductsList());
            ModalService.show('purchase-modal');
        },
        addProduct: function () {
            ProductCreate.onProductAdded = function (product) {
                self.viewModel.productsList.push(new self.ProductVM(product));
                ModalService.close('product-create-modal');
            };

            ModalService.show('product-create-modal');
        }
    };

    function initEvents() {
        $(document).off('order.clear').on('order.clear', function () {
            self.viewModel.orderProductsList().forEach(function (p) {
                self.viewModel.dropProduct(p);
            });
        });
    }
}).apply(MainPage);