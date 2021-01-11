let scene;
let camera;
let renderer;
let orbit;
const main = function(){

  scene = new THREE.Scene();
  camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
  renderer = new THREE.WebGLRenderer();
  renderer.setSize(window.innerWidth, window.innerHeight);
  orbit = new THREE.OrbitControls(camera);
  document.body.appendChild(renderer.domElement);

  createFigure();
  

  createPointLight(0x0000ff, new THREE.Vector3(-20, 0, 0), 'pl1');
  createPointLight(0x00ff00, new THREE.Vector3(-5, 0, 0), 'pl2');
  createPointLight(0xff0000, new THREE.Vector3(5, 0, 0), 'pl3');
  control = new function () {
      this.count = 0.01;
  };

  render()

}

function createFigure(){
  let r = 1; 
  let c = 2;
  let d = 1;
  let teta = Math.PI * 0.5;

  function mongeSurfaceDiretrixSinusoidaMeridian(alpha, t, target){
      alpha *= 10;
      t *= 10;

      let A = t * Math.cos(teta) - c * Math.sin(d * t) * Math.sin(teta);

      let x = r * Math.cos(alpha) - (A + t * Math.cos(teta) - c *  Math.sin(d * t) * Math.sin(teta)) * Math.sin(alpha);

      let y = r * Math.sin(alpha) + (A + t * Math.cos(teta) - c *  Math.sin(d * t) * Math.sin(teta)) * Math.cos(alpha);

      let z = t * Math.sin(teta) + c * Math.sin(d * t) * Math.cos(teta);

      target.set(x, y, z);
  }

  const geometry = new THREE.ParametricGeometry(mongeSurfaceDiretrixSinusoidaMeridian, 50, 25);

  camera.position.z = 20;

  line = new THREE.Mesh(geometry, new THREE.MeshStandardMaterial({color: 0xfff}));
  scene.add(line);
}

function createPointLight(color, position, name) {
  let pointLight = new THREE.PointLight();
  pointLight.color = new THREE.Color(color);
  pointLight.intensity = 5;
  pointLight.distance = 100;

  pointLight.position.copy(position);
  pointLight.name = name;
  scene.add(pointLight);

  var bulbMat = new THREE.MeshBasicMaterial();
  bulbMat.color = new THREE.Color(color);
  pointLight.add(new THREE.Mesh(new THREE.SphereGeometry(0.5), bulbMat));
}

function render() {
  renderer.render(scene, camera);
  orbit.update();

  var light = scene.getObjectByName('pl1');
  light.position.y = 10 * Math.sin(control.count += 0.005);
  var light = scene.getObjectByName('pl2');
  light.position.y = 10 * Math.sin((control.count += 0.005) + 0.5 * Math.PI);
  var light = scene.getObjectByName('pl3');
  light.position.y = 10 * Math.sin((control.count += 0.005) + 1.0 * Math.PI);


  light.lookAt(scene.position);


  requestAnimationFrame(render);
};

window.addEventListener('load', main);
