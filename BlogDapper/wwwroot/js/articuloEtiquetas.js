var datatable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    datatable = $("#tblArticuloEtiquetas").DataTable({
        "ajax": {
            "url": "/admin/Etiquetas/GetArticulosEtiquetas",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idArticulo", "width": "30%" },
            { "data": "titulo", "width": "30%" },
            { "data": "etiqueta.[0].nombreEtiqueta", "width": "30%" },
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
