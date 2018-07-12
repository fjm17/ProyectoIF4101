function Volver ()
{
    window.location.href = "PaginaInicio.html";
}

function MandarParaCarrito() {
    localStorage["paraCarrito"] = 1;
    Volver();
}

function VerificarSesion() {
    /*var correo = localStorage["correo"];
    if (typeof correo !== 'undefined' && correo !== null) {
        alert(correo);
    }
    else
    {
        alert("Get Out");
        location.href = "IniciarSesionCliente.html";
        //alert("You're cool " + localStorage["correo"]);
    }*/
}

function CerrarSesion() {
    localStorage["correo"] = 'undefined';
}


function AInicioSesion() {
}