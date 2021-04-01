import page from "../node_modules/page/page.mjs";

import { render } from "../node_modules/lit-html/lit-html.js";


import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";
import { allCarsPage } from "./views/allCars.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { myCarsPage } from "./views/myCars.js";


import {logout}  from "./api/data.js";


page("/", decorateContext, homePage);
page("/home", decorateContext, homePage);
page("/login", decorateContext, loginPage);
page("/register", decorateContext, registerPage);
page("/all", decorateContext, allCarsPage);
page("/create", decorateContext, createPage);
page("/details/:id", decorateContext, detailsPage);
page("/edit/:id", decorateContext, editPage);
page("/myCars", decorateContext, myCarsPage);


const main = document.getElementById("site-content");


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
  const token = sessionStorage.getItem("authToken");
  if (token != null) {
    const username = sessionStorage.getItem('username')
    document.getElementById('welcome').textContent=`Welcome ${username}`
    document.getElementById("profile").style.display = "";
    document.getElementById("guest").style.display = "none";
  } else {
    document.getElementById("profile").style.display = "none";
    document.getElementById("guest").style.display = "";
  }
}
