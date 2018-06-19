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
	$query = mysql_query("SELECT * FROM `item`", $bd);
	while($row=mysql_fetch_array($query)){
		echo '<p>id_item = '.$row['id_item'].'. Name_item = '.$row['name_item'].'. Id_category = '.$row['id_category'].'. Price_item = '.$row['price_item'].'. Count item = '.$row['count_item'].'. Sold_item = '.$row['sold_item'].'</p>';
	}
	echo '</div>';
?>
	<div id="all">
		<a href="./index.php">Back to main menu</a>
	</div>
</body>
</html>