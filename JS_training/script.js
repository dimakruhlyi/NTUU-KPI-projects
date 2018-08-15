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

/*									String
function ucFirst (str){
	if(!str) return str;
	return str[0].toUpperCase() + str.slice(1);
}

alert(ucFirst("dimas"));
*/

/*
function checkSpam(str){
	var lowerStr = str.toLowerCase();
	return !!(~lowerStr.indexOf('viagra') || ~lowerStr.indexOf('xxx'));
}

alert(checkSpam('buy ViAgRA now'));
alert(checkSpam('free xxxxxxx'));
alert(checkSpam('innocence rabbit'));
*/

/*
function truncate(str, maxLength){
	if(str.length <= maxLength) return str;
	else{
		var newStr = str.slice(0, maxLength - 3);
		var threePoints = "...";
		return newStr + threePoints;
	}
}

alert(truncate("Dimas is the best programmer in the world!", 20));
*/

/*
function extractCurrencyValue(str)
{
	var newStr = str.slice(1, str.length + 1);
	return +newStr;
}
alert(typeof(extractCurrencyValue("$120")));
*/

/*
	var  user = { };
	user[name] = 'Oleg';
	delete user.name;
	user.surname = 'Petrov';
	alert(user.surname);
*/

/*
	function isEmpty(obj){
		var counter = 0;
		for(var checker in obj){
			counter++;
		}
		return counter == 0 ? true : false;
	}

	var object = {};
	alert(isEmpty(object));
	object.time = "any time";
	alert(isEmpty(object));
*/

/*
	var salaries = {
		"Dima": 400,
		"Oleg": 350,
		"Andrew": 100
	};
	function sumSalaries(obj){
		var sum = 0;
		for(var key in obj){
			sum+=obj[key];
		}
		return sum;
	}

	alert(sumSalaries(salaries));
*/

/*
	var salaries = {
		"Dima": 300,
		"Oleg": 350,
		"Andrew": 100
	};
	
		var high = 0, name = "";
		for(var key in salaries){
			if(salaries[key] > high) {
				high = salaries[key];
				name = key;
			}
			
		}
		
	alert(name || "There isn't employees!");
*/


/*
	var menu = {
		width: 200,
		height: 300,
		title: "My menu"
	};

	function isNumeric(n){
		return !isNaN(parseFloat(n)) && isFinite(n);
	}

	function multiplyNumeric(obj){
		for(var key in obj){
			if(isNumeric(obj[key])) obj[key]*=2;
		}
	}
	multiplyNumeric(menu);
	alert(menu.width);
	alert(menu.height);
	alert(menu.title);
*/

/*
	var goods  = [1,2,3,4,5,6,7];
	var lastChild = goods[goods.length-1];
	goods.push("Computer");
	alert(goods[goods.length-1]);
*/

/*
	var styles = ["Jazz", "Bliuz"];
	styles.push("Rock-n-Roll");
	styles[styles.length-2] = "Classic";
	var firstChild = styles.shift();
	styles.unshift("Rap", "Reggi");
	alert(styles);
*/

/*
	var arr = ["Apple", "Orange", "Pear", "Limon"];
	var rand = Math.floor(Math.random() * arr.length);
	alert(arr[rand]);
*/

/*
	var arr = [];
	var i =0, sum = 0;
	while(true){
		arr[i] = prompt("Enter "+ (i + 1) + " number: ");
		if(arr[i] == "" || arr[i] == null)
			break;
		sum += +arr[i];
		i++;
	}
	alert("Sum = " + sum);
*/

/*
	var arr = ["Test", 2, 1.5, false];

	function find(arr,value){
		for(var i = 0; i < arr.length; i++){
			if(arr[i] === value) return i; 
		}
		return -1;
	}
	alert(find(arr,1.5));
*/

/*
	var arr = [5,4,3,8,0];

	function filterRange(arr,a,b)
	{
		var mas = [];
		var count = 0;
		for(var i = 0; i < arr.length; i++){
			if(i >= a && i <= b)
			{
				mas[count] = arr[i];
				count++;
			}
		}
		return mas;
	}

	var newArr = filterRange(arr,1,3);
	alert(newArr);
	alert(arr);
*/

/*                                           	Решето Эратосфена
	//step 1
	var arr = [];

	for(var i = 2; i < 100; i++){
		arr[i] = true;
	}

	//step 2
	var p = 2;

	do{
		//step 3
		for(i = 2*p; i < 100; i += p){
			arr[i] = false;
		}
		//step 4
		for(i = p + 1; i < 100; i++){
			if(arr[i]) break;
		}

		p = i;
	}while (p * p < 100) //step 5

	// step 6 (done)
	//count sum
	var sum = 0;
	for( i = 0; i < arr.length; i++){
		if(arr[i])
			sum += i;
	}

	alert("Sum = " + sum);
*/



/*                                        	Подмассив наибольшей суммы
	function getMaxSubSum(arr){
		var maxSum = 0,
			partialSum = 0;

		for(var i = 0; i < arr.length; i++){
			partialSum += arr[i];
			maxSum = Math.max(maxSum, partialSum);
			if(partialSum < 0) partialSum = 0;
		}
		return maxSum;
	}

	alert(getMaxSubSum([-1,2,3,-9]));
	alert(getMaxSubSum([-1,2,3,-9,11]));
	alert(getMaxSubSum([-2,-1,1,2]));
	alert(getMaxSubSum([1,2,3]));
	alert(getMaxSubSum([100,-9,2,-3,5]));
	alert(getMaxSubSum([-1,-2,-3]));
*/

