function Volver ()
{
    window.location.href = "PaginaInicio.html";
}

function MandarParaCarrito() {
    localStorage["paraCarrito"] = 1;
    Volver();
}

function VerificarSesion() {
    var correo = localStorage["correo"];
    if (correo == null) {
        //alert("Get Out");
        window.localStorage.href = "IniciarSesionCliente.html";
    }
    else {
        //alert("You're cool " + localStorage["correo"]);
    }
}

function CerrarSesion() {
    localStorage["correo"] = null;
}


function AInicioSesion() {
}