<?php
preg_match('/(.*)\/(.*)$/',$_SERVER['REQUEST_URI'],$m);
$PathToFile = str_replace('core', 'datas/'.$m[2], dirname($_SERVER['SCRIPT_FILENAME']));
if(file_exists($PathToFile)){
 header("Pragma: public");
 header("Expires: 0");
 header("Cache-Control: must-revalidate, post-check=0, pre-check=0");
 header("Cache-Control: private",false);
 header("Content-type: application/force-download");
 header("Content-Disposition: attachment; filename=".$m[2].";");
 header("Content-Transfer-Encoding: binary");
 header("Accept-Ranges: bytes");
 header("Content-Length: ".filesize($PathToFile));
 readfile($PathToFile);
}
?>