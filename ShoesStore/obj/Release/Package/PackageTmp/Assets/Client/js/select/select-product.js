var shoe = {
    init: function () {
        shoe.selectColor();
        shoe.addToCart();
        shoe.selectSize();
    },

    selectColor: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            $('.btn-add-to-cart').removeData('colorid');
            $('.btn-add-to-cart').attr('data-colorid', $(this).data('color'));
            var ShoeID = $(this).data('id');
            var ColorID = $(this).data('color');
            $.ajax({
                url: '/Product/ChangeImage',
                data: { ShoeID: ShoeID, ColorID: ColorID },
                dataType: "json",
                type: "POST",
                success: function (response) {
         
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
    },

    addToCart: function () {
        $('.btn-add-to-cart').on('click', function (e) {
            e.preventDefault();
            var ShoeID = $(this).data('id');
            var ColorID = $(this).data('colorid');
            var quantity = $('#spinner-quantity').val();
            $(this).removeData('size');
            var size = $(this).data('size');
            if (size == "-1") {
                $('.head-size-id').show();
                $('.btn-select-size').css('border-color', 'orangered');

            } else {
                $('.head-size-id').hide();
                $.ajax({
                    url: '/Cart/UpdateQuantity',
                    data: { ShoeID: ShoeID, ColorID: ColorID, quantity: quantity, size: size },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        if (response.status == true) {
                            $('.nav-shop__circle').text(response.total);
                            let html = "";
                            response.cart.forEach(el => {
                                var j = 1;
                                html += `<tr>
                                    <td class="w-25">
                                        <img src="${el.Product.Image}" class="img-fluid img-thumbnail"  alt="Sheep">
                                    </td>
                                    <td>${el.Product.Name}</td>
                                    <td>${el.Product.Price}$</td>
                                    <td>
                                        <div class="div-select-size">
                                          <select class="select-size form-control" style="width:auto">`;

                                el.SizeOther.forEach(p => {
                                    if (p == el.Size) {
                                        html += ` <option value="${j++}" data-id="${el.Product.ShoeID}" data-colorid="${el.Product.ColorID}" selected="selected">${p}</option>`;
                                    } else {
                                        html += ` <option value="${j++}" data-id="${el.Product.ShoeID}" data-colorid="${el.Product.ColorID}">${p}</option>`;
                                    }

                                });

                                html += `          </select>
                                         </div>
                                      </td>
                                     <td class="qty"><input type="number" min="1" class="form-control spinner-quantity" id="input1" value="${el.Quantity}" data-id="${el.Product.ShoeID}" data-colorid="${el.Product.ColorID}" data-price="${el.Product.Price}"></td>
                                    <td class="price-a-product-${el.Product.ShoeID}-${el.Product.ColorID}">${(el.Product.Price * el.Quantity)}$</td>
                                    <td>
                                         <div>
                                        <button class="btn btn-danger btn-sm" data-id="${el.Product.ShoeID}" data-colorid="${el.Product.ColorID}" data-size="${el.Size}">
                                            <i class="fa fa-times"></i>
                                        </button>
                                        </div>
                                    </td>
                                </tr>`;
                            })

                            $(".table-cart tbody").html(html);

                            let html2 = `<h5 >Total: <span class="price text-success cost-of-cart">${response.cost}$</span></h5>`
                            $(".justify-content-end").html(html2);

                            if (response.cart.length > 0) {
                                let html3 = `<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <form action="/Cart/Checkout">
                    <input type="submit" value="Checkout" class="btn btn-success" />
                </form>`;
                                $(".justify-content-between").html(html3);
                            }
                        }

                    }
                });
            }
        });
    },
    selectSize: function () {
        $('.btn-select-size').off('click').on('click', function (e) {
            $('.head-size-id').hide();
            $('.btn-select-size').css('border-color', '#007bff');
            $('.btn-add-to-cart').attr('data-size', $(this).val());
            $(this).css('border-color', 'gray');
        });
        $('#spinner-quantity').off('change').on('change', function (e) {
            var value = $(this).val();
            if ($.isNumeric(value) == true) {
                if (value < 1) {
                    $(this).val(1);
                }
            }
        });
    }
}
shoe.init();

var flashInterval;