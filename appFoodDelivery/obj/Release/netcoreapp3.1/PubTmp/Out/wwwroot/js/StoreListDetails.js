


var datatable;
$(document).ready(function () {   
        loadtable();    
});

function loadtable() {


    datatable = $('#tblData').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/Account/GetStoreListDetails/"
            // "type": "GET",
            //"datatype": "json"
        },

        "columns": [
            //{ "data": "id", "width": "10%", style="display:none;" },
            {
                "data": "storeBannerPhoto",
                "render": function (data) {
                    return `
<div class="text-center">
     <img alt="image" src="${data}" />
   
</div>`
                }, "width": "10%"
            },

            { "data": "ownername", "width": "10%" },
            { "data": "storeName", "width": "10%" },
            { "data": "storestatus", "width": "10%" },
            { "data": "taxstatus", "width": "10%" },
            { "data": "taxstatusPer", "width": "10%" },
            //{ "data": "img", "width": "20% " },         


            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/Account/EditListUsers/${data}" class="btn btn-success text-white" style="cursor:pointer">
        Edit
    </a>
    <a href="/Account/deleteListUsers/${data}" class="btn btn-danger text-white" style="cursor:pointer">
        Delete
    </a>
 <a href="/Account/storeDetails/${data}" class="btn btn-info text-white" style="cursor:pointer">
        Details
    </a>
</div>`
                }, "width": "30%"

            }

        ]
    });
}
 


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
