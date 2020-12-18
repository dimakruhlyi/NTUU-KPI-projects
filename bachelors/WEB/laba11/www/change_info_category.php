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

	if (isset($_POST['name_category'])) {
		$name_category = $_POST['name_category'];
		if ($name_category == '') {
			unset($name_category);
		}
	}

	if (isset($_POST['id_change_category'])) {
		$id_change_category = $_POST['id_change_category'];
		if ($id_change_category == '') {
			unset($id_change_category);
		}
	}

	
	$query = mysql_query("UPDATE `category` SET `name_category` = '$name_category' WHERE `id_category` = '$id_change_category'", $bd);
	
	if ($query == 'true') {
		echo "Record CHANGED successfully";
	} else {
		echo "FAILED";
	}

	?>
	<div id="all">
		<a href="./index.php">Back to main menu</a>
	</div>
</body>
</html>