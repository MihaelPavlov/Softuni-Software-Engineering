import { html } from "../../node_modules/lit-html/lit-html.js";
import { getRecordById, deleteRecord } from "../api/data.js";

const detailsTemplate = (record, isCreator, onDelete) => html`
  <section id="details-page" class="content details">
    <h1>${record.title}</h1>

    <div class="details-content">
      <strong>Published in category ${record.category}</strong>
      <p>
      ${record.content}
      </p>

      ${isCreator
        ? html`<div class="buttons">
            <a href="javascript:void(0)" @click=${onDelete} class="btn delete"
              >Delete</a
            >
            <a href="/edit/${record._id}" class="btn edit">Edit</a>
            <a href="/home" class="btn edit">Back</a>
          </div>`
        : html` <div class="buttons">
            <a href="/home" class="btn edit">Back</a>
          </div>`}
    </div>
  </section>
`;

export async function detailsPage(ctx) {
  console.log("details page", ctx.params.id);
  const item = await getRecordById(ctx.params.id);
  const userId = sessionStorage.getItem("userId");
  ctx.render(detailsTemplate(item, item._ownerId == userId, onDelete));

  async function onDelete() {
    await deleteRecord(item._id);
    ctx.page.redirect("/home");
  }
}
