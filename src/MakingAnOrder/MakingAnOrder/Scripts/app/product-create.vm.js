class ProductCreateVM {
    constructor() {
        this.Id = ko.observable();
        this.Name = ko.observable();
        this.Description = ko.observable();
        this.Price = ko.observable();
        this.IsNewProduct = ko.computed(() => {
            this.Id() === undefined;
        });

        this.submitUrl = null;
        this.modalId = null;
        this.formId = null;

        this.validationRules = null;
    }

    initialize(submitUrl, modalId, formId) {
        this.submitUrl = submitUrl;
        this.modalId = modalId;
        this.formId = formId;

        this.applyBindings();
        this.bindEvents();
        this.initializeValidation();
    }

    createProduct() {
        $('#' + this.formId).validate({
            rules: this.validationRules,
            errorElement: 'span',
            errorClass: 'text-danger'
        });

        if ($('#' + this.formId).valid()) {
            var data = this.getRequestModel();

            $.ajax(this.submitUrl, {
                method: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: (data) => {
                    toastr.success('The product has been added successfully!');
                    this.Id(+data.Id);
                    this.triggerCreatedEvent();
                    this.reset();
                },
                error: () => {
                    toastr.error('Error!');
                }
            });
        }
    }

    getRequestModel() {
        return {
            Name: this.Name(),
            Description: this.Description(),
            Price: this.Price()
        };
    }

    reset() {
        this.Id(null);
        this.Name(null);
        this.Description(null);
        this.Price(null);
    }

    triggerCreatedEvent() {
        var product = new Product();
        product.Id = this.Id;
        product.Name = this.Name;
        product.Description = this.Description;
        product.Price = this.Price;

        $(document).trigger('product.created', { product: product });
    }

    initializeValidation() {
        this.validationRules = {
            Name: {
                required: true,
                minlength: 3,
                maxlength: 64
            },
            Description: {
                required: false,
                maxlength: 256
            },
            Price: {
                required: true,
                number: true,
                range: [1, 149999]
            }
        };
    }

    applyBindings() {
        ko.applyBindings(this, document.getElementById(this.modalId));
    }

    bindEvents() {
        $(document).off('product-create.open').on('product-create.open', () => {
            var modal = new ModalWindow('#' + this.modalId);
            modal.show();
        });
    }
}