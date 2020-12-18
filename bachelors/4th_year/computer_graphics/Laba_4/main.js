
canvas = document.querySelector("canvas");
ctx = canvas.getContext("2d");

var dot = [];
var drag = false;
var delta= {
  x:0,
  y:0
};
document.body.appendChild(canvas);
dot.push({x:970,y:313,dragit:false});


dot.push({x:1022,y:353,dragit:false});
dot.push({x:1053,y:409,dragit:false});
dot.push({x:1083,y:463,dragit:false});




dot.push({x:1100,y:493,dragit:false});

dot.push({x:1111,y:518,dragit:false});
dot.push({x:1113,y:548,dragit:false});
dot.push({x:1121,y:593,dragit:false});
dot.push({x:1105,y:690,dragit:false});
dot.push({x:1260,y:565,dragit:false});
dot.push({x:1260,y:375,dragit:false});
dot.push({x:1280,y:320,dragit:false});
dot.push({x:1310,y:365,dragit:false});
dot.push({x:1350,y:610,dragit:false});
dot.push({x:1100,y:775,dragit:false});
dot.push({x:1015,y:775,dragit:false});
dot.push({x:900,y:775,dragit:false});
dot.push({x:830,y:760,dragit:false});
dot.push({x:900,y:730,dragit:false});
dot.push({x:900,y:675,dragit:false});
dot.push({x:850,y:675,dragit:false});
dot.push({x:800,y:700,dragit:false});
dot.push({x:793,y:772,dragit:false});
dot.push({x:725,y:800,dragit:false});
dot.push({x:771,y:682,dragit:false});
dot.push({x:795,y:650,dragit:false});
dot.push({x:800,y:600,dragit:false});
dot.push({x:750,y:650,dragit:false});
dot.push({x:725,y:760,dragit:false});
dot.push({x:690,y:790,dragit:false});
dot.push({x:675,y:760,dragit:false});
dot.push({x:685,y:665,dragit:false});
dot.push({x:720,y:580,dragit:false});


dot.push({x:710,y:550,dragit:false});
dot.push({x:700,y:500,dragit:false});
dot.push({x:690,y:475,dragit:false});
dot.push({x:688,y:440,dragit:false});
dot.push({x:685,y:415,dragit:false});
dot.push({x:690,y:360,dragit:false});
dot.push({x:725,y:340,dragit:false});
dot.push({x:690,y:290,dragit:false});
dot.push({x:640,y:255,dragit:false});
dot.push({x:668,y:184,dragit:false});
dot.push({x:659,y:62,dragit:false});
dot.push({x:710,y:177,dragit:false});
dot.push({x:735,y:160,dragit:false});
dot.push({x:744,y:176,dragit:false});
dot.push({x:767,y:36,dragit:false});
dot.push({x:791,y:175,dragit:false});
dot.push({x:835,y:235,dragit:false});
dot.push({x:820,y:245,dragit:false});
dot.push({x:907,y:272,dragit:false});
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

  for(let i = 1; i < 10;i++){
        choose(dot[i - 1].x,dot[i - 1].y,dot[i].x,dot[i].y,dot[i+1].x,dot[i+1].y,i);
  }

  canvas.onmousedown = Down;
  canvas.onmouseup = Up;

}

function choose(x0,y0,x1,y1,x2,y2,i){
  if(i == 2 ){
    ctx.strokeStyle = "red";
    ctx.beginPath();
    ctx.arc(x0,y0,20,0,2*Math.PI);
    ctx.stroke();
    ctx.beginPath();
    ctx.arc(x1,y1,20,0,2*Math.PI);
    ctx.stroke();
    ctx.beginPath();
    ctx.arc(x2,y2,20,0,2*Math.PI);
    ctx.stroke();
  }
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
          delta.x = dot[i].x;
          delta.y = dot[i].y;

          dot[i].x = mx;
          dot[i].y = my;

          delta.x -= dot[i].x;
          delta.y -= dot[i].y;
          last(i,mx,my,delta);
        }

      }
        start();
  }

}

function last (i,mx,my){

  var alpha1 = Math.sqrt( (dot[1+1].x - dot[1].x)*(dot[1+1].x - dot[1].x) + (dot[1+1].y - dot[1].y)*(dot[1+1].y - dot[1].y)  );
  var alpha2 = Math.sqrt( (dot[1+1].x - dot[1+2].x)*(dot[1+1].x - dot[1+2].x) + (dot[1+1].y - dot[1+2].y)*(dot[1+1].y - dot[1+2].y)  );


  if(i == 2 )
  {
    dot[i-1].x -= delta.x;
    dot[i-1].y -= delta.y;

    dot[i+1].x -= delta.x;
    dot[i+1].y -= delta.y;
  }
    if(i == 1 ){

      dot[i+2].x = dot[i+1].x + alpha2/alpha1 * (dot[i+1].x -dot[i].x);
      dot[i+2].y = dot[i+1].y + alpha2/alpha1 * (dot[i+1].y -dot[i].y);
        // dot[i+2].x =  (dot[i+1].x - alpha2/alpha1 * (dot[i+1].x - dot[i].x)) ;
        // dot[i+2].y = (dot[i+1].y - alpha2/alpha1 * (dot[i+1].y - dot[i].y)) ;

    }
    if(i == 3 ){
      //  var alpha1 = Math.sqrt( (dot[i].x - dot[i-1].x)*(dot[i].x - dot[i-1].x) + (dot[i].y - dot[i-1].y)*(dot[i].y - dot[i-1].y)  );
      //  var alpha2 = Math.sqrt( (dot[i-1].x - dot[i-2].x)*(dot[i-1].x - dot[i-2].x) + (dot[i-1].y - dot[i-2].y)*(dot[i-1].y - dot[i-2].y)  );



      dot[i-2].x = dot[i-1].x + alpha1/alpha2 * (dot[i-1].x -dot[i].x);
      dot[i-2].y = dot[i-1].y + alpha1/alpha2 * (dot[i-1].y -dot[i].y);
    }
}

function Down(e){

   for(let i=0;i<dot.length;i++){
      if(e.clientX <= dot[i].x+15 && e.clientY <= dot[i].y+15 && e.clientX >= dot[i].x-15 && e.clientY >= dot[i].y-15){
        drag = true;
        dot[i].dragit=true;
        console.clear();
        console.log(dot[i].x,dot[i].y, " i = " + i);
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
