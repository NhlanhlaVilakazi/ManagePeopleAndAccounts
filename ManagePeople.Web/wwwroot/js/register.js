
$(document).ready(function () {

    var shared = new SharedFunctionality();

    if (shared.getUserState() === "logged-in") {
        $("#login-btn").text("Logout");
    }
    else {
        $("#login-btn").text("Login");
    }

    $(".register-link").click(function () {
        $(".wrapper").addClass("active");
    });

    $(".login-link").click(function () {
        $(".wrapper").removeClass("active");
    });

    $(".login-btn").click(function () {
      
        if (shared.getUserState() === "logged-in") {
            shared.setUserState("logged-out");
            $("#login-btn").text("Login");
            $(location).attr('href', "../Home/Index");
        }
        else {
            if ($(".wrapper").hasClass("popup-active")) {
                $(".wrapper").removeClass("popup-active");
            }
            else {
                $(".wrapper").addClass("popup-active");
            }
        }
    });

    $(".icon-close").click(function () {
        $(".wrapper").removeClass("popup-active");
    });

    $("#site-register-btn").click(function () {
        var username = $("#usernameTxt").val();
        var password = $("#passwordTxt").val();
        var confirm = $("#confirmTxt").val();

        $("#error-label").text("");

        if (!hasErrors(username, password, confirm)) {
            if (passwordMatch(password, confirm)) {
                
                shared.animateButton("#site-register-btn");
                $.ajax({
                    url: "../User/RegisterUser",
                    type: "POST",
                    data: { username: username, password: password },
                    success: function (result) {
                        if (result === 200) {
                            stopButtonAnimation("#site-register-btn", "Register");
                            $("#usernameTxt").val("");
                            $("#passwordTxt").val("");
                            $("#confirmTxt").val("");
                            $(".wrapper").removeClass("popup-active");
                            $("#login-btn").html('<span class="" role="status" aria-hidden="true"></span> Logout');
                            shared.setUserState("logged-in");
                        } else {
                            shared.stopButtonAnimation("#site-register-btn", "Register");
                            $("#error-label").text("An error occured, please try again later..");

                        }
                    },
                    error: function (err) {
                        shared.stopButtonAnimation("#site-register-btn", "Register");
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