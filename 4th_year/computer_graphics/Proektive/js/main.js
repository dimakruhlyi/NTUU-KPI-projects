var cx = document.querySelector("canvas").getContext("2d");

var startX, startY, startD;
let form = document.forms.f;
var a = form.elements.a;
var b = form.elements.b;
var c = form.elements.c;
var d = form.elements.d;

var centers = document.forms.centershape;
var x = centers.elements.x;
var y = centers.elements.y;

let turnover = document.forms.turnover;
let xT = turnover.elements.x;
let yT = turnover.elements.y;
let dT = turnover.elements.d;

let Afin = document.forms.Afin;
var Xx = Afin.elements.Xx;
var Yx = Afin.elements.Yx;

var Xy = Afin.elements.Xy;
var Yy = Afin.elements.Yy;

var X0 = Afin.elements.X0;
var Y0 = Afin.elements.Y0;

var W0 = Afin.elements.W0;
var Wx = Afin.elements.Wx;
var Wy = Afin.elements.Wy;

var center ={
  x: 725,
  y:380,
  d: 0
};

var turn ={
  x: 725,
  y:380,
  d: 0
};
const sizes = {
  leght_down_width: 200,
  inner_straight_height: 180,
  middle_straight_height: 200,
};

cx.beginPath();

//фигура
function start(){
center.y = center.y + +y.value;
center.x = center.x + +x.value;

turn.x = turn.x + +xT.value;
turn.y = turn.y + +yT.value;
turn.d = turn.d + +dT.value;

cx.setTransform(1, 0, 0, 1, 0, 0);
cx.clearRect(0, 0, document.querySelector("canvas").width, document.querySelector("canvas").height);

  cx.fillStyle = "#fff";
  cx.fillRect(0, 0, 1500, 1500);
  //клетки
  cx.lineWidth = 1;
  cx.beginPath();
  for (let y = 50; y < 1500; y += 50) {
    let mas,x1,y1,x2,y2;
    mas = Matrixcord(0,y);
    x1 = mas[0]; y1 = mas[1];
      cx.moveTo(x1, y1);
      mas = Matrixcord(1500,y);
      x2 = mas[0]; y2 = mas[1];
      cx.lineTo(x2, y2);
      cx.font = "13px normal";
      cx.fillStyle = "#000";
      cx.fillText(y + "px", 10, y);
    }
  cx.stroke();
  cx.beginPath();
  for (let x = 50; x < 1500; x += 50) {
    let mas,x1,y1,x2,y2;
    mas = Matrixcord(x,0);
    x1 = mas[0]; y1 = mas[1];
      cx.moveTo(x1, y1);
      mas = Matrixcord(x,1500);
      x2 = mas[0]; y2 = mas[1];
       cx.lineTo(x2, y2);
       cx.font = "13px normal";
       cx.fillStyle = "#000";
       cx.fillText(x + "px", x, 15);
     }
  cx.stroke();
  //начало координат
  cx.font = "25px normal";
  cx.fillStyle = "#000";
  cx.fillText("О", 5, 20);
  cx.font = "20px normal";
  cx.fillText("x", 30, 15);
  cx.fillText("y", 5, 35);
   cx.lineWidth = 3;
  cx.strokeStyle = "#000";
  cx.beginPath();
  let x3, y3;
  mas = Matrixcord(0,1);
  x3 = mas[0]; y3 = mas[1];
    cx.moveTo(x3, y3);
    mas = Matrixcord(1500,1);
  x3 = mas[0]; y3 = mas[1];
    cx.lineTo(x3, y3);
  cx.stroke();
  cx.beginPath();
  mas = Matrixcord(1,0);
  x3 = mas[0]; y3 = mas[1];
    cx.moveTo(x3, y3);
    mas = Matrixcord(1,1500);
  x3 = mas[0]; y3 = mas[1];
    cx.lineTo(x3, y3);
  cx.stroke();


cx.lineWidth = 3;
cx.strokeStyle = "black";

//point();



//квадрат внутри = a

RectInside();

//круги радиус кругов = b. растояние = c

Circles();

drawMainLines();
//внешняя фигура = d
//Hexagon();

}

