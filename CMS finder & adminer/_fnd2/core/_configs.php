<?php

error_reporting(E_ALL);
ini_set('error_reporting', E_ALL);
ini_set('display_errors', '0');
ini_set('log_errors', '1');
ini_set('log_errors_max_len', '1024');
//ini_set('max_execution_time', 0);
//ini_set('memory_limit','128M');

class config{

 var $path = array('root'=>'../..');
 var $checkPerFounds = 100; // количество найденных кратное
	
 function __construct(){
  
  $this->path['dirWork'] = preg_replace('/core$/i','', dirname($_SERVER['SCRIPT_FILENAME'])); 

  $this->path['fileFnd'] = $this->path['dirWork'].'_service/founds.dat';
  $this->path['fileErr'] = $this->path['dirWork'].'_service/_errors.log';
  ini_set('error_log', $this->path['fileErr']);
  
  $this->path['extSrch'] = $this->path['dirWork'].'/datas/searches.ext';
  $this->path['extExld'] = $this->path['dirWork'].'/datas/exclude.ext';
  $this->path['dirExld'] = $this->path['dirWork'].'/datas/exclude.dir';
  $this->path['listFnd'] = $this->path['dirWork'].'/datas/list_files.txt';

 }

}
$config = new config;
?>