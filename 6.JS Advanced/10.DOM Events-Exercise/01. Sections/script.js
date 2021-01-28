function create(words) {
  let content = document.getElementById("content");

  words.forEach((el) => {
    let div = document.createElement("div");
    let p = document.createElement("p");
    p.textContent = el;
    p.style.display = "none";
    div.appendChild(p);
    content.appendChild(div);
  });
  content.addEventListener("click", function (e) {
    if (e.target.tagName === "DIV" || e.target.tagName === "P") {
      const p = e.target.children[0] || e.target;
      const isVisible = p.style.display === "block";
      p.style.display = isVisible ? "none" : "block";
    }
  });
}
