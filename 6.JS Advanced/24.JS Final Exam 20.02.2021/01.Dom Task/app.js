function solve() {
  const button = document.getElementsByClassName("create")[0];

  const sectionWithPosts = document.getElementsByTagName("section")[1];
  const sectionWithArchivePosts = document.getElementsByClassName(
    "archive-section"
  )[0].lastElementChild;

  button.addEventListener("click", createNewPost);
  document.getElementsByTagName("main")[0].addEventListener("click", (e) => {
    if (e.target.tagName === "BUTTON") {
      if (e.target.classList.contains("delete")) {
        deletePost(e);
      } else if (e.target.classList.contains("archive")) {
        archivePost(e);
      }
    }
  });

  function deletePost(e) {
    const article = e.target.parentElement.parentElement;
    article.remove();
  }
  function archivePost(e) {
  
    const title =
      e.target.parentElement.parentElement.firstElementChild.textContent;
    const li = createElement("li", title);
 
    sectionWithArchivePosts.appendChild(li);
    const array = Array.from(sectionWithArchivePosts.children);
    array.sort((a,b)=> a.textContent.localeCompare(b.textContent))
    array.forEach(e=>{
      sectionWithArchivePosts.appendChild(e);
    })
    deletePost(e);
  }
  function createNewPost(e) {
    e.preventDefault();

    const author = document.getElementById("creator");
    const title = document.getElementById("title");
    const category = document.getElementById("category");
    const content = document.getElementById("content");

    const article = createElement("article");
    const h1 = createElement("h1", title.value);
    const pCategory = createElement("p", "Category:");
    const strongCategory = createElement("strong", category.value);
    const pCreator = createElement("p", "Creator:");
    const strongCreator = createElement("strong", author.value);
    const pContent = createElement("p", content.value);
    const divWithButtons = createElement("div", undefined, ["class=buttons"]);
    const deleteButton = createElement("button", "Delete", ["class=btn"]);
    deleteButton.classList.add("delete");
    const archiveButton = createElement("button", "Archive", ["class=btn"]);
    archiveButton.classList.add("archive");

    article.appendChild(h1);
    pCategory.appendChild(strongCategory);
    article.appendChild(pCategory);
    pCreator.appendChild(strongCreator);
    article.appendChild(pCreator);
    article.appendChild(pContent);
    divWithButtons.appendChild(deleteButton);
    divWithButtons.appendChild(archiveButton);
    article.appendChild(divWithButtons);
    sectionWithPosts.appendChild(article);
  }

  function createElement(type, text, attributes = []) {
    let element = document.createElement(type);
    if (text) {
      element.textContent = text;
    }
    attributes
      .map((attr) => attr.split("="))
      .forEach(([name, value]) => {
        element.setAttribute(name, value);
      });

    return element;
  }
}
