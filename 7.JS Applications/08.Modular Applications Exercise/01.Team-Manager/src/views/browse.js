import { html } from "../../node_modules/lit-html/lit-html.js";
import {
  getTeams,
  getTeamById,
} from "../api/data.js";

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
const teamArticleTemplate = (team) => html`
  <article class="layout">
    <img src="${team.logoUrl}" class="team-logo left-col" />
    <div class="tm-preview">
      <h2>${team.name}</h2>
      <p>${team.description}</p>
      <span class="details"
        >? Members</span
      >
      <div><a href="/details/${team._id}" class="action">See details</a></div>
    </div>
  </article>
`;

export async function browsePage(ctx) {
  console.log("browse page", ctx);
  const teams = await getTeams();

  ctx.render(browseTemplate(teams));
}

async function countOfMembers(id) {
  const teams = await getTeamById(id);

  const members = await getAllMembersFromTeamCount(teamId);

  return  members;
}