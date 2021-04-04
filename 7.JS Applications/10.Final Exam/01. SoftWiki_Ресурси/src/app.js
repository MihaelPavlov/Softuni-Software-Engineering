import page from "../node_modules/page/page.mjs";

import { render } from "../node_modules/lit-html/lit-html.js";


import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";
import { catalogPage } from "./views/catalog.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { searchPage } from "./views/search.js";


import { logout}  from "./api/data.js";


page("/", decorateContext, homePage);
page("/home", decorateContext, homePage);
page("/login", decorateContext, loginPage);
page("/register", decorateContext, registerPage);
page("/catalog", decorateContext, catalogPage);
page("/create", decorateContext, createPage);
page("/details/:id", decorateContext, detailsPage);
page("/edit/:id", decorateContext, editPage);
page("/search", decorateContext, searchPage);



const main = document.getElementById("main-content");


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
    document.getElementById("user").style.display = "";
    document.getElementById("guest").style.display = "none";
  } else {
    document.getElementById("user").style.display = "none";
    document.getElementById("guest").style.display = "";
  }
}
