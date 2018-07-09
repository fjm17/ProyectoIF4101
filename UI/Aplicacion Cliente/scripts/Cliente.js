function Registrar()
{
    var correo = document.createElement("li");
    var a = document.createElement("a");
    a.innerHTML = localStorage["correo"];
    correo.appendChild(a);
    //document.getElementById("navbarElements").appendChild(correo);
    $("#navbarElements").append(correo);
    //document.body.appendChild(correo);
   // alert(localStorage["correo"]);
}

function IniciarSesion()
{
    var correo = $('#tbCorreo').val();
    var contrasena = $('#tbContrasena').val();

    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/IniciarSesion?correo=" + correo + "&contrasena=" + contrasena,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos)
    {
        localStorage["correo"] = correo;
        Validar(datos);
    });

    req.fail(function ()
    {
        alert("No se pudo completar la transaccion");
    });

}

function Validar(datos) {
    if (datos)
    {
        window.location.href = "PaginaInicio.html";
    }
    else
    {
        alert("Los datos son invalidos. Por favor, intente de nuevo.");
    }
}