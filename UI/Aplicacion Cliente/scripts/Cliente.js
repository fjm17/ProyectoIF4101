function Registrar() {
    var correo = $('#tbCorreo').val();
    var nombre = $('#tbNombre').val();
    var contrasena = $('#tbContrasenaCrear').val();
    var contrasenaConf = $('#tbContrasenaConfirmar').val();
    var direccion = $('#tbDireccionCasa').val();

    var req = $.ajax(
        {
            url: "http://jrvz97-001-site1.dtempurl.com/WS/WSRESTCliente.svc/Registrarse?correo=" + correo + "&nombreCompleto=" + nombre + "&direccion=" + direccion + "&contrasena=" + contrasena,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        alert("Cliente insertado satisfactoriamente.");
        location.href = "IniciarSesionCliente.html";
        //localStorage["correo"] = correo;
    });

    req.fail(function () {
        alert("No se pudo registrar al usuario.");
    });
}

function MostrarCliente() {
    var correo = localStorage["correo"];
    var req = $.ajax(
        {
            url: "http://jrvz97-001-site1.dtempurl.com/WS/WSRESTCliente.svc/MostrarCliente?correo=" + correo,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        document.getElementById("tbNombreNuevo").value = datos.Nombre_Completo;
        document.getElementById("tbDireccionCasaNueva").value = datos.Direccion;
    });

    req.fail(function () {
        alert("No se pudo completar la transaccion.");
    });
}

function ModificarCliente() {
    var correo = localStorage["correo"];
    var nombre = document.getElementById("tbNombreNuevo").value;
    var direccion = document.getElementById("tbDireccionCasaNueva").value;
    var contrasena = document.getElementById("tbContrasenaNueva").value;

    var req = $.ajax(
        {
            url: "http://jrvz97-001-site1.dtempurl.com/WS/WSRESTCliente.svc/ModificarCliente?correo="
                + correo + "&nombre=" + nombre + "&contrasena=" + contrasena,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
    });

    req.fail(function () {
        alert("No se pudo completar la transaccion.");
    });
}
