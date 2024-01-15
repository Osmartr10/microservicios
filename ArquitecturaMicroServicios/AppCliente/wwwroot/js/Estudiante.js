function PreEliminar(id) {
    $("#IdEliminar").val(id);
    $("#eliminarModal").modal("show");
}
function Eliminar() {

    var Idestudiante = $("#IdEliminar").val()
    $.ajax({
        url: "/Estudiante/Delete",
        type: "POST",
        dataType: "json",
        data: { id: Idestudiante },
        success: function (data) {
            $("#eliminarModal").modal("hide");
            location.reload();
        },
        error: function () {

        }
    });
}