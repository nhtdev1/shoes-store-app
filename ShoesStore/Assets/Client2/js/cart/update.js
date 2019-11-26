var cart = {
    init: function () {
        cart.updateCart();
        cart.sizeChange();
        cart.quantityChange();
    },

    updateCart: function () {
        $(document).on('click', '.btn-danger', function () {
            var ShoeID = $(this).data('id');
            var ColorID = $(this).data('colorid');
            var size = $(this).data('size');
            $.ajax({
                url: '/Cart/UpdateCart',
                data: { ShoeID: ShoeID, ColorID: ColorID, size: size },
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
                                html += ` <option value="${j++}" data-id="${el.Product.ShoeID}" data-colorid="${el.Product.ColorID}">${p}</option>`
                            });
                            html += `          </select>
                                         </div>
                                      </td>
                                    <td class="qty"><input type="number" min="1" class="form-control spinner-quantity" id="input1" value="${el.Quantity}" data-id="${el.Product.ShoeID}" data-colorid="${el.Product.ColorID}" data-price="${el.Product.Price}""></td>
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
                        $(".justify-content-end").html(html2)
                    }
                }
            });

        });
    },

    sizeChange: function () {
        $(document).off('change').on('change', '.select-size', function () {
            var size = $(this).children("option:selected").text();
            var ShoeID = $(this).children("option:selected").data('id');
            var ColorID = $(this).children("option:selected").data('colorid');
            console.log(ShoeID + "-" + ColorID + "-" + size);
            $.ajax({
                url: '/Cart/UpdateSize',
                data: { ShoeID: ShoeID, ColorID: ColorID, NewSize: size },
                dataType: "json",
                type: "POST",
                success: function (response) {
                }
            });
        });
    },

    quantityChange: function () {
        $(document).off('change').on('change', '.spinner-quantity', function () {
            var quantity = $(this).val();
            var ShoeID = $(this).data('id');
            var ColorID = $(this).data('colorid');
            var Price = $(this).data('price');
            $('.price-a-product-' + ShoeID + '-' + ColorID).text((quantity * Price) + '$');
            $.ajax({
                url: '/Cart/UpdateCost',
                data: { ShoeID: ShoeID, ColorID: ColorID, quantity: quantity },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        $('.nav-shop__circle').text(response.total);
                        $('.cost-of-cart').text(response.cost + '$');
                    }
                }
            });
        });
    },
};

cart.init();

