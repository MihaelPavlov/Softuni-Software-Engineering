import { html } from "../../node_modules/lit-html/lit-html.js";
import { until } from "../../node_modules/lit-html/directives/until.js";
import {
  getRequestsByTeamId,
  getTeamById,
  requestToJoin,
  cancelMembership
} from "../api/data.js";
import { loaderTemplate } from "./common/loader.js";

const detailsTemplate = (team, createControls) => html`
  <section id="team-home">
    <article class="layout">
      <img src="${team.logoUrl}" class="team-logo left-col" />
      <div class="tm-preview">
        <h2>${team.name}</h2>
        <p>${team.description}</p>
        <span class="details">3 Members</span>
        <div>${createControls()}</div>
      </div>
      <div class="pad-large">
        <h3>Members</h3>
        <ul class="tm-members">
          <li>My Username</li>
        </ul>
      </div>
      <div class="pad-large">
        <h3>Membership Requests</h3>
        <ul class="tm-members"></ul>
      </div>
    </article>
  </section>
`;
const memberTemplate = (member) => html`
  <li>
    ${member.name}<a href="#" class="tm-control action">Remove from team</a>
  </li>
`;

const memberShipRequestsTemplate = (member) => html`
  <li>
    ${member.name}<a href="#" class="tm-control action">Approve</a
    ><a href="#" class="tm-control action">Decline</a>
  </li>
`;

export async function detailsPage(ctx) {
  console.log("details page", ctx);
  const teamId = ctx.params.id;
  ctx.render(until(populateTemplate(teamId), loaderTemplate()));

  async function populateTemplate(teamId) {
    const userId = sessionStorage.getItem("userId");
    const [team, requests] = await Promise.all([
      getTeamById(teamId),
      getRequestsByTeamId(teamId),
    ]);

    return detailsTemplate(team, createControls);

    function createControls() {
      const request =  requests.find((r) => r._ownerId == userId );
      if (userId != null) {
        if (userId == team._ownerId) {
          // current user is owner
          return html`<a href="/edit/${team._id}" class="action">Edit team</a>`;
        } else if (
         request && request.status=='member'
        ) {
          //current user is a member
          return html`<a @click=${e=>leave(e,request._id)} href="javascript:void(0)" class="action invert"
            >Leave team</a
          > `;
        } else if (
          request && request.status=='pending'
        ) {
          //current user has a pending request
          return html`Membership pending.
            <a @click=${e=>leave(e,request._id)} href="javascript:void(0)">Cancel request</a> `;
        } else {
          // user is not realted to the team
          return html`<a @click=${join} href="javascript:void(0)" class="action"
            >Join team</a
          >`;
        }
      } else {
        //guest visitor

        return "";
      }
    }
    async function join(event) {
      event.target.remove();
      await requestToJoin(teamId);
      ctx.render(await populateTemplate(teamId));
    }
    async function leave(event,requestId) {
      const confirmed = confirm('are u sure ?')
      if (confirmed) {
        event.target.remove();
        await cancelMembership(requestId)
      }
      ctx.render(await populateTemplate(teamId));

    }
  }
}
