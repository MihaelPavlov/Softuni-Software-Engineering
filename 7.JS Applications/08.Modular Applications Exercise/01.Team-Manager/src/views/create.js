import { html } from "../../node_modules/lit-html/lit-html.js";
import { createTeam } from "../api/data.js";
const createTemplate = (onSubmit, errorMsg) => html`
  <section id="create">
    <article class="narrow">
      <header class="pad-med">
        <h1>New Team</h1>
      </header>
      <form @submit=${onSubmit} id="create-form" class="main-form pad-large">
        ${errorMsg ? html`<div class="error">${errorMsg}</div>` : ""}
        <label>Team name: <input type="text" name="name" /></label>
        <label>Logo URL: <input type="text" name="logoUrl" /></label>
        <label>Description: <textarea name="description"></textarea></label>
        <input class="action cta" type="submit" value="Create Team" />
      </form>
    </article>
  </section>
`;

export async function createPage(ctx) {
  console.log("create page");
  ctx.render(createTemplate(onSubmit));
  async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const name = formData.get("name");
    const logoUrl = formData.get("logoUrl");
    const description = formData.get("description");
    [...event.target.querySelectorAll('input')].forEach(el => {
      el.disabled=true;
    });
    
    try {
      if (name.length < 4) {
        throw new Error("Name need must be at least 4 characters long.");
      }
      if (description.length < 10) {
        throw new Error(
          "Description need must be at least 10 characters long."
        );
      }
      if (logoUrl.length == "") {
        throw new Error("Team logo is required");
      }

      const result = await createTeam({ name, logoUrl, description });
      ctx.page.redirect(`/details/${result._id}`);
    } catch (err) {
      ctx.render(createTemplate(onSubmit, err.message));
    }
    finally{
      [...event.target.querySelectorAll("input")].forEach(el => {
        el.disabled=false;
      });
    }
  }
}
