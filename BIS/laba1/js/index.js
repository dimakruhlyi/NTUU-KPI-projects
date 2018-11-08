function randomInteger(min, max) {
  var rand = min + Math.random() * (max - min)
  rand = Math.round(rand);
  return rand;
}
function CeasarsCipher(obj){
	//creating alphabet and variables

	var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".toLowerCase(),
	otherCharacters = "-=~\"\'#$%&*^:<>?/!{(|)}.1234567890\, \\ ",
	OUTPUT = "",
	STRING,
	shiftAmount,
	shiftedAlphabet;

	//Take values
	if(typeof obj == "object"){
		shiftAmount = obj.shift;
		if(shiftAmount>26 || shiftAmount<-25){
			shiftAmount = randomInteger(1, 25);
		}
		STRING = obj.msg.toLowerCase();
	}else{
		return;
	}		

	//Shift alphabet
	if(typeof STRING === "string" || typeof (STRING + "") === "string"){
		shiftedAlphabet = alphabet.slice(shiftAmount);
		shiftedAlphabet += alphabet.slice(0, shiftAmount);
		shiftedAlphabet +=otherCharacters;
		alphabet += otherCharacters;

		//Encrypt the message
		for(var i = 0; i < STRING.length; i++){
			var NUMBER = alphabet.indexOf(STRING[i]);

			OUTPUT += shiftedAlphabet[NUMBER];
		}
	}else{
		return;
	}
	return OUTPUT;
}

document.getElementById("message").addEventListener("input", function(){
	var itsValue = this.value;
	document.getElementById("output").textContent = CeasarsCipher({
		msg: itsValue,
		shift: document.getElementById("shift").value
	});
});
document.getElementById("shift").addEventListener("keyup", function(){
	var itsValue = this.value;
	document.getElementById("output").textContent = CeasarsCipher({
		msg: document.getElementById("message").value,
		shift: itsValue
	});
});

document.getElementById("output").textContent = CeasarsCipher({
	msg: document.getElementById("message").value,
	shift: document.getElementById("shift").value
});


