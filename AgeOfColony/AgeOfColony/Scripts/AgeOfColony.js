function getMainBuliding() {
    $.ajax({
        type: 'GET',
        url: '@Url.Action',
        success: function (data) {
            $('#DivDetail').html(data);
        }
    });
}