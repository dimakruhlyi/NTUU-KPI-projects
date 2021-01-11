const canvas = document.getElementById("canvas");

const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.position.set(0, 0, -10);
camera.lookAt(0, 0, 0);

const renderer = new THREE.WebGLRenderer({ canvas: canvas });
renderer.setSize(window.innerWidth, window.innerHeight);
renderer.setClearColor(0x000000);

const geometry = new THREE.ParametricGeometry(mongeSurfaceDiretrixSinusoidaMeridian, 100, 100);
const material = createMipmapMaterial();
const kleinBottle = new THREE.Mesh(geometry, material);
scene.add(kleinBottle);

const gui = new dat.GUI();
const box = gui.addFolder('Switcher');
box.add(kleinBottle.material, 'wireframe').listen();
box.open();

const controls = new THREE.OrbitControls(camera, renderer.domElement);
const light = new THREE.AmbientLight(0xffffff);
scene.add(light);

function creatingMipmapTexture(sizeScr) {
  const imageCanvas = document.createElement("canvas");
  const context = imageCanvas.getContext("2d");

  imageCanvas.width = imageCanvas.height = sizeScr;
  context.fillStyle = "#fff";
  
  const greenTexture = "img/green.jpg";
  const blueTexture = "img/blue.jpg";
  const redTexture = "img/red.jpg";
  const yellowTexture = "img/yellow.jpg";
  const pinkTexture =  "img/pink.jpg";

  let imgTexture;
  switch (sizeScr) {
    case 64:
      imgTexture = greenTexture;
      break;
    case 32:
      imgTexture = blueTexture;
      break;
    case 16:
      imgTexture = redTexture;
      break;
    case 8:
      imgTexture = yellowTexture;
      break;
    case 4: 
      imgTexture = pinkTexture;
      break;
    default:
      imgTexture = pinkTexture;
      break;
  }

  let imgObj = new Image();
  imgObj.src = imgTexture;
  let x = 0;
  let y = 0;
  imgObj.onload = function () {
    context.drawImage(imgObj, x, y);
  }
  
  return imageCanvas;
}

function createMipmapMaterial() {
  const canvasObj = creatingMipmapTexture(128);
  const mipTexture = new THREE.CanvasTexture(canvasObj);
  mipTexture.mipmaps[0] = canvasObj;
  mipTexture.mipmaps[1] = creatingMipmapTexture(64, '#0f0');
  mipTexture.mipmaps[2] = creatingMipmapTexture(32, '#f00');
  mipTexture.mipmaps[3] = creatingMipmapTexture(16, '#00f');
  mipTexture.mipmaps[4] = creatingMipmapTexture(8, '#3f0');
  mipTexture.mipmaps[5] = creatingMipmapTexture(4, '#264');
  mipTexture.mipmaps[6] = creatingMipmapTexture(2, '#1a5');
  mipTexture.mipmaps[7] = creatingMipmapTexture(1, '#c4d');

	mipTexture.repeat.set( 150, 150 );
	mipTexture.wrapS = THREE.RepeatWrapping;
	mipTexture.wrapT = THREE.RepeatWrapping;

  const material = new THREE.MeshBasicMaterial({ map: mipTexture });

  return material;
}

function mongeSurfaceDiretrixSinusoidaMeridian(alpha, t, target){
  let r = 1; 
  let c = 2
  let d = 1;
  let teta = Math.PI * 0.2;

  alpha *= 10;
  t *= 10;

  let A = t * Math.cos(teta) - c * Math.sin(d * t) * Math.sin(teta);

  let x = r * Math.cos(alpha) - (A + t * Math.cos(teta) - c *  Math.sin(d * t) * Math.sin(teta)) * Math.sin(alpha);

  let y = r * Math.sin(alpha) + (A + t * Math.cos(teta) - c *  Math.sin(d * t) * Math.sin(teta)) * Math.cos(alpha);

  let z = t * Math.sin(teta) + c * Math.sin(d * t) * Math.cos(teta);

  return target.set(x, y, z);
}

renderer.setAnimationLoop(() => {
  renderer.render(scene, camera);
})