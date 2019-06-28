<?php
function removeDirs($path){
 if(file_exists($path) && is_dir($path)){
  $dirHandle = opendir($path);
  while(false !== ($file = readdir($dirHandle))){
   if($file != '.' && $file != '..'){
	$tmpPath = $path.'/'.$file; 
	chmod($tmpPath, 0777); 
	if(is_dir($tmpPath)) removeDirs($tmpPath);
 	else{if(file_exists($tmpPath)) unlink($tmpPath);}
   }
  }
  closedir($dirHandle);
  if(file_exists($path)) rmdir($path);
 }
}

if(isset($_POST['destruct'])){ 
 removeDirs(preg_replace('/core$/i','', dirname($_SERVER['SCRIPT_FILENAME']))); 
 die('
 <p>Программа ликвидирована успешно.</p>
 <p><a href="/">Перейти на главную страницу сайта ... &raquo;</a></p>
 ');
}
?>