﻿var ProductCreate = ProductCreate || {};

(function () {
    var self = this;
    var modalId = 'product-create-modal';

    self.initialize = function () {
        ko.applyBindings(new self.viewModel(), document.getElementById(modalId));

        ModalService.onClosed(modalId, function () {
            ko.cleanNode(document.getElementById(modalId));
        });
    }

    self.onProductAdded;

    self.viewModel = function () {
        var vm = this;

        vm.Id = ko.observable();
        vm.Name = ko.observable();
        vm.Description = ko.observable();
        vm.Price = ko.observable();

        vm.IsNewProduct = ko.computed(function () {
            return vm.Id() === undefined;
        });

        vm.createProduct = function () {
            var rules = {
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

            $("#product-create-form").validate({
                rules: rules,
                errorElement: 'span',
                errorClass: 'text-danger'
            })

            if ($("#product-create-form").valid()) {
                var product = vm.getModel();

                AjaxService.post('/Home/CreateProduct', product, function (data) {
                    toastr.success('The product has been added successfully!');
                    self.onProductAdded(data);
                    vm.reset();
                });
            }
        };

        vm.getModel = function () {
            return {
                Name: vm.Name(),
                Description: vm.Description(),
                Price: vm.Price()
            };
        };

        vm.reset = function () {
            vm.Id(undefined);
            vm.Name(undefined);
            vm.Description(undefined);
            vm.Price(undefined);
        };
    };
}).apply(ProductCreate);