function solve() {
  //
  const addButton = document.querySelector("form")[3];
  //Validate

  // my collection
  const allModules = new Map();
  //
  addButton.addEventListener("click", createModule);

  function createModule() {
    event.preventDefault();
    const HTMLModules = document.getElementsByClassName("modules");
    const inputName = document.getElementsByName("lecture-name")[0];
    const date = document.getElementsByName("lecture-date")[0];
    const module = document.getElementsByName("lecture-module")[0];
    const div = document.createElement("div");
    const h3 = document.createElement("h3");
    const ul = document.createElement("ul");
    const li = document.createElement("li");
    const h4 = document.createElement("h4");
    const button = document.createElement("button");
    console.log(date.value);
    let first = date.value.split("-");
    let second = date.value.split("T");
    let resultDate =
      first[0] +
      "/" +
      first[1] +
      "/" +
      first[2][0] +
      first[2][1] +
      " - " +
      second[1];

    if (
      inputName.value == "" ||
      date.value == "" ||
      module.value == "Select module"
    ) {
      return;
    }
    //if that module already contains
    if (allModules.get(module.value)) {
      // only add lecure
      const HTMLList = document.querySelector(`.${module.value} ul`);

      allModules.get(module.value).add(inputName.value);
      li.classList.add("flex");
      h4.textContent = inputName.value + " - " + resultDate;
      button.textContent = "Del";
      button.classList.add("red");
      button.addEventListener("click", DeleteLi);
      li.appendChild(h4);
      li.appendChild(button);
      HTMLList.appendChild(li);
      sort(HTMLModules[0], module.value);
    } else {
      allModules.set(module.value, new Set());
      div.classList.add("module");
      div.classList.add(module.value);
      h3.textContent = module.value;
      li.classList.add("flex");
      h4.textContent = inputName.value + " - " + resultDate;
      button.textContent = "Del";
      button.classList.add("red");
      button.addEventListener("click", DeleteLi);

      li.appendChild(h4);
      li.appendChild(button);
      ul.appendChild(li);
      div.appendChild(h3);
      div.appendChild(ul);
      HTMLModules[0].appendChild(div);
      sort(HTMLModules[0], module.value);
    }
  }
  function DeleteLi(event) {
    const ul = event.currentTarget.parentElement.parentElement;
    if (ul.children.length === 1) {
      const div = event.currentTarget.parentElement.parentElement.parentElement;
      allModules.delete(div.children[0].textContent);
      div.remove();
      return;
    }

    event.currentTarget.parentElement.remove();
  }

  function sort(htmlModules, moduleName) {
    const getRightModule = htmlModules.getElementsByClassName(moduleName);
    const value =
      getRightModule[0].children[1].children[0].children[0].textContent;
    console.log();
  }
}
