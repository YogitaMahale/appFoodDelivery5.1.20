


var datatable;
$(document).ready(function () {   
        loadtable();    
});

function loadtable() {


    datatable = $('#tblData').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/Account/GetUserDetails/"
            // "type": "GET",
            //"datatype": "json"
        },

        "columns": [
            //{ "data": "id", "width": "10%", style="display:none;" },
            

            { "data": "name", "width": "20%" },
            { "data": "email", "width": "30%" },
            { "data": "mobileno", "width": "20%" },
             
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/Account/EditListUsers/${data}" class="btn btn-success text-white" style="cursor:pointer">
        Edit
    </a>
   
  
</div>`
                }, "width": "30%"

            }

        ]
    });
}
 
 //<a href="/Account/deleteListUsers/${data}" class="btn btn-danger text-white" style="cursor:pointer">
    //    Delete
    //</a>
