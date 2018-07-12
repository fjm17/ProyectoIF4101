function MostrarDetalles() {
    var nombre = localStorage["nombre"];
    var req = $.ajax(
        {
            url: "http://localhost:6347/WS/WSRESTCliente.svc/MostrarDetallePlato?nombre=" + nombre,
            timeout: 10000,
            dataType: "jsonp"
        });

    req.done(function (datos) {
        MuestraPlato(datos);
    });

    req.fail(function () {
        alert("Ocurrió un problema. Por favor, intente de nuevo más tarde.");
    });
}

function MuestraPlato(datos) {
    var nombre = document.createElement("h1");
    var descripcion = document.createElement("h3");
    var precio = document.createElement("h4");
    var imagen = document.createElement("img");


    nombre.innerHTML = datos.Nombre;
    descripcion.innerHTML = datos.Descripcion;
    precio.innerHTML = datos.Precio;
    imagen.src = ".." + datos.Foto;
    
    document.getElementById("contdiv").appendChild(nombre);
    document.getElementById("contdiv").appendChild(descripcion);
    document.getElementById("contdiv").appendChild(precio);
    document.getElementById("contdiv").appendChild(imagen);


}