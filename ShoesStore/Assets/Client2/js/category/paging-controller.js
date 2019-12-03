$(document).ready(function () {
    var a_categoryId = "";
    var a_size = "";
    var a_colorName = "";
    var a_contentSearch = "";
    var a_order = "1";
    var a_range_price = "";
    var conditions = [a_categoryId, a_size, a_colorName, a_contentSearch, a_order, a_range_price];

    var load = function (page, conditions) {
        $.ajax({
            url: '/Category/ProductPagination',
            type: "POST",
            data: { page: page, conditions: conditions },
            dataType: 'json',
            success: function (result) {
                //create pagination
                var pagination_string = "";
                var pageCurrent = result.pageCurrent;
                var numSize = result.numSize;

                //create button previous
                if (pageCurrent > 1) {
                    var pagePrevious = pageCurrent - 1;
                    pagination_string +=
                        '<li class="page-item"><a href="" class="page-link" data-page='
                        + pagePrevious
                        + '>Previous</a></li>';
                }

                for (i = 1; i <= numSize; i++) {
                    if (i == pageCurrent) {
                        pagination_string +=
                            '<li class="page-item active"><a href="" class="page-link" data-page='
                            + i + '>'
                            + pageCurrent
                            + '</a></li>';
                    } else {
                        pagination_string += '<li class="page-item"><a href="" class="page-link" data-page='
                            + i
                            + '>'
                            + i
                            + '</a></li>';
                    }
                }

                //create button next
                if (pageCurrent > 0 && pageCurrent < numSize) {
                    var pageNext = pageCurrent + 1;
                    pagination_string += '<li class="page-item"><a href="" class="page-link"  data-page='
                        + pageNext
                        + '>Next</a></li>';
                }

                $("#load-pagination").html(pagination_string);
                $("#load-data").html(result.data);


            }
        });
    }


    $(document).on("click", ".pagination li a", function (event) {
        event.preventDefault();
        var page = $(this).attr('data-page');
        load(page, conditions);
    });

    $(document).on("click", ".categorination li a", function (event) {
        event.preventDefault();
        conditions[0] = $(this).attr('data-categoryid');
        conditions[1] = "";
        conditions[2] = "";
        conditions[3] = "";
        load(1, conditions);
    });

    $(document).on('click', '.my-size-card', function (e) {
        conditions[1] = $(this).data('size');
        load(1, conditions);
    });

    $(document).on('click', '.my-color-card', function (e) {
        conditions[2] = $(this).children('.my-label-color').text().toLowerCase();
        load(1, conditions);
    });

    $(document).on('click', '.button-search-product', function (e) {
        if (conditions[3] != "") {
            load(1, conditions);
            $('.input-search-product').val("");
        }
    });

    $(document).on('change', '.input-search-product', function (e) {
        conditions[3] = $(this).val().trim().toLowerCase();
    });

    $(document).on('change', '.select-product-filter', function (e) {
        conditions[4] = $(this).val();
        load(1, conditions);
    });

  

    load(1, conditions);

    /*var slider = document.getElementById('price-range');
    slider.noUiSlider.destroy();
    noUiSlider.create(slider, {
        start: [50, 100],
        connect: true,
        range: {
            'min': 0,
            'max': 300
        },
        step: 5
    });
    slider.noUiSlider.on('update', function () {
        var model = slider.noUiSlider.get();
        $('#lower-value').text(model[0]);
        $('#upper-value').text(model[1]);
        conditions[5] = model[0] + "-" + model[1];
    });

    slider.noUiSlider.on('change', function () {
        load(1, conditions);
        conditions[5] = "";
    });*/
});


