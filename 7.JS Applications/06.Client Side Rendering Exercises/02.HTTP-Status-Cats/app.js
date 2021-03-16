import { render } from "./node_modules/lit-html/lit-html.js";
import {cats,cardTemplate} from './catSeeder.js'

const ul = document.createElement("ul");

const sectionCats = document.getElementById("allCats")

const allCats = cats.map(cardTemplate);
render(allCats,ul);
render(ul,sectionCats)