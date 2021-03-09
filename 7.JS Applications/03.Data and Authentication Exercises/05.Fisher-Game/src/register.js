import { showHome } from "./home.js";



export async function onRegister(event) {
  event.preventDefault();
  const formData = new FormData(event.target);
  const email = formData.get("email");
  const password = formData.get("password");
  const repass = formData.get("rePass");

  if (email == "" || password == "") {
    return alert("All fields are required!");
  } else if (password != repass) {
    return alert("Passwords don't match!");
  }

  const response = await fetch("http://localhost:3030/users/register", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ email, password }),
  });

  if (response.ok) {
    event.target.reset();
    const data = await response.json();
    sessionStorage.setItem("authToken", data.accessToken);
    sessionStorage.setItem("userId", data._id);
    showHome();
  } else {
    const error = await response.json();
    alert(error.message);
  }
}

export function showRegisterPage(e) {
  e.preventDefault();
  document.getElementsByTagName("main")[0].innerHTML='';
  const divContainer = document.createElement('div')
  divContainer.className='container';
  divContainer.innerHTML = document.getElementById(
    "register"
  ).innerHTML;
  document.getElementsByTagName("main")[0].appendChild(divContainer);
  document.getElementById('registerForm').addEventListener('submit',onRegister);
}
