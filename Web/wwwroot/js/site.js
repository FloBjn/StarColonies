// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
function setupImagePreview(inputId, previewId) {
    const inputElement = document.getElementById(inputId);
    const previewElement = document.getElementById(previewId);

    if (inputElement && previewElement) {
        inputElement.addEventListener('change', function (e) {
            const file = e.target.files[0];
            if (file) {
                console.log(file)
                previewElement.src = URL.createObjectURL(file);
                previewElement.style.display = 'block';
            }
        });
    }
}

function togglePopup(buttonId, popupId, closeBtnId, fileInputId, previewId) {
    const popup = document.getElementById(popupId);
    const openBtn = document.getElementById(buttonId);
    const cancelBtn = document.getElementById(closeBtnId);
    const fileInput = document.getElementById(fileInputId); // Récupère le champ file input
    const preview = document.getElementById(previewId);
    
    if (openBtn && popup && cancelBtn) {
        // Initialement, on cache le popup avec visibility et opacity
        popup.style.visibility = 'hidden';
        popup.style.opacity = '0';

        // Affichage du popup avec une transition de 0.3 secondes
        openBtn.addEventListener('click', () => {
            popup.style.visibility = 'visible';
            popup.style.opacity = '1'; // Affichage fluide
        });

        // Fermeture du popup
        cancelBtn.addEventListener('click', () => {
            popup.style.visibility = 'hidden';
            popup.style.opacity = '0'; // Cache le popup
            fileInput.value = '';
            preview.style.display = 'none';
        });
    }
}

function setupFormSubmission(formId) {
    document.addEventListener('DOMContentLoaded', function () {
        const form = document.getElementById(formId);
        
        form.addEventListener('submit', function(event) {
            event.preventDefault(); // Empêche la soumission automatique
            console.log(`Formulaire ${formId} soumis`);
        });
    });
}

function setupFormWatcher(formId, saveBtnId, cancelBtnId) {
    const form = document.getElementById(formId);
    const inputs = form.querySelectorAll("input");
    const saveBtn = document.getElementById(saveBtnId);
    const cancelBtn = document.getElementById(cancelBtnId);

    const initialValues = {};
    inputs.forEach(input => {
        initialValues[input.name] = input.value;
    });

    function checkForChanges() {
        let hasChanged = false;
        inputs.forEach(input => {
            const currentValue = input.value;
            const originalValue = initialValues[input.name];
            if (currentValue !== originalValue) {
                hasChanged = true;
                input.classList.add("changed-field");
            } else {
                input.classList.remove("changed-field");
            }
        });
        saveBtn.disabled = !hasChanged;
        cancelBtn.disabled = !hasChanged;
    }

    inputs.forEach(input => {
        input.addEventListener("input", checkForChanges);
    });

    cancelBtn.addEventListener("click", () => {
        inputs.forEach(input => {
            input.value = initialValues[input.name];
            input.classList.remove("changed-field");
        });
        saveBtn.disabled = true;
        cancelBtn.disabled = true;
    });
}
// Write your JavaScript code.
