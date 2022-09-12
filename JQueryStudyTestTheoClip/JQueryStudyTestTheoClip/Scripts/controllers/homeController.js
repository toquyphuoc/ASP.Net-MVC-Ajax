var homeController = {
    init: function(){
        homeController.loadData();
        homeController.registerEvent();
    },
    registerEvent: function () {
        $('.txtLuong').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                homeController.updateLuong(id, value);
            }
        });
    },
    updateLuong: function (id, value) {
        var data = {
            id: id,
            Luong:value     
        };
        $.ajax({
            url: 'Home/Update',
            type: 'POST',
            dataType: 'json',
            data: {
                model: JSON.stringify(data)
            }, success: function (reponse) {
                if (reponse.status) {
                    alert("Cập nhật thành công");
                }
                else {
                    alert("Cập nhật thất bại");
                }
            }
        })
    },
    loadData: function () {
        $.ajax({
            url: 'Home/LoadNhanVien',
            type:'GET',
            dataType: 'json',
            success: function (reponse) {
                if (reponse.status) {
                    var data = reponse.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            id: item.id,
                            Hoten: item.Hoten,
                            Luong: item.Luong,
                            TrangThai: item.TrangThai == true ? "<span class=\"label label-success\">Actived</span>": "<span class=\"label label-warning\">Locked</span>"
                         });
                    });
                    $('#tblData').html(html);
                    homeController.registerEvent();
                }
            }
        });
    }
}
homeController.init()