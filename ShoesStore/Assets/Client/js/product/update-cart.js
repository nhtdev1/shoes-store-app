var cart = {
    init: function () {
        shoe.registerEvents();
    },

    registerEvents: function () {
        $('.btn-cart').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: '/Cart/UpdateQuantity',
                dataType: "json",
                type: "POST",
                success: function (response) {
                    $('.nav-shop__circle').text(response.quantity);
                }
            });
        });
    }
}
cart.init();    