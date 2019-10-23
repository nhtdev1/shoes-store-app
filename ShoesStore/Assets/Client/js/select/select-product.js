var shoe = {
    init: function () {
        shoe.registerEvents();
    },

    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var ShoeID = $(this).data('id');
            var Code = $(this).data('code');
            $.ajax({
                url: '/Product/ChangeImage',
                data: { ShoeID : ShoeID, Code : Code },
                dataType:"json",
                type: "POST",
                success: function (response) {
                    $('.img-fluid').attr({
                        'src': response.Image,
                        'alt':''
                    });
                }
            });
        });
    }
}
shoe.init();    