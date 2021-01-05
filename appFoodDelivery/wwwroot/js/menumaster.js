var datatable;
$(document).ready(function () {


    $("#cusineid").change(function () {

        //var url = '@Url.Content("~/")' + 'CityRegistration/getstatebyid';
        var ddlsource = "#cusineid";
        // alert($(ddlsource).val());
        loadtable($(ddlsource).val());
        //$.getJSON(url,

    });
    //   loadtable();
});

function loadtable(id) {


    datatable = $('#tblData').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/menumaster/GetALL/" + id
            // "type": "GET",
            //"datatype": "json"
        },
        "columns": [
            //{ "data": "cusinename", "width": "30%" },
            { "data": "name", "width": "30%" },
            //{ "data": "img", "width": "20% " },
            {
                "data": "img",
                "render": function (data) {
                    return `
<div class="text-center">
     <img alt="image" src="${data}" />
   
</div>`
                }, "width": "20%"

            },
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/menumaster/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer">
        Edit
    </a>
    <a href="/menumaster/Delete/${data}" class="btn btn-danger text-white" style="cursor:pointer">
        Delete
    </a>
</div>`
                }, "width": "20%"

            }

        ]
    });
}

//<a class="btn btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/Category/Delete/${data}") >
//    Delete
//    </a >
//function Delete(url) {
//    swal({
//        title: "Are you sure you want to delete?",
//        text: "You will not be able to restore the data",
//        icon: "warning",
//        buttons: true,
//        dangerMode: true

//    }).then((willDelete) => {
//        if (willDelete) {
//            $.ajax({
//                type: "DELETE",
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                        dataTable.ajax.reload();
//                    }
//                    else {
//                        toastr.error(data.message);
//                    }
//                }
//            });
//        }


//    });

//}



























































 