$(document).ready(function () {
    loadDataTable();
});

var dataTable;
function loadDataTable() {
    dataTable = new DataTable('#tblData', {
        ajax: { url: '/admin/product/getall' },
        columns: [
            { data: 'title' },
            { data: 'isbn' },
            { data: 'author' },
            { data: 'price' },
            { data: 'category.name' },
            {
                data: 'id',
                render: function (data) {
                    return `
                        <a href="/admin/product/upsert/${data}" class="btn btn-primary"><i class="bi bi-pencil-square"></i> Edit</a>
                        <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger"><i class="bi bi-trash-fill"></i> Delete</a>
                    `;
                },
                className: 'text-center'
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    Swal.fire({
                        title: "Deleted!",
                        text: data.message,
                        icon: "success"
                    }).then(() => {
                        dataTable.ajax.reload();
                    });
                },
                error: function () {
                    Swal.fire({
                        title: "Error!",
                        text: "Something went wrong.",
                        icon: "error"
                    });
                }
            });
        }
    });

}
