const cx = document.querySelector("canvas").getContext("2d");

const sizes = {
  leght_down_width: 200,
  inner_straight_height: 180,
  middle_straight_height: 200,
};

draw_img.onclick = function() {
  sizes.leght_down_width = document.getElementById('size_A').value;
  sizes.inner_straight_height = document.getElementById('size_B').value;;
  sizes.middle_straight_height = document.getElementById('size_C').value;;
  firstCircle.radius = document.getElementById('size_Radius').value;
  secondCircle.radius = document.getElementById('size_Radius').value;

drawGrid();
//drawSymetricLines();
point();
if(firstCircle.radius > 75 || firstCircle.radius < 1){
  alert("Error! Circle radius is wrong!")
}
else{
  drawFirstCircle();
  drawSecondCircle();
}

drawHalfCircle();
drawRomb();
drawMainLines();
};

const firstCircle = {
  x: 850,
  y: 250,
  radius: 30,
  // drawSymetric(){
  //   cx.beginPath();
  //   cx.lineWidth = 2;
  //   cx.moveTo(firstCircle.x-firstCircle.radius-10,firstCircle.y);
  //   cx.lineTo(firstCircle.x+firstCircle.radius+10, firstCircle.y);
  //   cx.closePath();
  //   cx.stroke();

  //   cx.beginPath();
  //   cx.lineWidth = 2;
  //   cx.moveTo(firstCircle.x,firstCircle.y-firstCircle.radius-10);
  //   cx.lineTo(firstCircle.x, firstCircle.y+firstCircle.radius+10);
  //   cx.closePath();
  //   cx.stroke();
  // }
}
var center ={
  x: 725,
  y:380,
  d: 0
};
const secondCircle = {
  x: 600,
  y: 250,
  radius: 30,
  // drawSymetric(){
  //   cx.beginPath();
  //   cx.lineWidth = 2;
  //   cx.moveTo(secondCircle.x-secondCircle.radius-10,secondCircle.y);
  //   cx.lineTo(secondCircle.x+secondCircle.radius+10, secondCircle.y);
  //   cx.closePath();
  //   cx.stroke();

  //   cx.beginPath();
  //   cx.lineWidth = 2;
  //   cx.moveTo(secondCircle.x,secondCircle.y-secondCircle.radius-10);
  //   cx.lineTo(secondCircle.x, secondCircle.y+secondCircle.radius+10);
  //   cx.closePath();
  //   cx.stroke();
  // }
}
const halfCircle = {
  x: 725,
  y: 380,
  radius: 50,
}

function drawGrid() {

  cx.fillStyle = "#FFF";
  cx.fillRect(0, 0, 1450, 750);

  cx.lineWidth = 1;
  cx.beginPath();
  let hght = 0;
  for (let y = 0; y < 750; y += 50) {
    cx.moveTo(0, y);
    cx.lineTo(1500, y);
    cx.font = "13px normal";
    cx.fillStyle = "black";
    cx.fillText(hght, 10, y - 3);
    hght+=50;
  }
 
  cx.stroke();
  cx.beginPath();
  for (let x = 0; x < 1500; x += 50) {
    cx.moveTo(x, 0);
    cx.lineTo(x, 750);
    cx.font = "13px normal";
    cx.fillStyle = "black";
   
    cx.fillText(x , x , 15);
  }
  cx.stroke();
  cx.font = "25px normal";
  cx.fillStyle = "black";
  cx.fillText("О", 15, 30);
  cx.font = "20px normal";

  cx.lineWidth = 3;
  cx.strokeStyle = "black";
  cx.beginPath();
  cx.moveTo(1504, 0);
  cx.lineTo(1470, 8);
  cx.stroke();

  cx.lineWidth = 3;
  cx.strokeStyle = "black";
  cx.beginPath();
  cx.moveTo(2, 750);
  cx.lineTo(8, 720);
  cx.stroke();
 


  cx.fillText("Х", 1480, 30);
  cx.fillText("Y", 10, 735);
  cx.lineWidth = 3;
  cx.strokeStyle = "black";
  cx.beginPath();
  cx.moveTo(0, 2);
  cx.lineTo(1500, 2);
  cx.stroke();
  cx.beginPath();
  cx.moveTo(2, 0);
  cx.lineTo(2, 750);
  cx.stroke();
  cx.lineWidth = 3;
  cx.strokeStyle = "black";
  
}

// function drawSymetricLines(){

//   for(let i = 70; i< 630; i+=100){
//     cx.beginPath();
//     cx.lineWidth = 2;
//     cx.moveTo(725,i);
//     cx.lineTo(725, i+60);
//     cx.closePath();
//     cx.stroke();
//   }
//   for(let i = 140; i< 630; i+=100){
//     cx.beginPath();
//     cx.lineWidth = 2;
//     cx.moveTo(725,i);
//     cx.lineTo(725, i+20);
//     cx.closePath();
//     cx.stroke();
//   }

