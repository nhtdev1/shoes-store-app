var shoe = {
    init: function () {
        shoe.registerEvents();
    },

    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var ShoeID = $(this).data('id');
            var ColorID = $(this).data('color');
            $.ajax({
                url: '/Product/ChangeImage',
                data: { ShoeID : ShoeID, ColorID : ColorID },
                dataType:"json",
                type: "POST",
                success: function (response) {
                    var model = response.ImageList;
                    $('.img-fluid').eq(0).attr({
                        'src': response.ImageList[2],
                        'alt': ''
                    });
                    $('.img-fluid').eq(1).attr({
                        'src': response.ImageList[3],
                        'alt': ''
                    });
                    $('.img-fluid').eq(2).attr({
                        'src': response.ImageList[0],
                        'alt': ''
                    });
                    $('.img-fluid').eq(3).attr({
                        'src': response.ImageList[1],
                        'alt': ''
                    });
                    $('.img-fluid').eq(4).attr({
                        'src': response.ImageList[2],
                        'alt': ''
                    });
                    $('.img-fluid').eq(5).attr({
                        'src': response.ImageList[3],
                        'alt': ''
                    });
                    $('.img-fluid').eq(6).attr({
                        'src': response.ImageList[0],
                        'alt': ''
                    });
                    $('.img-fluid').eq(7).attr({
                        'src': response.ImageList[1],
                        'alt': ''
                    });

                    $('#ProductPrice').text(response.Price);
                }
            });
        });
    }
}
shoe.init();    