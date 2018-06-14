<?php
include('bd.php');
?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>add record</title>
	<link rel="stylesheet" href="./css/style.css">
</head>
<body>
	<div id="all">
		<form method="POST" action="change_info_category.php">
			<input type="text" name="id_change_category" placeholder="enter id of changing category">
			<br>
			<input type="text" name="name_category" placeholder="Enter name of new category">
			<br>
			
			<input type="submit" name="submit" value="change category">
		</form>
	</div>
</body>
</html>