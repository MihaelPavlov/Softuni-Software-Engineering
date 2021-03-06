import page from "../node_modules/page/page.mjs";

import { render } from "../node_modules/lit-html/lit-html.js";

import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import {registerPage } from "./views/register.js";
import {browsePage } from "./views/browse.js";
import {myTeamsPage } from "./views/myTeams.js";
import {detailsPage } from "./views/details.js";
import { createPage } from "./views/create.js";
import { editPage } from "./views/edit.js";


import {logout}  from "./api/data.js";

const main = document.querySelector(".container");


page("/",decorateContext,  homePage);
page("/index.html",decorateContext,  homePage);
page("/browse",decorateContext,  browsePage);
page("/login",decorateContext,  loginPage);
page("/register",decorateContext,  registerPage);
page("/myTeams",decorateContext,  myTeamsPage);
page("/details/:id",decorateContext,  detailsPage);
page("/create",decorateContext,  createPage);
page("/edit/:id",decorateContext,  editPage);


document.getElementById("logoutBtn").addEventListener("click", async () => {
  await logout();
  setUserNav();
  page.redirect("/");
});

setUserNav();

page.start();

function decorateContext(ctx, next) {
  console.log(`this is the renderMiddleware context -> ${ctx} next ->${next}`);
  ctx.render = (content) => render(content, main);
  ctx.setUserNav = setUserNav;
  next();
}

function setUserNav(ctx, next) {
  const userId = sessionStorage.getItem("userId");
  if (userId != null) {
    Array.from(document.getElementsByClassName("user")).forEach(el => {
      console.log(el);
      el.style.display = "inline-block";
    });
    Array.from(document.getElementsByClassName("guest")).forEach(el => {
      el.style.display = "none";
    });
  } else {
    Array.from(document.getElementsByClassName("user")).forEach(el => {
      console.log(el);
      el.style.display = "none";
    });
    Array.from(document.getElementsByClassName("guest")).forEach(el => {
      el.style.display = "inline-block";
    });
  }
}