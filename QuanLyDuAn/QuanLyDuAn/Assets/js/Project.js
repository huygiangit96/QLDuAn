$('.delete_pro').off('click').on('click',function () {
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
        data: { name: name, emp_id: emp_id, cus_id: cus_id, time_start: time_start, time_end: time_end, desc: desc },
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
$('.btn_SuaVC').off('click').on('click', function () {
    $('#CalenderModalEdit').modal('show');
    var macv = $(this).data('id');
    if ($('#user_authorization').val() != 3 || $('input[type="hidden"]').hasClass('user_project_manager')) {
        $('.has_author_change').prop('disabled', false);
    }

    $('#cvv_TenDA').text('');
    $('#cvv_TenCV').text('');
    $('#cvv_NoiDung').text('');;
    $('#cvv_start_time').text('');
    $('#cvv_end_time').text('');
    $('#cvv_cong').text('');

    //$('#cvv_TenDA').val(calEvent.TenDA);
    //$('#cvv_TenCV').val(calEvent.TenCV);
    //$('#cvv_NoiDung').append(calEvent.NoiDung);
    //$('#cvv_start_time').val($.formattedDate(new Date(parseInt(calEvent.ThoiGianBD.substr(6)))).split("/").reverse().join("-"));
    //$('#cvv_end_time').val($.formattedDate(new Date(parseInt(calEvent.ThoiGianKT.substr(6)))).split("/").reverse().join("-"));
    //$('#cvv_cong').val(calEvent.SoCong);

    $.ajax({
        url: '/Project/GetCVbyID',
        dataType: 'json',
        data: { macv: macv },
        type: 'get',
        success: function (data) {
            $('#cvv_TenDA').val(data.TenDA);
            $('#cvv_TenCV').val(data.TenCV);
            $('#cvv_NoiDung').append(data.NoiDung);
            $('#cvv_start_time').val($.formattedDate(new Date(parseInt(data.ThoiGianBD.substr(6)))).split("/").reverse().join("-"));
            $('#cvv_end_time').val($.formattedDate(new Date(parseInt(data.ThoiGianKT.substr(6)))).split("/").reverse().join("-"));
            $('#cvv_cong').val(data.SoCong);
        }
    })

    $.ajax({
        url: '/Task/GetNV_CV_Vtri',
        type: 'GET',
        dataType: 'json',
        data: { macv: macv},
        success: function (data) {
            var rows = "";
            var count = 0;
            $.each(data, function (i, item) {
                count++;
                if ($('#user_authorization').val() != 3 || $('input[type="hidden"]').hasClass('user_project_manager')) {
                    rows += '<tr><th scope="row">' + count + '</th>'
                    + '<td>' + item.TenNV + '</td>'
                    + '<td>' + item.ViTri + '</td>'
                    + '<td data-id="' + item.MaNV + '"><i class="fix_vitri fa fa-wrench" role="button" data-toggle="modal" data-target="#Modal_sua_vt" data-id1=' + item.MaNV + ' data-id2=' + item.MaCV + '></td></tr>';
                }
                else {
                    rows += '<tr><th scope="row">' + count + '</th>'
                    + '<td>' + item.TenNV + '</td>'
                    + '<td>' + item.ViTri + '</td>'
                    + '<td ></td></tr>';
                }
            })
            $('#edit_cv_nv').empty();
            $('#edit_cv_nv').attr('data-id', macv);
            $('#edit_cv_nv').append(rows);
        }
    })

})


$('.edit_pro').off('click').on('click', function () {
    var mada = $(this).data('id');
    $.ajax({
        url: '/Project/GetProjByID',
        dataType: 'json',
        type: 'get',
        data: { mada: mada },
        success: function (data) {
            $('#project_name_e').val(data.Ten);
            $('#select_leader_e').val(data.TruongDuAn);
            $('#select_customer_e').val(data.KhachHang);
            $('#time_start_pro_e').val($.formattedDate(new Date(parseInt(data.NgayBatDau.substr(6)))).split("/").reverse().join("-"));
            $('#time_end_pro_e').val($.formattedDate(new Date(parseInt(data.NgayKetThuc.substr(6)))).split("/").reverse().join("-"));
            $('#descr_pro_e').val(data.MoTa);
        }
    })
    $('#CalenderModalEdit').modal('show');
    $('#Edit_Project').attr('data-id', mada);
})
$('#Edit_Project').off('click').on('click', function () {
    var mada = document.getElementById('Edit_Project').getAttribute('data-id');
    var truongduan = $('#select_leader_e').val();
    var start_time = $('#time_start_pro_e').val();
    var end_time = $('#time_end_pro_e').val();
    var mota = $('#descr_pro_e').val();
    $.ajax({
        url: '/Project/Update_DA',
        type: 'post',
        dataType: 'json',
        data: { mada: mada, truongduan: truongduan, start_time: start_time, end_time: end_time, mota: mota },
        success: function (res) {
            if (res.status == true) { alert('Sửa thành công'); }
            else { alert('Có lỗi xảy ra !!');}
        }
    })
})