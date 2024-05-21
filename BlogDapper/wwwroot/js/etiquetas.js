var datatable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    datatable = $("#tblEtiquetas").DataTable({
        "ajax": {
            "url": "/admin/etiquetas/GetEtiquetas",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idEtiqueta", "width": "5%" },
            { "data": "nombreEtiqueta", "width": "40%" },
            { "data": "fechaCreacion", "width": "20%" },
            {
                "data": "idEtiqueta",
                "render": function (data) {
                    return `
                      <div class="text-center">
                        <a href="/admin/etiquetas/editar/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-pencil-square"></i> Editar
                        </a>
                        &nbsp;
                        <a onclick=Delete("/admin/etiquetas/BorrarEtiqueta/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px">
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
