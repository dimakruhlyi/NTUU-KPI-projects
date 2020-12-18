canvas = document.querySelector("canvas");
ctx = canvas.getContext("2d");
var form = document.forms.forma;
var angleX, angleY, angleZ, delU = 0, delV = 0, dot = [], dot3 = [], dotp = [], dot2 = [];

var center ={
  x: 600,
  y: 450,
  z: 200,
}

mainDrawing();

function mainDrawing() {
  ctx.setTransform(1, 0, 0, 1, 0, 0);
  ctx.clearRect(0, 0, document.querySelector("canvas").width, document.querySelector("canvas").height);
  angleX =  form.elements.x.value * Math.PI/180;
  angleY =  form.elements.y.value * Math.PI/180;
  angleZ =  form.elements.z.value * Math.PI/180;
  form.elements.wx.value = form.elements.x.value;
  form.elements.wy.value = form.elements.y.value;
  form.elements.wz.value = form.elements.z.value;
  delU = form.elements.u.value;
  delV = form.elements.v.value;
  center.x = +form.elements.c1.value;
  center.y = +form.elements.c2.value;
  center.z = +form.elements.c3.value;
    
    surface();
    picture();
    rules(dot3);
    draw(dot2);
}

function draw(dot){
    ctx.strokeStyle = "black";
    ctx.lineWidth = 1;
    var prevPath = dot[0].closePath;
    ctx.beginPath();
      for(let i = 0; i < 12000;i++){
            if( prevPath != dot[i].closePath){
              prevPath = dot[i].closePath;
              ctx.closePath();
              ctx.moveTo(dot[i].x,dot[i].y);
              i--;
            }else{
                ctx.lineTo(dot[i].x,dot[i].y);
            }
      }
      ctx.closePath();
      ctx.stroke();
      ctx.beginPath();
      ctx.lineWidth = 5;
      ctx.strokeStyle = "darkred";
      for(let i = 14400; i < dot.length;i++){
        ctx.lineTo(dot[i].x,dot[i].y);
      }
      ctx.closePath();
      ctx.stroke();
      dot2 = [];
  }

function  Radian(i){
  return  i * Math.PI / 180;
}

function surface(){
  dot3 = [];
  var a =  +form.elements.R.value;
  for(i = 0; i < 360; i += 6){
        for(j = 0; j < 360; j += 6){
            x = a * Math.cos( Radian(i)) * Math.cos( Radian(j));
            y = a* Math.sin( Radian(i)) * Math.cos( Radian(j));
            z = a * Math.sin( Radian(j))*0.5;
            dot3.push({x:x+center.x,y:y+center.y,z:z+center.z,closePath:i});
        }
    }
    for(j = 0; j < 360; j += 6){
        for(i = -180; i < 180; i += 2){
            x = a * Math.cos( Radian(i)) * Math.cos( Radian(j));
            y = a * Math.sin( Radian(i)) * Math.cos( Radian(j));
            z = a * Math.sin( Radian(j))*0.5;
            dot3.push({x:x+center.x,y:y+center.y,
                z:z+center.z,closePath:j});
        }
    }
}

function picture(){
  dot =[]; dotp =[]; 
  conturPicture();
  var a =  +form.elements.R.value;
  anglez =  form.elements.Nz.value * Math.PI/180;
  var RotateZ =[
    [Math.cos( anglez ),Math.sin( anglez ),0,],
    [-Math.sin( anglez ),Math.cos( anglez ),0,],
    [0,0,1]
  ];
  for(i = 0; i < dotp.length; i ++){
        pu = 595/3 * Math.PI/14 + delU*1;
        pv = 460/3 * Math.PI/14 + delV*1;

        x = a * Math.cos( Radian(pu)) * Math.cos( Radian(pv));
        y = a * Math.sin( Radian(pu)) * Math.cos( Radian(pv));

        pu = x;
        pv = y;
        var m0 =[
        [1,0,0],
        [0,1,0],
        [-pu,-pv,1]
        ];
        var m9 =[
        [1,0,0],
        [0,1,0],
        [pu,pv,1]
        ];
        u = dotp[i].x/3 * Math.PI/14 + delU*1;
        v = dotp[i].y/3 * Math.PI/14 + delV*1;
        x = a * Math.cos( Radian(u)) * Math.cos( Radian(v));
        y = a* Math.sin( Radian(u)) * Math.cos( Radian(v));
        z = a * Math.sin( Radian(v))*0.5;
        var v0 = [x,y,1];
        var v1 = multiplyVector(v0,m0);
        var vz = multiplyVector(v1,RotateZ);
        var vec = multiplyVector(vz,m9);
        dot3.push({x:vec[0]+center.x,y:vec[1]+center.y,z:vec[2]+center.z,
        closePath:"stroke"});
    }
}

