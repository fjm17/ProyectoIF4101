function AgregarACarrito()
{
    var nombre = localStorage["nombre"];
    alert("in carrito " + nombre);
    
    var platos = JSON.parse(localStorage.getItem("platos"));
    var plato = { p: nombre };

    //localStorage.removeItem("platos");

    if (platos == null)
    {
        platos = [];
        platos.push(plato);
        localStorage.setItem("platos", JSON.stringify(platos));
        alert("platos was null so was created");
    }
    else
    {
        platos.push(plato);
        localStorage.setItem("platos", JSON.stringify(platos));
        alert("platos was not null rite");
    }
    var result = JSON.parse(localStorage.getItem("platos"));

    $.each(result, function () {
        var value = String(this);
        alert(value);

        var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/MostrarAlgoAyuda?nombre=" + this,
            timeout: 10000,
            dataType: "jsonp"
        });
        req.done(function (datos) {
            alert("en " + datos);
        });

        req.fail(function () {
            alert("Ocurrió un problema.");
        });

    });

}