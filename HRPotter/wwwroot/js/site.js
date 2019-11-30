// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var ViewModel = function (count) {
    this.count = ko.observable(count);
};

viewModel = new ViewModel();
ko.applyBindings(viewModel);