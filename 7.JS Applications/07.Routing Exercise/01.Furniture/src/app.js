import page from "../node_modules/page/page.mjs";

import { dashboardPage } from "./views/dashboard.js";
import { detailsPage } from "./views/details.js";
import { createPage } from "./views/create.js";
import { editPage } from "./views/edit.js";
import { registerPage } from "./views/register.js";
import { loginPage } from "./views/login.js";
import { myPage } from "./views/myFurniture.js";

import * as api from "./api/data.js";

window.api = api;
page("/", dashboardPage);
page("/my-furniture", myPage);
page("/details/:id", detailsPage);
page("/create", createPage);
page("/edit/:id", editPage);
page("/register", registerPage);
page("/login", loginPage);

page.start();
