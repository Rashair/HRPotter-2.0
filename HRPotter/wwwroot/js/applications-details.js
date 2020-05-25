$(document).ready(() => {
    var $loading = $('#loadingSpinner');
    getApplications("");

    $('#searchForm').submit(function searchApplications(e) {
        e.preventDefault();

        $('#tableContent').html("");
        $loading.show();

        let val = $(this).find('input#searchInput').val();
        getApplications(val);
    });

    function getApplications(val) {
        $.ajax({
            url: 'https://d2pwb47r49781h.cloudfront.net/JobApplications/GetApplicationsTable?query=' + val,
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
