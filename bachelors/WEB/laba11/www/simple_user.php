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