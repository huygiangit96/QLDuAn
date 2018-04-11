
// Delete one customer
$('.delete_cus').click(function () {
    var id = $(this).data('id');
    var r = confirm("bạn có chăn chắn muốn xóa không ?");
    if (r == true) {
        $.ajax({
            url: '/Customer/Delete',
            data: { id: id },
            type: 'GET',
            datatype: 'json',
            success: function (data) {
                if (data == true) {
                    alert("Xóa thành công");
                    window.location.href = "/Customer/Index";
                }
                else {
                    alert("Có lỗi trong quá trình xóa");
                }
            },
            error: function (err) {
                alert("Bạn không có quyền thực hiện tác vụ này");
            }
        })
    }
});

//Insert one customer
$('#Insert_Cus').click(function () {
    var ten = $('#Cus_name').val();
    var diachi = $('#Cus_address').val();
    var sotk = $('#Cus_bank').val();
    var phone = $('#Cus_phone').val();

    $.ajax({
        url: '/Customer/Insert',
        data: {name: ten, address: diachi, bank: sotk, phone: phone },
        type: 'POST',
        datatype: 'json',
        success: function (data) {
            if (data == true) {
                alert("Thêm thành công");
            }
            window.location.href = "/Customer/Index";
        },
        error: function () {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
});

// Update one customer
$('#Edit_Cus').click(function () {
    var id = $('#Cus_code').val();
    var ten = $('#Cus_name').val();
    var diachi = $('#Cus_address').val();
    var sotk = $('#Cus_bank').val();
    var phone = $('#Cus_phone').val();

    $.ajax({
        url: '/Customer/Edit',
        data: { code: id, name: ten, address: diachi, bank: sotk, phone: phone },
        type: 'POST',
        datatype: 'json',
        success: function (data) {
            if (data == true) {
                alert("Cập nhật thành công");
            }
            window.location.href = "/Customer/Index";
        },
        error: function () {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
});

// show one customer on modal
$('.btn_edit_cus').click(function () {
    var id = $(this).data('id');
    $.ajax({
        url: '/Customer/Get',
        data: { id: id },
        type: 'GET',
        datatype: 'json',
        success: function (data) {
            $('#Cus_code_E').val(id);
            $('#Cus_name_E').val(data.Ten);
            $('#Cus_address_E').val(data.DiaChi);
            $('#Cus_bank_E').val(data.SoTK);
            $('#Cus_phone_E').val(data.SoDT);
            $('#editModal').modal('show');
        },
        error: function (err) {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
});
