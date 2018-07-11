function MostrarPlatos() {
    //http://jrvz97-001-site1.dtempurl.com/WS/WSRESTCliente.svc/VerPlatos?nombre=
    //http://localhost:6347/
    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/VerPlatos?nombre=",
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        ProcesarPlatos(datos);
    });

    req.fail(function () {
        alert("Ocurrió un problema. Por favor, intente de nuevo más tarde.");
    });
}

function ProcesarPlatos(datos) {
    //$('#tablePlatos').empty();
    CrearTableHeader();
    var tbody = document.createElement("tbody");

    $.each(datos, function () {

        var newTr = document.createElement("tr");
        var newTdNombre = document.createElement("td");
        //var newTdDescripcion = document.createElement("td");
        var newTdPrecio = document.createElement("td");

        var newTdVerDetalles = document.createElement("td");

        var newInputDetalles = document.createElement("input");
        newInputDetalles.setAttribute("type", "submit");
        newInputDetalles.value = "Ver Detalles";

        newInputDetalles.click(function () {
            alert("bkhvjv");
            var $item = $(this).closest("tr")
                               .find(".nr")
                               .text();
            alert($item);
            //$("#resultas").append($item);     
        });


        newTdVerDetalles.appendChild(newInputDetalles);

        var newTdAgregarCarrito = document.createElement("td");

        var newInputAgregarCarrito = document.createElement("input");
        newInputAgregarCarrito.setAttribute("type", "submit");
        newInputAgregarCarrito.style.backgroundColor = 'red';
        newInputAgregarCarrito.value = "Agregar al Carrito";

        newTdAgregarCarrito.appendChild(newInputAgregarCarrito);

        newTdNombre.innerHTML = this.Nombre;
        //newTdDescripcion.innerHTML = this.Descripcion;
        newTdPrecio.innerHTML = this.Precio;

        newTr.appendChild(newTdNombre);
        //newTr.appendChild(newTdDescripcion);
        newTr.appendChild(newTdPrecio);
        newTr.appendChild(newTdVerDetalles);
        newTr.appendChild(newTdAgregarCarrito);

        tbody.appendChild(newTr);

    });
    $('#tablePlatos').append(tbody);
    document.getElementById("tablePlatos").appendChild(tbody);
}


function CrearTableHeader() {
    var thead = document.createElement("thead");
    var tr = document.createElement("tr");

    var thNombre = document.createElement("th");
    thNombre.innerHTML = "Nombre";
    /*var thDescripcion = document.createElement("th");
    thDescripcion.innerHTML = "Descripcion";*/
    var thPrecio = document.createElement("th");
    thPrecio.innerHTML = "Precio";
    var thDetalles = document.createElement("th");
    thDetalles.innerHTML = "Detalles";
    var thAgregarCarrito = document.createElement("th");
    thAgregarCarrito.innerHTML = "Carrito";

    tr.appendChild(thNombre);
    //tr.appendChild(thDescripcion);
    tr.appendChild(thPrecio);
    tr.appendChild(thDetalles);
    tr.appendChild(thAgregarCarrito);

    thead.appendChild(tr);

    $('#tablePlatos').append(thead);
}