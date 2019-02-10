class PurchaseVM {
    constructor() {
        this.submitUrl = null;
        this.modalId = null;
        this.modal = null;

        this.products = ko.observableArray([]);
        this.totalSum = ko.computed(() => {
            var sum = 0;

            this.products().forEach(p => {
                sum += p.TotalPrice();
            });

            return sum;
        });
    }

    initialize(submitUrl, modalId) {
        this.submitUrl = submitUrl;
        this.modalId = modalId;
        this.modal = new ModalWindow('#' + modalId);
        this.applyBindings();
        this.bindEvents();
    }

    purchase() {
        var data = this.getRequestModel();

        $.ajax(this.submitUrl, {
            data: JSON.stringify(data),
            contentType: 'application/json',
            method: 'POST',
            success: (data) => {
                toastr.success('The order has been purchased successfully!');
                this.modal.hide();
                $(document).trigger('order.clear');
            },
            error: () => {
                toastr.error('Error!');
            }
        });
    }

    getRequestModel() {
        var purchaseModel = this.products().map(p => {
            return {
                Id: p.Id(),
                Discount: p.Discount()
            };
        });

        return purchaseModel;
    }

    applyBindings() {
        ko.applyBindings(this, document.getElementById(this.modalId));
    }

    bindEvents() {
        $(document).off('purchase.open').on('purchase.open', (event, data) => {
            this.products(data.products);
            this.modal.show();
        });
    }
}