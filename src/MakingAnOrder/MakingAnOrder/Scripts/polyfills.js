Date.prototype.format = function (format) {
    return moment(this).format(format);
};

Date.prototype.monthStart = function () {
    return moment(this).startOf('month').toDate();
};

Date.prototype.monthEnd = function () {
    return moment(this).endOf('month').toDate();
};