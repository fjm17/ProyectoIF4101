function Registrar() {
    var correo = $('#tbCorreo').val();
    var nombre = $('#tbNombre').val();
    var contrasena = $('#tbContrasenaCrear').val();
    var contrasenaConf = $('#tbContrasenaConfirmar').val();
    var direccion = $('#tbDireccionCasa').val();

    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/Registrarse?correo=" + correo + "&nombreCompleto=" + nombre + "&direccion=" + direccion + "&contrasena=" + contrasena,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        alert("Cliente insertado satisfactoriamente.");
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
            url: "http://localhost:6347/WS/WSRESTCliente.svc/MostrarCliente?correo=" + correo,
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
    
}
