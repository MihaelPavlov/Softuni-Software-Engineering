import { html } from "../../node_modules/lit-html/lit-html.js";
import { getTeams, getTeamById, getAllMembers } from "../api/data.js";

const browseTemplate = (teams) => html`
  <section id="browse">
    <article class="pad-med">
      <h1>Team Browser</h1>
    </article>

    <article class="layout narrow">
      <div class="pad-small">
        <a href="#" class="action cta">Create Team</a>
      </div>
    </article>

    ${teams.map(teamArticleTemplate)}
  </section>
`;
const teamArticleTemplate =(team) => html`
     <article class="layout">
                  <img src="./assets/rocket.png" class="team-logo left-col">
                  <div class="tm-preview">
                      <h2>Team Rocket</h2>
                      <p>Gotta catch 'em all!</p>
                      <span class="details">${countOfMembers(team._id)} Members</span>
                      <div><a href="#" class="action">See details</a></div>
                  </div>
              </article>
`;

export async function browsePage(ctx) {
  console.log("browse page", ctx);
  const teams = await getTeams();
  ctx.render(browseTemplate(teams));
}

async function countOfMembers(id) {
  const teams = await getTeams();
  console.log(Array.from(teams));
 const team = Array.from(teams).filter(x=>x._id ==id)
  console.log(team._ownerId);
}