function point() {
  let mas,x,y;
  mas = Matrix(turn.x,turn.y);
  x = mas[0]; y = mas[1];
  cx.beginPath();
  cx.arc(x,y,7,0, 2 * Math.PI);
  cx.fill();
}

function RectInside() {

  var num = {
    zer: 0,
    fft: a.value
  };

  cx.font = "25px normal";
  //var cor =  (a.value*Math.sqrt(2))/2;
  cx.beginPath();
  cx.lineWidth = 4;
  let mas,x,y;
  mas = Matrix(center.x,center.y+90);
  x = mas[0]; y = mas[1];
      cx.moveTo(x,y);

  mas = Matrix(center.x+50,center.y+140);
  x = mas[0]; y = mas[1];
      cx.lineTo(x,y);

  mas = Matrix(center.x,center.y+190);
  x = mas[0]; y = mas[1];
      cx.lineTo(x,y);

  mas = Matrix(center.x-50,center.y+140);
  x = mas[0]; y = mas[1];
      cx.lineTo(x,y);

  cx.closePath();
  cx.stroke();

}


function Circles() {
  var x,y;
  var mas;
  var side = (3/Math.sqrt(3)) * c.value;
  var nside = Math.sqrt( (side*side) - ( side*side )/4 );
  var  i, angle, x1, y1;
  var r = d.value;
 
  cx.beginPath();
  cx.lineWidth = 4;
  for(i = 0; i < 360; i += 0.1)
        {
              angle = i;
              x1 = r * Math.cos(angle * Math.PI / 180);
              y1 = r * Math.sin(angle * Math.PI / 180);
              mas = Matrix(center.x + x1-(125), (center.y + y1+ +150) -nside);
              x = mas[0]; y = mas[1];
              cx.lineTo(x, y);
        }
        cx.stroke();
        cx.closePath();




  cx.beginPath();
  cx.lineWidth = 4;
  for(i = 0; i < 360; i += 0.1)
        {
              angle = i;
              x1 = r * Math.cos(angle * Math.PI / 180);
              y1 = r * Math.sin(angle * Math.PI / 180);
              mas = Matrix(center.x + x1 +(125), (center.y + y1+ +150) -nside);
              x = mas[0]; y = mas[1];
              cx.lineTo(x, y);
        }
        cx.stroke();
        cx.closePath();

  cx.beginPath();
  cx.lineWidth = 4;
  for(i = 0; i < 180; i += 0.1)
  {
        angle = i;
        x1 = 50 * Math.cos(angle * Math.PI / 180);
        y1 = 50 * Math.sin(angle * Math.PI / 180);
        mas = Matrix(center.x + x1, center.y + y1+ +0);
        x = mas[0]; y = mas[1];
        cx.lineTo(x, y);
  }
  cx.stroke();
  cx.closePath();
      
}

