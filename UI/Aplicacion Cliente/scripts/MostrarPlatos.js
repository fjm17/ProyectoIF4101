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
    CrearTableHeader();
    var tbody = document.createElement("tbody");

    $.each(datos, function () {

        var newTr = document.createElement("tr");
        var newTdNombre = document.createElement("td");
        newTdNombre.id = "nombre";

        var newTdPrecio = document.createElement("td");
        var newTdVerDetalles = document.createElement("td");
        var newInputDetalles = document.createElement("input");
        newInputDetalles.setAttribute("type", "button");
        newInputDetalles.value = "Ver Detalles";

        newInputDetalles.id = "detalles";
        
        /*Agregar metodo para boton Ver Detalles*/
        newInputDetalles.onclick = (function () {
            var cells = $(this).closest("tr").children("td");
            var nombre = cells.eq(0).text();
            localStorage["nombre"] = nombre;

            window.location.href = "MostrarDetalles.html";
        });

        newTdVerDetalles.appendChild(newInputDetalles);

        var newTdAgregarCarrito = document.createElement("td");

        var newInputAgregarCarrito = document.createElement("input");
        newInputAgregarCarrito.setAttribute("type", "button");
        newInputAgregarCarrito.style.backgroundColor = 'red';
        newInputAgregarCarrito.value = "Agregar al Carrito";

        /*Agregando metodo para boton Agregar a Carrito*/
        newInputAgregarCarrito.onclick = (function () {
            /*Extrayendo valor necesario.*/
            var cells = $(this).closest("tr").children("td");
            var nombre = cells.eq(0).text();
            localStorage["nombre"] = nombre;
            /*Agregando a carrito.*/
            AgregarACarrito();
        });

        newTdAgregarCarrito.appendChild(newInputAgregarCarrito);

        newTdNombre.innerHTML = this.Nombre;
        newTdPrecio.innerHTML = this.Precio;

        newTr.appendChild(newTdNombre);
        newTr.appendChild(newTdPrecio);
        newTr.appendChild(newTdVerDetalles);
        newTr.appendChild(newTdAgregarCarrito);

        tbody.appendChild(newTr);
        
    });
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