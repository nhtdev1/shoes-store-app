var product = {
    init: function () {
        product.changeProduct();
        product.autoPlayProductReview();
        product.addProductToCart();
    },

    changeProduct: function () {
        var idtemp;
        $(document).on({
            mouseenter: function () {
                var id = $(this).attr('id');
                idtemp = id;
                $("#div-template-hover-" + id).show();
                $("#div-color-hover-" + id).hide();
            },
            mouseleave: function () {
                var id = $(this).attr('id');
                $("#div-template-hover-" + id).hide();
                $(`#div-color-hover-${id}`).show();
            }
        }, '.product-block');
        $(document).on({
            mouseenter: function () {
                var model = $(this).attr('src');
                var ShoeID = $(this).data('id');
                var ColorID = $(this).data('colorid');
                $('#img-product-large-' + idtemp).attr('src', model);
                /*jQuery sẽ tìm nạp giá trị đó từdata-thuộc tính HTML chỉ khi nó không thể tìm thấy giá trị được lưu trữ bên trong. Nếu bạn truy xuất$(el).data('original-title')lại sau khi thay đổi thuộc tính HTML, bạn sẽ thấy nó không bị thay đổi.
    
    Nếu đây là một vấn đề, sử dụng .removeData()phương pháp để xóa giá trị được lưu trữ bên trong. Lần sau khi bạn sử dụng .data(), jQuery sẽ thấy rằng nó bị thiếu và truy xuất data-thuộc tính HTML.*/
                $('#btn-cart-' + ShoeID).attr('data-colorid', ColorID);
                $('#btn-cart-' + ShoeID).removeData('colorid');
                $('#btn-cart-' + ShoeID).data('colorid');
            },
            mouseleave: function () {

            }
        }, '.img-template-hover');
    },

    autoPlayProductReview: function () {
        $(document).on('click', '.videoModalTriger', function (e) {
            var theModal = $(this).data("target");
            var videoSRC = $(this).attr("data-videoModal");
            $(theModal + ' iframe').attr('src', videoSRC);
            $(theModal).on('hidden.bs.modal', function (e) {
                $(theModal + ' iframe').attr('src', '');
            });
        });
    },

    addProductToCart: function () {
        $(document).on('click', '.btn-cart', function (e) {
            var ShoeID = $(this).data('id');
            var ColorID = $(this).data('colorid');
            $.ajax({
                url: '/Cart/UpdateQuantity',
                data: { ShoeID: ShoeID, ColorID: ColorID, quantity: 1, size: 40 },
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
                                html += ` <option value="${j++}" data-id="${el.Product.ShoeID}" data-colorid="${el.Product.ColorID}">${p}</option>`;
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
                        $(".justify-content-end").html(html2)


                        if (response.cart.length > 0) {
                            let html3 = `<button type="button" class="btn btn-secondary" data-dismiss="modal" style="visibility:hidden">Close</button>
                <form action="/Cart/Checkout">
                    <input type="submit" value="Checkout" class="btn btn-success" />
                </form>`;
                            $(".justify-content-between").html(html3);
                        }
                    }
                }
            });
        });
    },
}

product.init();
/*jQuery sẽ tìm nạp giá trị đó từdata-thuộc tính HTML chỉ khi nó không thể tìm thấy giá trị được lưu trữ bên trong. Nếu bạn truy xuất$(el).data('original-title')lại sau khi thay đổi thuộc tính HTML, bạn sẽ thấy nó không bị thay đổi.

Nếu đây là một vấn đề, sử dụng .removeData()phương pháp để xóa giá trị được lưu trữ bên trong. Lần sau khi bạn sử dụng .data(), jQuery sẽ thấy rằng nó bị thiếu và truy xuất data-thuộc tính HTML.*/