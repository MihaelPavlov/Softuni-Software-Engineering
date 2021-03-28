import page from "../node_modules/page/page.mjs";

import { render } from "../node_modules/lit-html/lit-html.js";


import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";
import { allMemesPage } from "./views/allMeme.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { myProfilePage } from "./views/my-profile.js";


import {logout}  from "./api/data.js";

const main = document.querySelector("main");

page("/", decorateContext, homePage);
page("/home", decorateContext, homePage);
page("/login", decorateContext, loginPage);
page("/register", decorateContext, registerPage);
page("/allMemes", decorateContext, allMemesPage);
page("/create", decorateContext, createPage);
page("/details/:id", decorateContext, detailsPage);
page("/edit/:id", decorateContext, editPage);
page("/my-profile", decorateContext, myProfilePage);


//start Application
document.getElementById("logoutBtn").addEventListener("click", async () => {
  await logout();
  setUserNav();
  page.redirect("/");
});
setUserNav();
page.start();

// ctx->context come from page
function decorateContext(ctx, next) {
  console.log(`this is the renderMiddleware context -> ${ctx} next ->${next}`);
  ctx.render = (content) => render(content, main);
  ctx.setUserNav = setUserNav;
  next();
}
function setUserNav(ctx, next) {
  const userId = sessionStorage.getItem("authToken");
  if (userId != null) {
    const email = sessionStorage.getItem('email')
    document.getElementsByClassName('welcome')[0].textContent=`Welcome, ${email}`
    document.getElementsByClassName("user")[0].style.display = "";
    document.getElementsByClassName("guest")[0].style.display = "none";
  } else {
    document.getElementsByClassName("user")[0].style.display = "none";
    document.getElementsByClassName("guest")[0].style.display = "";
  }
}
