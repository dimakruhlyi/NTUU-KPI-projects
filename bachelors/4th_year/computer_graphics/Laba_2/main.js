
var cx = document.querySelector("canvas").getContext("2d");

let form = document.forms.f;
var a1 = form.elements.a;
var t1 = form.elements.t;
var doot_coord = form.elements.coord_dot;
var doot_Y1 = form.elements.dot_Y1;
var doot_Y2 = form.elements.dot_Y2;
var centers = document.forms.centershape;
var x = centers.elements.x;
var y = centers.elements.y;

var lines = document.forms.lines;
var dot1 = lines.elements.dot;
var nor1 = lines.elements.nor;

//console.log("dooot cord "+ doot_X2);
let turnover = document.forms.turnover;
let xT = turnover.elements.x;
let yT = turnover.elements.y;
let dT = turnover.elements.d;

var center ={
  x:800,
  y:500
};

var sum = 0;
var min = 0;
var min_y = 0;
var flag = true;
var sum_flag = true;
var displa_flag = true;
var ssum = 0;
var turn ={
  x:0,
  y:0,
  d: 0
};

var arrPrev ={
  r: 1,
  a: 7
};
var newValue ={
  a:0
}
cx.beginPath();

//фигура
function start(){
center.y = center.y + +centers.y.value;
center.x = center.x + +centers.x.value;


turn.x = turn.x + +xT.value;
turn.y = turn.y + +yT.value;
turn.d += (+dT.value)*Math.PI/180;

cx.setTransform(1, 0, 0, 1, 0, 0);
cx.clearRect(0, 0, document.querySelector("canvas").width, document.querySelector("canvas").height);

start2();

//расчет
//var L = (+a1.value/2 * Math.PI *( Math.sqrt(1 + Math.PI * Math.PI)) + Math.log(Math.PI + (  Math.sqrt(1 + Math.PI * Math.PI)) ));
document.getElementById("L").innerHTML = 'Arc length: '+ (ssum*2).toFixed(4);
sum = 0;
}

function point() {
  cx.beginPath();
  cx.arc(turn.x,turn.y,7,0, 2 * Math.PI);
  cx.fill();
}


function Draw (a,b){
  let r;
      a1.value = a;
      let steps = Math.abs(a - b);
      if(a > b){ r = -1}
      else{r = 1}
      a1.value = +a1.value - r;
      var it = 0, max = steps, delay = -100, run;
              run = function(){
                a1.value = +a1.value + r;
                start2();
                 if(it++ < max){
                    setTimeout(run, delay);
                 }
              }
              run();

}




function Create2DArray(rows) {
  var arr = [];

  for (var i=0;i<rows;i++) {
     arr[i] = [];
  }

  return arr;
}

function start2(){

cx.setTransform(1, 0, 0, 1, 0, 0);
cx.clearRect(0, 0, document.querySelector("canvas").width, document.querySelector("canvas").height);

  //клетки
cx.strokeStyle = "black";
  cx.lineWidth = 1;
  cx.beginPath();

  for (let y = 50; y < 1500; y += 50) {


      cx.moveTo(0,y);

      cx.lineTo(1500,y);
      cx.font = "13px normal";
      cx.fillStyle = "black";
      cx.fillText(y + "px", 10, y);
    }
  cx.stroke();
  cx.beginPath();
  for (let x = 50; x < 1500; x += 50) {


      cx.moveTo(x,0);

       cx.lineTo(x,1500);
       cx.font = "13px normal";
       cx.fillStyle = "black";
       cx.fillText(x + "px", x, 15);
     }
  cx.stroke();
  //начало координат
  cx.font = "25px normal";
  cx.fillStyle = "black";
  cx.fillText("О", 5, 20);
  cx.font = "20px normal";
  cx.fillText("x", 30, 15);
  cx.fillText("y", 5, 35);
   cx.lineWidth = 3;
  cx.strokeStyle = "black";


  cx.beginPath();
    cx.moveTo(0,1);

    cx.lineTo(1500,1);
  cx.stroke();
  cx.beginPath();

    cx.moveTo(1,0);

    cx.lineTo(1,1500);
  cx.stroke();


cx.lineWidth = 3;
cx.strokeStyle = "black";

cx.beginPath();
  cx.moveTo(0, 500);
  cx.lineTo(1500, 500);
cx.stroke();
cx.beginPath();
  cx.moveTo(800, 0);
  cx.lineTo(800, 1500);
cx.stroke();
cx.closePath();







pAS();
sum_flag = false;
cx.stroke();
if(displa_flag){
  if((+doot_coord.value)==170 || (+doot_coord.value)==169 || (+doot_coord.value)==171){
    dot_170();
  }
  if((+doot_coord.value)==90 || (+doot_coord.value)==91 || (+doot_coord.value)==89){
    dot_89();
  }
  if((+doot_coord.value)==130 || (+doot_coord.value)==131 || (+doot_coord.value)==129){
    dot_130();
  }
  if((+doot_coord.value)==45 || (+doot_coord.value)==46 || (+doot_coord.value)==44){
    dot_45();
  }
  if((+doot_coord.value)==265 || (+doot_coord.value)==264 || (+doot_coord.value)==266){
    dot_265();
  }
  if((+doot_coord.value)==225 || (+doot_coord.value)==224 || (+doot_coord.value)==226){
    dot_225();
  }
  if((+doot_coord.value)>=267){
    alert("Error!");
  }
}
ssum = 1797.93115;
}

