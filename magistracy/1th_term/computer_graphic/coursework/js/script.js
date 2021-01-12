const canvas = document.getElementById("canvas");

const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.position.set(0, 0, -10);
camera.lookAt(0, 0, 0);

const renderer = new THREE.WebGLRenderer({ canvas: canvas });
renderer.setSize(window.innerWidth, window.innerHeight);
renderer.setClearColor(0x000000);

const delta = 0.001;
let mainNormal, firstTangent, secondTangent;

const geometry = new THREE.ParametricGeometry(mongeSurfaceDiretrixSinusoidaMeridian, 100, 100);
const material = new THREE.MeshNormalMaterial();
const kleinBottle = new THREE.Mesh(geometry, material);
scene.add(kleinBottle);

const gui = new dat.GUI();
const box = gui.addFolder('Switcher');
box.add(kleinBottle.material, 'wireframe').listen();
box.open();

var movingU = 0.5;
var movingV = 0.5;

const controls = new THREE.OrbitControls(camera, renderer.domElement);
const light = new THREE.AmbientLight(0xffffff);
scene.add(light);

drawingTangentsAndNormal(movingU, movingV);

renderer.setAnimationLoop(() => { renderer.render(scene, camera); })

document.addEventListener('keydown',(event) => {
  event.preventDefault();
      switch (event.code) {
        case "KeyA":
          movingU -= 0.01;
          drawingTangentsAndNormal(movingU, movingV);
          break;
        case "KeyD":
          movingU += 0.01;
          drawingTangentsAndNormal(movingU, movingV);
          break;
        case "KeyW":
          movingV += 0.01;
          drawingTangentsAndNormal(movingU, movingV);
          break;
        case "KeyS":
          movingV -= 0.01;
          drawingTangentsAndNormal(movingU, movingV);
          break;
    }
});

function drawingTangentsAndNormal(alpha, t) {
  alpha *= 10;
  t *= 10;

  let tv = new THREE.Vector3(dxdv(alpha,t), dydv(alpha,t), dzdv(alpha,t));
  let tu = new THREE.Vector3(dxdu(alpha,t), dydu(alpha,t), dzdu(alpha,t));
  let normal = new THREE.Vector3(0,0,0).copy(tv).crossVectors(tv, tu);
  let vect = new THREE.Vector3(calcX(alpha, t), calcY(alpha, t), calcZ(alpha, t));

  let geomTv = new THREE.Geometry();
  geomTv.vertices.push(tv, vect);

  let geomTu = new THREE.Geometry();
  geomTu.vertices.push(tu, vect);
 
  let geomNormal = new THREE.Geometry();
  geomNormal.vertices.push(normal, vect);

  if(mainNormal == null) {
    firstTangent = new THREE.Line(geomTv, new THREE.LineBasicMaterial({ color: 0xFF0000 }));
    secondTangent = new THREE.Line(geomTu, new THREE.LineBasicMaterial({ color: 0x00FF00 }));    
    mainNormal = new THREE.Line(geomNormal, new THREE.LineBasicMaterial({ color: 0xFFFFFF }));
  }

  firstTangent.geometry = geomTv;
  secondTangent.geometry = geomTu;
  mainNormal.geometry = geomNormal;

  scene.add(firstTangent);
  scene.add(secondTangent);
  scene.add(mainNormal);
}

function dxdv(u, v){
  return (calcX(u, v + delta * v) - calcX(u, v)) / delta;
}

function dydv(u, v){
  return (calcY(u, v + delta * v) - calcY(u, v)) / delta;
}

function dzdv(u, v){
  return (calcZ(u, v + delta * v) - calcZ(u, v)) / delta;
}

function dxdu(u, v){
  return (calcX(u + delta * u, v) - calcX(u, v)) / delta;
}

function dydu(u, v){
  return (calcY(u + delta * u, v) - calcY(u, v)) / delta;
}

function dzdu(u, v){
  return (calcZ(u + delta * u, v) - calcZ(u, v)) / delta;
}

function calcX(alpha, t){
  return  1 * Math.cos(alpha) - 
  (t * Math.cos(Math.PI * 0.2) - 2 * Math.sin(1 * t) * Math.sin(Math.PI * 0.2) + t * Math.cos(Math.PI * 0.2) - 
  2 *  Math.sin(1 * t) * Math.sin(Math.PI * 0.2)) * Math.sin(alpha);
}

function calcY(alpha, t){
  return 1 * Math.sin(alpha) + 
  (t * Math.cos(Math.PI * 0.2) - 2 * Math.sin(1 * t) * Math.sin(Math.PI * 0.2) + t * Math.cos(Math.PI * 0.2) - 
  2 *  Math.sin(1 * t) * Math.sin(Math.PI * 0.2)) * Math.cos(alpha);
}

function calcZ(alpha, t){
  return t * Math.sin(Math.PI * 0.2) + 2 * Math.sin(1 * t) * Math.cos(Math.PI * 0.2);
}

function mongeSurfaceDiretrixSinusoidaMeridian(alpha, t, target){
  alpha *= 10;
  t *= 10;

  let x = calcX(alpha, t);
  let y = calcY(alpha, t);
  let z = calcZ(alpha, t);

  return target.set(x, y, z);
}