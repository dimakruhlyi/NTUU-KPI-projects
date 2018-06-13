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
		<form method="POST" action="add_info_item.php">
			<input type="text" name="name_item" placeholder="Enter name of new item"><br>
			<input type="text" name="id_item_category" placeholder="Enter id_item_category of new item"><br>
			<input type="text" name="price_item" placeholder="Enter price of new item"><br>
			<input type="text" name="count_item" placeholder="Enter count of new item"><br>
			<input type="text" name="sold_item" placeholder="Enter sold of new item"><br>
			<input type="submit" name="submit" value="add new item">
		</form>
	</div>
</body>
</html>