$('#JobOfferForm').submit(function (e) {
    let validationResult = true;

    if (!validateSalary()) {
        validationResult = false;
        $('#SalaryFrom').focusout(validateSalary);
        $('#SalaryTo').focusout(validateSalary);
    }
    

    if (!validateExpirationDate()) {
        validationResult = false;
        $('#ValidUntil').focusout(validateExpirationDate);
    }

    return validationResult;
});

function validateSalary() {
    let result = true;
    let salaryFrom = parseInt($('#SalaryFrom').val());
    let salaryTo = parseInt($('#SalaryTo').val());
    if (!isNaN(salaryFrom) && !isNaN(salaryTo) && salaryFrom > salaryTo) {
        $('#SalaryRange-Error').text("Lower bound of salary cannot be greater than upper bound.");
        result = false;
    }
    else {
        $('#SalaryRange-Error').text("");
    }

    return result;
}

function validateExpirationDate() {
    let result = true;
    let validUntil = new Date($('#ValidUntil').val());
    let currentDate = new Date();
    currentDate.setHours(0, 0, 0, 0);
    if (!isNaN(validUntil) && validUntil < currentDate) {
        $('#PastDate-Error').text("Offer expiration date cannot be past date.");
        result = false;
    }
    else {
        $('#PastDate-Error').text("");
    }

    return result;
}


