$('#JobOfferForm').submit(function (e) {
    let validationResult = true;

    let salaryFrom = parseInt($('#SalaryFrom').val());
    let salaryTo = parseInt($('#SalaryTo').val());
    if (!isNaN(salaryFrom) && !isNaN(salaryTo) && salaryFrom > salaryTo) {
        $('#SalaryRange-Error').text("Lower bound of salary cannot be greater than upper bound.");
        validationResult = false;
    }
    else {
        $('#SalaryRange-Error').text("");
    }
    

    let validUntil = new Date($('#ValidUntil').val());
    let currentDate = new Date();
    currentDate.setHours(0, 0, 0, 0);
    if (!isNaN(validUntil) && validUntil < currentDate) {
        $('#PastDate-Error').text("Offer expiration date cannot be past date.");
        validationResult = false;
    }
    else {
        $('#PastDate-Error').text("");
    }
    

    return validationResult;
});


