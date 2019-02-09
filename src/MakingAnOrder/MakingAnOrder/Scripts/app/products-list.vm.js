class ProductsListVM {
    constructor() {
        this.products = ko.observableArray([]);
    }

    initialize(products) {
        products.forEach(p => {
            let prod = new Product();
            prod.Id(p.Id);
            prod.Name(p.Name);
            prod.Description(p.Description);
            prod.Price(p.Price);
            prod.InOrder(p.InOrder);
            prod.Discount(p.Discount);

            this.products.push(prod);
        });

        this.applyBindings();
        this.bindEvents();

        this.handleProduct = (product) => {
            if (product.InOrder() === true) {
                this.dropProduct(product);
            } else {
                this.buyProduct(product);
            }
        };
    }

    addProduct() {
        //ProductCreate.onProductAdded = function (product) {
        //    self.viewModel.productsList.push(new self.ProductVM(product));
        //    ModalService.close('product-create-modal');
        //};

        ModalService.show('product-create-modal');
    }
    
    buyProduct(product) {
        if (product) {
            product.InOrder(true);
            $(document).trigger('product.bought', product);
        }
    }

    dropProduct(product) {
        if (product) {
            product.InOrder(false);
            $(document).trigger('product.dropt', product);
        }
    }

    getHandleProductCallback(product) {
        if (product.InOrder()) {
            return this.dropProduct;
        }

        return this.buyProduct;
    }

    isEmpty() {
        return this.products().length === 0;
    }

    applyBindings() {
        ko.applyBindings(this, document.getElementById('products-list'));
    }

    bindEvents() {
        $(document).off('make-order.product.dropt').on('make-order.product.dropt', (event, data) => {
            this.dropProduct(data);
        });
    }
}