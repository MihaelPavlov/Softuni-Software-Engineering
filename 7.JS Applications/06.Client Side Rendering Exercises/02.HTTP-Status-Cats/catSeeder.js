import { html } from "./node_modules/lit-html/lit-html.js";

class Cat {
  constructor(id, statusCode, statusMessage, imageLocation) {
    this.id = id;
    this.statusCode = statusCode;
    this.statusMessage = statusMessage;
    this.imageLocation = imageLocation;
  }
}

const cats = [
  new Cat("100", 100, "Continue", "cat100"),
  new Cat("200", 200, "Ok", "cat200"),
  new Cat("204", 204, "No content", "cat204"),
  new Cat("301", 301, "Moved permanently", "cat301"),
  new Cat("304", 304, "Not modified", "cat304"),
  new Cat("400", 400, "Bad request", "cat400"),
  new Cat("404", 404, "Not Found", "cat404"),
  new Cat("406", 406, "Not Acceptable", "cat406"),
  new Cat("410", 410, "Gone", "cat410"),
  new Cat("500", 500, "Internal Server Error", "cat500"),
  new Cat("511", 500, "Network Authentication Required", "cat511"),
];

function showMore(e) {
  console.log(e);
  if (e.target.parentElement.lastElementChild.style.display == "block") {
    e.target.parentElement.lastElementChild.style.display = "none";
  } else if (e.target.parentElement.lastElementChild.style.display == "none") {
    e.target.parentElement.lastElementChild.style.display = "block";
  }
}
const cardTemplate = (data) => html`
  <li>
    <img
      src="./images/${data.imageLocation}.jpg"
      width="250"
      height="250"
      alt="Card image cap"
    />
    <div class="info">
      <button @click=${showMore} class="showBtn">
        Show status code
      </button>
      <div class="status" style="display: none" id="${data.id}">
        <h4>Status Code: ${data.statusCode}</h4>
        <p>${data.statusMessage}</p>
      </div>
    </div>
  </li>
`;

export { cats, cardTemplate };
