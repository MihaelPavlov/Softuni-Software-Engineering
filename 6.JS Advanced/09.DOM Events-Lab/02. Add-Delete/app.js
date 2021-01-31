function addItem() {
  const text = document.getElementById("newItemText").value;
  const ul = document.getElementById("items");
  const createLi = document.createElement("li");
  createLi.textContent = text;
  const createAnchor = document.createElement("a");
  createAnchor.setAttribute("href", "#");
  createAnchor.textContent = "[Delete]";
  createAnchor.addEventListener("click", function (e) {
    let li = e.target.parentElement;
    li.remove();
  });
  createLi.appendChild(createAnchor);
  ul.appendChild(createLi);
}
