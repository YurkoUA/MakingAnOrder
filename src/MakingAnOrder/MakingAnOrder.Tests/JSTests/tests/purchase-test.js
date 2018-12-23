describe('JS Tests - Purchase', () => {
    it('totalSum - returns 100', () => {
        var products = [{
            TotalPrice: ko.observable(40),
        }, {
            TotalPrice: ko.observable(5)
        }, {
            TotalPrice: ko.observable(55)
        }];

        Purchase.products(products);

        var expectedTotalSum = 100;
        var actualTotalSum = Purchase.totalSum();

        expect(expectedTotalSum).toEqual(actualTotalSum);
    });

    it('purchase - modal is closed', () => {
        spyOn(ModalService, 'close');
        spyOn(toastr, 'success');
        spyOn(Purchase, 'getModel');

        spyOn(AjaxService, 'post').and.callFake(function (url, product, callback) {
            callback();
        });

        Purchase.purchase();

        expect(ModalService.close).toHaveBeenCalled();
    });
});