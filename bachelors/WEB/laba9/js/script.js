/*                                                                      TASK 12
		var passw = prompt("Введите пароль доступа: ");
		if (passw == 9583 || passw == 1747)
			alert("Доступ разрешен! Доступны модули баз А, В и С.");
		else if (passw == 3331 || passw == 7922)
			    alert("Доступ разрешен! Доступны модули баз В и С.");
		    else if (passw == 9455 || passw == 8997)
			        alert("Доступ разрешен! Доступен модуль базы С.");*/


/*                                                                      TASK 20
var x = prompt("Enter number:")
var y =  prompt("Enter stepin: ");
while(y>0)
{

    document.write("X в степени "+y+" = "+Math.pow(x,y)+"<br/>");
    --y;
}*/

/*                                                                      TASK 23
var number = prompt("Введите число от 1 до 100: ");
var try_count = 0;
while(true)
{
    var guess_numb = prompt("Второй игрок, давай, угадывай число:");
    if(guess_numb<number)
    {
        alert("Мало! Думай еще!");
        try_count++;
    }
    if(guess_numb>number)
    {
        alert("Много! Думай еще!");
        try_count++;
    }
    if(guess_numb==number)
    {
        alert("Vunderbar! Вы угадали!");
        try_count++;
        break;
    }
}
alert("Но вы угадали число с "+try_count+" попытки! Выводы делайте сами.")*/


/*                                                                      TASK 29
function factorial(n) {
      return (n != 1) ? n * factorial(n - 1) : 1;
}

alert( factorial(1) );*/

/*                                                                      TASK 30
var countries = new Array();
countries[0] = "Ukraine";
countries[1] = "USA";
countries[2] = "Canada";
countries[3] = "Spanish";
countries[4] = "Poland";
var population = [42.8,365.7,28.2,54.3,39.1];
for(let i = 0; i<countries.length;i++)
{
    document.write("Population "+countries[i]+" is "+population[i]+" mln people. <br/>");
}*/

/*----------------------------------------------------------------------------------------------------------------------------------
function Employee(name,subdivision, telephone, salary){
    this.name = "Dimas";
    this.subdivision = "TEF";
    this.telephone = "0664579764";
    this.salary = "12345";
}
var empl = new Employee;
Employee.prototype.address = "Kyiv";
document.write(empl.name+" "+empl.subdivision+" "+empl.telephone+" "+empl.salary+" "+empl.address);
----------------------------------------------------------------------------------------------------------------------------------*/

/*                                                                      TASK 36
function turFirma (countDays, countPeople, countryTaryf){
    this.countDays = countDays;
    this.countPeople = countPeople;
    this.countryTaryf = countryTaryf;
    this.calculate = function(){
        return countDays*countPeople*countryTaryf;
    }
}
var obj1 = new turFirma(14,54,1.22);
alert(obj1.calculate());*/

/*                                                                      TASK 37
var associate  = new Object();
associate.name = "Dima";
associate.subdivision = "KPI, TEF, TR-61";
associate.telephone = "+(380)66-45-79-764";
associate.salary = 1234.5;

function associateShow()
{
    for(var i in associate)
    {
        document.write(i+": "+associate[i]+"<br>");
    }
}
associate.show = associateShow();
associate.show();*/


/*----------------------------------------------------------------------------------------------------------------------------------
var now=new Date();
var hours=now.getHours();
 var minutes = now.getMinutes();
var seconds= now.getSeconds();
if(minutes < 10){
    minutes = "0"+minutes;
     }
if(seconds<10){
 seconds = "0"+seconds;
  }
  document.write("Текущее время: " + hours + ":" + minutes + ":" + seconds);
----------------------------------------------------------------------------------------------------------------------------------*/


/*                                                                      TASK 7_4
function viewDate(N)
{
    var months = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь","Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь"];
    var days = ["Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница","Суббота"];

    var day_now = new Date();
    var milliNow = day_now.getTime();

    var day_after_N = new Date(1000 * 60 * 60 * 24 * N);
    var milliN = day_after_N.getTime();

    var milliNowPlusN = new Date(milliNow + milliN);

    document.write(N + " - через указанное Вами число дней будет следующая ДАТА: <p>");
    document.write("Год: " + milliNowPlusN.getFullYear() + "<br>");
    document.write("Месяц: " + months[milliNowPlusN.getMonth()] + "<br>");
    document.write("День недели: " + days[milliNowPlusN.getDay()] + "<br>");
    document.write("Число: " + milliNowPlusN.getDate() + "<br>");
}

var searchDate  = prompt("Через сколько дней вы хотите узнать дату? (введите число от 1 до 1000) ");
if(searchDate<1 || searchDate>1000)
{
    alert("Ошибка. Я же говорил в каких пределах надо вводить!")
}
else{
    viewDate(searchDate);
}*/