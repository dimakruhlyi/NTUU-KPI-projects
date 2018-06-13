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
		<form method="POST" action="add_info_category.php">
			<input type="text" name="name_category" placeholder="Enter name of new category">
			<input type="submit" name="submit" value="add new category">
		</form>
	</div>
</body>
</html>