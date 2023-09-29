$(document).ready(function () {

    var shared = new SharedFunctionality();

    shared.hideOrShowPersonLink(shared.getUserState());

    $("#site-login-btn").click(function () {
        $("#log-error-label").text("");
        var username = $("#log-usernameTxt").val();
        var password = $("#log-passwordTxt").val();

        if (!hasErrors(username, password)) {
            shared.animateButton("#site-login-btn");
            $.ajax({
                url: "../User/Login",
                type: "POST",
                data: { username: username, password: password },
                success: function (result) {
                    if (result === true) {
                        shared.stopButtonAnimation("#site-login-btn", "Login");
                        $("#log-usernameTxt").val("");
                        $("#log-passwordTxt").val("");

                        $(".wrapper").removeClass("popup-active");
                        $("#login-btn").html('<span class="" role="status" aria-hidden="true"></span> Logout');
                        shared.setUserState("logged-in");
                        shared.hideOrShowPersonLink("logged-in");
                    } else {
                        shared.stopButtonAnimation("#site-login-btn", "Login");
                        $("#log-error-label").text("Incorrect username or password");

                    }
                },
                error: function (err) {
                    shared.stopButtonAnimation("#site-login-btn", "Login");
                    $("#log-error-label").text("An error occured, please try again later..");

                }
            });
        }
        else {
            $("#log-error-label").text("Please input all fields..");
        }
    });
});

function hasErrors(username, password) {
    var hasErrors = false;
    if (username === "" || username === null || username === undefined) {
        hasErrors = true;
    }
    if (password === "" || password === null || password === undefined) {
        hasErrors = true;
    }
    return hasErrors;
}