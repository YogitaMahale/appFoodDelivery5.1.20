


var datatable;
$(document).ready(function () {   
        loadtable();    
});

function loadtable() {


    datatable = $('#tblData').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/Feedback/customerToStoreFeedbackJson/"
            // "type": "GET",
            //"datatype": "json"
        },

        "columns": [
            

            { "data": "customername", "width": "20" },
            { "data": "storename", "width": "20%" },
            { "data": "comment", "width": "35%" },
            //{ "data": "rating", "width": "10%" },
             
            {
                "data": "rating",

                "render": function (data, type, row, meta) {
                    //alert(data);
                    var i;
                    var str = "<div>";
                    for (i = 0; i < 5; i++) {
                        if (i < data) {
                            str += "<span class='fas fa-star checked text-info'></span>"
                        }
                        else {
                            str += "<span class='fas fa-star'></span>"
                        }
                    }
                    str += "</div>";
                    return `${str}`

                }, "width": "15%"

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
