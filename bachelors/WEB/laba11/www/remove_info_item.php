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

	

	if (isset($_POST['id_remove_item'])) {
		$id_remove_item = $_POST['id_remove_item'];
		if ($id_remove_item == '') {
			unset($id_remove_item);
		}
	}

	
	$query = mysql_query("DELETE FROM `item` WHERE `id_item` = '$id_remove_item'", $bd);
	if ($query == 'true') {
		echo "Record REMOVED successfully";
	} else {
		echo "FAILED";
	}

	?>
	<div id="all">
		<a href="./index.php">Back to main menu</a>
	</div>
</body>
</html>