// }

function drawHalfCircle() {
  cx.beginPath();
  cx.lineWidth = 4;
  cx.arc(halfCircle.x, halfCircle.y, halfCircle.radius, 0, Math.PI);
  cx.stroke();
}

function drawFirstCircle() {
  cx.beginPath();
  cx.lineWidth = 4;
  cx.arc(firstCircle.x, firstCircle.y, firstCircle.radius, 0, Math.PI *2);
  cx.stroke();
}

function drawSecondCircle() {
  cx.beginPath();
  cx.lineWidth = 4;
  cx.arc(secondCircle.x, secondCircle.y, secondCircle.radius, 0, Math.PI *2);
  cx.stroke();
}
function point() {
  cx.beginPath();
  cx.arc(center.x,center.y,7,0, 2 * Math.PI);
  cx.fill();
}
function drawRomb(){
  // const Symetrichorizontal = () => {
  //     for(let i = 695; i < 700; i+=100){
  //       cx.beginPath();
  //       cx.lineWidth = 2;
  //       cx.moveTo(i,520);
  //       cx.lineTo(i+60, 520);
  //       cx.closePath();
  //       cx.stroke();
  //     }
      
  //     for(let i = 665; i < 800; i+=100){
  //       cx.beginPath();
  //       cx.lineWidth = 2;
  //       cx.moveTo(i,520);
  //       cx.lineTo(i+20, 520);
  //       cx.closePath();
  //       cx.stroke();
  //     }
  //   };
    //Symetrichorizontal();

    cx.beginPath();
    cx.lineWidth = 4;
    cx.moveTo(725,470);
    cx.lineTo(775, 520);
    cx.closePath();
    cx.stroke();

    cx.beginPath();
    cx.lineWidth = 4;
    cx.moveTo(725,570);
    cx.lineTo(775, 520);
    cx.closePath();
    cx.stroke();

    cx.beginPath();
    cx.lineWidth = 4;
    cx.moveTo(725,570);
    cx.lineTo(675, 520);
    cx.closePath();
    cx.stroke();

    cx.beginPath();
    cx.lineWidth = 4;
    cx.moveTo(725,470);
    cx.lineTo(675, 520);
    cx.closePath();
    cx.stroke();
}

function drawMainLines(){
  // const Symetrichorizontal = () => {
  //   for(let i = 500; i < 1000; i+=100){
  //     cx.beginPath();
  //     cx.lineWidth = 2;
  //     cx.moveTo(i,380);
  //     cx.lineTo(i+60, 380);
  //     cx.closePath();
  //     cx.stroke();
  //   }
  //   for(let i = 570; i < 900; i+=100){
  //     cx.beginPath();
  //     cx.lineWidth = 2;
  //     cx.moveTo(i,380);
  //     cx.lineTo(i+20, 380);
  //     cx.closePath();
  //     cx.stroke();
  //   }
  
  // };
  //Symetrichorizontal();

// Horizontal down
  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(725-sizes.leght_down_width/2,600);
  cx.lineTo(725+sizes.leght_down_width/2, 600);
  cx.closePath();
  cx.stroke();
// Angle down
  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(725-sizes.leght_down_width/2,600);
  cx.lineTo(525, 350);
  cx.closePath();
  cx.stroke();

  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(725+sizes.leght_down_width/2,600);
  cx.lineTo(925, 350);
  cx.closePath();
  cx.stroke();
// Middle straight
  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(925,350);
  cx.lineTo(925, 350 - sizes.middle_straight_height);
  cx.closePath();
  cx.stroke();

  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(525,350);
  cx.lineTo(525, 350 - sizes.middle_straight_height);
  cx.closePath();
  cx.stroke();
// Inner straight
  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(775,380);
  cx.lineTo(775, 380-sizes.inner_straight_height);
  cx.closePath();
  cx.stroke();

  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(675,380);
  cx.lineTo(675, 380-sizes.inner_straight_height);
  cx.closePath();
  cx.stroke();
// Horizontal top
  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(925,350 - sizes.middle_straight_height);
  cx.lineTo(825, 150);
  cx.closePath();
  cx.stroke();

  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(525,350 - sizes.middle_straight_height);
  cx.lineTo(625, 150);
  cx.closePath();
  cx.stroke();
// Angle inner top
  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(825,150);
  cx.lineTo(775, 380-sizes.inner_straight_height);
  cx.closePath();
  cx.stroke();

  cx.beginPath();
  cx.lineWidth = 4;
  cx.moveTo(625,150);
  cx.lineTo(675, 380-sizes.inner_straight_height);
  cx.closePath();
  cx.stroke();
}