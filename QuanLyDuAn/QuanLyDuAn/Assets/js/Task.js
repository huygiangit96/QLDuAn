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

$('.mail_title').off('click').on('click', function () {
    var id = $(this).data('id');

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
        }
    })
})


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
        }
    })
})

$('#save_them_nvcv').off('click').on('click', function () {
    var manv = $('#cv_pick_emp_add').val();
    var macv = $('#edit_cv_nv').data('id');
    $.ajax({
        url: '/Task/Insert_NV_CV',
        dataType: 'json',
        type: 'POST',
        data: { manv: manv, macv: macv},
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
            }
            else {
                alert('Nhân viên này đã là member!');
            }
        }
    })
})
$('#save_sua_vt').off('click').on('click', function () {

})
