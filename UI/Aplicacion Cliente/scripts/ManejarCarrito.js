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
    }
    else
    {
        platos.push(nombre);
        localStorage.setItem("platos", JSON.stringify(platos));
    }
}

function RemoverDePedido(nombre) {
    var platos = JSON.parse(localStorage.getItem("platos"));
    var indice = platos.indexOf(nombre);
    platos.splice(indice, 1);
}

function TerminarCompra() {
    var platos = JSON.parse(localStorage.getItem("platos"));
    CrearPedido();
    EnviarPedidos(platos);
}

function CrearPedido() {
    var correo = localStorage["correo"];
    alert(correo);
    var req = $.ajax(
        {
            url: "http://jrvz97-001-site1.dtempurl.com/WS/WSRESTCliente.svc/InsertarPedido?correo=" + correo,
            timeout: 10000,
            dataType: "jsonp"
        });
    req.done(function (datos) {
        localStorage["numeroPedido"] = datos;
        alert("¡El pedido se ha creado exitosamente! ");
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
            url: "http://jrvz97-001-site1.dtempurl.com/WS/WSRESTCliente.svc/InsertarDetalle?numero=" + numeroPedido + "&nombre=" + this,
            timeout: 10000,
            dataType: "jsonp"
        });

        req.done(function (detalles) {
        });

        req.fail(function () {
            alert("Ocurrió un problema.");
        });
    });
}

function MontarCarrito() {
    CrearTableHeader();
    var tbody = document.createElement("tbody");
    var platos = JSON.parse(localStorage.getItem("platos"));

    $.each(platos, function () {

        var newTr = document.createElement("tr");

        var newTdNombre = document.createElement("td");
        newTdNombre.innerHTML = this;

        var newTdEliminar = document.createElement("td");

        var newInputEliminar = document.createElement("input");
        newInputEliminar.setAttribute("type", "button");
        newInputEliminar.value = "Eliminar";
        newInputEliminar.style.backgroundColor = 'red';

        /*Agregar metodo para boton Ver Detalles*/
        newInputEliminar.onclick = (function () {
            var cells = $(this).closest("tr").children("td");
            var nombre = cells.eq(0).text();
            RemoverDePedido(nombre);
            window.location.href = "Carrito.html";
        });

        newTdEliminar.appendChild(newInputEliminar);

        newTr.appendChild(newTdNombre);
        newTr.appendChild(newTdEliminar);

        tbody.appendChild(newTr);

    });
    document.getElementById("tableDetalles").appendChild(tbody);

}


function CrearTableHeader() {
    var thead = document.createElement("thead");
    var tr = document.createElement("tr");

    var thNombre = document.createElement("th");
    thNombre.innerHTML = "Nombre";
    var thEliminar = document.createElement("th");
    thEliminar.innerHTML = "Eliminar";

    tr.appendChild(thNombre);
    tr.appendChild(thEliminar);

    thead.appendChild(tr);

    $('#tableDetalles').append(thead);
}