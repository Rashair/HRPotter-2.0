var ViewModel = function(count) {
    this.count = ko.observable(count);
};

var viewModel = new ViewModel();
ko.applyBindings(viewModel);

$(document).ready(() => {
    $loading = $('#loadingSpinner');

    var getOffers = function (author, val) {
        $.ajax({
            url: '/JobOffers/GetOffersTable?e=' + author + '&query=' + val,
            type: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#tableContent').html(data);
            },
            error: function () {
                alert('Error! Please try again.');
            }
        }).done(function () {
            $loading.hide();
        });
    }
    getOffers($('#author').val(), "");

    $('#searchForm').submit(function searchApplications(e) {
        e.preventDefault();
        $('#tableContent').html("");
        $loading.show();

        let val = $(this).find('input#searchInput').val();
        let author = $(this).find('input#author').val();
        getOffers(author, val);
    });
});
