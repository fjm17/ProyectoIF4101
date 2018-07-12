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
        /*var sessionTimeout = 1; //hours
        var loginDuration = new Date();
        loginDuration.setTime(loginDuration.getTime() + (sessionTimeout * 60 * 60 * 1000));
        document.cookie = "CrewCentreSession=Valid; " + loginDuration.toGMTString() + "; path=/";*/

        if (datos.Valor === true) {
            localStorage["correo"] = correo;
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