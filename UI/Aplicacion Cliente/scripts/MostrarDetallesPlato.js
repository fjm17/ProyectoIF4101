function prepareForShowing() {
    localStorage["nombre"] = "Curry";
    window.location.href = "MostrarDetalles.html";
}

function MostrarDetalles() {
    localStorage["nombre"] = "Curry";
    var nombre = localStorage["nombre"];
    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/MostrarDetallePlato?nombre=" + nombre,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        //alert("Funcionaaaa");
        MuestraPlato(datos);
    });

    req.fail(function () {
        alert("Ocurrió un problema. Por favor, intente de nuevo más tarde.");
    });
}

function MuestraPlato(datos) {
    var h1 = document.createElement("h1");
    h1.innerHTML = datos.Descripcion;
    document.getElementById("form1").appendChild(h1);
}