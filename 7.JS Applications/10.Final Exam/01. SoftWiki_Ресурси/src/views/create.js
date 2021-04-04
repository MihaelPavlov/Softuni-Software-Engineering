import { html } from "../../node_modules/lit-html/lit-html.js";
import { createRecord } from "../api/data.js";
const createTemplate = (onSubmit) => html`
  <section id="create-page" class="content">
    <h1>Create Article</h1>

    <form @submit=${onSubmit} id="create" action="#" method="">
      <fieldset>
        <p class="field title">
          <label for="create-title">Title:</label>
          <input
            type="text"
            id="create-title"
            name="title"
            placeholder="Enter article title"
          />
        </p>

        <p class="field category">
          <label for="create-category">Category:</label>
          <input
            type="text"
            id="create-category"
            name="category"
            placeholder="Enter article category"
          />
        </p>
        <p class="field">
          <label for="create-content">Content:</label>
          <textarea name="content" id="create-content"></textarea>
        </p>

        <p class="field submit">
          <input class="btn submit" type="submit" value="Create" />
        </p>
      </fieldset>
    </form>
  </section>
`;
export async function createPage(ctx) {
  console.log("Create page", ctx);
  const token = sessionStorage.getItem("authToken");
  if (token == null) {
    ctx.page.redirect("/");
  }
  ctx.render(createTemplate(onSubmit));
  async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.target);
    const title = formData.get("title");
    const category = formData.get("category");
    const content = formData.get("content");

    if (title == "" || category == "" || content == "") {
      return alert("Missing Fields!");
    }
    if (
      category == "JavaScript" ||
      category == "C#" ||
      category == "Java" ||
      category == "Python"
    ) {
      await createRecord({
        title,
        category,
        content,
      });
      
      ctx.page.redirect(`/home`);
    }else{

      return alert("Invalid Category!!!");
    }
  }
}
