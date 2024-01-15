function PreEliminar(id) {
    $("#IdEliminar").val(id);
    $("#eliminarModal").modal("show");
}
function Eliminar() {

    var Idlibro = $("#IdEliminar").val()
    $.ajax({
        url: "/Libro/Delete",
        type: "POST",
        dataType: "json",
        data: { id: Idlibro },
        success: function (data) {
            $("#eliminarModal").modal("hide");
            location.reload();
        },
        error: function () {

        }
    });
}