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

    function toggleEducationFields(isCurrentlyStudying) {
        if (isCurrentlyStudying) {
            $('#updatePassedYear').prop('disabled', true).val('');
            $('#updateGrade').prop('disabled', true).val('');
        } else {
            $('#updatePassedYear').prop('disabled', false);
            $('#updateGrade').prop('disabled', false);
        }
    }

    $('.update-education-btn').click(function () {

        $('#formEducationId').val($(this).data('education-id'));
        $('#formUserId').val($(this).data('user-id'));

        $('#updateInstitutionName').val($(this).data('institution-name'));
        $('#updateDegree').val($(this).data('degree'));
        $('#updateField').val($(this).data('field'));
        $('#updateLocation').val($(this).data('location'));

        let isCurrentlyStudying = $(this).data('currently-studying') === true ||
            $(this).data('currently-studying') === "true";

        $('#updateCurrentlyStudying').prop('checked', isCurrentlyStudying);

        if (!isCurrentlyStudying) {
            $('#updatePassedYear').val($(this).data('passed-year') || '');
            $('#updateGrade').val($(this).data('grade') || '');
        }

        toggleEducationFields(isCurrentlyStudying);
    });

    $(document).on('change', '#updateCurrentlyStudying', function () {
        toggleEducationFields($(this).is(':checked'));
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