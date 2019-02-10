var OrderHistoryController = /** @class */ (function () {
    function OrderHistoryController(orderHistoryUrl, tableId, startDatePickerId, endDatePickerId, applyFiltersBtnId) {
        this.orderHistoryUrl = orderHistoryUrl;
        this.tableId = tableId;
        this.startDatePickerId = startDatePickerId;
        this.endDatePickerId = endDatePickerId;
        this.applyFiltersBtnId = applyFiltersBtnId;
    }
    OrderHistoryController.prototype.initialize = function () {
        this.initializeDatePickers();
        this.initializeDataTable();
        this.bindEvents();
    };
    OrderHistoryController.prototype.reset = function () {
        this.table.destroy();
    };
    OrderHistoryController.prototype.runTable = function () {
        $('#' + this.tableId).DataTable().draw();
    };
    OrderHistoryController.prototype.initializeDatePickers = function () {
        var opts = {
            format: Constants.DateTime.ShortDate
        };
        var start = moment().utc().startOf('month').format(Constants.DateTime.MomentShortDate);
        var end = moment().utc().endOf('month').format(Constants.DateTime.MomentShortDate);
        $('#' + this.startDatePickerId).datepicker(opts);
        $('#' + this.endDatePickerId).datepicker(opts);
        $('#' + this.startDatePickerId).datepicker('update', start);
        $('#' + this.endDatePickerId).datepicker('update', end);
    };
    OrderHistoryController.prototype.initializeDataTable = function () {
        var _this = this;
        this.table = $('#' + this.tableId).DataTable({
            processing: true,
            serverSide: true,
            ajax: {
                url: this.orderHistoryUrl,
                method: 'POST',
                contentType: Constants.JSON_MIME,
                data: function (data) {
                    var start = $('#' + _this.startDatePickerId).datepicker(Constants.Datepicker.getUTCDate).format(Constants.DateTime.MomentShortDate);
                    var end = $('#' + _this.endDatePickerId).datepicker(Constants.Datepicker.getUTCDate).format(Constants.DateTime.MomentShortDate);
                    data.startDate = start;
                    data.endDate = end;
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
    };
    OrderHistoryController.prototype.buildSubgrid = function (data) {
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
    };
    OrderHistoryController.prototype.bindEvents = function () {
        var _this = this;
        $('#' + this.applyFiltersBtnId).off('click').on('click', function (event, data) {
            _this.runTable();
        });
        $('#' + this.tableId).off('click').on('click', 'td.details-control', function (event, data) {
            var tr = $(event.target).closest('tr');
            var row = $('#' + _this.tableId).DataTable().row(tr);
            if (row.child.isShown()) {
                row.child.hide();
                tr.removeClass('shown');
            }
            else {
                row.child(_this.buildSubgrid(row.data())).show();
                tr.addClass('shown');
            }
        });
    };
    return OrderHistoryController;
}());
//# sourceMappingURL=order-history.controller.js.map