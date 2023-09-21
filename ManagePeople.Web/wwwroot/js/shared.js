class SharedFunctionality {
    animateButton(buttonId) {
        setTimeout(function () {
            $(buttonId).prop("disabled", true);
            $(buttonId).html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...');
        }, 200);
    }

    stopButtonAnimation(buttonId, text) {
        setTimeout(function () {
            $(buttonId).prop("disabled", false);
            $(buttonId).html(text);
        }, 200);
    }

    setUserState(state) {
        localStorage.setItem("user-state", state);
    }

    getUserState() {
        return localStorage.getItem("user-state");
    }
}