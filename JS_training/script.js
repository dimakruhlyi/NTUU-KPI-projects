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

/*
	function stepin(){
		 var result=x;
		 for(var i = 1; i < n; i++){
		 	result*=x;
		 }
		 return result;
	}
	var x = prompt("Enter x: ");
	var n = prompt("Enter n: ");
	alert(stepin());
*/

/*	
 var firstNumb = +prompt("Enter first number: ","");
 var secondNumb = +prompt("Enter second number: ","");

 alert("Sum = "+(firstNumb+secondNumb));
*/

/*
var price1 = 0.1, price2 = 0.2;
alert(+(price1+price2).toFixed(2));
*/

/*
var i = 0;
while(i<11)
{
	i+=0.2;
	if(i>9.8 && i<10.2) alert(i);
}
*/

/*
function getDecimal(num){
	var str = "" + num;
	var zeroPos = str.indexOf(".");
	if(zeroPos == -1) return 0;
	str = str.slice(zeroPos);
	return +str;
}

alert(getDecimal(17.3));
alert(getDecimal(-4.7));
*/

/*                                                              Формула Бинне та числа Фиббоначчи
function fibBinet(n){
	var Fn = 0;
	Fn = Math.pow(((1+Math.sqrt(5))/2),n)/Math.sqrt(5);
	return Math.round(Fn);	
}

function fib(n){
	var a = 1, b = 0, x;
	for(i = 0;i < n; i++){
		x = a + b;
		a = b;
		b = x;
	}
	return b;
}

alert(fibBinet(77));
alert(fib(77));	
*/

/*                              				Случайное из интервала (0, max)
var max = 10;
alert(Math.random() * max);
*/

/*                               				Случайное из интервала (min, max)
var min = 5, max = 10;
alert(min + Math.random() * (max - min));
*/

/*                               				Случайное целое от min до max
function randomIteger(min, max){
	var rand = min + Math.random() * (max + 1 - min);
	rand = Math.floor(rand);
	return rand;
}

alert(randomIteger(5, 10));
*/
