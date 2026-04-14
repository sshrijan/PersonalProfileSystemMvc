// Dashboard Modals JavaScript
$(document).ready(function () {
    // ==================== ADDRESS MODAL ====================
    $('.update-address-btn').click(function () {
        var addressId = $(this).data('address-id');
        var userId = $(this).data('user-id');
        var country = $(this).data('country');
        var provinceState = $(this).data('province-state');
        var districtCity = $(this).data('district-city');
        var tole = $(this).data('tole');
        var ward = $(this).data('ward');

        $('#updateAddressId').val(addressId);
        $('#updateAddressUserId').val(userId);
        $('#updateCountry').val(country);
        $('#updateProvinceState').val(provinceState);
        $('#updateDistrictCity').val(districtCity);
        $('#updateTole').val(tole);
        $('#updateWard').val(ward);
    });

    // ==================== SKILL MODAL ====================
    $('.update-skill-btn').click(function () {
        var skillId = $(this).data('skill-id');
        var userId = $(this).data('user-id');
        var skillName = $(this).data('skill-name');
        var skillLevel = $(this).data('skill-level');
        var yearsOfExperience = $(this).data('years-of-experience');

        $('#skillFormSkillId').val(skillId);
        $('#skillFormUserId').val(userId);
        $('#updateSkillName').val(skillName);
        $('#updateSkillLevel').val(skillLevel);
        $('#updateYearsOfExperience').val(yearsOfExperience);
    });

    // ==================== UPDATE EDUCATION MODAL ====================
    $('.update-education-btn').click(function () {
        var educationId = $(this).data('education-id');
        var userId = $(this).data('user-id');
        var institution = $(this).data('institution-name') || '';
        var degree = $(this).data('degree') || '';
        var field = $(this).data('field') || '';
        var location = $(this).data('location') || '';
        var currentlyStudying = $(this).data('currently-studying');
        var passedYear = $(this).data('passed-year');
        var grade = $(this).data('grade') || '';

        // Fill form
        $('#formEducationId').val(educationId);
        $('#formUserId').val(userId);
        $('#updateInstitutionName').val(institution);
        $('#updateDegree').val(degree);
        $('#updateField').val(field);
        $('#updateLocation').val(location);

        var isCurrently = (currentlyStudying === true ||
            currentlyStudying === 'true' ||
            currentlyStudying === 'True' ||
            currentlyStudying === 1);

        $('#updateCurrentlyStudying').prop('checked', isCurrently);

        var pyInput = $('#updatePassedYear');
        var gInput = $('#updateGrade');

        if (isCurrently) {
            pyInput.prop('readonly', true).val('');
            gInput.prop('readonly', true).val('');
        } else {
            pyInput.prop('readonly', false).val((passedYear != null && passedYear !== 0) ? passedYear : '');
            gInput.prop('readonly', false).val(grade);
        }
    });

    // Handle checkbox toggle inside the modal
    $(document).on('change', '#updateCurrentlyStudying', function () {
        var checked = $(this).is(':checked');
        var pyInput = $('#updatePassedYear');
        var gInput = $('#updateGrade');

        if (checked) {
            pyInput.prop('readonly', true).val('');
            gInput.prop('readonly', true).val('');
        } else {
            pyInput.prop('readonly', false);
            gInput.prop('readonly', false);
        }
    });// ==================== UPDATE EDUCATION MODAL ====================
$('.update-education-btn').click(function () {
    var educationId   = $(this).data('education-id');
    var userId        = $(this).data('user-id');
    var institution   = $(this).data('institution-name') || '';
    var degree        = $(this).data('degree') || '';
    var field         = $(this).data('field') || '';
    var location      = $(this).data('location') || '';
    var currentlyStudying = $(this).data('currently-studying');
    var passedYear    = $(this).data('passed-year');
    var grade         = $(this).data('grade') || '';

    // Fill form
    $('#formEducationId').val(educationId);
    $('#formUserId').val(userId);
    $('#updateInstitutionName').val(institution);
    $('#updateDegree').val(degree);
    $('#updateField').val(field);
    $('#updateLocation').val(location);

    var isCurrently = (currentlyStudying === true || 
                       currentlyStudying === 'true' || 
                       currentlyStudying === 'True' || 
                       currentlyStudying === 1);

    $('#updateCurrentlyStudying').prop('checked', isCurrently);

    var pyInput = $('#updatePassedYear');
    var gInput  = $('#updateGrade');

    if (isCurrently) {
        pyInput.prop('readonly', true).val('');
        gInput.prop('readonly', true).val('');
    } else {
        pyInput.prop('readonly', false).val((passedYear != null && passedYear !== 0) ? passedYear : '');
        gInput.prop('readonly', false).val(grade);
    }
});

// Handle checkbox toggle inside the modal
$(document).on('change', '#updateCurrentlyStudying', function () {
    var checked = $(this).is(':checked');
    var pyInput = $('#updatePassedYear');
    var gInput  = $('#updateGrade');

    if (checked) {
        pyInput.prop('readonly', true).val('');
        gInput.prop('readonly', true).val('');
    } else {
        pyInput.prop('readonly', false);
        gInput.prop('readonly', false);
    }
});


    // ==================== CONTACT MODAL ====================
    $('#updateContactForm').on('submit', function () {
        var contactId = $('#contactId').val();
        if (contactId) {
            $('<input>').attr({
                type: 'hidden',
                name: 'ContactId',
                value: contactId
            }).appendTo(this);
        }
    });
});