
// Delete one employee
$('.delete_emp').click(function () {
    var id = $(this).data('id');
    var r = confirm("bạn có chăn chắn muốn xóa không ?");
    if (r == true) {
        $.ajax({
            url: '/Employee/Delete',
            data: { id: id },
            type: 'GET',
            datatype: 'json',
            success: function (data) {
                if (data == true) {
                    alert("Xóa thành công");
                    window.location.href = "/Employee/Index";
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

//Insert one Employee
$('#Insert_Emp').click(function () {
    var id = $('#Emp_code').val();
    var ten = $('#Emp_name').val();
    var diachi = $('#Emp_address').val();
    var phongban = $('#Emp_select_pb option:selected ').val();
    var bophan = $('#Emp_select_bp option:selected ').val();
    var vaitro = $('#Emp_select_vt option:selected ').val();
    var sotk = $('#Emp_bank').val();
    var sodt = $('#Emp_phone').val();
    var trinhdo = $('#Emp_level').val();
    var email = $('#Emp_email').val();

    $.ajax({
        url: '/Employee/Insert',
        data: {
            code: id, name: ten, address: diachi, department: phongban, parts: bophan,
            role: vaitro, bank: sotk, phone: sodt, level: trinhdo, email: email
        },
        type: 'POST',
        datatype: 'json',
        success: function (data) {
            if (data == true) {
                alert("Thêm thành công");
            }
            else {
                alert("Có lỗi trong quá trình thêm, bạn hãy xem lại các giá trị đã nhập");
            }
            window.location.href = "/Employee/Index";
        },
        error: function () {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
});

// Update one customer
$('#Edit_Emp').click(function () {
    var id = $('#Emp_code_E').val();
    var ten = $('#Emp_name_E').val();
    var diachi = $('#Emp_address_E').val();
    var phongban = $('#Emp_select_pb_E option:selected ').val();
    var bophan = $('#Emp_select_bp_E option:selected ').val();
    var vaitro = $('#Emp_select_vt_E option:selected ').val();
    var sotk = $('#Emp_bank_E').val();
    var sodt = $('#Emp_phone_E').val();
    var trinhdo = $('#Emp_level_E').val();
    var email = $('#Emp_email_E').val();

    $.ajax({
        url: '/Employee/Edit',
        data: {
            code: id, name: ten, address: diachi, department: phongban, parts: bophan,
            role: vaitro, bank: sotk, phone: sodt, level: trinhdo, email: email
        },
        type: 'POST',
        datatype: 'json',
        success: function (data) {
            if (data == true) {
                alert("Sửa thành công");
            }
            window.location.href = "/Employee/Index";
        },
        error: function () {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
});
// show one customer on modal
$('.btn_edit_emp').click(function () {
    var id = $(this).data('id');
    $.ajax({
        url: '/Employee/Get',
        data: { id: id },
        type: 'GET',
        datatype: 'json',
        success: function (data) {
            $('#Emp_code_E').val(id);
            $('#Emp_name_E').val(data.Ten);
            $('#Emp_address_E').val(data.DiaChi);
            $('#Emp_bank_E').val(data.SoTK);
            $('#Emp_phone_E').val(data.SoDT);
            $('#Emp_level_E').val(data.TrinhDo);
            $('#Emp_email_E').val(data.Email);
            $('#Emp_select_pb_E option:selected').val(data.MaPB);
            $('#Emp_select_vt_E').val(data.MaVT).change();
            $('#Emp_select_bp_E option:selected').val(data.MaBP);
            $('#editModal').modal('show');
        },
        error: function (err) {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
});
