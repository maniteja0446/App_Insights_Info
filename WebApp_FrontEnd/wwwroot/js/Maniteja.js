$(document).ready(function () {
    //alert("Maniteja");
    //$.ajax({
    //    type: "GET",        
    //    //url: "https://localhost:44336/api/Departments",     
    //    url: "https://azrg-wa-api.azurewebsites.net/api/departments",     
    //    contentType: "application/json; charset=utf-8", 
    //    dataType: "json",
    //    success: function (data) {
    //        $("#DID").empty();
    //        alert(data);
    //        //$.each(data, function (i) {
    //        //    var optionhtml = '<option value="' +
    //        //        data[i].value + '">' + data[i].text + '</option>';
    //        //    $("#DID").append(optionhtml);
    //        //});
    //        //console.log(data);
    //    },
    //    error: function (req, status, error) {
    //        alert(error);
    //    }
    //});

    $.ajax({
        type: "GET",
        url: 'https://azrg-wa-api.azurewebsites.net/api/departments', // <-- Where should this point?
        //url: "https://localhost:44336/api/Departments", 
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {
        console.log(data.result);
    });


});





