function refreshContent(val = "") {
    $.ajax({
        url: 'GetUsersTable/',
        type: 'GET',
        data: { searchString: val },
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

$(document).ready(() => {
    $loading = $('#loadingSpinner');
    refreshContent();

    $('#searchForm').submit(function searchApplications(e) {
        e.preventDefault();

        $('#tableContent').html("");
        $loading.show();

        let val = $(this).find('input#searchInput').val();
        refreshContent(val);
    });

    $('#searchInput').on('change', function searchApplicationsOnChange() {
        $('#tableContent').html("");
        $loading.show();

        let val = $(this).val();
        refreshContent(val);
    });
});

// Used in UsersTable
function toggleEditModal(id) {
    $.ajax({
        url: 'GetEditModal/' + id,
        type: 'GET',
        dataType: 'html',
        success: function (data) {
            $('#modalWrapper').html(data);
        },
        error: function () {
            alert('Error! Please try again.');
        }
    }).done(function () {
        $('#editRole').modal("show");
    });
};

function toggleDeleteModal(id) {
    $.ajax({
        url: 'GetDeleteModal/' + id,
        type: 'GET',
        dataType: 'html',
        success: function (data) {
            $('#modalWrapper').html(data);
        },
        error: function () {
            alert('Error! Please try again.');
        }
    }).done(function () {
        $('#confirmDelete').modal("show");
    });
};

