
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

    $("#site-login-btn").click(function () {
        var username = $("#usernameTxt").val();
        var password = $("#passwordTxt").val();
        var confirm = $("#confirmTxt").val();

        if (passwordMatch(password, confirm)) {
            animateButton("#site-login-btn");
            $.ajax({
                url: "../User/RegisterUser",
                type: "GET",
                data: { username: username, password: password },
                success: function (result) {
                    if (result === 200) {
                        console.log("Success");
                    } else {
                        console.log("Error");
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
        
    });

});

function passwordMatch(password, confirm) {
    if (password === confirm) {
        $("#error-label").show();
        return true;
    }
    $("#error-label").hide();
    return false;
}

function animateButton(buttonId) {
    setTimeout(function () {
        $(buttonId).prop("disabled", true);
        $(buttonId).html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...');
    }, 200);
}