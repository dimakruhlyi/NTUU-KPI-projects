<?php $Title='Поиск файлов'; $ver='2015 v1.0.8 UTF'; header("Content-Type:text/html; charset=utf-8");?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><?php echo $Title.' '.$ver;?></title>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
<script type="text/javascript" src="_js/jquery/jquery-form.js"></script>
<link type="text/css" rel="stylesheet" href="_js/selbox/selbox.css" media="screen" />
<script type="text/javascript" src="_js/selbox/selbox.js"></script>
<link href="_img/_main.css" media="screen" rel="stylesheet" type="text/css" />
<link href="_img/_btns.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="_js/main.js"></script>
</head>
<body>
<div class="result"><div class="founds"></div></div>
<div class="container shdw crnrsr solid_ccc">
<?php include 'core/_configs.php'; ?>
<form id="mainform" action="core/main.php" enctype="multipart/form-data" method="post">

 <div class="panel-r">
  <div class="panel-r-innr">
   <div class="title crnrsr bggray shdwtxt">Не искать в папках:</div>
   <textarea name="excludes"><?=file_exists($config->path['dirExld']) ? file_get_contents($config->path['dirExld']):''?></textarea>
  </div>
 </div>

 <div class="panel-l">
  <div class="title crnrsr bggray shdwtxt">
   <div class="btnsldr" title="Развернуть..."></div>
   <button class="btns dstruct" title="Удалить скрипт ...">Self-destruct</button>
   <b><?php echo $Title.' '.$ver;?></b>
  </div>
  <label>Место поиска:</label><input type="text" name="dir" value="/" placeholder="/" />
  <input type="submit" class="btns" name="start" value="Старт" />
  <hr class="clr inn" />
  <label>Типы файлов:</label><input type="text" name="typefls"  placeholder="*.*" />
  <select name="typef">
   <option value="*.*">Все файлы</option>
<?php 
if(file_exists($config->path['extSrch'])){
 $exts = file_get_contents($config->path['extSrch']);
 $exts = explode('|',$exts);	
 foreach($exts as $v) if(trim($v)!='') echo '<option value="'.$v.'">*.'.$v.'</option>';
}
?>	    
  </select>
  <hr class="clr inn" />
  <label>Искать текст:</label><input type="text" name="_findtxt" value="" />
  <input type="checkbox" name="_registr" />учит-ь регистр
  <label>Исп. рег. выраж.:</label><textarea name="_findreg"></textarea><br />
  <div class="wrng"><b>Внимание!</b> Замена текста в файлах будет производиться БЕЗ подтверждения.</div>
  <label>Заменить на: <input type="checkbox" name="_repls" <?php if(!isset($_GET['rw'])):?> disabled="disabled"<?php endif; ?> /></label><textarea name="_findrpl" readonly="readonly" ></textarea>
 </div>
 
 <hr class="clr inn" />
 <label>В результат:</label>&nbsp;<input type="checkbox" name="_datef">&nbsp;дата файла&nbsp;<input type="checkbox" name="_sizef">&nbsp;размер файла
 
 <div class="clr" style="margin-top:5px;"></div>
</form>

 <div class="stsbar shdwtxt bggray">
  <hr class="out" style="margin:0;" />
  <div><div class="progress solid_ccc"><div class="bar"></div><div class="percent">0%</div></div><div class="status ok"></div></div> 
 </div>
  
</div>

</body>
</html>