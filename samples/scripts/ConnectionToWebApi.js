$(document).ready(function () {
    $("#carTable").hide();       
	$("#saveBtn").hide();		
				
    $("#searchbtn").click(function () {
        $("#comments").hide();
        $("#searchbtn").prop('disabled', true);
        $.ajax({
            url: '/api/Car/Post',
            type: 'POST',
            data: { Brand: $("#brandSelector").val(), Model: $("#modelSelector").val(), Engine_Capacity: $("#engineCapacitySelector").val(), Fuel_Type: $("#fuelTypeSelector").val(), Type: $("#typeSelector").val(), Condition: $("#conditionSelector").val(), Price: $("#priceSelector").val() },
            dataType: 'json',
            success: function (carsList) {
				carListSuccess(carsList);
                $("#carTable").show();
				$("#saveBtn").show();                           
                $("#searchbtn").prop('disabled', false);
            },
            error: function (request, message, error) {
                handleException(request, message, error);
                $("#searchbtn").prop('disabled', false);
            }
        });
    });
				
	$("#sendEmailBtn").click(function () {
		$("#sendEmailBtn").prop('disabled', true);					
        $.ajax({
            url: '/api/Car/SendEmail',
            type: 'POST',
            data: { Name: $("#name").val(), Email: $("#email").val(), Comments:$("#commentsBox").val() },
            dataType: 'json',
            success: function (value) {
				window.confirm(value);
                $("#sendEmailBtn").prop('disabled', false);	
            },
            error: function (request, message, error) {
                handleException(request, message, error);
                $("#sendEmailBtn").prop('disabled', false);	
            }
        });
    });
                
});
			
function carListSuccess(carsList) {
    $("#carTable tbody").empty();
    $.each(carsList, function (index, car) {
		$("#carTable tbody").append(carBuildTableRow(car));	
    });
}
			
function carBuildTableRow(car) {
    var carRow =
    "<tr>" +
    "<td>" + car.Brand + "</td>" +
    "<td>" + car.Model + "</td>" +
    "<td>" + car.Engine_Type + "</td>" +
    "<td>" + car.Engine_Capacity + "</td>" +
    "<td>" + car.Max_Speed + "</td>" +
    "<td>" + car.Acceleration + "</td>" +
    "<td>" + car.Horse_Power + "</td>" +
    "<td>" + car.Fuel_Type + "</td>" +
    "<td>" + car.Fuel_Consumption + "</td>" +
    "<td>" + car.Type + "</td>" +
    "<td>" + car.Doors + "</td>" +
    "<td>" + car.Price + "</td>" +
    "</tr>";
    return carRow;
}
			
function handleException(request, message, error) {
    var msg = "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }
    window.alert(msg);
}
			
			
			
			