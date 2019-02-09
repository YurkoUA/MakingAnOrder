class MakeOrderVM {
    constructor() {
        this.products = ko.observableArray([]);
    }

    initialize() {
        this.applyBindings();
        this.bindEvents();
    }

    isEmpty() {
        return this.products().length === 0;
    }

    dropProduct(product) {
        $(document).trigger('make-order.product.dropt', product);
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
            this.products.removeAll();
        });
    }
}