// ==================== ADD EDUCATION MODAL ====================
$(document).ready(function () {
    // Handle checkbox for ADD Education
    $(document).on('change', '#addCurrentlyStudying', function () {
        var checked = $(this).is(':checked');
        var passedYearInput = $('#addPassedYear');
        var gradeInput = $('#addGrade');

        if (checked) {
            passedYearInput.prop('readonly', true).val('');
            gradeInput.prop('readonly', true).val('');
        } else {
            passedYearInput.prop('readonly', false);
            gradeInput.prop('readonly', false);
        }
    });

    // Optional: Reset form when modal is closed
    $('#addEducationModal').on('hidden.bs.modal', function () {
        $('#addCurrentlyStudying').prop('checked', false);
        $('#addPassedYear').prop('readonly', false).val('');
        $('#addGrade').prop('readonly', false).val('');
    });
});