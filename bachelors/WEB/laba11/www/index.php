<?php
include('bd.php');
?>

<!DOCTYPE html>
<html>
<head>
	<meta charset="UTF-8">
	<title>main page</title>
	<link rel="stylesheet" href="./css/style.css">
</head>
<body>
	<div id="all">
		<h1>Log In</h1>
		<form action="" class="form_submit">
			Enter login <br>
			<input type="text" name="personName" placeholder="login">
			<br>
			Enter password<br>
			<input type="password" name="password" value="">
			<br>
			<input type="button" value="Send This" onclick="submitFunction()">
		</form>
	</div>
	<script src="./script.js"></script>
</body>
</html>