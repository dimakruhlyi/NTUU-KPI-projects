let scene = new THREE.Scene();
let camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
let renderer = new THREE.WebGLRenderer();
renderer.setSize(window.innerWidth, window.innerHeight);
let orbit = new THREE.OrbitControls(camera);
let axis = new THREE.Vector3();
let up = new THREE.Vector3(0, 1, 0);
let pos = 0;
let control;
document.body.appendChild(renderer.domElement);

const main = function(){
  
    createFigure();
    
    createPointLight(0x0000ff, new THREE.Vector3(-20, 0, 0), 'pl1');
    createPointLight(0x00ff00, new THREE.Vector3(-5, 0, 0), 'pl2');
    createPointLight(0xff0000, new THREE.Vector3(5, 0, 0), 'pl3');
    control = new function () {
        this.count = 0.01;
    };
  
    render() 
}

const main2 = function(){
    
    createSpline();
    createFigure();
   
    createPointLight(0xFFFF00, new THREE.Vector3(-100, 20, 100), 'light');
    cretateDirectionalLight(scene);
  
    control = new function () {
      this.rotationSpeed = 0.005;
      this.scale = 1;
    };
  
    render2();
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

function cretateDirectionalLight(scene) {
    let directionalLight = new THREE.DirectionalLight();
    directionalLight.position.copy(new THREE.Vector3(70, 40, -50));
    directionalLight.castShadow = true;
    directionalLight.shadowCameraVisible = false;
    directionalLight.shadowCameraNear = 25;
    directionalLight.shadowCameraFar = 200;
    directionalLight.shadowCameraLeft = -50;
    directionalLight.shadowCameraRight = 50;
    directionalLight.shadowCameraTop = 50;
    directionalLight.shadowCameraBottom = -50;
    directionalLight.shadowMapWidth = 2048;
    directionalLight.shadowMapHeight = 2048;

    directionalLight.name = 'dirLight';
    scene.add(directionalLight);
}

function positionLight() {
    light = scene.getObjectByName('light');
    if (pos <= 1) {
        light.position.copy(spline.getPointAt(pos));
        pos += 0.001
    } else {
        pos = 0;
    }
}

function createSpline() {
    spline = new THREE.SplineCurve3([
       new THREE.Vector3(10, 0, 20 ),
        new THREE.Vector3(-15, 5, 10 ),
        new THREE.Vector3( -5, 5, -5 ),
        new THREE.Vector3( 5, -5, 0 ),
        new THREE.Vector3( 10, 0, 20 )]);

    let geometry = new THREE.Geometry();
    let splinePoints = spline.getPoints(50);

    let material = new THREE.LineBasicMaterial({
        color: 0xffffff
    });

    geometry.vertices = splinePoints;
    let line = new THREE.Line(geometry, material);
    scene.add(line);
}


function addControls(controlObject) {
    let gui = new dat.GUI();
    gui.add(controlObject, 'rotationSpeed', -0.1, 0.1);
    gui.add(controlObject, 'scale', 0.01, 2);
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
}

function render2() {
    renderer.render(scene, camera);
  
    positionLight();
  
    orbit.update();
    requestAnimationFrame(render2);
} 

window.addEventListener('load', main);
let switcher = document.getElementById('switcher');
switcher.addEventListener('change', () => {
    if(switcher.checked){
        scene.remove.apply(scene, scene.children);
        main2();
    }else{
        scene.remove.apply(scene, scene.children);
        main();
    }
});