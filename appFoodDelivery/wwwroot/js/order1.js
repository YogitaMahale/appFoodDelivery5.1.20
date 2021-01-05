var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    // alert(url);
    if (url.includes("pending")) {
        loadDataTable("GetOrderList?status=pending");
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

                            loadDataTable("GetOrderList?status=all");

                        }

                    }

                }
            }
        }
    }
    //pending
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
            { "data": "id", "width": "10%" },
            { "data": "storename", "width": "10%" },
            { "data": "customerName", "width": "10%" },
            { "data": "amount", "width": "10%" },
            { "data": "placedate", "width": "20%" },
            { "data": "orderstatus", "width": "10%" },
            {
                "data": "id",
                //"render": function (data) {
                    
                //    return str +" "+`<div class="text-center">
                        
                //        <a href="/Order/Details?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                //            Details
                //        </a>
                //        </div>`;
                //}
                  "render": function (data, type, row, meta) {
                      //alert(row['orderstatus'] + " -----" + row['id']);
                        
                      if (row['orderstatus'] == "Placed")
                      {
                          return `<div class="text-center">
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                      approved
                                  </a>
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                      Details
                                  </a>
                                    <a href="/Order/Details?id=${row['id']}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                      Cancel Order
                                  </a>
                                 </div>`;
                      }
                      else if (row['orderstatus'] == "approved")
                      {
                          return `<div class="text-center">
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                      Process
                                  </a>
                                  <a href="/Order/Details?id=${row['id']}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                      Details
                                  </a>
                                    <a href="/Order/Details?id=${row['id']}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                      Cancel Order
                                  </a>
                                 </div>`;
                      }
                      else if (row['orderstatus'] == "processorders") {

                      }
                      else if (row['orderstatus'] == "ongoingorders") {

                      }
                      else if (row['orderstatus'] == "completedorders") {

                      }
                      else if (row['orderstatus'] == "cancelledorders") {

                      }
                     
                }
                //"render": function (data, type, row, meta) {
                //    alert(row['district']);
                //    return '<a href="/schools/' + makeSlug(row['district']) + '/' + makeSlug(data) + '">' + data + '</a>';
                //}


                , "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//<a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
//    onclick=Delete('/api/book?id=' + ${ data })>
//        Delete
//                        </a >

     