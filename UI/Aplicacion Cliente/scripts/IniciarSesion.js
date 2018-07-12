function IniciarSesion() {
    var correo = document.getElementById("tbCorreo").value;
    var contrasena = document.getElementById("tbContrasena").value;

    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/IniciarSesion?correo=" + correo + "&contrasena=" + contrasena,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        if (datos.Valor === true) {
            window.location.href = "PaginaInicio.html";
        }
        else {
            alert("Los datos son invalidos. Por favor, intente de nuevo.");
        }
    });

    req.fail(function () {
        alert("Ocurrió un problema.");
    });
}