function pAS() {
  cx.strokeStyle = "blue";
  let lps = Number(+a1.value);
  // if(lps == 1) 
  // {
  //   ssum = 213.1471;
  //   min = -66.0461;
  //   min_y = -20.3152;
  // }
  // if(lps == 2) 
  // {
  //   ssum = 809.0725; 
  //   min = -189.836092;
  //   min_y = -18.131; 
  // }
  if(lps == 3) 
  {
    ssum = 1797.93115;
    min = -315.07293; 
    min_y = -16.4101;
  }
  // if(lps == 4) {
  //   ssum = 3180.56125;
  //   min =-440.5737;
  //   min_y = -21.539;
  // } 
  // if(lps == 5) {
  //   ssum = 4957.22725;
  //   min =-566.10920;
  //   min_y = -25.869;
  // } 
  // if(lps>5){
  //   alert("Too hight loops!")
  //   displa_flag = false;
  //   ssum =0;
  //   return 0;
  // }
  //console.log(lps);
  let a=.0,ai=0.04,r=.3,ri=0.8,as=lps*2*Math.PI,n=as/ai;
  //var masDots = Create2DArray(360);
  let x=y=0, x1=y1=0, mas;
  let x2=y2=0;
  let arra = [];
  cx.beginPath();
  cx.translate(center.x,center.y);
  for (var i=1; i<n; i++) {
    x=r*Math.cos(a), y=r*Math.sin(a);
    mas = Rotate(x,y);
    x1 = mas[0]; y1 = mas[1];
    arra[i] = x1;
      cx.lineTo(x1,y1);
    // console.log(`x[${i}]: `+x1);
    // console.log(`y[${i}]: `+y1);
    r+=ri; a+=ai;
    x2 = r*Math.cos(a);
    y2 = r*Math.sin(a);
   
    //sum+=Math.pow(x2-mas[0],2)+Math.pow(y2-mas[1],2);
   
    sum+=Math.sqrt(Math.pow(x2-mas[0],2)+Math.pow(y2-mas[1],2));
   console.log(`sum[${i}]: `+sum);
  //  if(+doot_coord.value == parseInt(sum,10))
  //  {
  //   min =x1;
  //   min_y = y1;
  //  }
  }
 //console.log(min+ "----- "+min_y);
  arra.sort((function compareNumeric(a, b) {
    if (a > b) return 1;
    if (a == b) return 0;
    if (a < b) return -1;
  }));
// for(let i= 0; i< arra.length; i++){
//   console.log(arra[i]);
// }

//min = arra[0];

  cx.stroke();
  cx.setTransform(1, 0, 0, 1, 0, 0);
}

