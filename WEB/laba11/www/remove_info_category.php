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

	

	if (isset($_POST['id_remove_category'])) {
		$id_remove_category = $_POST['id_remove_category'];
		if ($id_remove_category == '') {
			unset($id_remove_category);
		}
	}

	
	$query = mysql_query("DELETE FROM `category` WHERE `id_category` = '$id_remove_category'", $bd);
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