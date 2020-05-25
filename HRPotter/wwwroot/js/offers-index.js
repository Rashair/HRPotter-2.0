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
    $('#pagingContent').html("");
    $loading.show();

    let val = $('input#searchInput').val();
    _getOffers(val, pageSize, pageNo);
}

function _getOffers(val, pageSize, pageNo) {
    $.ajax({
        url: 'https://cz7k3d7r2i.execute-api.us-east-1.amazonaws.com/Prod/JobOffers/GetOffersTable',
        type: 'GET',
        data: { pageNo: pageNo, pageSize: pageSize, searchString: val },
        dataType: 'html',
        success: function (data) {
            $.ajax({
                url: 'https://cz7k3d7r2i.execute-api.us-east-1.amazonaws.com/Prod/JobOffers/GetPagingBar',
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
