
document.addEventListener('DOMContentLoaded', function () {
    //Se obtenga los objetos de botones y men+u desplegable
    const buttonDarkMode = document.getElementById("darkmode-toggle");
    const dropdownMenu = document.getElementById("dropdownMenu");
    const image = document.getElementById("logo");
    var path = window.location.pathname;



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

        //Mejorar el color de los input en el tema oscuro
        var inputs = document.querySelectorAll('input[type="text"], input[type="email"], input[type="password"], input[type="datetime"], input[type="tel"],  input[type="number"], input[type="search"] ');
        inputs.forEach(function (input) {
            input.style.backgroundColor = '#333'; // Cambia el color de fondo
            input.style.color = '#fff'; // Cambia el color del texto
        });

        var select = document.getElementById("select2");

        if (select !== null) {
            select.classList.add('select2-darkmode');

        }

        buttonDarkMode.checked = true;
        document.body.setAttribute("data-bs-theme", "dark");
        dropdownMenu.style.backgroundColor = '#121212';
        image.src = "../Images/logo_sin_fondo_darkMode.png";

        // DARKMODE SELECT2

        
        var stylesheet = document.styleSheets[5];


        stylesheet.insertRule(".select2-selection__rendered{background-color: #333 !important;color: white !important;}", stylesheet.cssRules.length);
        stylesheet.insertRule(".select2-search--dropdown, .select2-search__field, .select2-results {background-color: #333;color: white;}", stylesheet.cssRules.length);
        stylesheet.insertRule(".select2-results__option--selected {background-color: #505050!important;color: white !important;}", stylesheet.cssRules.length);
        stylesheet.insertRule(".select2-results__option--highlighted {background-color: #5897fb !important;color: white !important;}", stylesheet.cssRules.length);

        



        buttonDarkMode.style.color = 'white';
        if (path == "/") {
            document.body.classList.add('background-dark');
            document.getElementById("logoIndex").src = 'Images/logo_sin_fondo_darkMode.png';

        }
        document.body.classList.remove('hidden');

    }

    function lightModeFun() {

        //Mejorar el color de los input en el tema claro
        var inputs = document.querySelectorAll('input[type="text"], input[type="email"], input[type="password"], input[type="datetime"], input[type="tel"],  input[type="number"], input[type="search"] ');
        inputs.forEach(function (input) {
            input.style.backgroundColor = '#D6D6D6'; // Cambia el color de fondo
            input.style.color = '#000'; // Cambia el color del texto
        });

        var select = document.getElementById("select2");

        if (select !== null) {
            select.classList.remove('select2-darkmode');

        }

        buttonDarkMode.checked = false;
        document.body.setAttribute("data-bs-theme", "light");
        dropdownMenu.style.backgroundColor = '#E0E0E0';
        image.src = "../Images/logo_sin_fondo.png";
        buttonDarkMode.style.color = 'black';

        
        // DELETE DARKMODE
        var stylesheet = document.styleSheets[5];

        stylesheet.deleteRule(stylesheet.cssRules.length -1 );
        stylesheet.deleteRule(stylesheet.cssRules.length -1 );
        stylesheet.deleteRule(stylesheet.cssRules.length -1  );
        stylesheet.deleteRule(stylesheet.cssRules.length -1 );

        


        if (path == "/") {
            document.body.classList.remove('background-dark');
            document.getElementById("logoIndex").src = 'Images/logo_sin_fondo.png';


        }
        document.body.classList.remove('hidden');


    }
});




