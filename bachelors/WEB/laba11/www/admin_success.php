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
<?php
$query_category = mysql_query("SELECT * FROM `category`", $bd);
$result_category = mysql_fetch_array($query_category);
/*
	<div id="text"> ID: $result[id]</div>
	<div id="text"> text: $result[text]</div>
*/
$query_item = mysql_query("SELECT * FROM `item`", $bd);
$result_item = mysql_fetch_array($query_item);

print<<<HERE
	<div id="all"> 
	<div id="text">ID_category</div>
	<div id="text">name_category</div>
	<form method="POST" action="add_category.php">
		<input type="submit" id="submit" value="Add record to category table">
	</form>
	<form method="POST" action="change_category.php">
		<input type="submit" id="submit" value="Change record to category table">
	</form>
	<form method="POST" action="remove_category.php">
		<input type="submit" id="submit" value="Remove record to category table">
	</form>
	</div>

	<div id="all"> 
	<div id="text">id_item</div>
	<div id="text">name_item</div>
	<div id="text">id_category</div>
	<div id="text">price_item</div>
	<div id="text">count_item</div>
	<div id="text">sold_item</div>
	<form method="POST" action="add_item.php">
		<input type="submit" id="submit" value="Add record to item table">
	</form>
	<form method="POST" action="change_item.php">
		<input type="submit" id="submit" value="Change record to item table">
	</form>
	<form method="POST" action="remove_item.php">
		<input type="submit" id="submit" value="Remove record to item table">
	</form>
	<form method="POST" action="sell_item.php">
		<input type="submit" id="submit" value="Sell item">
	</form>
	</div>
	<div id="all">
	<form method="POST" action="report_category.php">
		<input type="submit" id="submit" value="report category table">
	</form>
	<form method="POST" action="report_items.php">
		<input type="submit" id="submit" value="report item table">
	</form>
	</div>
HERE;
?>
</body>
</html>