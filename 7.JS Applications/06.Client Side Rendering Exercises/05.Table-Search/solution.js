import { render, html } from "./node_modules/lit-html/lit-html.js";
import { getData } from "./requests.js";

const template = (data) => html`
  <tr>
    <td>${data.firstName} ${data.lastName}</td>
    <td>${data.email}</td>
    <td>${data.course}</td>
  </tr>
`;

async function solve() {
  const tbody = document.querySelector("tbody");
  const allStudents = await getData();
  const result = Object.values(allStudents).map(template);
  render(result, tbody);
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  async function onClick() {
    const input = document.getElementById("searchField");

    Array.from(tbody.children).forEach((el) => {
      if (el.classList.contains("select")) {
        el.classList.remove("select");
      }
      if (
        el.firstElementChild.textContent.includes(input.value) ||
        el.children[1].textContent.includes(input.value) ||
        el.lastElementChild.textContent.includes(input.value)
      ) {
        el.classList.add("select");
      }
    });
    input.value='';
  }
}

solve();
