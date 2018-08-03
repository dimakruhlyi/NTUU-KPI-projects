"use strict"

//[1,2].forEach(alert);

/*
var name = "Дмитрий";
var admin = name;
document.write("<b>"+admin+"</b>");
*/

/*
var nameEarth = "Земля";
var visitorName = "Dima";
*/

/*
var a = 1, b = 1, c, d;
c = ++a; alert(c); // 2
d = b++; alert(d); // 1
c = (2+ ++a); alert(c); // 5
d = (2+ b++); alert(d); // 4
alert(a); // 3
alert(b); // 3
*/

/*
var a = 2;
var x = 1 + (a *= 2);
*/

/*
var name = prompt("Введите свое имя:\n");
alert("Привет "+name);
var conf = confirm("Вы точно "+name +"?");
alert(conf);
*/

/*
var name = prompt("Каково официальное название JS?\n");
if(name == "EcmaScript"){
  alert("Congratulate!");
}
else{
  alert("You don't know!");
}
*/

/*
var login = prompt("Enter your login: \n");
if(login == null){
	alert("Entrance is cancelled!");
}
else if(login == "Админ"){
	var passw = prompt("Enter your passord:\n");
	if(passw == null){
		alert("Entrance is cancelled!");
	}
	else{
		alert("Welcome!");
	}
}else{
	alert("I don't know you!");
}
*/

/*
var message;
var login = prompt("Enter you login:\n");
(login == "Vasia") ? message = "Hello!" : (login == "Manager") ? message = "Good afternoon!" : (login == " ") ? message = "Login doesn't exist!" : message = " ";
alert(message);
*/

/*
var number;
for(;;){
	number = prompt("Enter number, than more 100: ");
	if(number > 100 || number == null)
		{
			alert("Well!");
			break;
		}
}
*/

/*
nextStep:for(var i = 2;i<10;i++)
{
	for(var j = 2;j<i;j++)
	{
		if(i % j == 0)
			continue nextStep;
	}
	alert(i);
}
*/

/*
	var a = +prompt("a? ",'');
	switch(a){
		case 0:
			alert(0);
			break;
		case 1:
			alert(1);
			break;
		case 2:
		case 3:
			alert("2,3");
			break;
		default:
		alert("lol");
	}
*/
