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


$('#Insert_Emp_Pro').click(function () {
    var pro_id = $(this).data('id');
    var emp_id = $('#Emp_select option:selected ').val();
    $.ajax({
        url: '/Project/AddEmpInProject',
        data: { emp_id: emp_id, pro_id: pro_id },
        type: 'POST',
        datatype: 'json',
        success: function (data) {
            if (data == true) {
                alert("Thêm nhân viên vào dự án thành công");
                window.location.href = "/Project/Statistic/" + pro_id;
            }
            else {
                alert("Nhân viên này đã có trong dự án");
            }
        },
        error: function () {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
})

//validate project
function check_project() {
    var name = $('#project_name').val();
    var cus_id = $('#select_customer option:selected ').val();
    var emp_id = $('#select_leader option:selected ').val();
    var time_start = $('#time_start_pro').val();
    var time_end = $('#time_end_pro').val();
    var desc = $('#descr_pro').val();

    if(name = "" || cus_id == "" || emp_id == "" || time_start == "" || time_end == "")
    {
        return false;
    }
}
// thêm dự án
$('#Insert_Project').click(function () {
    var name = $('#project_name').val();
    var cus_id = $('#select_customer option:selected ').val();
    var emp_id = $('#select_leader option:selected ').val();
    var time_start = $('#time_start_pro').val();
    var time_end = $('#time_end_pro').val();
    var desc = $('#descr_pro').val();

    $.ajax({
        url: '/Project/Insert',
        data: { name: name, emp_id: emp_id, cus_id: cus_id, time_start: time_start, time_end: time_end, describe: desc },
        type: 'POST',
        datatype: 'json',
        success: function (data) {
            if (data == true) {
                alert("Thêm dự án thành công");
                window.location.href = "/Project/Index";
            }
            else {
                alert("Có lỗi trong quá trình thêm");
            }
        },
        error: function () {
            if (check_project() == false)
            {
                alert("Dữ liệu nhập chưa chính xác, bạn hãy kiểm tra lại");
            }
            else
            {
                alert("Bạn không có quyền thực hiện tác vụ này");
            } 
        }
    })
})

$('#Insert_CV').click(function () {
    var name = $('#name_cv').val();
    var cong = $('#cong_cv').val();
    var emp_id = $('#select_leader_cv option:selected ').val();
    var time_start = $('#time_start_cv').val();
    var time_end = $('#time_end_cv').val();
    var content = $('#cong_noidung').val();
    var pro_id = $(this).data('id');
    $.ajax({
        url: '/Project/Insert_CV',
        data: { name: name, content: content, emp_id: emp_id, pro_id: pro_id, time_start: time_start, time_end: time_end, cong: cong },
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data == true) {
                alert("Thêm công việc thành công");
                window.location.href = "/Project/Statistic/" + pro_id;
            }
            else {
                alert("Có lỗi trong quá trình thêm");
            }
        },
        error: function () {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
})

$('.Delete_CV').click(function () {
    var cv_id = $(this).data('id');
    var pro_id = $(this).data('pro');
    var result = confirm("Bạn có chắc chắn muốn xóa bản ghi này");
    if(result == true)
    {
        $.ajax({
            url: '/Project/Delete_CV',
            data: { id: cv_id },
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                if(data == true)
                {
                    alert("Xóa công việc thành công");
                    window.location.href = "/Project/Statistic/" + pro_id;
                }
                else
                {
                    alert("Có lỗi trong quá trình xóa");
                }
            },
            error: function () {
                alert("Bạn không có quyền thực hiện tác vụ này");
            }
        })
    }
})

$('.btn_status_cv').click(function () {
    var cv_id = $(this).data('id');
    var pro_id = $(this).data('pro');
    $.ajax({
        url: '/Project/Change_status_cv',
        data: { id: cv_id },
        type: 'POST',
        dataType: 'json',
        success: function (data) {
                window.location.href = "/Project/Statistic/" + pro_id;
        },
        error: function () {
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
})
