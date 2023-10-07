

var people = [];
var action = null;

$(document).ready(function () {
    getPeople();
});

function getPeople() {
    
    $.ajax({
        url: "../Person/LoadPersons",
        type: "GET",
        async: false,
        success: function (result) {
            
            $.each(result, function (key, value) {
                var editBtn = "<button class='borderless edit-btn' > <i class='fas fa-pen'></i> <div style='visibility:hidden;'>{"+ value.code +"}</div></button>";
                var deleteBtn = "<button class='borderless' data-id="+value.code+"><i class='fas fa-trash'></i></button>";
                var id = "<input type='hidden' value = " + value.code + "/>";
                action = editBtn + "&nbsp; &nbsp; &nbsp;" + deleteBtn + id;
                people.push([value.name, value.surname, value.idNumber, action])
            })
        },
        error: function (err) {
            console.log("Error");
            console.log(err);
        }
    });

    $("#person-tbl").DataTable({
        data: people
    });

    $(".edit-btn").click(function (e) {
        var personId = getPersonId(e);
        window.location = "/Person/Edit?personId=" + personId;
    })
}

function getPersonId(e) {
    var innerHtm = e.currentTarget.innerHTML;
    var firstSub = innerHtm.substr(innerHtm.indexOf("{") + 1);
    return parseInt(firstSub.substr(0, firstSub.indexOf("}")));
}



