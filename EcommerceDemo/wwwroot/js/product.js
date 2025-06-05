var dataTable;
$(function () {
    loadTableData();
});


function loadTableData() {
   dataTable= $('#productDetails').DataTable({
        "ajax": {
            url: '/admin/product/getall',
            //dataSrc: function (json) {
            //    console.log(json); // Check the structure here in the browser console
            //    return json; // Or json.data if your endpoint returns { data: [...] }
            //}
        },
        "columns": [
            { data: 'name',"width":"20%"},
            { data: 'description', "width": "20%" },
            { data: 'price', "width": "10%" },
            { data: 'discount', "width": "10%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?id=${data}"  class="btn btn-primary mx-2"><i class="bi bi-pencil"></i>Edit</a>
                    <a onClick=Delete('/admin/product/delete?id=${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>Delete </a>
                    </div>`
                }
            }
        ]
    });
}

function Delete(url){
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this imaginary file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: url,
                    type: "DELETE",
                    success: function (data) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                })
            } 
            else {
                swal("Your imaginary file is safe!");
            }
        });
}