describe('JS Tests - ProductCreate', () => {
    it('createProduct - onProductAdded callback is called when form is valid', () => {
        spyOn(AjaxService, 'post').and.callFake(function (url, product, callback) {
            callback();
        });

        spyOn($.fn, 'valid').and.returnValue(true);
        spyOn($.fn, 'validate');
        spyOn(toastr, 'success');

        ProductCreate.onProductAdded = () => { };
        spyOn(ProductCreate, 'onProductAdded');

        var viewModel = new ProductCreate.viewModel();
        viewModel.createProduct();
        expect(ProductCreate.onProductAdded).toHaveBeenCalled();
    });

    it('createProduct - onProductAdded callback is not called when form is invalid', () => {
        spyOn(AjaxService, 'post').and.callFake(function (url, product, callback) {
            callback();
        });

        spyOn($.fn, 'valid').and.returnValue(false);
        spyOn($.fn, 'validate');
        spyOn(toastr, 'success');

        ProductCreate.onProductAdded = () => { };
        spyOn(ProductCreate, 'onProductAdded');

        var viewModel = new ProductCreate.viewModel();
        viewModel.createProduct();
        expect(ProductCreate.onProductAdded).not.toHaveBeenCalled();
    });
});