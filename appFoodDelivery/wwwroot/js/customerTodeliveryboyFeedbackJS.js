﻿


var datatable;
$(document).ready(function () {   
    loadtable();    
    //$('#input-3').rating({ displayOnly: true, step: 0.5 });
});

function loadtable() {


    datatable = $('#tblData').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/Feedback/customerTodeliveryboyFeedbackJson/"
            // "type": "GET",
            //"datatype": "json"
        },

        "columns": [
            

            { "data": "customername", "width": "20" },
            { "data": "deliveryboyname", "width": "20%" },
            { "data": "comment", "width": "10%" },
            { "data": "rating", "width": "10%" }
             
 //             {
 //               "data": "id",
 //               "render": function (data, type, row, meta) {
 //                   return `
 
 //<div class="rating-stars d-flex mr-5">
 //                                       <input id="input-3" name="input-3" value="4" class="rating-loading">      
 //                                       </div>`
 //               }, "width": "40%"

 //           }
           
           
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
$(function () {
    $('span.stars').stars();
});