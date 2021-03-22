import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../api/api.js";

const loginTemplate = (onSubmit) => html`
 <section id="login">
      <article class="narrow">
          <header class="pad-med">
              <h1>Login</h1>
          </header>
          <form @submit=${onSubmit} id="login-form" class="main-form pad-large">
              <div class="error">Error message.</div>
              <label>E-mail: <input type="text" name="email"></label>
              <label>Password: <input type="password" name="password"></label>
              <input class="action cta" type="submit" value="Sign In">
          </form>
          <footer class="pad-small">Don't have an account? <a href="#" class="invert">Sign up here</a>
          </footer>
      </article>
  </section>
`


export async function loginPage(ctx) {
    console.log("login page", ctx);
    ctx.render(loginTemplate(onSubmit));
  
    async function onSubmit(event) {
      event.preventDefault();
      const formData = new FormData(event.target);
      const email = formData.get("email").trim();
      const password = formData.get("password").trim();
      if (email == "" || password == "") {
        ctx.render(
          loginTemplate(onSubmit, email == "", password == "")
        );
        return alert("All fields are required!");
      }
      await login(email, password);
      ctx.setUserNav();
      ctx.page.redirect("/");
    }
  }