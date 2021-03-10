import { createComment, showComments } from "./comment.js";
import { createTopic, showTopics } from "./create.js";

let id;
document.getElementById("createForm").addEventListener("submit", createTopic);

document.body.addEventListener("load", showTopics());

document.getElementById("allTopics").addEventListener("click", (event) => {
  if (event.target.tagName == "H2") {
    id = event.target.parentElement.id;
    showComments(id);

  }
});
