var dataTable;

$(document).ready(function () {
    var url = window.location.search;


    // alert(url);
    if (url.includes("pending")) {
        loadDataTable("GetOrderList?status=Placed");
    } else {
        if (url.includes("approved")) {
            loadDataTable("GetOrderList?status=approved");
        }
        else {
            if (url.includes("processorders")) {
                loadDataTable("GetOrderList?status=processorders");
            }
            else {
                if (url.includes("ongoingorders")) {
                    loadDataTable("GetOrderList?status=ongoingorders");
                }
                else {

                    if (url.includes("completedorders")) {
                        loadDataTable("GetOrderList?status=completedorders");
                    }
                    else {

                        if (url.includes("cancelledorders")) {
                            loadDataTable("GetOrderList?status=cancelledorders");
                        }
                        else {

                            loadDataTable("GetOrderList?status=Placed");

                        }

                    }

                }
            }
        }
    }
    //Placed
    //approved
    //processorders
    //ongoingorders
    //completedorders
    //cancelledorders



});

function loadDataTable(url) {
    //alert(url);
    dataTable = $('#DT_load').DataTable({

        "ajax": {
            "url": "/Order/" + url,
            "type": "GET",
            "datatype": "json"
        },


        "columns": [
            {
                "data": "id",
                "render": function (data, type, row, meta) {
                    //alert(row['orderstatus'] + " -----" + row['id']);
                    if (row['logintype'] == "admin") {
                        if (row['paymenttype'] == "Cash on Delivery") {


                            if (row['orderstatus'] == "completedorders" || row['orderstatus'] == "cancelledorders") {
                                return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                  
                                      
                            `;
                            }
                            else {

                                if (row['deliveryboyid'] === undefined || row['deliveryboyid'] == null || row['deliveryboyid'] == "") {

                                    return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                  
                                      <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>
  <a data-toggle="modal" data-id=${row['id']} data-toggle="modal" title="Add this item" class="open-AddBookDialog btn btn-success text-white btn-lg"  style='cursor:pointer; width:80px;' href="#myModal">Complete COD </a> 
            <a href="/Order/deliveryboyassign?id=${row['id']}" class='btn btn-warning text-white btn-lg'  style='cursor:pointer; width:100px;'>
                                      Assign Deliveryboy
                                  </a> 
                                
                            `;
                                }
                                else {
                                    return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                  
                                      <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>
  <a data-toggle="modal" data-id=${row['id']} data-toggle="modal" title="Add this item" class="open-AddBookDialog btn btn-success text-white btn-lg"  style='cursor:pointer; width:80px;' href="#myModal">Complete COD </a> 
        
                                
                            `;
                                }



                            }
                            //                          return `<div class="text-center">                           

                            //                                <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>

                            //                                    <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>
                            //<a data-toggle="modal" data-id=${row['id']} data-toggle="modal" title="Add this item" class="open-AddBookDialog btn btn-success text-white btn-lg"  style='cursor:pointer; width:80px;' href="#myModal">Complete COD </a> 


                            //                          `;

                        }
                        else {


                            if (row['orderstatus'] == "completedorders" || row['orderstatus'] == "cancelledorders") {
                                return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                    
                                 
                            `;
                            }
                            else {


                                if (row['deliveryboyid'] === undefined || row['deliveryboyid'] == null || row['deliveryboyid'] == "") {
                                    return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                    <a href="/Order/changeorderStatus?id=${row['id']}&status=completedorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:80px;'>Complete</a>
                                      <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>
                             <a href="/Order/deliveryboyassign?id=${row['id']}" class='btn btn-warning text-white btn-lg'  style='cursor:pointer; width:100px;'>
                                      Assign Deliveryboy
                                  </a> 
                                 
                            `;
                                }
                                else {
                                    return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                    <a href="/Order/changeorderStatus?id=${row['id']}&status=completedorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:80px;'>Complete</a>
                                      <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>
                           
                                 
                            `;
                                }






                            }


                            //return `<div class="text-center">                           

                            //      <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                            //        <a href="/Order/changeorderStatus?id=${row['id']}&status=completedorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:80px;'>Complete</a>
                            //          <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>


                            //`;

                        }


                        //paymenttype
                    }
                    else {
                        if (row['orderstatus'] == "Placed") {
                            return `<div class="text-center">
                            
                                  <a href="/Order/changeorderStatus?id=${row['id']}&status=approved" class='btn btn-success btn-block text-white btn-lg' style='cursor:pointer; width:70px;'>Approve</a>
                                 
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                     
                                    <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg btn-block' style='cursor:pointer; width:70px;'>Cancel Order</div>`;
                        }
                        else if (row['orderstatus'] == "approved") {
                            return `<div class="text-center">
                                   <a href="/Order/changeorderStatus?id=${row['id']}&status=processorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:70px;'>Process</a>
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg'  style='cursor:pointer; width:70px;'>
                                      Details
                                  </a> 
                                
                                    <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger  text-white btn-lg' style='cursor:pointer; width:70px;'>
                                      Cancel Order
                                  </a>
<a href="/Order/deliveryboyassign?id=${row['id']}" class='btn btn-warning text-white btn-lg'  style='cursor:pointer; width:100px;'>
                                      Assign Deliveryboy
                                  </a> 
                                 </div>`;
                        }
                        else if (row['orderstatus'] == "processorders") {
                            if (row['paymenttype'] == "Cash on Delivery") {
                                return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                  <a href="/Order/changeorderStatus?id=${row['id']}&status=ongoingorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:70px;display:none;'>Shipped</a>
                                      <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>
  <a data-toggle="modal" data-id=${row['id']} data-toggle="modal" title="Add this item" class="open-AddBookDialog btn btn-success text-white btn-lg"  style='cursor:pointer; width:80px;' href="#myModal">Complete COD </a> 
            
                                
                            `;
                            }
                            else {
                                return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
<a href="/Order/changeorderStatus?id=${row['id']}&status=ongoingorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:70px;display:none;'>Shipped</a>
                                    <a href="/Order/changeorderStatus?id=${row['id']}&status=completedorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:80px;'>Complete</a>
                                      <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>
 
                                 
                            `;

                            }

                            //return `<div class="text-center">
                            //       <a href="/Order/changeorderStatus?id=${row['id']}&status=ongoingorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:70px;display:none;'>Shipped</a>

                            //      <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg'  style='cursor:pointer; width:70px;'>
                            //          Details
                            //      </a> 

                            //     </div>`;
                        }
                        else if (row['orderstatus'] == "ongoingorders") {
                            if (row['paymenttype'] == "Cash on Delivery") {
                                return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                  
                                      <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>
  <a data-toggle="modal" data-id=${row['id']} data-toggle="modal" title="Add this item" class="open-AddBookDialog btn btn-success text-white btn-lg"  style='cursor:pointer; width:80px;' href="#myModal">Complete COD </a> 
            
                                
                            `;
                            }
                            else {
                                return `<div class="text-center">                           
                                  
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg btn-block ' style='cursor:pointer; width:70px;'>Details</a>
                                    <a href="/Order/changeorderStatus?id=${row['id']}&status=completedorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:80px;'>Complete</a>
                                      <a href="/Order/changeorderStatus?id=${row['id']}&status=cancelledorders" class='btn btn-danger text-white btn-lg' style='cursor:pointer; width:80px;'>Cancel</a>

                                 
                            `;

                            }
                            //return `<div class="text-center">
                            //       <a href="/Order/changeorderStatus?id=${row['id']}&status=completedorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:70px;display:none;'>Complete</a>

                            //      <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg'  style='cursor:pointer; width:70px;'>
                            //          Details
                            //      </a> 

                            //     </div>`;
                        }
                        else if (row['orderstatus'] == "completedorders") {
                            return `<div class="text-center">
                                   
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg'  style='cursor:pointer; width:70px;'>
                                      Details
                                  </a> 
                                    
                                 </div>`;
                        }
                        else if (row['orderstatus'] == "cancelledorders") {
                            return `<div class="text-center">
                                   
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-warning text-white btn-lg'  style='cursor:pointer; width:70px;'>
                                      Details
                                  </a> 
                                    
                                 </div>`;
                        }
                    }


                }
                , "width": "15%"
            }
            , { "data": "id", "width": "5%" },


            { "data": "cityName", "width": "10%" },
            { "data": "storename", "width": "20%" },
            { "data": "customerName", "width": "20%" },
            {
                "data": "amount",
                "render": function (data, type, row, meta) {
                    return `<div class="text-center">                           
                                  
                                 <i class="fas fa-rupee-sign fa-lg text-primary" style="margin-right:0.7em"></i> ${row['amount']}              
                                </div>
                            `;
                }
                , "width": "5%"
            },
            { "data": "placedate", "width": "10%" },
            { "data": "orderstatusPropername", "width": "10%" },
            { "data": "deliveryboyname", "width": "10%" },
            {
                "data": "time",
                "render": function (data, type, row, meta) {
                    return `<div class="text-center">                           
                                  
                                   <i class="fas fa-clock fa-lg text-primary" style="margin-right:0.7em"></i> ${row['time']}  Minutes ago              
                                </div>
                            `;
                }
                , "width": "10%"
            },
            { "data": "paymenttype", "width": "5%" }
            //{ "data": "paymentstatus", "width": "5%" },
            //{ "data": "deliveryboyCheckStaus", "width": "5%" }

            //, { "data": "logintype", "width": "10%" },
        ],
        "language": {
            "emptyTable": "no data found"
        },
        //'columnDefs': [
        //    //hide the second & fourth column
        //    //{ 'visible': false, 'targets': [1, 3] }
        //    {
        //        'targets': [0],
        //        'render': function (data, type, row, meta) {
        //            var student = row['logintype'];
        //            if (student == 'admin') {
        //                dataTable.columns(1).visible(false);
        //            } else {

        //            }
        //        }
        //    },
        //],
        "width": "100%"
    });
}

//<a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
//    onclick=Delete('/api/book?id=' + ${ data })>
//        Delete
//                        </a >

  //<a href="/Order/changeorderStatus?id=${row['id']}&status=completedorders" class='btn btn-success text-white btn-lg' style='cursor:pointer; width:80px;'>Complete</a>