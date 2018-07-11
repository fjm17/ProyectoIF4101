/*function VerificarSesion () {
    if ()
    {

    }
}*/

function Registrar() {
    var correo = $('#tbCorreo').val();
    var nombre = $('#tbNombre').val();
    var contrasena = $('#tbContrasenaCrear').val();
    var contrasenaConf = $('#tbContrasenaConfirmar').val();
    var direccion = $('#tbDireccionCasa').val();

    alert(correo + nombre + contrasena + contrasenaConf + direccion);

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



function imprimir() {

    /*var correo = document.getElementById("tbCorreo").value;
    var contrasena = document.getElementById("tbContrasena").value;

    alert(correo + contrasena);*/
}

/*var correo = document.createElement("li");
    var a = document.createElement("a");
    a.innerHTML = localStorage["correo"];
    correo.appendChild(a);
    //document.getElementById("navbarElements").appendChild(correo);
    $("#navbarElements").append(correo);
    //document.body.appendChild(correo);
    // alert(localStorage["correo"]);*/