function drawMainLines(){

    cx.font = "25px normal";
    let mas,x,y;
  // Horizontal down
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x-sizes.leght_down_width/2,center.y+220);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x+sizes.leght_down_width/2,center.y+220);
    x = mas[0]; y = mas[1];
    cx.lineTo(x,y);
    cx.closePath();
    cx.stroke();
  // Angle down
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x-sizes.leght_down_width/2,center.y+220);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x-200,center.y-30);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x+sizes.leght_down_width/2,center.y+220);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x+200,center.y-30);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  // Middle straight
   cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x+200,center.y-30);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x+200,center.y-30- sizes.middle_straight_height);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x-200,center.y-30);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x-200,center.y-30- sizes.middle_straight_height);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  // Inner straight
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x+50,center.y);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x+50,center.y-sizes.inner_straight_height);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x-50,center.y);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x-50,center.y-sizes.inner_straight_height);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  // Horizontal top
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x+200,center.y-30- sizes.middle_straight_height);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x+100,center.y-230);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x-200,center.y-30- sizes.middle_straight_height);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x-100,center.y-230);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  // Angle inner top

    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x+100,center.y-230);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x+50,center.y-sizes.inner_straight_height);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
  
    cx.beginPath();
    cx.lineWidth = 4;
    mas = Matrix(center.x-100,center.y-230);
    x = mas[0]; y = mas[1];
    cx.moveTo(x,y);
    mas = Matrix(center.x-50,center.y-sizes.inner_straight_height);
    x = mas[0]; y = mas[1];
    cx.lineTo(x, y);
    cx.closePath();
    cx.stroke();
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
  
  function multiplyMatrices(m1, m2) {
      var result = [];
      for (var i = 0; i < m1.length; i++) {
          result[i] = [];
          for (var j = 0; j < m2[0].length; j++) {
              var sum = 0;
              for (var k = 0; k < m1[0].length; k++) {
                  sum += m1[i][k] * m2[k][j];
              }
              result[i][j] = sum;
          }
      }
      return result;
  }
  
  function Matrix(a,b){
  
    var turnover = Object.values(turn);
  
    turnX = turnover[0];
    turnY = turnover[1];
    turnD = turnover[2];
    var ancle = turnD*Math.PI/180;
  
  var WA =[
    [Xx.value * Wx.value, Yx.value * Wx.value, Wx.value],
    [Xy.value * Wy.value, Yy.value * Wy.value, Wy.value],
    [X0.value * W0.value, Y0.value * W0.value, W0.value]
  ];
  
  var TA = [
    [Xx.value/50,Yx.value/50,0],
    [Xy.value/50,Yy.value/50,0],
    [X0.value/50,Y0.value/50,1]
  ];
  
  
    var m0 = [
      [1,0,0],
      [0,1,0],
      [-turnX ,-turnY ,1]
    ];
    var N = [
      [Math.cos( ancle ),Math.sin( ancle ),0],
      [-Math.sin( ancle ),Math.cos( ancle ),0],
      [0,0,1]
    ];
    var m9 = [
      [1,0,0],
      [0,1,0],
      [turnX,turnY,1]
    ];
  
    var v1 = [a,b,1];
    var v2 = multiplyVector(v1,m0);
    var v3 = multiplyVector(v2,N);
    var v4 = multiplyVector(v3,m9);
    var v5 = multiplyVector(v4,WA);
    var znam = v5[2];
  //console.log(znam);
    a = v5[0]/znam;
    b = v5[1]/znam;
    return [a,b];
  
  }
  
  function Matrixcord(a,b){
    var WA =[
      [Xx.value* Wx.value, Yx.value * Wx.value, Wx.value],
      [Xy.value * Wy.value, Yy.value * Wy.value, Wy.value],
      [X0.value * W0.value, Y0.value * W0.value, W0.value]
    ];
    var TA = [
      [Xx.value/50,Yx.value/50,0],
      [Xy.value/50,Yy.value/50,0],
      [X0.value/50,Y0.value/50,1]
    ];
  
      var v = [a,b,1];
  
      var v4 = multiplyVector(v,WA);
      var znam = v4[2];
      a = v4[0]/znam;
      b = v4[1]/znam;
      return [a,b];
  }
  
  function Rotate(a,b,x,y,ancle){
    var m0 = [
      [1,0,0],
      [0,1,0],
      [-x ,-y ,1]
    ];
    var N = [
      [Math.cos( ancle ),Math.sin( ancle ),0],
      [-Math.sin( ancle ),Math.cos( ancle ),0],
      [0,0,1]
    ];
    var m9 = [
      [1,0,0],
      [0,1,0],
      [x,y,1]
    ];
    var v1 = [a,b,1];
    var v2 = multiplyVector(v1,m0);
    var v3 = multiplyVector(v2,N);
    var v4 = multiplyVector(v3,m9);
    a = v4[0];
    b = v4[1];
    return [a,b];
  
  }