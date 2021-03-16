import { render, html } from "./node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";

const template = (data) => html` <li>${data}</li> `;

const ul = document.createElement("ul");
const container = document.getElementById("towns");
const jsonTowns = towns.map(template);
render(jsonTowns, ul);
render(ul, container);

document.getElementById("searchBtn").addEventListener("click", (event) => {
  event.preventDefault();
  const input = document.getElementById("searchText");
  search(input.value);
});

function search(input) {
   let counter =0;

   Array.from(container.firstElementChild.children).forEach(el => {
      console.log(el);
      if (el.classList.contains('active')) {
         el.classList.remove('active');
      }
      if (el.textContent.startsWith(input)) {
         counter++;
         el.classList.add('active')
      }
   });
   document.getElementById("result").textContent=`${counter} matches found`
}
