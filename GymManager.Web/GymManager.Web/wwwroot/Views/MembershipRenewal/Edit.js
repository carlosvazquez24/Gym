(function () {
    $("select").select2({
        width: '100%' // ocupa todo el contenedor
    });
}());


document.addEventListener("DOMContentLoaded", () => {

    UpdateRenewalDate();

    $("#MembershipId").on("change.select2", function () {
        UpdateRenewalDate();
    });


    function UpdateRenewalDate() {

        // Se obtiene el select que selecciona la membresia
        const membershipSelect = document.getElementById("MembershipId");

        //Se obtiene el div que guarda la nueva fecha de expiración
        const renewalDateInput = document.getElementById("renewalDateDisplay");

        //Se obtiene la membresia
        const selectedOption = membershipSelect.options[membershipSelect.selectedIndex];

        //Se obtiene los meeses de la nueva membresia
        const months = parseInt(selectedOption.getAttribute("data-months"), 10);


        if (!isNaN(months)) {
            const now = new Date();

            //Se agregan los nuevos meses de la membresia a la fecha actual
            now.setMonth(now.getMonth() + months);

            // Formatear como "yyyy-MM-ddTHH:mm" para <input type="datetime-local">
            const year = now.getFullYear();
            const month = String(now.getMonth() + 1).padStart(2, "0");
            const day = String(now.getDate()).padStart(2, "0");
            const formatted = `${day}/${month}/${year}`;
            renewalDateInput.textContent = formatted.toString();
        }
    }

});