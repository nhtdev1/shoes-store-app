
$(document).ready(function () {
    var load = function (page, CategoryID) {
        $.ajax({
            url: '/Product/ProductPagination',
            type: "POST",
            data: { page: page, CategoryID: CategoryID },
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

                $('#navigationListProduct').remove('data-categoryid');
                $('#navigationListProduct').attr('data-categoryid', result.categoryid);
            }
        });
    }


    $("body").on("click", ".pagination li a", function (event) {
        event.preventDefault();
        var page = $(this).attr('data-page');
        var category = $('#navigationListProduct').data('categoryid');
        load(page, category);
    });

    $("body").on("click", ".categorination li a", function (event) {
        event.preventDefault();
        var CategoryID = $(this).attr('data-categoryid');
        load(1, CategoryID);
    });

    load(1, 1);
});

