function toggleModal(id, name) {

    console.log("working");
    $.ajax({
        url: '/Companies/Delete/' + id,
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
