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
            if(data == true)
            {
                alert("Thêm nhân viên vào dự án thành công");
                window.location.href = "/Project/Statistic/" + pro_id;
            }
            else
            {
                alert("Nhân viên này đã có trong dự án");
            }
        },
        error: function(){
            alert("Bạn không có quyền thực hiện tác vụ này");
        }
    })
})

$('#Insert_Project').click(function () {
    alert("dsasshjfdshfgsdfds");
    var name = $('#project_name').val();
    var cus_id = $('#select_customer option:selected ').val();
    var time_start = $('#time_start_pro').val();
    var time_end = $('#time_end_pro').val();
    var desc = $('#descr_pro').val();

    $.ajax({
        url: '/Project/Insert',
        data: { name: name, cus_id: cus_id, time_start: time_start, time_end: time_end, describe: desc },
        type: 'POST',
        datatype: 'json',
        success: function (data) {
            if(data ==true)
            {
                alert("Thêm dự án thành công");
                window.location.href = "/Project/Index";
            }
            else
            {
                alert("Có lỗi trong quá trình thêm");
            }
        },
        error: function () {
            alert("Bạn không có quyền thực hiện tác vụ này")
        }
    })
})