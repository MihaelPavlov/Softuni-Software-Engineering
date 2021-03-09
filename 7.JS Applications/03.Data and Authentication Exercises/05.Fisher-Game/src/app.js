import { onRegister, showRegisterPage } from "./register.js";
import { onLogin, showLoginPage } from "./login.js";
import { showHome } from "./home.js";

document.body.addEventListener("load", showHome());

document
  .getElementById("registerBtn")
  .addEventListener("click", showRegisterPage);

document.getElementById("loginBtn").addEventListener("click", showLoginPage);

document.getElementById("homeBtn").addEventListener("click", showHome);
