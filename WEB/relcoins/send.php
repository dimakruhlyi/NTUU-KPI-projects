<?php
	$project_name = "RelCoins";
	$from_email = "i@up-site.com.ua";
	//$to_email = "vlad_vlk@mail.ua";
	$to_email = "dimakruhly@gmail.com";

	$name = trim($_POST["name"]);
	$phone = trim($_POST["phone"]);
	
	$message = "Имя: $name \r\nТелефон: $phone" ;
	$headers = "From: $from_email \r\n";
	$headers .= "Content-type: text/html; charset=utf-8";
	
	$send_mail = mail($to_email, $project_name, $message, $headers);
	if($send_mail){
		
	}
	else{
		echo "Ошибка!";
	}
?>
