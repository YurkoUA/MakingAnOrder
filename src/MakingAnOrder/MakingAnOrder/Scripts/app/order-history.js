var OrderHistory = OrderHistory || {};

(function () {
    var self = this;

    function Initialize(data) {
        $('table#order-history-table').DataTable({
            data: data,
            columns: [
                { data: 'Id' },
                { data: 'Date' },
                { data: 'TotalPrice' },
                { data: 'ProductsQuantity' }
            ]
        });
    }

    self.OrderVM = function (order) {
        var vm = this;

        vm.Id = ko.observable(order.Id);
        vm.Date = ko.observable(new Date(order.Date).format('DD.MM.YYYY'));
        vm.TotalPrice = ko.observable(order.TotalPrice);
        vm.ProductsQuantity = ko.observable(order.ProductsQuantity);
        vm.Products = ko.observableArray([]);

        if (order.Products && Array.isArray(order.Products)) {
            for (var i in order.Products) {
                vm.Products.push(new self.OrderProductVM(order.Products[i]));
            }
        }
    };

    self.OrderProductVM = function (product) {
        var vm = this;

        vm.Price = ko.observable(product.Price);
        vm.Discount = ko.observable(product.Discount);
        vm.Quantity = ko.observable(product.Quantity);
    };

    self.filter = {
        offset: ko.observable(0),
        take: ko.observable(20),
        startDate: ko.observable(new Date().monthStart()),
        endDate: ko.observable(new Date().monthEnd()),
        column: ko.observable('Id'),
        direction: ko.observable('DESC')
    };

    self.viewModel = {
        orders: ko.observableArray([]),
        filter: self.filter,
        resetFilter: function () {
            self.filter.offset(0);
            self.filter.take(20);
            self.filter.startDate(new Date().monthStart());
            self.filter.endDate(new Date().monthEnd());
            self.filter.column('Id');
            self.filter.direction('DESC');
        },
        getOrders: function () {
            self.viewModel.orders([]);

            AjaxService.get('/Home/Orders/?' + $.param(self.viewModel.getFilterAsModel()), function (data) {
                if (data && Array.isArray(data)) {
                    for (var i in data) {
                        self.viewModel.orders.push(new self.OrderVM(data[i]));
                    }

                    Initialize(self.viewModel.orders());
                }
            });
        },
        getFilterAsModel: function () {
            return {
                offset: self.filter.offset(),
                take: self.filter.take(),
                startDate: self.filter.startDate().format('YYYY-MM-DD'),
                endDate: self.filter.endDate().format('YYYY-MM-DD'),
                column: self.filter.column(),
                direction: self.filter.direction()
            };
        }
    };

    ko.applyBindings(self.viewModel, document.getElementById('order-history-modal'));
}).apply(OrderHistory);