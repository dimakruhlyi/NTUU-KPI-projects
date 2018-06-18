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
	echo '<div id="all">';
	$query = mysql_query("SELECT * FROM `category`", $bd);
	while($row=mysql_fetch_array($query)){
		echo '<p>id_category = '.$row['id_category'].'. Name_category = '.$row['name_category'].'</p>';
	}
	echo '</div>';
?>
	<div id="all">
		<a href="./index.php">Back to main menu</a>
	</div>
</body>
</html>