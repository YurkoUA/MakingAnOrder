var OrderHistory = OrderHistory || {};

(function () {
    var self = this;

    var table = null;
    var tableSelector = 'table#order-history-table';
    var startDatePickerSelector = '#start-date-picker';
    var endDatePickerSelector = '#end-date-picker';

    self.orderHistoryUrl = '';

    
    self.initialize = function () {
        initalizeDatepickers();
        initalizeDatatable();
        bindEvents();
        applyBindings();
    };

    self.reset = function () {
        table.destroy();
        resetBindings();
    };
    
    self.OrderVM = function (order) {
        var vm = this;

        vm.Id = ko.observable(order.Id);
        vm.Date = ko.observable(new Date(order.Date).format(Constants.DateTime.ShortDate));
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
        column: ko.observable('Id'),
        direction: ko.observable('DESC')
    };

    self.viewModel = {
        orders: ko.observableArray([]),
        filter: self.filter,

        resetFilter: function () {
            self.filter.offset(0);
            self.filter.take(20);
            self.filter.column('Id');
            self.filter.direction('DESC');
        },
        getOrders: function () {
            self.viewModel.orders([]);
        },
        getFilterAsModel: function () {
            return {
                offset: self.filter.offset(),
                take: self.filter.take(),
                column: self.filter.column(),
                direction: self.filter.direction()
            };
        },
        runTable: function () {
            $(tableSelector).DataTable().draw();
        }
    };

    function initalizeDatatable() {
        table = $(tableSelector).DataTable({
            processing: true,
            serverSide: true,
            ajax: {
                url: self.orderHistoryUrl,
                method: 'POST',
                contentType: Constants.JSON_MIME,
                data: function (data) {
                    if (self.viewModel) {
                        var start = $(startDatePickerSelector).datepicker(Constants.Datepicker.getUTCDate).format(Constants.DateTime.MomentShortDate);
                        var end = $(endDatePickerSelector).datepicker(Constants.Datepicker.getUTCDate).format(Constants.DateTime.MomentShortDate);

                        data.startDate = start;
                        data.endDate = end;
                    }
                    return JSON.stringify(data);
                }
            },
            columns: [
                {
                    "className": 'details-control',
                    "orderable": false,
                    "data": null,
                    "defaultContent": ''
                },
                { data: 'Id', name: 'Id' },
                { data: 'Date', name: 'Date' },
                { data: 'TotalPrice', name: 'TotalPrice' },
                { data: 'ProductsQuantity', name: 'ProductsQuantity' }
            ],
            columnDefs: [
                {
                    targets: 2, render: function (data) {
                        return moment(data).format(Constants.DateTime.MomentShortDate);
                    }
                }
            ]
        });
    }

    function initalizeDatepickers() {
        var opts = {
            format: Constants.DateTime.ShortDate
        };

        var start = moment().utc().startOf('month').format(Constants.DateTime.MomentShortDate);
        var end = moment().utc().endOf('month').format(Constants.DateTime.MomentShortDate);

        $(startDatePickerSelector).datepicker(opts);
        $(endDatePickerSelector).datepicker(opts);

        $(startDatePickerSelector).datepicker('update', start);
        $(endDatePickerSelector).datepicker('update', end);
    }

    function buildSubgrid(data) {
        var table = '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">';

        for (var i in data.Products) {
            table += '<tr>';

            table += '<td><b>Name: </b>' + data.Products[i].Name + '</td>';
            table += '<td><b>Original Price: </b>' + data.Products[i].OriginalPrice + '</td>';
            table += '<td><b>Discount: </b>' + data.Products[i].Discount + '</td>';
            table += '<td><b>Quantity: </b>' + data.Products[i].Quantity + '</td>';

            table += '</tr>';
        }

        return table + '</table>';
    }

    function bindEvents() {
        $(tableSelector).on('click', 'td.details-control', function () {
            var tr = $(this).closest('tr');
            var row = table.row(tr);

            if (row.child.isShown()) {
                row.child.hide();
                tr.removeClass('shown');
            }
            else {
                row.child(buildSubgrid(row.data())).show();
                tr.addClass('shown');
            }
        });
    }

    function applyBindings() {
        ko.applyBindings(self.viewModel, document.getElementById('order-history-modal'));
    }

    function resetBindings() {
        ko.cleanNode(document.getElementById('order-history-modal'));
    }
}).apply(OrderHistory);