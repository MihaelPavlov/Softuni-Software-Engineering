import { html } from "../../node_modules/lit-html/lit-html.js";
import { getMemeById,deleteMeme } from "../api/data.js";

const detailsTemplate = (meme, isCreator, onDelete) => html`
  <section id="meme-details">
    <h1>Meme Title: ${meme.title}</h1>
    <div class="meme-details">
      <div class="meme-img">
        <img alt="meme-alt" src="${meme.imageUrl}" />
      </div>
      <div class="meme-description">
        <h2>Meme Description</h2>
        <p>${meme.description}</p>
        ${isCreator
          ? html`
              <a class="button warning" href="/edit/${meme._id}">Edit</a>
              <button @click=${onDelete} class="button danger">Delete</button>
            `
          : ""}
      </div>
    </div>
  </section>
`;

export async function detailsPage(ctx) {
  console.log("details page", ctx.params.id);
  const item = await getMemeById(ctx.params.id);
  const userId = sessionStorage.getItem("userId");
  ctx.render(detailsTemplate(item, item._ownerId == userId, onDelete));

  async function onDelete() {
    await deleteMeme(item._id);
    ctx.page.redirect("/allMemes");
  }
}
