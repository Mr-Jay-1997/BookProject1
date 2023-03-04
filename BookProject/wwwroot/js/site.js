// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollX": false,
        "scrollY": false,
        "scrollCollapse": true,
        "paging": true,
        "sWidth" : '10%'

    });
});

$(document).ready(function () {
    $('#myTable2').DataTable({
        "scrollX": false,
        "scrollY": false,
        "scrollCollapse": true,
        "paging": true,
        "sWidth": '10%',
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
        ]
    }); 
});


//showInPopup = (url, title) => {
//    $.ajax({
//        type: "GET",
//        url: url,
//        success: function (res) {
//            $("#form-modal .modal-body").html(res);
//            $("#form-modal .modal-title").html(title);
//            $("#form-modal").modal('show');
//        }

//    })
//}
