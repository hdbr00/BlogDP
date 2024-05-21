var datatable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    datatable = $("#tblComentarios").DataTable({
        "ajax": {
            "url": "/admin/comentarios/GetComentarios",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idComentario", "width": "5%" },
            { "data": "titulo", "width": "20%" },
            { "data": "mensaje", "width": "20%" },
            { "data": "articulo.titulo", "width": "20%" },
            { "data": "fechaCreacion", "width": "20%" },
            {
                "data": "idComentario",
                "render": function (data) {
                    return `
                      <div class="text-center">
                        <a onclick=Delete("/admin/comentarios/BorrarComentario/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-x-square"></i> Borrar
                        </a>
                      </div>`;
                }
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: '¿Está seguro de borrar?',
        text: 'Este contenido no se puede borrar.',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        confirmButtonText: 'Sí, borrarlo'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}










//function Delete(url) {
//    Swal({
//        title: '¿Está seguro de borrar?',
//        text: 'Este contenido no se puede borrar.',
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        confirmButtonText: 'Sí, borrarlo'
//    }, function () {
//            $.ajax({
//                type: 'DELETE',
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                        datatable.ajax.reload();
//                    } else {
//                        toastr.error(data.message);
//                }

//            }
//       });
       
//    });
//}
