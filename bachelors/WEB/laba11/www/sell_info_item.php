
<?php
include('bd.php');
?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>listener</title>
	<link rel="stylesheet" href="./css/style.css">
</head>
<body>
	<?php

	if (isset($_POST['name_item'])) {
		$name_item = $_POST['name_item'];
		if ($name_item == '') {
			unset($name_item);
		}
	}

	if (isset($_POST['count_selling_items'])) {
		$count_selling_items = $_POST['count_selling_items'];
		if ($count_selling_items == '') {
			unset($count_selling_items);
		}
	}

	$result = mysql_query("SELECT `count_item` FROM `item` WHERE `name_item` = '$name_item'", $bd);

	$result_count = mysql_fetch_array($result);
	$count_item = $result_count[0] - $count_selling_items;

	$query = mysql_query("UPDATE `item` SET `count_item`='$count_item' WHERE `name_item` = '$name_item'", $bd);
	if ($query == 'true') {
		echo "Record REDUCED successfully";
	} else {
		echo "FAILED";
	}

	?>
	<div id="all">
		<a href="./index.php">Back to main menu</a>
	</div>
</body>
</html>