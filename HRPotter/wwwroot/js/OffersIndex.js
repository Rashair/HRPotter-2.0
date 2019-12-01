$(document).ready(() => {
    pageSize = 5;
    $loading = $('#loadingSpinner');

    getOffers(1);

    $('#searchForm').submit(function searchApplications(e) {
        e.preventDefault();
        getOffers(1);
    });
});

function getOffers(pageNo) {
    $('#tableContent').html("");
    $loading.show();

    let val = $('input#searchInput').val();
    let author = $('input#author').val();
    _getOffers(author, val, pageSize, pageNo);
}

function _getOffers(author, val, pageSize, pageNo) {
    $.ajax({
        url: '/JobOffers/GetOffersTable?e=' + author + '&query=' + val,
        type: 'GET',
        data: { pageNo: pageNo, pageSize: pageSize },
        dataType: 'html',
        success: function (data) {
            $.ajax({
                url: '/JobOffers/GetPagingBar',
                type: 'GET',
                data: { pageNo: pageNo, pageSize: pageSize, searchString: val },
                dataType: 'html',
                success: function (pagingData) {
                    $('#tableContent').html(data);
                    $('#pagingContent').html(pagingData);
                },
                error: function () {
                    alert('Error! Please try again.');
                }
            }).done(function () {
                $loading.hide();
            });
        },
        error: function () {
            alert('Error! Please try again.');
            $loading.hide();
        }
    }).done(function () {
    });
}