function conturPicture(){
    dot.push({x:1012,y:555 });
    dot.push({x:1085,y:625 });
    dot.push({x:1100,y:675 });
    dot.push({x:1120,y:750 });
    dot.push({x:1105,y:890 });
    dot.push({x:1260,y:765 });
    dot.push({x:1260,y:575 });
    dot.push({x:1280,y:520 });
    dot.push({x:1310,y:565 });
    dot.push({x:1350,y:810 });
    dot.push({x:1100,y:975 });
    dot.push({x:1015,y:975 });
    dot.push({x:900,y:975 });
    dot.push({x:830,y:960 });
    dot.push({x:900,y:930 });
    dot.push({x:900,y:875 });
    dot.push({x:850,y:875 });
    dot.push({x:800,y:900 });
    dot.push({x:793,y:972 });
    dot.push({x:725,y:1000 });
    dot.push({x:771,y:882 });
    dot.push({x:795,y:850 });
    dot.push({x:800,y:800 });
    dot.push({x:750,y:850 });
    dot.push({x:725,y:960 });
    dot.push({x:690,y:990 });
    dot.push({x:675,y:960 });
    dot.push({x:685,y:865 });
    dot.push({x:720,y:780 });
    dot.push({x:710,y:750 });
    dot.push({x:700,y:700 });
    dot.push({x:690,y:675 });
    dot.push({x:688,y:640 });
    dot.push({x:685,y:615 });
    dot.push({x:690,y:560 });
    dot.push({x:725,y:540 });
    dot.push({x:690,y:490 });
    dot.push({x:640,y:455 });
    dot.push({x:668,y:384 });
    dot.push({x:659,y:262 });
    dot.push({x:710,y:377 });
    dot.push({x:735,y:360 });
    dot.push({x:744,y:376 });
    dot.push({x:767,y:236 });
    dot.push({x:791,y:375 });
    dot.push({x:835,y:435 });
    dot.push({x:820,y:445 });
    dot.push({x:950,y:475 });
    dot.push(dot[0]);
  for(let i = 0; i < dot.length-1;i = i + 2){
    bezie2Order(dot[i].x,dot[i].y,dot[i+1].x,dot[i+1].y,dot[i+2].x,dot[i+2].y);
  }
}

function bezie2Order(x0,y0,x1,y1,x2,y2){
  var x,y;
  for(t =0;t <= 1; t = t +0.01){
    x= (1 - t)*(1 - t)*x0 + 2*t*(1-t)*x1 + t*t*x2;
    y= (1 - t)*(1 - t)*y0 + 2*t*(1-t)*y1 + t*t*y2;
    dotp.push({x:x,y:y,stroke:true});
  }
}

function rules(arr){
  var m0 =[
    [1,0,0,0],
    [0,1,0,0],
    [0,0,1,0],
    [-center.x,-center.y,-center.z,1]
  ];
  var m9 =[
    [1,0,0,0],
    [0,1,0,0],
    [0,0,1,0],
    [center.x,center.y,center.z,1]
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
    dot2.push({x:vec[0],y:vec[1],closePath:arr[i].closePath});
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