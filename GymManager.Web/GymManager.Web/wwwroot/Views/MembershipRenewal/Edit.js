(function () {
    $("#MembershipId").select2();
}());

document.addEventListener("DOMContentLoaded", () => {
    const membershipSelect = document.getElementById("membershipSelect");
    const renewalDateInput = document.getElementById("renewalDate");

    membershipSelect.addEventListener("change", () => {
        const selectedOption = membershipSelect.options[membershipSelect.selectedIndex];
        const months = parseInt(selectedOption.getAttribute("data-months"), 10);

        if (!isNaN(months)) {
            const now = new Date();
            now.setMonth(now.getMonth() + months);

            // Formatear como "yyyy-MM-ddTHH:mm" para <input type="datetime-local">
            const year = now.getFullYear();
            const month = String(now.getMonth() + 1).padStart(2, "0");
            const day = String(now.getDate()).padStart(2, "0");
            const hours = String(now.getHours()).padStart(2, "0");
            const minutes = String(now.getMinutes()).padStart(2, "0");

            const formatted = `${year}-${month}-${day}T${hours}:${minutes}`;
            renewalDateInput.value = formatted;
        }
    });
});