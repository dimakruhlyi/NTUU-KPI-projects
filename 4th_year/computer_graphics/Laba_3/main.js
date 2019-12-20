
canvas = document.querySelector("canvas");
ctx = canvas.getContext("2d");

var dot = [];
var drag = false;

document.body.appendChild(canvas);
  dot.push({x:1000,y:12,dragit:false});
  dot.push({x:1051,y:10,dragit:false});
  dot.push({x:1066,y:60,dragit:false});
  dot.push({x:1064,y:109,dragit:false});
  dot.push({x:1015,y:209,dragit:false});
  dot.push({x:1016.,y:263,dragit:false});
  dot.push({x:974,y:306,dragit:false});
  dot.push({x:1013,y:332,dragit:false});
  dot.push({x:976,y:355,dragit:false});
  dot.push({x:973,y:396,dragit:false});
  dot.push({x:953,y:448,dragit:false});
  dot.push({x:896,y:478,dragit:false});
  dot.push({x:848,y:502,dragit:false});
  dot.push({x:788,y:523,dragit:false});
  dot.push({x:796,y:533,dragit:false});
  dot.push({x:821,y:607,dragit:false});
  dot.push({x:826,y:641,dragit:false});
  dot.push({x:829,y:780,dragit:false});
  dot.push({x:793,y:772,dragit:false});
  dot.push({x:784,y:725,dragit:false});
  dot.push({x:781,y:682,dragit:false});
  dot.push({x:787,y:623,dragit:false});
  dot.push({x:724,y:545,dragit:false});
  dot.push({x:741,y:640,dragit:false});
  dot.push({x:724,y:692,dragit:false});
  dot.push({x:695,y:794,dragit:false});
  dot.push({x:662,y:754,dragit:false});
  dot.push({x:681,y:689,dragit:false});
  dot.push({x:679,y:576,dragit:false});
  dot.push({x:668,y:496,dragit:false});
  dot.push({x:639,y:440,dragit:false});
  dot.push({x:609,y:443,dragit:false});
  dot.push({x:607,y:373,dragit:false});
  dot.push({x:569,y:333,dragit:false});
  dot.push({x:621,y:311,dragit:false});
  dot.push({x:637,y:261,dragit:false});
  dot.push({x:667,y:248,dragit:false});
  dot.push({x:681,y:224,dragit:false});
  dot.push({x:668,y:184,dragit:false});
  dot.push({x:659,y:62,dragit:false});
  dot.push({x:710,y:177,dragit:false});
  dot.push({x:735,y:160,dragit:false});
  dot.push({x:744,y:176,dragit:false});
  dot.push({x:767,y:36,dragit:false});
  dot.push({x:791,y:175,dragit:false});
  dot.push({x:850,y:164,dragit:false});
  dot.push({x:900,y:200,dragit:false});
  dot.push({x:1050,y:125,dragit:false});
  //dot.push({x:560,y:450,dragit:false});
  dot.push(dot[0]);



function start() {

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




  for(let i = 0; i < dot.length;i++){
    draw(dot[i].x,dot[i].y,i);
  }

  for(let i = 0; i < dot.length-1;i = i + 2){
    triangle(dot[i].x,dot[i].y,dot[i+1].x,dot[i+1].y,dot[i+2].x,dot[i+2].y);
  }
  for(let i = 0; i < dot.length-1;i = i + 2){
    bezier(dot[i].x,dot[i].y,dot[i+1].x,dot[i+1].y,dot[i+2].x,dot[i+2].y);
  }

  canvas.onmousedown = Down;
  canvas.onmouseup = Up;

}

function bezier(x0,y0,x1,y1,x2,y2){
  var x,y;
  ctx.beginPath();
  ctx.lineWidth = 4;
 ctx.strokeStyle = "black";
  for(t =0;t <= 1; t = t +0.01){
    x= (1 - t)*(1 - t)*x0 + 2*t*(1-t)*x1 + t*t*x2;
    y= (1 - t)*(1 - t)*y0 + 2*t*(1-t)*y1 + t*t*y2;
    ctx.lineTo(x,y);
  }
  ctx.stroke();

}

function draw(x,y,i){
  if(i%2){
    ctx.fillStyle = "blue";
  } else {ctx.fillStyle = "black";}
  ctx.beginPath();
  ctx.arc(x,y,10,0,2*Math.PI);
  ctx.fill();
}

function Move(e) {
  if(drag) {

    var mx=parseInt(e.clientX);
    var my=parseInt(e.clientY);

    for(let i=0;i<dot.length;i++){
      if(dot[i].dragit==true){
          dot[i].x = mx;
          dot[i].y = my;
        }

      }
        start();
  }

}

function Down(e){
  console.clear();
  console.log(e.clientX,e.clientY);
   for(let i=0;i<dot.length;i++){
      if(e.clientX <= dot[i].x+15 && e.clientY <= dot[i].y+15 && e.clientX >= dot[i].x-15 && e.clientY >= dot[i].y-15){
        drag = true;
        dot[i].dragit=true;
        canvas.onmousemove = Move;
      }
  }
}
function Up() {
  drag = false;
  for(var i=0;i<dot.length;i++){
    dot[i].dragit=false;
  }
}

function triangle(x0,y0,x1,y1,x2,y2) {
  ctx.lineWidth = 2;
  ctx.strokeStyle = 'rgba(200, 0, 0, 0.35)';
  ctx.beginPath();
  ctx.moveTo(x0,y0);
  ctx.lineTo(x1,y1);
  ctx.lineTo(x2,y2);
  ctx.stroke();
}
start();
