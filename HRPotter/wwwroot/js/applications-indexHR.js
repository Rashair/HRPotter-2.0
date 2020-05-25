// TODO: Asynchronous request to sort list by status
$(document).ready(() => {
    $loading = $('#loadingSpinner');
    $loading.hide();

    $('#searchForm').submit(function searchApplications(e) {
        e.preventDefault();

        $('#updatePanel').html("");
        $loading.show();
        let id = $(this).children('input#idInput').val();
        let val = $(this).find('input#searchInput').val();
        $.ajax({
            url: 'https://cz7k3d7r2i.execute-api.us-east-1.amazonaws.com/Prod/JobApplications/ApplicationsForOffer/' + id + '?query=' + val,
            type: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#updatePanel').html(data);
            },
            error: function () {
                alert('Error! Please try again.');
            }
        }).done(function () {
            $loading.hide();
        });
    });
});