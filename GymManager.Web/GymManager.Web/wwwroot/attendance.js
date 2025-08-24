


document.addEventListener('DOMContentLoaded', function () {



    //Se obtenga los objetos de botones y men+u desplegable
    const buttonDarkMode = document.getElementById("darkmode-toggle");
    const dropdownMenu = document.getElementById("dropdownMenu");
    const image = document.getElementById("logo");
    var path = window.location.pathname;
    var inBtn = document.getElementById("in-button");
    var outBtn = document.getElementById("out-button");
    const textCheck = document.getElementById("text-check");
    var textExplain = document.getElementById("textExplain");




    //Se obtendrá del localStorage el valor del modo oscuro, si está activado o no
    var darkMode = localStorage.getItem("darkMode");

    //Si el modo oscuro se activa, se le aplicará en todas las páginas, automaticamente
    if (darkMode == "activated" || darkMode == null) {
        darkModeFun();

    } else if (darkMode == "disactivated") {
        lightModeFun();

    }

    // Cada que cambie el estado del switch
    buttonDarkMode.addEventListener("change", () => {
        darkMode = localStorage.getItem("darkMode");

        //Si el modo oscuro está activado, se cambiará a modo claro
        if (buttonDarkMode.checked) {
            darkModeFun();
            localStorage.setItem("darkMode", "activated");
        }
        else {
            lightModeFun();
            localStorage.setItem("darkMode", "disactivated");

        }

    })

    function darkModeFun() {
        buttonDarkMode.checked = true;
        document.body.setAttribute("data-bs-theme", "dark");
        dropdownMenu.style.backgroundColor = '#121212';
        image.src = "../Images/logo_sin_fondo_darkMode.png";

        inBtn.classList.remove('check-buttons-light');
        outBtn.classList.remove('check-buttons-light');

        inBtn.classList.add('check-buttons-dark');
        outBtn.classList.add('check-buttons-dark');

        buttonDarkMode.style.color = 'white';
        if (path == "/") {
            document.body.classList.add('background-dark');
            document.getElementById("logoIndex").src = 'Images/logo_sin_fondo_darkMode.png';

        }
        document.body.classList.remove('hidden');

    }

    function lightModeFun() {
        buttonDarkMode.checked = false;
        document.body.setAttribute("data-bs-theme", "light");
        dropdownMenu.style.backgroundColor = '#E0E0E0';
        image.src = "../Images/logo_sin_fondo.png";
        buttonDarkMode.style.color = 'black';

        inBtn.classList.remove('check-buttons-dark');
        outBtn.classList.remove('check-buttons-dark');

        inBtn.classList.add('check-buttons-light');
        outBtn.classList.add('check-buttons-light');

        if (path == "/") {
            document.body.classList.remove('background-dark');
            document.getElementById("logoIndex").src = 'Images/logo_sin_fondo.png';


        }
        document.body.classList.remove('hidden');


    }

    //Botones para cambiar el contenido de Check In y Check Out

    //Check In button
    inBtn.addEventListener("click", () => {

        inBtn.classList.add("active");
        outBtn.classList.remove("active");

        textCheck.textContent = 'Check In';

        textExplain.textContent = ' These are the members that are outside of the business. You can register the entry of the member here.';
        

        //Cargar el contenido dependiendo del botón que se haya orpimido
        var contenidoElement = document.getElementById('dinamic-table');
        var xhr = new XMLHttpRequest();

        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                contenidoElement.innerHTML = xhr.responseText;
            }
        };

        xhr.open('GET', '/Attendance/MemberIn', true);
        xhr.send();
    });

    outBtn.addEventListener("click", () => {

        outBtn.classList.add("active");
        inBtn.classList.remove("active");

        textCheck.textContent = 'Check Out';

        textExplain.textContent = ' These are the members that are inside of the business. You can register the entry of the member here.';


        //Cargar el contenido dependiendo del botón que se haya orpimido
        var contenidoElement = document.getElementById('dinamic-table');
        var xhr = new XMLHttpRequest();

        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                contenidoElement.innerHTML = xhr.responseText;
            }
        };

        xhr.open('GET', '/Attendance/MemberOut' , true);
        xhr.send();
    });


})

function mostrarModal() {
    $('#modal').modal('show');
    setTimeout(cerrarModal, 2000);
}

function nombreArchivoActual() {
    var rutaAbsoluta = self.location.href;
    var posicionUltimaBarra = rutaAbsoluta.lastIndexOf("/");
    var rutaRelativa = rutaAbsoluta.substring(posicionUltimaBarra + 1, rutaAbsoluta.length);
    return rutaRelativa;
}

function cerrarModal() {
    $('#modal').modal('hide');
}


function checkin(button) {
    // Obtener el valor del atributo data-id del botón
    var memberId = $(button).data("id");
    var expirationDate = new Date($(button).data("expiration-date"));

    var movement = "checkin";


    if (expirationDate < new Date()) {
        // Mostrar modal de expiración
        document.getElementById("contenido").innerHTML =
            "<b>The membership has expired </b> <i class='fa-solid fa-xmark' style='color: red;'></i> <br/> The user has to renew his membership";
        mostrarModal();


    } else {

        // Realizar la solicitud AJAX con el Id del usuario
        $.ajax({
            type: "POST",
            url: "/Attendance/Check",
            contentType: "application/json",
            data: JSON.stringify({ IdMember: memberId, Movement: movement }),
            success: function (data) {
                // Modificar el contenido del modal con los datos recibidos
                //$("#contenido").html(data.mensaje + "<i class="fa - solid fa - check" style="color: #04e000; "></i>");

                document.getElementById("contenido").innerHTML = data.mensaje + '   <i class="fa-solid fa-check" style="color: #0fe000;"></i>';

                // Mostrar el modal
                mostrarModal();

                var contenidoElement = document.getElementById('dinamic-table');
                var xhr = new XMLHttpRequest();

                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        contenidoElement.innerHTML = xhr.responseText;
                    }
                };

                xhr.open('GET', '/Attendance/MemberIn', true);
                xhr.send();
            },
            error: function () {
                // Manejar errores de la solicitud AJAX
                alert("Error registering ");
            }
        });

    }


}

function checkout(button) {
    // Obtener el valor del atributo data-id del botón
    var memberId = $(button).data("id");
    var movement = "checkout";

    // Realizar la solicitud AJAX con el Id del usuario
    $.ajax({
        type: "POST",
        url: "/Attendance/Check",
        contentType: "application/json",
        data: JSON.stringify({ IdMember: memberId, Movement: movement }),
        success: function (data) {
            // Modificar el contenido del modal con los datos recibidos
            //$("#contenido").html(data.mensaje + "<i class="fa - solid fa - check" style="color: #04e000; "></i>");

            document.getElementById("contenido").innerHTML = data.mensaje + '   <i class="fa-solid fa-check" style="color: #0fe000;"></i>';

            // Mostrar el modal
            mostrarModal();

            var contenidoElement = document.getElementById('dinamic-table');
            var xhr = new XMLHttpRequest();

            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    contenidoElement.innerHTML = xhr.responseText;
                }
            };

            xhr.open('GET', '/Attendance/MemberOut', true);
            xhr.send();
        },
        error: function () {
            // Manejar errores de la solicitud AJAX
            alert("Error registering ");
        }
    });
}

