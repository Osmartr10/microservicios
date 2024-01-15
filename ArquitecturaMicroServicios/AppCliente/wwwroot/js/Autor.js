function PreEliminar(id) {
    $("#IdEliminar").val(id);
    $("#eliminarModal").modal("show");
}
function Eliminar() {

    var Idautor = $("#IdEliminar").val()
    $.ajax({
        url: "/Autor/Delete",
        type: "POST",
        dataType: "json",
        data: { id: Idautor },
        success: function (data) {
            $("#eliminarModal").modal("hide");
            location.reload();
        },
        error: function () {

        }
    });
}