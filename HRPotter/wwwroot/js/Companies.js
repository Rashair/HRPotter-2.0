function refreshContent() {
    $.ajax({
        url: 'https://d2pwb47r49781h.cloudfront.net/Companies/GetCompaniesTable/',
        type: 'GET',
        dataType: 'html',
        success: function (data) {
            $('#contentWrapper').html(data);
        },
        error: function () {
            alert('Error! Please try again.');
        }
    }).done(function () {

    });
}

$(document).ready(() => {
    refreshContent();
    $('#createForm').submit(function (e) {
        e.preventDefault();

        var compName = $(this).find('input#companyName').val()
        var company = { id: 0, name: compName };
        $.ajax({
            type: 'POST',
            url: 'https://d2pwb47r49781h.cloudfront.net/Companies/Create',
            headers: { "RequestVerificationToken": $(this).find('input[name="__RequestVerificationToken"]').val() },
            data: { company: company },
            dataType: 'html',
            success: function (data) {
                $('#createCompany').modal("hide");
            },
            error: function () {
                alert('Error! Please try again.');
            }
        }).done(function () {
            refreshContent();
        });
    });
});

// Used in _CompaniesTable
function toggleDeleteModal(id) {
    $.ajax({
        url: 'https://d2pwb47r49781h.cloudfront.net/Companies/GetDeleteModal/' + id,
        type: 'GET',
        dataType: 'html',
        success: function (data) {
            $('#deleteModalWrapper').html(data);
        },
        error: function () {
            alert('Error! Please try again.');
        }
    }).done(function () {
        $('#confirmDelete').modal("show");
    });
};
