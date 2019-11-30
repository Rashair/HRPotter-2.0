$(document).ready(() => {
    var $loading = $('#loadingSpinner');
    getOffers($('#author').val(), "");

    $('#searchForm').submit(function searchApplications(e) {
        e.preventDefault();
        $('#tableContent').html("");
        $loading.show();

        let val = $(this).find('input#searchInput').val();
        let author = $(this).find('input#author').val();
        getOffers(author, val);
    });

    function getOffers(author, val) {
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
});
