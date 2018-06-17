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
		<form method="POST" action="remove_info_category.php">
			<input type="text" name="id_remove_category" placeholder="enter id of removing category">
			<br>
			<input type="submit" name="submit" value="REMOVE">
		</form>
	</div>
</body>
</html>