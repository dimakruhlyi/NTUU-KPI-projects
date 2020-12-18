<?php 
	
	$user_name = htmlspecialchars($_POST['user_name']); 
	$user_surname = htmlspecialchars($_POST['user_surname']);
	$password = htmlspecialchars($_POST['parol']);
	$user_email = htmlspecialchars($_POST['user_email']);
	$user_number = htmlspecialchars($_POST['user_number']);
	$teams = htmlspecialchars($_POST['quant']);
	$quont_tickets = htmlspecialchars($_POST['quont_tickets']);
	$count_people = htmlspecialchars($_POST['eluveitie']);
	$first_date = htmlspecialchars($_POST['first_date']);
	$wish = htmlspecialchars($_POST['wish']);


	$address="dimakruhly@gmail.com";
	$sub = 'Data for UEFA';

	
 	$msg="
		Name: $user_name \n
		Surame: $user_surname \n
		Password: $password \n
		E-mail: $user_email \n
		Mobile number: $user_number \n
		Favourite teams: $teams \n
		Count of tickets: $quont_tickets \n
		Count people: $count_people \n
		First date: $first_date \n
		Wish: $wish \n
	";

	$from  = "From: $user_name <$user_email> \r\n Reply-To: $user_email \r\n";
	
	mail($address, $sub, $msg, "Content-type: text/plain; charset = \"utf-8\"\n From: $address");
 	
?>