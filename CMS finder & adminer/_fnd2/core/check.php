<?php

include '_configs.php';
include '_json_encode.php';

if(isset($_POST['start'])){

 $founds = array(0,0); 
 
 if(file_exists($config->path['fileErr'])){ 
  
//  $outStr = file_get_contents($config->path['fileErr']);
//  $outStr = str_replace(PHP_EOL, '<br />', $outStr);
//  $outStr = '<b class="red">Runtime Error Script:</b><br />'.$outStr;
//  
//  die('{"errs":"Runtime Error Script", "outStr":'. my_json_encode($outStr). '}'); 

 }
 
 if(!file_exists($config->path['fileFnd'])) sleep(1);
 if(file_exists($config->path['fileFnd'])){
  $fd = file($config->path['fileFnd']);
  $founds = explode(':',$fd[0]);
  if($_POST['start'] == $founds[1]){ unlink($config->path['fileFnd']); $founds[1] = 'ok'; }
 }
 
 die('{"found":"'. $founds[0] .'", "total":"'. $founds[1].'"}'); 
}
?>