function Rotate(a,b){
  var m0 = [
    [1,0,0],
    [0,1,0],
    [-turn.x ,-turn.y ,1]
  ];
  var N = [
    [Math.cos( turn.d ),Math.sin(  turn.d ),0],
    [-Math.sin(  turn.d ),Math.cos( turn.d ),0],
    [0,0,1]
  ];
  var m9 = [
    [1,0,0],
    [0,1,0],
    [turn.x ,turn.y ,1]
  ];
  var v1 = [a,b,1];
  var v2 = multiplyVector(v1,m0);
  var v3 = multiplyVector(v2,N);
  var v4 = multiplyVector(v3,m9);
  a = v4[0];
  b = v4[1];
  return [a,b];

}


function multiplyVector(v,m) {
  var result =[];
  m = TransMatrix(m);
    for (let i = 0; i < m.length; i++)
    {
        var sum = 0;
        for (let j = 0; j < m.length; j++)
        {
          sum += m[i][j] * v[j];
        }
        result[i] = sum;
    }
    return result;
}

function TransMatrix(A)
{
    var m = A.length, n = A[0].length, AT = [];
    for (var i = 0; i < n; i++)
     { AT[ i ] = [];
       for (var j = 0; j < m; j++) AT[ i ][j] = A[j][ i ];
     }
    return AT;
}

