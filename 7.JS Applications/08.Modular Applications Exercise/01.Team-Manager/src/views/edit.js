import { html } from "../../node_modules/lit-html/lit-html.js";
import { editTeam, getTeamById } from "../api/data.js";
import { until } from "../../node_modules/lit-html/directives/until.js";
import { loaderTemplate } from "./common/loader.js";

const editTemplate = (team, onSubmit, errorMsg) => html`
  <section id="edit">
    <article class="narrow">
      <header class="pad-med">
        <h1>Edit Team</h1>
      </header>
      <form @submit=${onSubmit} id="edit-form" class="main-form pad-large">
        ${errorMsg ? html`<div class="error">${errorMsg}</div>` : ""}
        <label
          >Team name: <input type="text" name="name" .value=${team.name}
        /></label>
        <label
          >Logo URL:
          <input type="text" name="logoUrl" value="$1" .value=${team.logoUrl}
        /></label>
        <label
          >Description:
          <textarea .value=${team.description} name="description"></textarea>
        </label>
        <input class="action cta" type="submit" value="Save Changes" />
      </form>
    </article>
  </section>
`;

export async function editPage(ctx) {
  console.log("edit page");
  const teamId = ctx.params.id
  ctx.render(until(populateTemplate(),loaderTemplate()));

 
  async function populateTemplate() {
    const team = await getTeamById(teamId);

    return editTemplate(team,onSubmit);

    async function onSubmit(event) {
      event.preventDefault();
      const formData = new FormData(event.target);
      const name = formData.get("name");
      const logoUrl = formData.get("logoUrl");
      const description = formData.get("description");
      [...event.target.querySelectorAll("input")].forEach((el) => {
        el.disabled = true;
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
  
        const result = await editTeam(teamId, {
          name,
          logoUrl,
          description,
        });
        ctx.page.redirect(`/details/${result._id}`);
      } catch (err) {
        ctx.render(editTemplate(team, onSubmit, err.message));
      } finally {
        [...event.target.querySelectorAll("input")].forEach((el) => {
          el.disabled = false;
        });
      }
    }
  }
}
