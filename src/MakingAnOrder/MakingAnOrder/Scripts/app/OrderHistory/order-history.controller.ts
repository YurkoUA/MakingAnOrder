declare var Constants;

class OrderHistoryController {
    private table: any;

    constructor(private orderHistoryUrl: string,
        private tableId: string,
        private startDatePickerId: string,
        private endDatePickerId: string,
        private applyFiltersBtnId: string) {

    }

    initialize(): void {
        this.initializeDatePickers();
        this.initializeDataTable();
        this.bindEvents();
    }

    reset(): void {
        this.table.destroy();
    }

    private runTable(): void {
        $('#' + this.tableId).DataTable().draw();
    }

    private initializeDatePickers(): void {
        var opts = {
            format: Constants.DateTime.ShortDate
        };

        var start = moment().utc().startOf('month').format(Constants.DateTime.MomentShortDate);
        var end = moment().utc().endOf('month').format(Constants.DateTime.MomentShortDate);

        $('#' + this.startDatePickerId).datepicker(opts);
        $('#' + this.endDatePickerId).datepicker(opts);

        $('#' + this.startDatePickerId).datepicker('update', start);
        $('#' + this.endDatePickerId).datepicker('update', end);
    }

    private initializeDataTable(): void {
        this.table = $('#' + this.tableId).DataTable({
            processing: true,
            serverSide: true,
            ajax: {
                url: this.orderHistoryUrl,
                method: 'POST',
                contentType: Constants.JSON_MIME,
                data: (data) => {
                    var start = $('#' + this.startDatePickerId).datepicker(Constants.Datepicker.getUTCDate).format(Constants.DateTime.MomentShortDate);
                    var end = $('#' + this.endDatePickerId).datepicker(Constants.Datepicker.getUTCDate).format(Constants.DateTime.MomentShortDate);

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
    }

    private buildSubgrid(data: any): string {
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

    private bindEvents(): void {
        $('#' + this.applyFiltersBtnId).off('click').on('click', (event, data) => {
            this.runTable();
        });

        $('#' + this.tableId).off('click').on('click', 'td.details-control', (event, data) => {
            var tr = $(event.target).closest('tr');
            var row = $('#' + this.tableId).DataTable().row(tr);

            if (row.child.isShown()) {
                row.child.hide();
                tr.removeClass('shown');
            }
            else {
                row.child(this.buildSubgrid(row.data())).show();
                tr.addClass('shown');
            }
        });
    }
}