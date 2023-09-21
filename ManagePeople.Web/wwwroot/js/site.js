
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

        $("#error-label").text("");

        if (!hasErrors(username, password, confirm)) {
            if (passwordMatch(password, confirm)) {
                
                animateButton("#site-login-btn");
                $.ajax({
                    url: "../User/RegisterUser",
                    type: "GET",
                    data: { username: username, password: password },
                    success: function (result) {
                        if (result === 200) {
                            stopButtonAnimation("#site-login-btn", "Register");
                        } else {
                            stopButtonAnimation("#site-login-btn", "Register");
                            $("#error-label").text("An error occured, please try again later..");

                        }
                    },
                    error: function (err) {
                        stopButtonAnimation("#site-login-btn", "Register");
                        $("#error-label").text("An error occured, please try again later..");

                    }
                });

            }
            else {
                $("#error-label").text("Provided passwords does not match");
            }
        }
        else {
            $("#error-label").text("Please input all fields");
        }
        
    });

});

function hasErrors(username, password, confirm) {
    var hasErrors = false;
    debugger
    if (username === "" || username === null || username === undefined) {
        hasErrors = true;
    }
    if (password === "" || password === null || password === undefined) {
        hasErrors = true;
    }
    if (confirm === "" ||confirm === null || confirm === undefined) {
        hasErrors = true;
    }
    return hasErrors;
}

function passwordMatch(password, confirm) {
    if (password === confirm) {
        return true;
    }
    return false;
}

function animateButton(buttonId) {
    setTimeout(function () {
        $(buttonId).prop("disabled", true);
        $(buttonId).html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...');
    }, 200);
}

function stopButtonAnimation(buttonId, text) {
    setTimeout(function () {
        $(buttonId).prop("disabled", false);
        $(buttonId).html(text);
    }, 200);
}