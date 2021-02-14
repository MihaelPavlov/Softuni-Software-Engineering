function solve() {
  const openTasks = document.querySelectorAll("section")[1];
  const inProgressTasks = document.querySelectorAll("section")[2];
  const completeTasks = document.querySelectorAll("section")[3];

  document.getElementsByTagName("main")[0].addEventListener("click", (e) => {
    e.preventDefault();
    if (e.target.tagName === "BUTTON") {
      if (e.target.textContent === "Add") {
        addToOpen(e);
      } else if (
        e.target.textContent === "Start" &&
        e.target.classList.contains("green")
      ) {
        addInProgress(e);
      } else if (
        e.target.textContent === "Finish" &&
        e.target.classList.contains("orange")
      ) {
        addToComplete(e);
      } else if (e.target.textContent === "Delete") {
        del(e);
      }
    }
  });

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

  function addToComplete(e) {
    const startArticle = e.target.parentNode.parentNode;

    const div = e.target.parentNode;
    div.remove();

    completeTasks.children[1].appendChild(startArticle);
  }
  function addInProgress(e) {
    const startArticle = e.target.parentNode.parentNode;
    const div = e.target.parentNode;
    const startButton = div.children[0];
    startButton.remove();

    const finishBtn = createElement("button", "Finish", ["class=orange"]);
    div.appendChild(finishBtn);
    inProgressTasks.children[1].appendChild(startArticle);

    // e.preventDefault();
    // const startArticle = e.target.parentNode.parentNode;
    // const div = e.target.parentNode;
    // const startButton = div.children[0];
    // startButton.remove();
    // const finishBtn = createElement("button", "Finish", "class=orange");
    // div.appendChild(finishBtn);
    // inProgressTasks.lastElementChild.appendChild(startArticle);
  }
  function addToOpen(e) {
    const taskName = document.getElementById("task");
    const taskDescription = document.getElementById("description");
    const taskDate = document.getElementById("date");

    if (
      taskName.value == "" ||
      taskDescription.value == "" ||
      taskDate.value == ""
    ) {
      return;
    }
    const divWithButtons = createElement("div", undefined, ["class=flex"]);
    const deleteButton = createElement("button", "Delete", ["class=red"]);
    const startButton = createElement("button", "Start", ["class=green"]);

    divWithButtons.appendChild(startButton);
    divWithButtons.appendChild(deleteButton);

    const parentArticle = createElement("article");

    const h3TaskName = createElement("h3", taskName.value);
    const pDescription = createElement(
      "p",
      `Description: ${taskDescription.value}`
    );
    const pDate = createElement("p", `Due Date: ${taskDate.value}`);

    parentArticle.appendChild(h3TaskName);
    parentArticle.appendChild(pDescription);
    parentArticle.appendChild(pDate);
    parentArticle.appendChild(divWithButtons);
    openTasks.children[1].appendChild(parentArticle);
  }
  function del(e) {
    const delArticle = e.target.parentNode.parentNode;
    delArticle.remove();
  }
}
