'use strict';
function submitFunction() {
  let form_submit = document.getElementsByClassName("form_submit")[0];
  let personName = form_submit.querySelector("input[name='personName']");

  let password = form_submit.querySelector("input[name='password']");


  alert("Name: " + personName.value + "\nPassword: " + password.value);
  if (personName.value === "admin" && password.value === "admin") {
    window.open("./admin_success.php");
  } else {
  	window.open("./simple_user.php");
  }
}