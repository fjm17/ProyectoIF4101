function MostrarPlatos()
{
    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/VerPlatos?nombre=",
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        alert("Funciona");
        ProcesarPlatos(datos);
    });

    req.fail(function () {
        alert("Ocurrió un problema. Por favor, intente de nuevo más tarde.");
    });
}

function ProcesarPlatos (datos)
{
    //$('#tablePlatos').empty();
    var tbody = document.createElement("tbody");

    CrearTableHeader();

    $.each(datos, function () {
        
        var newTr = document.createElement("tr");
        var newTdNombre = document.createElement("td");
        var newTdDescripcion = document.createElement("td");
        var newTdPrecio = document.createElement("td");

        newTdNombre.innerHTML = this.Nombre;
        newTdDescripcion.innerHTML = this.Descripcion;
        newTdPrecio.innerHTML = this.Precio;

        newTr.appendChild(newTdNombre);
        newTr.appendChild(newTdDescripcion);
        newTr.appendChild(newTdPrecio);

        tbody.appendChild(newTr);

    });
    $('#tablePlatos').append(tbody);
}


function CrearTableHeader ()
{
    var thead = document.createElement("thead");
    var tr = document.createElement("tr");
    var thNombre = document.createElement("th");
    thNombre.innerHTML = "Nombre";
    var thDescripcion = document.createElement("th");
    thDescripcion.innerHTML = "Descripcion";
    var thPrecio = document.createElement("th");
    thPrecio.innerHTML = "Precio";

    tr.appendChild(thNombre);
    tr.appendChild(thDescripcion);
    tr.appendChild(thPrecio);

    thead.appendChild(tr);

    $('#tablePlatos').append(thead);
}
