//var js = jQuery.noConflict(true);

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
                console.log(key);
                console.log(value);
                people.push([value.name, value.surname, value.idNumber])
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
}