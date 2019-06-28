$(document).ready( function(){ 

 $('select').selectbox();
 
 showFounds = function(f, t, sp){
  if(t == 'ok') return false;
  else{
   $('div.status b.grn').text(f);
   $('div.status i').text(t);
   setTimeout(function(){ checkProcess(t) }, sp);
  }
 }
 
 checkProcess = function(t){
  $.post('core/check.php', {start:t}, function(rsp){ 
   
   if(rsp.errs){
    $('div.status').removeClass('load').addClass('error').html(rsp.errs);
	$('div.founds').html(rsp.outStr);
	return false;
   }
   else showFounds(rsp.found, rsp.total, 1000)
   
  }, 'json') 
  .done(function(){ })
  .fail(function(){ alert('Error. No response from the server!') })
 }
 
 var Form_AjaxOnSubmit = function(form, prms){
  
  function processJson(data){
   if(data.info) $('div.status').removeClass('load').addClass('ok').html(data.info);
   if(data.errs) $('div.status').removeClass('load').addClass('error').html(data.errs);
   //$('input[name="dir"]').val(data.srch_pth);
   $('input[name="typefls"]').val(data.typefls);
   $('div.founds').html(data.founds);
  }
  
  form.ajaxForm({dataType:'json',
   beforeSend: function(){
    if(prms.bar){
	 prms.bar.parent().fadeIn('fast'); prms.status.empty(); prcntVal = '0%'; prms.bar.width(prcntVal); prms.percent.html(prcntVal) 
	}
   },
   uploadProgress: function(event, position, total, percentComplete){ 
    if(prms.bar){ 
	 var prcntVal = percentComplete + '%'; prms.bar.width(prcntVal); prms.percent.html(prcntVal);
	 if(percentComplete == 100){ 
	  prms.bar.parent().fadeOut('slow');
	  $('div.status').html('Найдено файлов: <b class="grn">0</b> / <i>0</i>'); 
	  setTimeout(function(){checkProcess(1), 500});
	 }
	}
   },
   success: processJson,
   complete: function(xhr, sts){ /*if(prms.bar && sts == 'success') prms.bar.parent().fadeOut('slow')*/ } 
  });
  return false; 
 }
  
 var form = '#mainform';
 $(form + ' input[type="submit"]').click( function(){ null, 
  $('div.status').removeClass('ok').removeClass('error').addClass('load');
  Form_AjaxOnSubmit($(form), { bar:$('.bar'), percent:$('.percent'), status:$('div.status')} ) 
 });
 
 $('div.btnsldr').click(function(){ bs = $(this);
  if($('div.container').width()==526) 
   $('div.container').animate( {'width':$('.panel-r-innr').width()+530},200,
   function(){ bs.css('background-image','url(_img/arrow_l.png)').attr('title','Свернуть...'); });
  else $('div.container').animate({'width':526},200,
   function(){ bs.css('background-image','url(_img/arrow_r.png)').attr('title','Развернуть...'); });
  return false;
 });

 var tf = '*.*';
 $('select[name="typef"]').change(function(){
  if($(this).val() != '*.*'){ if(tf == '*.*') tf = ''; if(tf != '') tf += ', '; tf = tf + $(this).val(); } else tf='';
  $('input[name="typefls"]').val(tf);
 });
 
 $('input[name="_repls"]').on('click', function(){ 
  if($(this).attr('checked')=='checked'){ 
   $('div.wrng').show();
   $('textarea[name="_findrpl"]').attr('readonly', false);
  }
  else{ 
   $('div.wrng').hide();
   $('textarea[name="_findrpl"]').val('').attr('readonly', true);
  }
 });
 
 $('.dstruct').on('click', function(){
  if(confirm("Удалить данное приложение с сервера?")){
   $.post('core/destruct.php', {destruct:true}, function(rsp){ $('.container').addClass('removed').html(rsp); }) 
    .fail(function(){ alert('Error. No response from the server') })
  }
  return false;
 });

});