class MakeOrderVM {
    constructor() {
        this.products = ko.observableArray([]);
        this.isEmpty = ko.computed(() => this.products().length === 0);
    }

    initialize() {
        this.applyBindings();
        this.bindEvents();
    }

    dropProduct(product) {
        $(document).trigger('make-order.product.dropt', { product: product });
    }

    purchase() {
        $(document).trigger('purchase.open', { products: this.products() });
    }

    applyBindings() {
        ko.applyBindings(this, document.getElementById('make-order'));
    }

    bindEvents() {
        $(document).off('product.bought').on('product.bought', (event, data) => {
            this.products.push(data);
        });

        $(document).off('product.dropt').on('product.dropt', (event, data) => {
            this.products.splice(this.products.indexOf(data), 1);
        });

        $(document).off('order.clear').on('order.clear', () => {
            this.products().forEach(p => {
                this.dropProduct(p);
            });

            this.products.removeAll();
        });
    }
}