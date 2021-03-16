import { render, html } from "./node_modules/lit-html/lit-html.js";
import { getData, createNewTown } from "./requests.js";
const template = (data) => html`
  <option value="${data._id}">${data.text}</option>
`;
async function loadMenu() {
  const menu = document.getElementById("menu");
  const result = await getData();
  const allOptions = Object.values(result).map(template);

  render(allOptions, menu);
}

document.getElementById("submitBtn").addEventListener("click", addItem);

async function addItem() {
    event.preventDefault();
  const input = document.getElementById("itemText");
  if (input.value=='') {
      return;
  }
  await createNewTown(input.value);
  loadMenu();
  input.value='';
}
loadMenu();