/*										Массивы: методы 
var obj = {
	className: 'open menu'
};

function addClass(obj, cls){
	var arr = obj.className ? obj.className.split(" ") : [];
	for(var i = 0; i < arr.length; i++){
		if(arr[i] == cls){
			return;
		}
	}
	arr.push(cls);

	obj.className = arr.join(" ");
}

addClass(obj, "lol");
addClass(obj, "open");
addClass(obj,"me");

alert(obj.className);
*/


/*
function camelize(str){
	var str_arr = str.split("-");
	
	for(var i = 1; i < str_arr.length; i++ ){
		str_arr[i] = str_arr[i].charAt(0).toUpperCase() + str_arr[i].slice(1);
	}
	
	return str_arr.join("");
}

alert(camelize("background-color"));
alert(camelize("list-style-image"));
alert(camelize("-webkit-transition"));
*/

/*
function removeClass(obj, cls){
	var classes = obj.className.split(' ');

	for(i = 0; i < classes.length; i++){
		if(classes[i] == cls){
			classes.splice(i, 1); //remove class
			i--;
		}
	}
	obj.className = classes.join(' ');
}

var obj = {
	className: "open menu menu"
};

removeClass(obj, "lol");
removeClass(obj, "menu");
alert(obj.className);
*/

/*
var arr = [5,3,8,1];

function filterRangeInPlace(arr, a, b){
	for(var i = 0; i < arr.length; i++){
		if(arr[i] < a || arr[i] > b){
			arr.splice(i--, 1);
		}
	}
}

filterRangeInPlace(arr, 1, 4);
alert(arr);
*/

/*
var arr = [5,2,1,-10,8];

function compareReversed(a, b){
	return b - a;
}
arr.sort(compareReversed);
alert(arr);
*/

/*
var arr = ["HTML", "Javascript", "CSS"];

var arrSorted = arr.slice().sort();

alert(arrSorted);
alert(arr);
*/

/*
var arr = [1,2,3,4,5];
function randomArray(a, b)
{
	return Math.random() - 0.5;
}

arr.sort(randomArray);
alert(arr);
*/

/*
var vasya = {name:"Vasya", age: 23};
var masha = { name: "Masha", age: 18};
var vovochka = { name: "Vovochka", age: 6};
var people = [ vasya, masha, vovochka];

function compareSort(a , b){
	return a.age - b.age;
}
people.sort(compareSort);
alert(people[0].age);
*/

/*                                         Односвязный список
var list = {
	value: 1,
	next: {
		value: 2,
		next: {
			value: 3,
			next: {
				value: 4,
				next: null
			}
		}
	}
};

function printList(list){
	var tmp = list;

	while(tmp){
		alert(tmp.value);
		tmp = tmp.next;
	}
}
printList(list);
*/

/*                                  Вывод с помощью рекурсии
var list = {
	value: 1,
	next: {
		value: 2,
		next: {
			value: 3,
			next: {
				value: 4,
				next: null
			}
		}
	}
};

function printList( list){

	alert(list.value);
	if(list.next){
		printList(list.next);
	}
}

printList(list);
*/

/*
var list = {
	value: 1,
	next: {
		value: 2,
		next: {
			value: 3,
			next: {
				value: 4,
				next: null
			}
		}
	}
};

function printReservedList( list){
	if(list.next){
		printReservedList(list.next);
	}
	alert(list.value);
}

printReservedList(list);
*/

/*                                     Обратный вывод без рекурсии
var list = {
	value: 1,
	next: {
		value: 2,
		next: {
			value: 3,
			next: {
				value: 4,
				next: null
			}
		}
	}
};

function printReservedList( list){
	var arr = [];
	var tmp = list;

	while( tmp){
		arr.push(tmp.value);
		tmp = tmp.next;
	}

	for(var i = arr.length - 1; i >= 0; i--){
		alert(arr[i]);
	}
}

printReservedList(list);
*/

/*                                                					Фильтрация анаграмм
var arr = ["воз", "киборг", "корсет", "ЗОВ", "гробик", "костер", "сектор"];

function aclean( arr){
	var obj = {};

	for(var i = 0; i < arr.length; i++){
		var sorted = arr[i].toLowerCase().split('').sort().join('');

		obj[sorted] = arr[i];
	}
	var result = [];

	for(var key in obj) result.push(obj[key]);

	return result;
}

alert(aclean(arr));
*/

/*
var strings = ["кришна", "кришна", "харе", "харе", "харе", "харе", "кришна", "кришна", "8-()"];

function unique( arr){
	var obj = {};

	for(var i = 0; i < arr.length; i++){
		var str = arr[i];
		obj[str] = true;
	}
	return Object.keys(obj);
}

alert(unique(strings));
*/

/*										Map
	var arr = ["Есть", "жизнь", "на", "Марсе"];

	var arrLength = arr.map(function(arr){
		return arr.length;
	});
	alert(arrLength);
*/

/*										Reduce
	function getSums(arr){
		var result = [];

		var totalSum = arr.reduce(function(sum, item){
			result.push(sum);
			return sum + item;
		});
		result.push(totalSum);

		return result;
	}

	alert(getSums([1,2,3,4,5]));
	alert(getSums([-2,-1,0,1]));
*/
