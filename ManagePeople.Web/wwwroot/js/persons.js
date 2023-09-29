

var people = [];
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
                var editBtn = "<a onclick='Edit(this)'> <i class='fas fa-pen'></i> </a>";
                var deleteBtn = "<a href='#'><i class='fas fa-trash'></i></a>";
                var id = "<input type='hidden' value = " + value.code + "/>";
                var action = editBtn + "&nbsp; &nbsp; &nbsp;" + deleteBtn + id;
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

    function Edit(code) {
        alert(code);
    }
}