


var datatable;
$(document).ready(function () {   
        loadtable();    
});

function loadtable() {


    datatable = $('#tblData').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/Feedback/deliveryboyCustomerFeedbackJson/"
            // "type": "GET",
            //"datatype": "json"
        },

        "columns": [
            
            { "data": "deliveryboyname", "width": "20%" },
            { "data": "customername", "width": "20" },
          
            { "data": "comment", "width": "50%" },
            { "data": "rating", "width": "10%" }
             
 //             {
 //               "data": "id",
 //               "render": function (data, type, row, meta) {
 //                   return `
 //<div class="rating-stars d-flex mr-5">
 //                                           <input type="number" readonly="readonly" class="rating-value star" name="rating-stars-value" value="2">
 //                                           <div class="rating-stars-container mr-2">
 //                                               <div class="rating-star sm">
 //                                                   <i class="fa fa-star"></i>
 //                                               </div>
 //                                               <div class="rating-star sm">
 //                                                   <i class="fa fa-star"></i>
 //                                               </div>
 //                                               <div class="rating-star sm">
 //                                                   <i class="fa fa-star"></i>
 //                                               </div>
 //                                               <div class="rating-star sm">
 //                                                   <i class="fa fa-star"></i>
 //                                               </div>
 //                                               <div class="rating-star sm">
 //                                                   <i class="fa fa-star"></i>
 //                                               </div>
 //                                           </div> 
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
