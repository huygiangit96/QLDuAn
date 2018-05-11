$.formattedDate = function (dateToFormat) {
    var dateObject = new Date(dateToFormat);
    var day = dateObject.getDate();
    var month = dateObject.getMonth() + 1;
    var year = dateObject.getFullYear();
    day = day < 10 ? "0" + day : day;
    month = month < 10 ? "0" + month : month;
    var formattedDate = day + "/" + month + "/" + year;
    return formattedDate;
};

// tạo biến lưu ID của người reply (ID tự nhận là của người gửi cho nó)
var ID_NguoiNhan = 0;
$('.mail_title').off('click').on('click', function () {
    var id = $(this).data('id');
    ID_NguoiNhan = $(this).data('idr');
    $('#NguoiNhan_id').val($('#TenNguoiNhan_reply').data('name'));

    $.ajax({
        url: '/Task/ChangeMessStatus',
        dataType: 'json',
        type: 'post',
        data: { id: id },
        success: function (res) {
            if (res.status == true) {

            }
        }
    })

    $.ajax({
        url: '/Task/ViewMessage',
        dataType: 'json',
        type: 'GET',
        data: { id: id },
        success: function (data) {
            $('#viewMessTime').empty();
            $('#viewMessTitle').empty();
            $('#viewMessTo').empty();
            $('#viewMessFrom').empty();
            $('#viewMessSender').empty();
            $('#viewMessReceived').empty();
            $('#viewMessContent').empty();
            $('#viewMessTime').append($.formattedDate(new Date(parseInt(data.NgayTao.substr(6)))));
            $('#viewMessTitle').append(data.TieuDe);
            $('#viewMessTo').append('đến');
            $('#viewMessFrom').append('Từ');
            if (id == data.MaNV) {
                $('#viewMessSender').append('Me');
                $('#viewMessReceived').append(data.NguoiNhan);
            }
            else {
                $('#viewMessSender').append(data.Ten);
                $('#viewMessReceived').append('me');
            }
            $('#viewMessContent').append(data.NoiDung);
            $('#del_mess').attr('data-id', id);
        }
    })
})
$('#send_message').off('click').on('click', function () {
    var manv = $('#user_identification').attr('value');
    var tieude = $('#mess_title').val();
    if (tieude == "") tieude = '(Không tiêu đề)';
    var noidung = $('#mess_content').val();
    var nguoinhan = $('#receiver_mess').val();
    $.ajax({
        url: '/Task/SendMessage',
        dataType: 'json',
        type: 'post',
        data: { manv: manv, tieude: tieude, noidung: noidung, nguoinhan: nguoinhan },
        success: function (res) {
            if (res.status == true) {
                alert('Gửi thành công !');
                window.location.href = '/Task/Message';
            }
        }
    })
})
// reply_message
$('#reply_message').off('click').on('click', function () {
    var manv = $('#user_identification').attr('value');
    var tieude = $('#mess_title_reply').val();
    if (tieude == "") tieude = '(Không tiêu đề)';
    var noidung = $('#mess_content_reply').val();
    var nguoinhan = ID_NguoiNhan;
    $.ajax({
        url: '/Task/SendMessage',
        dataType: 'json',
        type: 'post',
        data: { manv: manv, tieude: tieude, noidung: noidung, nguoinhan: nguoinhan },
        success: function (res) {
            if (res.status == true) {
                alert('Gửi thành công !');
                window.location.href = '/Task/Message';
            }
        }
    })
})
$('#del_mess').off('click').on('click', function () {
    var mann = $(this).data('id');
    $.ajax({
        url: '/Task/DelMessage',
        dataType: 'json',
        type: 'post',
        data: { mann: mann },
        success: function (res) {
            if (res.status == true) {
                alert('Xóa thành công');
                window.location.href = '/Task/Message';
            }
        }
    })
})

//validate
function check() {
    var manv = $('#cv_pick_emp').val();
    var mada = $('#cv_pick_proj').val();
    var ten = $('#cv_name').val();
    var noidung = $('#cv_descr').val();
    var cong = $('#cv_cong').val();
    var start_time = $('#cv_time_start').val();
    var end_time = $('#cv_time_end').val();

    if (manv == "" || mada == "" || ten == "" || cong == "" || start_time == "" || end_time == "") {
        return false;
    }
}
//calendar

