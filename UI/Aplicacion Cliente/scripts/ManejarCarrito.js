function AgregarACarrito()
{
    var nombre = localStorage["nombre"];
    //alert("in carrito " + nombre);
    var platos = JSON.parse(localStorage.getItem("platos"));

    if (platos == null)
    {
        platos = [];
        platos.push(nombre);
        localStorage.setItem("platos", JSON.stringify(platos));
        alert("platos was null so was created");
    }
    else
    {
        platos.push(nombre);
        localStorage.setItem("platos", JSON.stringify(platos));
        alert("platos was not null rite");
    }
    var result = JSON.parse(localStorage.getItem("platos"));
}

function TerminarCompra() {
    CrearPedido();
    EnviarPedidos(result);
}

function CrearPedido() {
    var correo = localStorage["correo"];
    alert(correo);
    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/InsertarPedido?correo=" + correo,
            timeout: 10000,
            dataType: "jsonp"
        });
    req.done(function (datos) {
        localStorage["numeroPedido"] = datos;
        alert("El pedido se ha creado exitosamente " + datos);
    });

    req.fail(function () {
        alert("Ocurrió un problema.");
    });

    localStorage.removeItem("platos");
}

function EnviarPedidos(detalles) {
    var numeroPedido = localStorage["numeroPedido"];
    $.each(detalles, function () {
        var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/InsertarDetalle?numero=" + numeroPedido + "&nombre=" + this,
            timeout: 10000,
            dataType: "jsonp"
        });

        req.done(function (detalles) {
            alert("Insercion");
        });

        req.fail(function () {
            alert("Ocurrió un problema.");
        });
    });
}