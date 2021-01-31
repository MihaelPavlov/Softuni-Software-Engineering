function addItem() {
  const text = document.getElementById("newItemText").value;

  const ul = document.getElementById("items");
  const createLi = document.createElement("li");
  createLi.textContent = text;
  ul.appendChild(createLi);
}
