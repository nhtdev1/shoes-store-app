$(document).ready(function () {
    var idtemp;
    $(".product-block").hover(function (e) {
        var id = $(this).attr('id');
        idtemp = id;
        $("#div-template-hover-" + id).show();
        $("#div-color-hover-" + id).hide();
    }, function () {
        var id = $(this).attr('id');
        $("#div-template-hover-" + id).hide();
        $(`#div-color-hover-${id}`).show();
    });


    $(".img-template-hover").hover(function (e) {
        var model = $(this).attr('src');
        $('#img-product-large-' + idtemp).attr('src', model);
    }, function () {
    });

});

$(document).ready(function () {
    autoPlayYouTubeModal();
});

function autoPlayYouTubeModal() {
    var trigger = $('.videoModalTriger');
    trigger.click(function () {
        var theModal = $(this).data("target");
        var videoSRC = $(this).attr("data-videoModal");
        $(theModal + ' iframe').attr('src', videoSRC);
        $(theModal).on('hidden.bs.modal', function (e) {
            $(theModal + ' iframe').attr('src', '');
        });
    });
};