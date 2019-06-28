<?php header("Content-Type:text/html; charset=utf-8");

include '_configs.php';

$ErrArray = array();
$ErrArray[1] = 'Нет такой папки!';
$ErrStr = '';

if(isset($_POST['start'])){
	
 if(file_exists($config->path['fileErr'])) unlink($config->path['fileErr']);
 if(file_exists($config->path['fileFnd'])) unlink($config->path['fileFnd']);	
 if(file_exists($config->path['listFnd'])) unlink($config->path['listFnd']);
	
 $srch_pth = isset($_POST['dir']) && trim($_POST['dir']) != '' ? $_POST['dir'] : '/';
 if(!preg_match('|/$|', $srch_pth)) $srch_pth .= '/';
 $srch_pth = $config->path['root'].'/'.$srch_pth;
 $srch_pth = preg_replace('|/+|','/', $srch_pth);
 
 if(file_exists($srch_pth)){
  
  $excludes = '';
  $fexclude = $config->path['dirExld'];
  if(trim($_POST['excludes'])!=''){
   $exclude = $_POST['excludes'];
   $f = fopen($fexclude, 'w'); fputs($f, $exclude); fclose($f); 
   $exclude = file($fexclude);
   foreach($exclude as $k=>$v) $excludes .= trim($v).'|';
   $excludes = str_replace('/','\/', $excludes);
  }
  elseif(file_exists($config->path['dirExld'])) unlink($config->path['dirExld']);

  $typefls = explode(', ', $_POST['typefls']);
  $typefls = array_unique($typefls);
  
  include('_search.php');
  $search = new search;

  $search->prms['srch_pth'] = $srch_pth;
  $search->TypesFiles = trim(implode('|',$typefls));
    
  $search->excludes['dir'] = trim($excludes,'|');
  $search->excludes['ext'] = file_get_contents($config->path['extExld']);
  
  foreach($_POST as $k=>$v) 
   if(preg_match('/^_(.*)$/',$k,$m) && $v) $search->prms[$m[1]] = $v; 
  
  if(!empty($search->prms['findtxt'])){ 
   $search->prms['findtxt_S'] = $search->getSearchStr($search->prms['findtxt']);
  }
  if(!empty($search->prms['findreg'])){ 
   if(!preg_match('|^/(.*)/(.*)?$|', $search->prms['findreg'])) die('{"errs":"Ошибка в регулярном выражении!"}');
   $search->prms['findreg_S'] = $search->getSearchStr($search->prms['findreg'], true);
  }
  
  $search->ReadDIR($srch_pth);
  
  $f = fopen($config->path['fileFnd'],'w'); fputs($f, $search->totals['fnds'].':'.$search->totals['count']); fclose($f);// sleep(1); 
  
  $sprtrH = '<br>----------------------------<br>';
  $sprtrP = PHP_EOL.'----------------------------'.PHP_EOL;
  $search->founds = '';
    
  if(file_exists($config->path['fileErr'])){
   $search->errors = file($config->path['fileErr']);
   $search->errorsStr = ''; foreach($search->errors as $v) $search->errorsStr .= trim($v).'<br>'; 
   $search->founds = '<b class=\"red\">Ошибки в процессе поиска</b>: [ <b class=\"red\">'. count($search->errors) .'</b> ]'.$sprtrH. $search->errorsStr . ltrim($sprtrH,'<br>');
  }
  
  if($search->totals['fnds'] > 0){ 
   sort($search->FoundFiles);
   $search->founds .= implode('<br>', $search->FoundFiles);
  }
  else{
   $search->founds .= 'Ничего не найдено';
   $search->FoundFiles[0] = $search->founds;
  }
   
  if(isset($search->prms['findreg_S'])){
   $search->FoundFiles[0] = 'Искали (исп. рег. выраж.): '. $search->prms['findreg'] .$sprtrP.$search->FoundFiles[0];
   $search->founds = 'Искали (исп. рег. выраж.): <b class=\"red\">'. htmlspecialchars($search->prms['findreg']) .'</b>'.$sprtrH.$search->founds;
  }
  elseif(isset($search->prms['findtxt_S'])){ 
   $search->FoundFiles[0] = 'Искали: '. $search->prms['findtxt'] .$sprtrP.$search->FoundFiles[0];
   $search->founds = 'Искали: <b class=\"red\">'. htmlspecialchars($search->prms['findtxt']) .'</b>'.$sprtrH.$search->founds;
  }
  else{
   $search->FoundFiles[0] = 'Все файлы:'.$sprtrP.$search->FoundFiles[0];
   $search->founds = 'Все файлы:'.$sprtrH.$search->founds;
  }
   
  if($search->totals['fnds'] > 0){
      
   $search->FoundFiles[] = $sprtrP;
   $search->founds .= $sprtrH;
   
   $StrTotal = 'Всего: '. number_format($search->totals['fnds'], 0, '', ' '). ' ( '. number_format($search->totals['sizes'], 0, '', ' ') . ' байт )';
   $search->FoundFiles[] = $StrTotal;
   $search->founds .= $StrTotal; 
   
   $f = fopen($config->path['listFnd'], 'w'); fputs($f, implode(PHP_EOL, $search->FoundFiles)); fclose($f);
   
   $InfStr = 'Найдено файлов: <b class=\"grn\">'. $search->totals['fnds'] .'</b> / <i>'.$search->totals['count'].'</i> [ <b>'. number_format($search->totals['sizes'], 0, '', ' '). 
   '</b> байт ] <a class=\"redb\" target=\"_blank\" href=\"datas/list_files.txt\">Скачать результат &raquo;</a>';
  }
  else $InfStr = '<b class=\"red\">Ничего не найдено</b>';
 }
 else $ErrStr = $ErrArray[1];
}

if($ErrStr != '') $out = '"errs":"'.$ErrStr .'"'; 
else{
 $out  = isset($InfStr) ? '"info":"'.$InfStr .'"' : '';
 $out .= isset($srch_pth) ? ',"srch_pth":"'. $srch_pth.'"' : ''; 
 $out .= isset($typefls) ? ',"typefls":"'. (implode(', ',$typefls)) .'"' : '';
 $out .= isset($search->founds) ?',"founds":"'.$search->founds.'"':'';
}

die('{'. $out .'}'); 
?>