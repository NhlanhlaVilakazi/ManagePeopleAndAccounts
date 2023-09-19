
$(document).ready(function () {
    $(".register-link").click(function () {
        $(".wrapper").addClass("active");
    });

    $(".login-link").click(function () {
        $(".wrapper").removeClass("active");
    });

    $(".login-btn").click(function () {
        if ($(".wrapper").hasClass("popup-active")) {
            $(".wrapper").removeClass("popup-active");
        }
        else {
            $(".wrapper").addClass("popup-active");
        }
    });

    $(".icon-close").click(function () {
        $(".wrapper").removeClass("popup-active");
    });
});