$(document).ready(function () {
    $(".chatbox-open").click(() =>
        $(".chatbox-popup, .chatbox-close").fadeIn()
    );
    $(".chatbox-close").click(() =>
        $(".chatbox-popup, .chatbox-close").fadeOut()
    );
});