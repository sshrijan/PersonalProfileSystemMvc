// educationModal.js
document.addEventListener("DOMContentLoaded", function () {
    // Handle Add Education Modal
    const addCheckbox = document.getElementById("currentlyStudying");
    const addPassedYear = document.getElementById("passedYear");
    const addGrade = document.getElementById("grade");

    if (addCheckbox) {
        addCheckbox.addEventListener("change", function () {
            addPassedYear.disabled = this.checked;
            addGrade.disabled = this.checked;
            if (this.checked) {
                addPassedYear.value = "";
                addGrade.value = "";
            }
        });
    }

    // Handle Update Education Modal dynamically
    const updateModal = document.getElementById("updateEducationModal");
    if (updateModal) {
        updateModal.addEventListener("shown.bs.modal", function () {
            const checkbox = document.getElementById("updateCurrentlyStudying");
            const passedYear = document.getElementById("updatePassedYear");
            const grade = document.getElementById("updateGrade");

            if (checkbox) {
                // Remove previous listeners to prevent duplicates
                checkbox.replaceWith(checkbox.cloneNode(true));
                const newCheckbox = document.getElementById("updateCurrentlyStudying");

                newCheckbox.addEventListener("change", function () {
                    passedYear.disabled = this.checked;
                    grade.disabled = this.checked;
                    if (this.checked) {
                        passedYear.value = "";
                        grade.value = "";
                    }
                });
            }
        });
    }
});