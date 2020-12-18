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
		<form method="POST" action="sell_info_item.php">
			<input type="text" name="name_item" placeholder="Enter name of selling item"><br>
			<input type="text" name="count_selling_items" placeholder="Enter count of selling items"><br>
			<input type="submit" name="submit" value="sell item('s)">
		</form>
	</div>
</body>
</html>