var cont = 0;
var detalles = 0;
document.getElementById("btnGuardar").style.display = "none";

function agregarProducto(idlibro, titulo, anio, editorial) {
   
    if (idlibro != "") {
        if (buscarProducto(idlibro)) {
            alert("El libro ya fue agregado a la lista");
        }
        else {
           

            var fila = '<tr class="filas" id="fila' + cont + '">' +

                '<td><input type="hidden"  class="form-control"  id="libro" name="idlibro[]" value="' + idlibro + '">' + idlibro + '</td>' +
                '<td>' + titulo + '</td>' +
                '<td>' + anio + '</td>' +
                '<td>' + editorial + '</td>' +
                '<td><button type="button" class="btn btn-danger" onclick="eliminarDetalle(' + cont + ')">X</button></td>' +
                '</tr>';
            cont++;
            detalles = detalles + 1;
            $('#detalles').append(fila);            
            evaluar();
        }
    }
    else {
        alert("Error al Ingresar el detalle, revisar los datos del libro");
    }
}
function buscarProducto(idproducto) {
    let filas = $('#detalles').find('tbody tr').length;

    if (filas > 0) {
        var productos = [];
        $('#detalles tbody tr').find('td:eq(0)').each(function () {
            id = $(this).find('#libro').val();
            productos.push(id);

        });
        let text = idproducto.toString();
        if (productos.includes(text)) {
            return true;
        } else {
            return false;

        }

    }
    else {
        return false;
    }
}



function eliminarDetalle(indice) {
    $("#fila" + indice).remove();
    calcularTotales();
    detalles = detalles - 1;
    evaluar();
}
function evaluar() {
    if (detalles > 0) {

        $("#btnGuardar").show();
    }
    else {
        $("#btnGuardar").hide();
        cont = 0;
    }
}


function PreEliminar(id) {
    $("#IdEliminar").val(id);
    $("#eliminarModal").modal("show");
}
function Eliminar() {

    var Idprestamo = $("#IdEliminar").val()
    $.ajax({
        url: "/Prestamo/Delete",
        type: "POST",
        dataType: "json",
        data: { id: Idprestamo },
        success: function (data) {
            $("#eliminarModal").modal("hide");
            location.reload();
        },
        error: function () {

        }
    });
}
function guardarDetalle() {

    var detalle = new Array();
    $("#detalles tbody tr").each(function () {

        var Idlibro = $(this).find('#libro').val();
     
        var Detalleventa = {};
        Detalleventa.Idlibro = Idlibro;      
        detalle.push(Detalleventa);
    });

    var strJson = JSON.stringify(detalle);
    $.ajax({
        url: "/Prestamo/InsertarDetalle",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: strJson,
        success: function () {

        },
        error: function () {

        }
    });

}