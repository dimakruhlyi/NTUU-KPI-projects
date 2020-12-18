/*                                                      Task 1
$(document).ready(function(){
    alert("Поздравляем! Вы починили код!"); });*/

   /*  $(document).ready(function(){
    $("body").css("fontSize", "1em");
    $("#meadow").css("fontSize","1.4em").css("color", "green");
    $(".rainbow").css("fontSize", "1.8em").css("color","red");
    $("#fut #future").css("fontSize", "1.2em").css("color","blue");
    $("[set]").css("fontSize", "1.3em").css("color","yellow");
    $("[last$='code']").css("fontSize", "1.7em").css("color","grey");
});*/
/*                                                      Task 3
$(document).ready(function(){
    $("p#pmtog").css("color","green");
    $("p.pr1").css("color","red");
    $(":button").css("background", "#FF4500");
    $("p.pmb1, .pmb2,.pmb3").css("color","blue");
    $("div#wrap1 .pmtobr").css("color","#8B4513");
    $("[src = 'mountimg3.jpg']").css("borderStyle","solid").css("borderColor","violet");
    $("div#iwrap :button,:submit").css("background","red");
});
*/
/*
$(document).ready(function(){

    $("#but1").click(function(){
        $("p#par1").css("color","green").css("fontSize","20px"); });

    $("p.podtask2").mouseover(function(){$("p.podtask2").css("color","#FF4500")});
    $("p.podtask2").mouseout(function(){$("p.podtask2").css("color","black")});

    $(".podtask4").select(function(event){
        $(".podtask4").css("color","red").css("fontSize","20px");

    });

    $("#but2").toggle(function(){
            $("#par2").css("color","red");
            $("#par2").css("font-family","Times New Roman");
            $("#par2").css("borderWidth","0px");},function(){
            $("#par2").css("color","blue");
            $("#par2").css("font-family","Arial");
            $("#par2").css("borderWidth","0px");},function(){
            $("#par2").css("color","black");
            $("#par2").css("font-family","Verdana");
            $("#par2").css("font-weight","bold");
            $("#par2").css("borderWidth","1px");
            $("#par2").css("borderStyle","solid");

        });
});*/
/*                                                      Task 5
$(document).ready(function(){

    $("#but1").click(function(){$("#par1").fadeOut(3000)});
    $("#but2").click(function(){$("#par1").fadeIn(3000)});


    $("#par2").mouseout(function(){ $("#par2").fadeTo(3000,1)});
    $("#par2").mouseover(function(){ $("#par2").fadeTo(3000,0.3)});


    $("#but3").click(function(){ $("#wrap1").slideUp(5000)});
    $("#but4").click(function(){ $("#wrap1").slideDown(7000)});


    $("#but5").click(function(){
        $("#square").animate({top:"10", left: "200"}, 1000),
            $("#square").animate({top: "100", left: "400"}, 1000),
            $("#square").animate({top: "300", left: "500"}, 1000),
            $("#square").animate({top: "300", left: "200"}, 1000),
            $("#square").animate({top: "100", left: "50"}, 1000),
            $("#square").animate({top:"", left:""}, 1000);});

});*/
/*                                                      Task 6
$(document).ready(function(){

    $("#but1").click(function(){
        text = $("#par1").html();
        $("#par2").append(text);
    });


    $("#but2").click(function(){
        $("#par3").append("HTML.");
        $("#par4").append("CSS");
        $("#par5").prepend("JAVAscript");
        $("#par6").prepend("jQuery");
    });


    $("#but3").click(function(){
        $("#href1").prepend($("#href1").attr("href"));
        $("#but3").wrap("<b></b>").after($("#par7").attr("class"));
        $(":text").after("key");
    });


    $('#but4').click(function(){
        $("#par8").wrap("<div id='style2'></div>");
        $("#par9").wrap("<div id='style3'></div>");
        $("#par10").wrap("<div id='style1'></div>");
        $("#par11").wrap("<div id='style4'></div>");
    });
});*/
/*                                                      Task 7
$(document).ready(function(){

    $("#but1").click(function(){
        alert($("#par1").css("color"));
        alert($("#par2").css("color"));
        alert($("#par3").css("color"));
    });


    $('#but2').click(function() {
        $('#par4').css('color', 'red');
        $('#par5').css('font-size', '25px');
        $('#par6').css('font-family', 'Veranda').css('font-size', '33px');
        $('#par7').wrap("").css('color', 'red').css('font-size', '27px').css('font-family', 'Times New Roman');
    });
});*/

