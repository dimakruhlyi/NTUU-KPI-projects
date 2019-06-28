<?php

class search{ 
 
 var $TypesFiles = '*.*';
 var $founds = '';
 var $TotalSize = 0;
 var $totals = array('count'=>0,'fnds'=>0, 'rplc'=>0, 'sizes'=>0);
 var $FoundFiles = array();
 var $excludes = array();
 var $prms = array();
 
 function getSearchStr($s, $reg=false){
  //htmlspecialchars($srchstr);
  $s = str_replace('"','\"',$s);
  $s = str_replace('(','\(',$s);
  $s = str_replace(')','\)',$s);
  if(!$reg) $s = str_replace('/','\/',$s);
  $s = str_replace('$','\$',$s);
  $s = str_replace('[','\[',$s);
  $s = str_replace(']','\]',$s);
  $s = str_replace('?','\?',$s);
  $s = str_replace('.','\.',$s);
  $s = str_replace('*','\*',$s);
  $s = str_replace('+','\+',$s);
  return $s;
 }

 function ReadDIR($Path){
  
  global $config;
  
  if($this->excludes['dir'] == '' || !preg_match('/('. $this->excludes['dir'] .')/', $Path)){
   $d = dir($Path);  
   while(($entry = $d->read()) != false){ 
    if($entry != '' && $entry != '.' && $entry != '..'){
 	 $all_path = $Path.$entry;
     $new_path = $this->go($all_path, is_file($all_path));  
     if(!is_file($all_path) && !$this->ReadDIR($new_path)) return false; 
    }
   }
  }  
  return true;
 } 
 
 function go($path2file, $is_file = true){
	 
  global $config;	 
  
  if($is_file && !preg_match('/\.('. $this->excludes['ext'] .')$/i', $path2file)){
   
   $found = false;
   if(trim($this->TypesFiles)=='' || $this->TypesFiles=='*.*' || preg_match("/\.(".$this->TypesFiles.")$/i", $path2file)) $found = true;
   
   if($found){ 	
	
	$this->totals['count']++;
	$tmpFname = str_replace('../', '', $path2file);
	
	if(!empty($this->prms['findtxt_S']) || !empty($this->prms['findreg_S'])){
	 
	 $found = false;

	 if(filesize($path2file) > 5000000){ /* for logs big files ... */}
	 else{

	  $fc = file_get_contents($path2file);

	  if(isset($this->prms['findreg_S'])){
	   if(preg_match($this->prms['findreg_S'], $fc, $m)){
	    $found = true;
	    $this->totals['fnds']++;
	   }
	  }
	  elseif(isset($this->prms['findtxt_S'])){
	   if(preg_match('/'. $this->prms['findtxt_S'] .'/'. (isset($this->prms['registr'])?'':'i'), $fc)){
	    $found = true;	
	    $this->totals['fnds']++;
	   }
	  }
	 }// if > ...
	 
	}
	else $this->totals['fnds']++;
	
	if($found){
	 $this->totals['sizes'] += filesize($path2file);
	 $S  = '';
	 if(isset($this->prms['datef'])) $S .= strftime("%d.%m.%Y %H:%M:%S", filemtime($path2file)) .' | ';
	 if(isset($this->prms['sizef'])) $S .= number_format(filesize($path2file), 0, '.', ' ') .' | '	;
	 $S .= $tmpFname;
	 $this->FoundFiles[] = $S;
	}

 	if($this->totals['count'] % $config->checkPerFounds == 0){ // количество найденных кратное ... (100)
	 $f = fopen($config->path['fileFnd'],'w'); fputs($f, $this->totals['fnds'].':'.$this->totals['count']); fclose($f);// sleep(1); 
	}

   }
   else $path2file = $path2file.'/';     
  }
  else $path2file = $path2file.'/';    
  
  return $path2file;
 } 
}
?>