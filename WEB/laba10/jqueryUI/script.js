/*                                                      Task 1
$(document).ready(function(){

    $("#tabs").tabs();
});*/


$(document).ready(function(){

    $("#el1").draggable().resizable();
    $("#sort1").sortable();

    $("#el2").draggable({stack:"#drop1"});
    $("#el3").draggable({stack:"#drop1"});
    $("#drop1").droppable({
        accept:"#el2, #el3",
        drop:function(br, ei){
            ei.draggable.css("display","none")
            $("#drop1").css("backgroundColor", "green")
            setTimeout('$("#drop1").css("backgroundColor", "white")',100);
        }
    });
    $("#drop2").droppable({
        accept:"#el2",
        drop:function(per1, per2){
            per2.draggable.css("display","none")
            $("#drop2").css("backgroundColor", "green")
            setTimeout('$("#drop2").css("backgroundColor", "white")',100);
        }
    });

});