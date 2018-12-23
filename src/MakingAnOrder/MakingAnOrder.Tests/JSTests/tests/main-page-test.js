describe('JS Tests - Main Page', () => {
    it('calculateProductTotalPrice - returns Price if Discount less than 0', () => {
        var price = 100;
        var discount = -3;

        var totalPrice = MainPage.calculateProductTotalPrice(price, discount);

        expect(totalPrice).toEqual(price);
    });

    it('calculateProductTotalPrice - returns Price if Discount the same', () => {
        var price = 99;
        var discount = 99;

        var totalPrice = MainPage.calculateProductTotalPrice(price, discount);

        expect(totalPrice).toEqual(price);
    });

    it('calculateProductTotalPrice - returns Price if Discount is greater', () => {
        var price = 99;
        var discount = 199;

        var totalPrice = MainPage.calculateProductTotalPrice(price, discount);

        expect(totalPrice).toEqual(price);
    });

    it('calculateProductTotalPrice - returns TotalPrice if Discount is less than Price and greater than 0', () => {
        var price = 200;
        var discount = 50;
        var expTotalPrice = 150;

        var actTotalPrice = MainPage.calculateProductTotalPrice(price, discount);

        expect(actTotalPrice).toEqual(expTotalPrice);
    });

    it('calculateProductTotalPrice - returns 0 if Price is undefined', () => {
        var price = undefined;
        var discount = 50;

        var actTotalPrice = MainPage.calculateProductTotalPrice(price, discount);

        expect(actTotalPrice).toEqual(0);
    });

    it('calculateProductTotalPrice - returns Price if Discount is undefined', () => {
        var price = 100;
        var discount = undefined;

        var actTotalPrice = MainPage.calculateProductTotalPrice(price, discount);

        expect(actTotalPrice).toEqual(price);
    });

    it('buyProduct - product goes to orderProductsList, InOrder becomes true', () => {
        var product = new MainPage.ProductVM({
            Id: 0,
            Name: 'Mars',
            Price: 20
        });

        MainPage.buyProduct(product);

        expect(product.InOrder()).toBeTruthy();
        expect(MainPage.viewModel.orderProductsList.indexOf(product)).toBeGreaterThan(-1);
    });

    it('dropProduct - product is removed from orderProductsList, InOrder becomes false', () => {
        var product = new MainPage.ProductVM({
            Id: 0,
            Name: 'Mars',
            Price: 20
        });

        MainPage.dropProduct(product);

        expect(product.InOrder()).toBeFalsy();
        expect(MainPage.viewModel.orderProductsList.indexOf(product)).toEqual(-1);
    });
});