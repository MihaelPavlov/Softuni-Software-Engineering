import { html } from "../../node_modules/lit-html/lit-html.js";
import { getCarById, deleteRecord } from "../api/data.js";

const detailsTemplate = (car, isCreator, onDelete) => html`
  <section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
      <img src="${car.imageUrl}" />
      <hr />
      <ul class="listing-props">
        <li><span>Brand:</span>${car.brand}</li>
        <li><span>Model:</span>${car.model}</li>
        <li><span>Year:</span>${car.year}</li>
        <li><span>Price:</span>${car.price}$</li>
      </ul>

      <p class="description-para">
        ${car.description}
      </p>
      ${isCreator
        ? html`
            <div class="listings-buttons">
              <a href="/edit/${car._id}" class="button-list">Edit</a>
              <a href="javascript:void(0)" @click=${onDelete} class="button-list">Delete</a>
            </div>
          `
        : ""}
    </div>
  </section>
`;

export async function detailsPage(ctx) {
  console.log("details page", ctx.params.id);
  const item = await getCarById(ctx.params.id);
  const userId = sessionStorage.getItem("userId");
  ctx.render(detailsTemplate(item, item._ownerId == userId, onDelete));

  async function onDelete() {
    await deleteRecord(item._id);
    ctx.page.redirect("/all");
  }
}
