class Product {
    constructor() {
        this.Id = ko.observable();
        this.Name = ko.observable();
        this.Description = ko.observable();
        this.Price = ko.observable(0);
        this.InOrder = ko.observable(false);
        this.Discount = ko.observable(0);
        this.TotalPrice = ko.computed(() => this.calculateTotalPrice());
    }

    initialize(product) {
        this.Id(product.Id);
        this.Name(product.Name);
        this.Description(product.Description);
        this.Price(product.Price);
    }

    calculateTotalPrice() {
        let price = this.Price();
        let discount = this.Discount();

        if (isNaN(price) || !isFinite(price)) {
            return 0;
        }

        if (isNaN(discount) || !isFinite(discount) || discount < 0 || discount >= price) {
            return price;
        }

        return price - discount;
    }
}