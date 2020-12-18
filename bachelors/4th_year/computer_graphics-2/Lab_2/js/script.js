
canvas = document.querySelector("canvas");
ctx = canvas.getContext("2d");
let form = document.forms.f;
var angleX,angleY,angleZ;

const dot3 = [];
var dot2 = [];

document.body.appendChild(canvas);
dot3.push({x:350,y:400,z:50,lineId:0});
dot3.push({x:425,y:400,z:50,lineId:1});
dot3.push({x:425,y:100,z:50,lineId:2});
dot3.push({x:350,y:100,z:50,lineId:3});
dot3.push({x:350,y:100,z:50,lineId:4});

dot3.push({x:350,y:400,z:0,lineId:0});
dot3.push({x:425,y:400,z:0,lineId:1});
dot3.push({x:425,y:100,z:0,lineId:2});
dot3.push({x:350,y:100,z:0,lineId:3});
dot3.push({x:350,y:100,z:0,lineId:4});




dot3.push({x:600,y:100,z:10,lineId:5});
dot3.push({x:600,y:70,z:10,lineId:6});
dot3.push({x:350,y:90,z:10,lineId:7});
dot3.push({x:350,y:100,z:10,lineId:8});

dot3.push({x:375,y:100,z:40,lineId:10});

dot3.push({x:600,y:100,z:40,lineId:5});
dot3.push({x:600,y:70,z:40,lineId:6});
dot3.push({x:350,y:90,z:40,lineId:7});
dot3.push({x:350,y:100,z:40,lineId:8});





start();

function start() {
  ctx.setTransform(1, 0, 0, 1, 0, 0);
  ctx.clearRect(0, 0, document.querySelector("canvas").width, document.querySelector("canvas").height);
  angleX =  form.elements.x.value * Math.PI/180;
  angleY =  form.elements.y.value * Math.PI/180;
  angleZ =  form.elements.z.value * Math.PI/180;
  form.elements.wx.value = form.elements.x.value;
  form.elements.wy.value = form.elements.y.value;
  form.elements.wz.value = form.elements.z.value;
    canv();
    projection(dot3);
    draw(dot2);

}

function draw(dot){
  ctx.strokeStyle = "black";
  
  ctx.beginPath();
  ctx.moveTo(dot[0].x,dot[0].y);
  //console.log(dot[0].x,dot[0].y);
    for(let i = 1; i < 10;i++){
      if(dot[i].lineId == 0){
        ctx.closePath();
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(dot[i].x,dot[i].y);
      }
      else  {ctx.lineTo(dot[i].x,dot[i].y);}
    }
    ctx.closePath();
    ctx.stroke();
    
    ctx.beginPath();
    ctx.moveTo(dot[10].x,dot[10].y);
    for(let i = 10; i < dot.length;i++){
      ctx.lineTo(dot[i].x,dot[i].y);
    }
    ctx.moveTo(dot[10].x,dot[10].y);
    ctx.lineTo(dot[13].x,dot[13].y);
    ctx.stroke();
    ctx.closePath();
    
    for(let i = 0; i < dot.length;i++){
      for(let j = 0; j < dot.length;j++){
        if(j!=i){
          if(dot[i].lineId == dot[j].lineId){
            ctx.beginPath();
            ctx.moveTo(dot[i].x,dot[i].y);
            ctx.lineTo(dot[j].x,dot[j].y);
            ctx.stroke();
            ctx.closePath();
          }
        }
      }
    }
    dot2 = [];
}

function projection(arr){

  var m0 =[
    [1,0,0,0],
    [0,1,0,0],
    [0,0,1,0],
    [-450,-250,0,1]
  ];
  var m9 =[
    [1,0,0,0],
    [0,1,0,0],
    [0,0,1,0],
    [450,250,0,1]
  ];
  var RotateX =[
    [1,0,0,0],
    [0,Math.cos( angleX ),Math.sin( angleX ),0],
    [0,-Math.sin( angleX ),Math.cos( angleX ),0],
    [0,0,0,1]
  ];
  var RotateY =[
    [Math.cos( angleY ),0,-Math.sin( angleY ),0],
    [0,1,0,0],
    [Math.sin( angleY ),0,Math.cos( angleY ),0],
    [0,0,0,1]
  ];
  var RotateZ =[
    [Math.cos( angleZ ),Math.sin( angleZ ),0,0],
    [-Math.sin( angleZ ),Math.cos( angleZ ),0,0],
    [0,0,0,0],
    [0,0,0,1]
  ];
  var Mz =[
    [1,0,0,0],
    [0,1,0,0],
    [0,0,0,0],
    [0,0,0,1]
  ];

  for(let i = 0; i < arr.length;i++){
    var vec0 = [arr[i].x,arr[i].y,arr[i].z,1];
    var v2 = multiplyVector(vec0,m0);
    var vx = multiplyVector(v2,RotateX);
    var vy = multiplyVector(vx,RotateY);
    var vz = multiplyVector(vy,RotateZ);
    var v4 = multiplyVector(vz,m9);
    var vec = multiplyVector(v4,Mz);
    dot2.push({x:vec[0],y:vec[1],lineId:arr[i].lineId});
  }
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

function canv(){
  ctx.setTransform(1, 0, 0, 1, 0, 0);
  ctx.clearRect(0, 0, document.querySelector("canvas").width, document.querySelector("canvas").height);
  ctx.fillStyle = "#fff";
    ctx.fillRect(0, 0, 1700, 1700);
    //клетки
  ctx.strokeStyle = "black";
    ctx.lineWidth = 1;
    ctx.beginPath();

    for (let y = 50; y < 1700; y += 50) {


        ctx.moveTo(0,y);

        ctx.lineTo(1700,y);
        ctx.font = "13px normal";
        ctx.fillStyle = "black";
        ctx.fillText(y + "px", 10, y);
      }
    ctx.stroke();
    ctx.beginPath();
    for (let x = 50; x < 1700; x += 50) {


        ctx.moveTo(x,0);

         ctx.lineTo(x,1700);
         ctx.font = "13px normal";
         ctx.fillStyle = "black";
         ctx.fillText(x + "px", x, 15);
       }
    ctx.stroke();
    //начало координат
    ctx.font = "25px normal";
    ctx.fillStyle = "black";
    ctx.fillText("О", 5, 20);
    ctx.font = "20px normal";
    ctx.fillText("x", 30, 15);
    ctx.fillText("y", 5, 35);
    ctx.lineWidth = 3;
    ctx.strokeStyle = "black";


    ctx.beginPath();
      ctx.moveTo(0,1);

      ctx.lineTo(1700,1);
    ctx.stroke();
    ctx.beginPath();

      ctx.moveTo(1,0);

      ctx.lineTo(1,1700);
    ctx.stroke();

}
