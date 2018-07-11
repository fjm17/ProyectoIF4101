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
        alert("Funciona");
        //localStorage["correo"] = correo;
        //Validar(datos);
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
        alert(datos.Nombre_Completo);
        //localStorage["correo"] = correo;
        //Validar(datos);
    });

    req.fail(function () {
        alert("No se pudo completar la transaccion.");
    });
}

/*"http://jrvz97-001-site1.dtempurl.com/WS/WSRESTCliente.svc/IniciarSesion?correo=" + correo + "&contrasena=" + contrasena,*/
/*"http://localhost:6347/WS/WSRESTCliente.svc/IniciarSesion?correo=" + correo + "&contrasena=" + contrasena,*/

function IniciarSesion() {
    var correo = $('#tbCorreo').val();
    var contrasena = $('#tbContrasena').val();

    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/IniciarSesion?correo=" + correo + "&contrasena=" + contrasena,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        alert("Funciona");
        localStorage["correo"] = correo;
        Validar(datos);
    });

    req.fail(function (jqXHR, textStatus, errorThrown) {
        alert(jqXHR);
        alert(textStatus);
        alert(errorThrown);
    });

}

function Validar(datos) {

    $.each(datos, function () {
        alert(this);
        if (this) {
            window.location.href = "PaginaInicio.html";
        }
        else {
            alert("Los datos son invalidos. Por favor, intente de nuevo.");
        }
    });
}


/*var correo = document.createElement("li");
    var a = document.createElement("a");
    a.innerHTML = localStorage["correo"];
    correo.appendChild(a);
    //document.getElementById("navbarElements").appendChild(correo);
    $("#navbarElements").append(correo);
    //document.body.appendChild(correo);
    // alert(localStorage["correo"]);*/