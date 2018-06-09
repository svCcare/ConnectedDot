$(document).ready(function () {
    $('main section p').hide();
    $('main section span').css({ color: '#fff' }).hover(function () {
        $(this).css("text-decoration", "underline");
    }, function () {
        $(this).css("text-decoration", "none");
    }).click(function (e) {
        e.preventDefault();
        $('main section p').hide();
        $(this).next('p').show();
    });
});