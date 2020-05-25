function refreshContent() {
    $.ajax({
        url: 'https://cz7k3d7r2i.execute-api.us-east-1.amazonaws.com/Prod/Companies/GetCompaniesTable/',
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
            url: 'https://cz7k3d7r2i.execute-api.us-east-1.amazonaws.com/Prod/Companies/Create',
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
        url: 'https://cz7k3d7r2i.execute-api.us-east-1.amazonaws.com/Prod/Companies/GetDeleteModal/' + id,
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
