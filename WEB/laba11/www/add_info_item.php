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

	if (isset($_POST['id_item_category'])) {
		$id_item_category = $_POST['id_item_category'];
		if ($id_item_category == '') {
			unset($id_item_category);
		}
	}

	if (isset($_POST['price_item'])) {
		$price_item = $_POST['price_item'];
		if ($price_item == '') {
			unset($price_item);
		}
	}

	if (isset($_POST['count_item'])) {
		$count_item = $_POST['count_item'];
		if ($count_item == '') {
			unset($count_item);
		}
	}

	if (isset($_POST['sold_item'])) {
		$sold_item = $_POST['sold_item'];
		if ($sold_item == '') {
			unset($sold_item);
		}
	}

	$query = mysql_query("INSERT INTO `item` (`name_item`, `id_category`, `price_item`, `count_item`, `sold_item`) VALUES ('$name_item', '$id_item_category', '$price_item','$count_item','$sold_item')", $bd);
	if ($query == 'true') {
		echo "Record ADDED successfully";
	} else {
		echo "FAILED";
	}

	?>
	<div id="all">
		<a href="./index.php">Back to main menu</a>
	</div>
</body>
</html>