function toggleDeleteModal(id) {
    $.ajax({
        url: '/Companies/Delete/' + id,
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

$(document).ready(() => {
    $('#createForm').submit(function (e) {
        e.preventDefault();

        var compName = $(this).find('input#companyName').val()
        var company = { id: 0, name: compName };
        $.ajax({
            type: 'POST',
            url: '/Companies/Create',
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
            getCompaniesTable();
        });
    });

    function getCompaniesTable() {
        $.ajax({
            url: '/Companies/CompaniesTable/',
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
});
