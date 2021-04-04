import { html } from "../../node_modules/lit-html/lit-html.js";
import { searchResult } from "../api/data.js";

const searchTemplate = (onSubmit, articles=[]) => html`
  <section id="search-page" class="content">
    <h1>Search</h1>
    <form @submit=${onSubmit} id="search-form">
      <p class="field search">
        <input
          type="text"
          placeholder="Search by article title"
          name="search"
        />
      </p>
      <p class="field submit">
        <input class="btn submit" type="submit" value="Search" />
      </p>
    </form>
    <div class="search-container">
      ${articles.length==0
        ? html`<h3 class="no-articles">No matching articles</h3>`
        : articles.map(articleTemplate)}
    </div>
  </section>
`;

const articleTemplate = (art) => html`
  <a class="article-preview" href="/details/${art._id}">
    <article>
      <h3>Topic: <span>${art.title}</span></h3>
      <p>Category: <span>${art.category}</span></p>
    </article>
  </a>
`;
export async function searchPage(ctx) {
  console.log("search page", ctx);

  ctx.render(searchTemplate(onSubmit));
  async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const search = formData.get("search").trim();

    if (search == "") {
      return alert("You need Search something :D");
    }
    const result = await searchResult(search);
    console.log(result);
    if (result) {
      ctx.render(searchTemplate(onSubmit,result));
    }
  }
}
