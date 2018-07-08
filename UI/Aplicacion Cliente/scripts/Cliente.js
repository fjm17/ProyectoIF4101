function IniciarSesion()
{
    var correo = $('#tbCorreo').val();
    var contrasena = $('#tbContrasena').val();

    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/IniciarSesion?correo=" + correo + "&contrasena=" + contrasena,
            timeout: 10000,
            dataType: 'jsonp'
        });

    alert("bright");
}