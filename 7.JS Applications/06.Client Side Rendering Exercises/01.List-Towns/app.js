import { render, html } from "./node_modules/lit-html/lit-html.js";

const cardTemplate = (data) => html` <li>${data}</li> `;

document.getElementById("formTowns").addEventListener("submit", (event) => {
  event.preventDefault();
  const formData = new FormData(event.target);
  const input = formData.get("towns");
  const ul = document.createElement("ul");

  const result = input.split(", ").map(cardTemplate);

  render(result, ul);

  render(ul, document.getElementById("root"));
});