function dot_170(){
  let mas,x1,y1;
  cx.translate(center.x,center.y);
  //дотична
  
  cx.strokeStyle = "red";
  cx.beginPath();
  let X1,X2,Y1,Y2,X,Y;
  var a = +a1.value;
  var dot = +dot1.value * Math.PI / 180;
  var dot2 = (+dot1.value +1) * Math.PI / 180;
  X1=a*Math.cos(dot)/dot;
  Y1=a*Math.sin(dot)/dot;
  X2=a*Math.cos(dot2)/(dot2);
  Y2=a*Math.sin(dot2)/(dot2);
  Y = (+doot_Y1.value);
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X =min;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1,y1);
  Y = (+doot_Y2.value);
  X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X =min;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  //нормаль
  cx.strokeStyle = "green";
  cx.beginPath();
  var a = +a1.value;
  var dot = +dot1.value * Math.PI / 180;
  var dot2 = (+dot1.value +1) * Math.PI / 180;
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x + a*Math.cos(dot)/dot,center.y + a*Math.sin(dot)/dot);
  cx.rotate(90*Math.PI/180);
  cx.beginPath();
  X1=a*Math.cos(dot)/dot;
  Y1=a*Math.sin(dot)/dot;
  X2=a*Math.cos(dot2)/(dot2);
  Y2=a*Math.sin(dot2)/(dot2);
  Y = -2000;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X =min_y;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1 - 2* X1,y1 - 2* Y1);
  Y = 2000;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X = min_y;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x,center.y);

  cx.lineWidth = 3;
}
function dot_89(){
  let mas,x1,y1;
  cx.translate(center.x,center.y);
  //дотична
  cx.strokeStyle = "red";
  cx.beginPath();
  Y = -346;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1,y1);
  Y = -346;
  X =2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  //нормаль
  cx.strokeStyle = "green";
  cx.beginPath();
  var a = +a1.value;
  var dot = +dot1.value * Math.PI / 180;
  var dot2 = (+dot1.value +1) * Math.PI / 180;
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x + a*Math.cos(dot)/dot,center.y + a*Math.sin(dot)/dot);
  cx.rotate(90*Math.PI/180);
  cx.beginPath();
  X1=a*Math.cos(dot)/dot;
  Y1=a*Math.sin(dot)/dot;
  X2=a*Math.cos(dot2)/(dot2);
  Y2=a*Math.sin(dot2)/(dot2);
  Y = -25;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1 - 2* X1,y1 - 2* Y1);
  Y = -25;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X = 2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x,center.y);
  cx.lineWidth = 3;
}
function dot_130(){
  let mas,x1,y1;
  cx.translate(center.x,center.y);
  //дотична
  cx.strokeStyle = "red";
  cx.beginPath();
  Y = 900;//900
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1,y1);
  Y = -1700;//-1700
  X =2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  //нормаль
  cx.strokeStyle = "green";
  cx.beginPath();
  var a = +a1.value;
  var dot = +dot1.value * Math.PI / 180;
  var dot2 = (+dot1.value +1) * Math.PI / 180;
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x + a*Math.cos(dot)/dot,center.y + a*Math.sin(dot)/dot);
  cx.rotate(90*Math.PI/180);
  cx.beginPath();
  X1=a*Math.cos(dot)/dot;
  Y1=a*Math.sin(dot)/dot;
  X2=a*Math.cos(dot2)/(dot2);
  Y2=a*Math.sin(dot2)/(dot2);
  Y = 1280;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1 - 2* X1,y1 - 2* Y1);
  Y = -1340;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X = 2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x,center.y);
  cx.lineWidth = 3;
}
function dot_45(){
  let mas,x1,y1;
  cx.translate(center.x,center.y);
  //дотична
  cx.strokeStyle = "red";
  cx.beginPath();
  Y = -1835;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1,y1);
  Y = 960;
  X =2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  //нормаль
  cx.strokeStyle = "green";
  cx.beginPath();
  var a = +a1.value;
  var dot = +dot1.value * Math.PI / 180;
  var dot2 = (+dot1.value +1) * Math.PI / 180;
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x + a*Math.cos(dot)/dot,center.y + a*Math.sin(dot)/dot);
  cx.rotate(90*Math.PI/180);
  cx.beginPath();
  X1=a*Math.cos(dot)/dot;
  Y1=a*Math.sin(dot)/dot;
  X2=a*Math.cos(dot2)/(dot2);
  Y2=a*Math.sin(dot2)/(dot2);
  Y = -1450;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1 - 2* X1,y1 - 2* Y1);
  Y = 1380;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X = 2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x,center.y);
  cx.lineWidth = 3;
}
function dot_265(){
  let mas,x1,y1;
  cx.translate(center.x,center.y);
  //дотична
  cx.strokeStyle = "red";
  cx.beginPath();
  Y = 284;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1,y1);
  Y = 284;
  X =2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  //нормаль
  cx.strokeStyle = "green";
  cx.beginPath();
  var a = +a1.value;
  var dot = +dot1.value * Math.PI / 180;
  var dot2 = (+dot1.value +1) * Math.PI / 180;
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x + a*Math.cos(dot)/dot,center.y + a*Math.sin(dot)/dot);
  cx.rotate(90*Math.PI/180);
  cx.beginPath();
  X1=a*Math.cos(dot)/dot;
  Y1=a*Math.sin(dot)/dot;
  X2=a*Math.cos(dot2)/(dot2);
  Y2=a*Math.sin(dot2)/(dot2);
  Y = 25;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1 - 2* X1,y1 - 2* Y1);
  Y = 25;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X = 2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x,center.y);
  cx.lineWidth = 3;
}
function dot_225(){
  let mas,x1,y1;
  cx.translate(center.x,center.y);
  //дотична
  cx.strokeStyle = "red";
  cx.beginPath();
  Y = -960;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1,y1);
  Y = 1665;
  X =2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  //нормаль
  cx.strokeStyle = "green";
  cx.beginPath();
  var a = +a1.value;
  var dot = +dot1.value * Math.PI / 180;
  var dot2 = (+dot1.value +1) * Math.PI / 180;
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x + a*Math.cos(dot)/dot,center.y + a*Math.sin(dot)/dot);
  cx.rotate(90*Math.PI/180);
  cx.beginPath();
  X1=a*Math.cos(dot)/dot;
  Y1=a*Math.sin(dot)/dot;
  X2=a*Math.cos(dot2)/(dot2);
  Y2=a*Math.sin(dot2)/(dot2);
  Y = -1380;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X =-2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.moveTo(x1 - 2* X1,y1 - 2* Y1);
  Y = 1450;
  //X = (Y-Y1)/(Y2-Y1)*(X2-X1)+X1;
  X = 2000;
  mas =Rotate(X,Y);
  x1 = mas[0]; y1 = mas[1];
  cx.lineTo(x1,y1);
  cx.stroke();
  cx.closePath();
  cx.setTransform(1, 0, 0, 1, 0, 0);
  cx.translate(center.x,center.y);
  cx.lineWidth = 3;
}