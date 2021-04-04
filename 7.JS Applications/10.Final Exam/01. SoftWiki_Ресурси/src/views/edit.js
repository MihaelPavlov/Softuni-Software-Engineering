import { html } from "../../node_modules/lit-html/lit-html.js";
import { editRecord ,getRecordById} from "../api/data.js";
const editTemplate = (onSubmit,record) => html`
  <section id="edit-page" class="content">
    <h1>Edit Article</h1>

    <form @submit=${onSubmit} id="edit" action="#" method="">
      <fieldset>
        <p class="field title">
          <label for="title">Title:</label>
          <input
            type="text"
            name="title"
            id="title"
            placeholder="Enter article title"
            .value=${record.title}
          />
        </p>

        <p class="field category">
          <label for="category">Category:</label>
          <input
            type="text"
            name="category"
            id="category"
            placeholder="Enter article category"
            .value=${record.category}
          />
        </p>
        <p class="field">
          <label for="content">Content:</label>
          <textarea name="content" id="content"
          .value=${record.content}></textarea>
        </p>

        <p class="field submit">
          <input class="btn submit" type="submit" value="Save Changes" />
        </p>
      </fieldset>
    </form>
  </section>
`;
export async function editPage(ctx) {
  console.log("Edit page", ctx);
  const record = await getRecordById(ctx.params.id);
  const token = sessionStorage.getItem("authToken");
  if (token == null) {
    ctx.page.redirect("/");
  }
  ctx.render(editTemplate(onSubmit,record));
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
      const newItem = await editRecord(ctx.params.id, {
        title,
        category,
        content,
      });

      ctx.page.redirect(`/details/${newItem._id}`);
    } else {
      return alert("Invalid Category!!!");
    }
  }
}
