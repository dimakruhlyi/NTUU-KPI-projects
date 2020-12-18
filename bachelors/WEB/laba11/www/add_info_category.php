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
	$query = mysql_query("INSERT INTO `category` (`name_category`) VALUES ('$name_category')", $bd);
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