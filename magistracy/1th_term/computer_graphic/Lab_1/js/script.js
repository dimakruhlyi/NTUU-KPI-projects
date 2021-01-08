const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer();
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

window.addEventListener('load', drawindSurface);
window.addEventListener('change', drawindSurface);

function drawindSurface(){
  let r = Number(document.getElementById('radius').value); 
  let c = Number(document.getElementById('coef').value);
  let d = Number(document.getElementById('d').value);
  let teta = Number(document.getElementById('teta').value) * Math.PI;

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

  camera.position.z = Number(document.getElementById('camera').value);

  const clearScene = function(){
    while(scene.children.length > 0){ 
      scene.remove(scene.children[0]); 
    }
  }

  const toggleFunction = function(){
    let toggle = document.getElementById("checking");

    const wireframe = new THREE.WireframeGeometry( geometry );
    let line = new THREE.LineSegments( wireframe );
    line.material.depthTest = false;
    line.material.opacity = 0.25;
    line.material.transparent = true;

    if(toggle.checked){
      clearScene();
      scene.add(line);
    }else{
      clearScene();
      line = new THREE.Mesh(geometry, new THREE.MeshNormalMaterial());
      scene.add(line);
    }

    (function animate() {
      requestAnimationFrame(animate);
    
      line.rotation.x += 0.01;
      line.rotation.y += 0.01;
    
      renderer.render(scene, camera);
    })();
  }

  toggleFunction()
}