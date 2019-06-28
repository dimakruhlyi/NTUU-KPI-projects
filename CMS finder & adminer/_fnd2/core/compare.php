<?
$f1 = file('list-1.txt'); sort($f1);
$f2 = file('list-2.txt'); sort($f2);

//$r = array_diff($f1,$f2);
for($i=1; $i < count($f2); $i++){ if(!array_search($f2[$i], $f1)){ $r[] = $f2[$i]; }}

echo("<pre>". htmlspecialchars(print_r($r,true)) . "</pre>");

//foreach($r as $k=>$v) $f3 .= $v.'<br>'; //PHP_EOL;
//echo $f3;

//echo("<pre>". htmlspecialchars(print_r($r,true)) . "</pre>");
?>