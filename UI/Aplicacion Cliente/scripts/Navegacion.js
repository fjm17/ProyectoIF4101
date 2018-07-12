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
        location.href = "IniciarSesionCliente.html";
    }
}

function CerrarSesion() {
    localStorage.removeItem("correo");
    location.href = "";
}