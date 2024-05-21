var datatable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    datatable = $("#tblArticulos").DataTable({
        "ajax": {
            "url": "/admin/articulos/GetArticulos",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idArticulo", "width": "5%" },
            { "data": "titulo", "width": "10%" },
           
            {
                "data": "imagen",
                "render": function (imagen) {
                    return `<img src=../${imagen} width="100"/>`;

                },"width":"10%"

            },
            { "data": "estado", "width": "5%" },
            { "data": "categoria.nombre", "width": "10%" },
            { "data": "categoria.fechaCreacion", "width": "15%" },
            {
                "data": "idArticulo",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/admin/articulos/editar/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-pencil-square"></i> Editar
                        </a>
                        &nbsp;
                        <a onclick=Delete("/admin/articulos/BorrarArticulo/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-x-square"></i> Borrar
                        </a>
                         &nbsp;
                         <a href="/admin/articulos/AsignarEtiquetas/${data}" class="btn btn-secondary text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-tags-fill"></i> Asignar Etiquetas
                         </a>
                      </div>
                      `;
                }, "width": "50%"
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