$('#cv_calendar_submit').off('click').on('click', function () {
    var manv = $('#cv_pick_emp').val();
    var mada = $('#cv_pick_proj').val();
    var ten = $('#cv_name').val();
    var noidung = $('#cv_descr').val();
    var cong = $('#cv_cong').val();
    var start_time = $('#cv_time_start').val();
    var end_time = $('#cv_time_end').val();
    var Vitri = 1;
    $.ajax({
        url: '/Task/InsertCalendar',
        data: { manv: manv, mada: mada, ten: ten, noidung: noidung, cong: cong, start_time: start_time, end_time: end_time, Vitri: Vitri },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status = true) {
                alert('Thêm công việc thành công !');
                window.location.href = '/Task/Assignment';
            }
            else {
                alert('Có lỗi trong quá trình thêm');
            }
        },
        error: function () {
            if (check() == false)
            {
                alert('Dữ liệu nhập chưa chính xác, bạn hãy kiểm tra lại');
            }
            else
            {
                alert('Bạn không có quyền thực hiện tác vụ này');
            }
        }
    })
})

$('#save_them_nvcv').off('click').on('click', function () {
    var manv = $('#cv_pick_emp_add').val();
    var macv = document.getElementById('edit_cv_nv').getAttribute('data-id');
    $.ajax({
        url: '/Task/Insert_NV_CV',
        dataType: 'json',
        type: 'POST',
        data: { manv: manv, macv: macv },
        success: function (res) {
            if (res.status == true) {
                alert('Thêm member thành công !');
                $.ajax({
                    url: '/Task/GetNV_CV_Vtri',
                    type: 'GET',
                    dataType: 'json',
                    data: { macv: macv },
                    success: function (data) {
                        var rows = "";
                        var count = 0;
                        $.each(data, function (i, item) {
                            count++;
                            rows += '<tr><th scope="row">' + count + '</th>'
                            + '<td>' + item.TenNV + '</td>'
                            + '<td>' + item.ViTri + '</td>'
                            + '<td data-id="' + item.MaNV + '"><i class="fix_vitri fa fa-wrench" role="button" data-toggle="modal" data-target="#Modal_sua_vt" data-id1=' + item.MaNV + ' data-id2=' + item.MaCV + '></td></tr>';
                        })
                        $('#edit_cv_nv').empty();
                        $('#edit_cv_nv').attr('data-id', macv);
                        $('#edit_cv_nv').append(rows);
                    }
                })
                $('#Modal_them_nv').modal('toggle');
                $('#cv_pick_emp_add option:first').attr('selected', true);
            }
            else {
                alert('Nhân viên này đã là member!');
            }
        }
    })
})
$(document).on("click", ".fix_vitri", function () {
    $('#save_sua_vt').attr('data-id1', $(this).data('id1'));
    $('#save_sua_vt').attr('data-id2', $(this).data('id2'));
});

$('#save_sua_vt').off('click').on('click', function () {
    var manv = document.getElementById('save_sua_vt').getAttribute('data-id1');
    var macv = document.getElementById('save_sua_vt').getAttribute('data-id2');
    var mavtri = $('#cv_pick_vtri_change').val();
    $.ajax({
        url: '/Task/Edit_VT',
        dataType: 'json',
        type: 'GET',
        data: { manv: manv, macv: macv, mavtri: mavtri },
        success: function (data) {
            alert(data);
            $.ajax({
                url: '/Task/GetNV_CV_Vtri',
                type: 'GET',
                dataType: 'json',
                data: { macv: macv },
                success: function (data) {
                    var rows = "";
                    var count = 0;
                    $.each(data, function (i, item) {
                        count++;
                        rows += '<tr><th scope="row">' + count + '</th>'
                            + '<td>' + item.TenNV + '</td>'
                            + '<td>' + item.ViTri + '</td>'
                            + '<td data-id="' + item.MaNV + '"><i class="fix_vitri fa fa-wrench" role="button" data-toggle="modal" data-target="#Modal_sua_vt" data-id1=' + item.MaNV + ' data-id2=' + item.MaCV + '></td></tr>';
                    })
                    $('#edit_cv_nv').empty();
                    $('#edit_cv_nv').attr('data-id', macv);
                    $('#edit_cv_nv').append(rows);
                }
            })
            $('#Modal_sua_vt').modal('toggle');
        }
    })
})
$('#save_cv').off('click').on('click', function () {
    var macv = document.getElementById('edit_cv_nv').getAttribute('data-id');
    var ten = $('#cvv_TenCV').val();
    var noidung = $('#cvv_NoiDung').val();
    var cong = $('#cvv_cong').val();
    var start_time = $('#cvv_start_time').val();
    var end_time = $('#cvv_end_time').val();
    $.ajax({
        url: '/Task/Edit_CV',
        dataType: 'json',
        type: 'post',
        data: { macv: macv, ten: ten, noidung: noidung, cong: cong, start_time: start_time, end_time: end_time },
        success: function (res) {
            if (res.status == true) {
                alert('Sửa thành công !');
                window.location.reload();
            }
            else { alert('Có lỗi xảy ra ! Xem lại các giá trị !'); }
        }
    })
})




