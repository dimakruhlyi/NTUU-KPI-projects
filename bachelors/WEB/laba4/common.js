$(document).ready(function(){

	$("#form").submit(function(){
		$.ajax({
			type: "POST",
			url: "send.php",
			data: $(this).serialize()
		}).done(function(){
			alert("Спасибо за заявку! Скоро мы с вами свяжемся.");
		});
		alert("Wrong!");
		return false;
	});

});