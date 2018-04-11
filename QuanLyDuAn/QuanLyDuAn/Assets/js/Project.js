$('#delete_pro').click(function () {
    var id = $(this).data('id');
    var r = confirm("Bạn có chắc chắn muốn xóa dự án này ?");
    if (r == true) {
        $.ajax({
            url: '/Project/Delete',
            data: { id: id },
            type: 'POST',
            datatype: 'json',
            success: function (data) {
                if (data == true) {
                    alert("Xóa dự án thành công");
                    window.location.href = "/Project/Index";
                }
                else {
                    alert("Có lỗi trong quá trình xóa");
                }
            },
            error: function () {
                alert("Bạn không có quyền thực hiện tác vụ này");
            }
        })
    }
})