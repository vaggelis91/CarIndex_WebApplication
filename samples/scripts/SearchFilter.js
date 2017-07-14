$(document).ready(function () {
    $("#contactSection").hide();
    
    $("#brandSelector").change(function() {
        $("#modelSelector").empty();
    });

    $("#optAlfaRomeo").click(function () {
        var AlfaRomeoModels = ["GT", "Giulietta"];     
		$("#modelSelector").append("<option></option>");					
        for (i = 0; i < AlfaRomeoModels.length; i++){
            $("#modelSelector").append("<option>" + AlfaRomeoModels[i] + "</option>");
        }       					
    });

    $("#optAudi").click(function () {
        var AudiModels = ["A1", "A3", "R8"]; 
		$("#modelSelector").append("<option></option>");					
        for (i = 0; i < AudiModels.length; i++) {
            $("#modelSelector").append("<option>" + AudiModels[i] + "</option>");
        }
    });

    $("#optBMW").click(function () {
        var BMWModels = ["M4", "Z8"]; 
		$("#modelSelector").append("<option></option>");
        for (i = 0; i < BMWModels.length; i++) {
            $("#modelSelector").append("<option>" + BMWModels[i] + "</option>");
        }					
    });

    $("#optFord").click(function () {
        var FordModels = ["Mustang", "Freestyle"];
		$("#modelSelector").append("<option></option>");
        for (i = 0; i < FordModels.length; i++) {
            $("#modelSelector").append("<option>" + FordModels[i] + "</option>");
        }	
    });
    $("#optJeep").click(function () {
        var JeepModels = ["Grand Cherokee"];
		$("#modelSelector").append("<option></option>");
        for (i = 0; i < JeepModels.length; i++) {
            $("#modelSelector").append("<option>" + JeepModels[i] + "</option>");
        }	
        });
    $("#clearbtn").click(function () {
        $("#brandSelector").val("");
        $("#modelSelector").empty();
        $("#engineCapacitySelector").val("");
        $("#fuelTypeSelector").val("");
        $("#typeSelector").val("");
        $("#priceSelector").val("");
    });
				
    $("#contact").click(function () {
        $("#contactSection").toggle();
    });

});