/*let button = document.querySelector('#button');
let name = document.querySelector('#name');

function getInfo(){
    axios.get('https://swapi.co/api/people/1').then(function(response){
        updateInfo(response.data);
    })
}
function updateInfo(data){
    name.InnerText = data.name
}
*/
var response;

document.onreadystatechange = function(){
    if(document.readyState == "complete"){
        catch_characters();
    }
}

function catch_characters(){
    var httpRequest = new XMLHttpRequest();

    httpRequest.onreadystatechange = function(){
        if(httpRequest.readyState === 4){
            if(httpRequest.status === 200){
                response = JSON.parse(httpRequest.responseText);
                var list = document.querySelector('#characters');
                list.innerHTML = "";

                response.results.forEach(function(el){
                    option = document.createElement("option");
                    option.innerHTML = el.name;
                    option.setAttribute('films', JSON.stringify(el.films));
                    list.appendChild(option);
                })
            }
        }
    }

    httpRequest.open('GET', 'https://swapi.co/api/people/');
    httpRequest.send();

}