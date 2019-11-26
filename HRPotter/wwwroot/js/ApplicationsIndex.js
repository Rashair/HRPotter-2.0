$(document).ready(() => {
    $loading = $('#loadingSpinner');
    $loading.hide();

    $('#searchForm').submit(function searchApplications(e) {
        e.preventDefault();

        $('#tableContent').html("");
        $loading.show();
        let val = $(this).find('input#searchInput').val();
        $.ajax({
            url: '/JobApplications/GetApplicationsTable?query=' + val,
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
    });
});
