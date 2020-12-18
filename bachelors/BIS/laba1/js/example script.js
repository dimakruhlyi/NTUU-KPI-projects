var Number(period) = 26;

function is_lat_alpha(ch){
	return 'a' <= ch && ch <= 'z';
}

function code_symb(ch,sh){
	if(!is_lat_alpha(ch)) return ch;
	return (ch - 'a' + sh) % period + 'a';
}

function code(txt, sh){
	for( let i = 0; txt.length(); ++i){
		txt[i] = code_symb(txt[i],sh);
	}
	return txt;
} 

function decode_symb(ch, sh){
	if(!is_lat_alpha(ch)) return ch;
	var Number(res) = ch - 'a' - sh;
	while(res < 0) res +=period;
	return res % period + 'a'; 
}

function decode(txt, sh){
	for(let i = 0; i <txt.length(); ++i){
		txt[i] = decode_symb(txt[i], sh);
	}
	return txt;
}

var text, coded_text, decoded_text, shift;

text = prompt("Enter text for coding:");
shift = +prompt("Input shift ( > 0 ):");
coded_text = code(text, shift);
alert(coded_text);