// CHẤM CÔNG

$('#choose_project').on('change', function () {
    var mada = $(this).val();
    if (mada == 0) {
        $.ajax({
            url: '/Task/ViewAll',
            dataType: 'json',
            type: 'get',
            success: function (data) {
                $('#tr_byproject').empty();
                $('#tr_bynone').html('<th style="width:100px;">Mã NV</th><th style="width:200px;">Họ tên</th><th style="width:100px;">Mã dự án tham gia</th><th style="width:350px;">Tên dự án</th><thstyle="width:100px;">Số công</th><thstyle="width:100px;">Tổng công</th>');
                $('#chamcong_table').empty();
                var rows = '';
                if (data.Count == 0) rows += '<tr><td colspan="5">Không có dữ liệu hiển thị</td></tr>';
                else {
                    var prev_nv = 0;
                    $.each(data, function (i, item) {
                        rows += '<tr>';
                        if (item.MaNV != prev_nv) {
                            rows += '<td rowspan= ' + item.TongDA + '>' + item.MaNV + '</td>' +
                                   '<td rowspan=' + item.TongDA + '>' + item.Ten + '</td>';
                        }
                        rows += '<td>' + item.MaDA + '</td>' +
                                '<td>' + item.TenDA + '</td>' +
                                '<td style="border-right-width:1px;">' + Math.round(item.Cong * 100) / 100 + '</td>';
                        if (item.MaNV != prev_nv) {
                            rows += '<td rowspan=' + item.TongDA + '>' + Math.round(item.TongCong * 100) / 100 + '</td>';
                        }
                        rows += '</tr>';
                        prev_nv = item.MaNV;
                    })
                }
                $('#chamcong_table').html(rows);
            }
        })
    }
    else {
        $.ajax({
            url: '/Task/ViewByProject',
            dataType: 'json',
            data: { mada: mada },
            type: 'get',
            success: function (data) {
                $('#tr_bynone').empty();
                $('#tr_byproject').html('<th>Mã NV</th><th>Họ tên</th><th>Công việc tham gia</th><th> Vị trí</th><th>Số công</th><th>Tổng Công</th>');
                $('#chamcong_table').empty();
                var rows = '';
                if (data.Count == 0) rows += '<tr><td colspan="5">Không có dữ liệu hiển thị</td></tr>';
                else {
                    var prev_nv = 0;
                    $.each(data, function (i, item) {
                        rows += '<tr>';
                        if (item.MaNV != prev_nv) {
                            rows += '<td rowspan= ' + item.TongCV + '>' + item.MaNV + '</td>' +
                                   '<td rowspan=' + item.TongCV + '>' + item.Ten + '</td>';
                        }
                        rows += '<td>' + item.TenCV + '</td>' +
                                '<td>' + item.ViTri + '</td>';
                        if (item.CVStatus == 1) rows += '<td style="border-right-width:1px;">' + Math.round(item.SoCong * 100) / 100 + '</td>';
                        else { rows += '<td>Chưa hoàn thành </td>'; }
                        if (item.MaNV != prev_nv) {
                            rows += '<td rowspan= ' + item.TongCV + '>' + Math.round(item.TongCong*100)/100 + '</td>';
                        }
                        rows += '</tr>';
                        prev_nv = item.MaNV;
                    })
                }
                $('#chamcong_table').html(rows);
                alert('Ngày bắt đầu phải nhỏ hơn ngày kết thúc !');
            }
        })
    }
})
