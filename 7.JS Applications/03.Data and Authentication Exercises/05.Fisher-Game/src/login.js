import { showHome } from "./home.js";
export async function onLogin(e) {
  e.preventDefault();
  const formData = new FormData(e.target);
  const email = formData.get("email");
  const password = formData.get("password");

  const response = await fetch("http://localhost:3030/users/login", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ email, password }),
  });

  if (response.ok) {
    e.target.reset();
    const data = await response.json();
    sessionStorage.setItem("authToken", data.accessToken);
    sessionStorage.setItem("userId", data._id);

    showHome();
  } else {
    const error = await response.json();
    alert(error.message);
  }
}

export function showLoginPage(e) {
  e.preventDefault();
  document.getElementsByTagName("main")[0].innerHTML='';
  document.getElementsByTagName("main")[0].innerHTML = document.getElementById(
    "login"
  ).innerHTML;

  document.getElementById('loginForm').addEventListener('submit',onLogin);
}

