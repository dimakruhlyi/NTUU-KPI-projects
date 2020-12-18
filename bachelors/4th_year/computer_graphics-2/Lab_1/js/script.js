(function(gosper) {
    // Private members
    let canvas = document.getElementById("canvas");
    let ctx = canvas.getContext("2d");
    let stepFactor = 120;
    let lineWidth = 1;
    let _iter;
    let x;
    let y;
    // Axiom
    let axiom = "A";
    // Production rules
    let rules = {
      A: "A-B--B+A++AA+B-",
      B: "+A-BB--B-A++A+B"
    };
    
  
    canvas.width = 2500;
    canvas.height = 2500;

    function replaceAll(str, mapObj){
      let re = new RegExp(Object.keys(mapObj).join("|"), "gi");
  
      return str.replace(re, function(matched){
          return mapObj[matched];
      });
    }
  
    // Production
    function produce(iterations) {
      _iter = Math.pow(iterations,2);
      let result = axiom;
      for(let i = 0; i < iterations; ++i) {
        result = replaceAll(result, rules);
      }
      return result;
    }
    
    function incX(angle) {
      return Math.cos(angle)*stepFactor/_iter;
    }
    
    function incY(angle) {
      return -Math.sin(angle)*stepFactor/_iter;
    }
    
    function drawStep(angle, colorAngle) {
      //ctx.strokeStyle = "hsl(" + colorAngle + ", 100%, 50%)";
      ctx.beginPath();
      ctx.moveTo(x, y);
      x += incX(angle);
      y += incY(angle);
      ctx.lineTo(x, y);
      ctx.stroke();
    }
    
    
    // Public members
    gosper.draw = function (iterations) {
      ctx.clearRect(0, 0, canvas.width, canvas.height);
      let angle = Math.PI/2;
      let colorAngle;
      let currentStep = 0;
      ctx.lineWidth = lineWidth;
      ctx.lineCap = "round";
      x = canvas.width/2;
      y = canvas.height/2;
   
      let result = produce(iterations);
  
      let numberOfAB = (result.match(/A|B/g) || []).length;
      
      for(let stringIndex = 0; stringIndex < result.length; stringIndex++) {
        switch(result[stringIndex]) {
          case "A":
          case "B":  
            colorAngle = currentStep / numberOfAB * 360;
            drawStep(angle, colorAngle);
            currentStep++;
            break;        
          case "-":
            angle -= Math.PI/3;
            break;
          case "+":
            angle += Math.PI/3;
            break;
        }
      }
      
      return result;
    }
    
  })(window.gosper = window.gosper || {});
  
  
  
  let result = gosper.draw(0);
  
  document.getElementById("iterationsSlider").addEventListener("input", function () {
    result = gosper.draw(parseInt(this.value));
    //console.log(result);
  });


// let i=1;
// function interval()
// {
//     gosper.draw(parseInt(i));
//     document.getElementById('interat').innerHTML = i++;
//     if(i>6){
//         clearInterval(intervalID);
//     }
// }
// let intervalID=setInterval(interval,2000);
