function MainPage() {
    var self = this;

    self.productsList = ko.observableArray([]);
    self.orderProducts = [];

    self.test = 'Test';
}

ko.applyBindings(MainPage);