function solve() {
  const divContainer = document.getElementById("container");
  const inputs = divContainer.querySelectorAll("input");
  const onScreenButton = divContainer.lastElementChild;

  const movies = document.querySelector("#movies ul");
  let moviesOnScreen = [];

  const archive = document.querySelector("#archive ul");

  const clearAllButton = document.querySelector("#archive button");

  onScreenButton.addEventListener("click", createMovie);

  movies.addEventListener("click", addMovieToArhive);

  archive.addEventListener("click", deleteMovie);

  clearAllButton.addEventListener("click", deleteAllMovies);

  function createMovie(e) {
    e.preventDefault();

    const name = inputs[0].value;
    const hall = inputs[1].value;
    const price = Number(inputs[2].value);
    inputs[0].value = "";
    inputs[1].value = "";
    inputs[2].value = "";

    if (!name || !hall || !price) {
      return;
    }

    const li = createMovieStructure(name, hall, price);
    moviesOnScreen.push(li);
    movies.appendChild(li);
  }

  function createMovieStructure(name, hall, price) {
    const li = document.createElement("li");
    const span = document.createElement("span");
    const strongHall = document.createElement("strong");
    const div = document.createElement("div");
    const strongPrice = document.createElement("strong");
    const input = document.createElement("input");
    const button = document.createElement("button");

    span.textContent = name;
    li.appendChild(span);
    strongHall.textContent = `Hall: ${hall}`;
    li.appendChild(strongHall);

    strongPrice.textContent = price.toFixed(2);
    input.placeholder = "Tickets Sold";
    button.textContent = "Archive";
    div.appendChild(strongPrice);
    div.appendChild(input);
    div.appendChild(button);
    li.appendChild(div);

    return li;
  }
  function createArchiveMovie(name, totalAmount) {
    const li = document.createElement("li");
    const span = document.createElement("span");
    const strong = document.createElement("strong");
    const button = document.createElement("button");

    span.textContent = name;
    strong.textContent = `Total amount: ${totalAmount.toFixed(2)}`;
    button.textContent = "Delete";
    li.appendChild(span);
    li.appendChild(strong);
    li.appendChild(button);
    return li;
  }

  function addMovieToArhive(e) {
    if (e.target.tagName != "BUTTON") {
      return;
    }
    const targetResult = e.target.parentElement.parentElement.children;
    const inputValue = targetResult[2].children[1];
    if (!Number(inputValue.value)) {
      return;
    }
    const name = targetResult[0].textContent;
    let price = targetResult[2].children[0].textContent;
    let sum = Number(price) * Number(inputValue.value);
    const createdArchiveMoview = createArchiveMovie(name, sum);
    movies.removeChild(e.target.parentElement.parentElement);
    archive.appendChild(createdArchiveMoview);
  }

  function deleteMovie(e) {
    if (e.target.tagName != "BUTTON") {
      return;
    }
    const movieToDelete = e.target.parentElement;
    const parent = e.target.parentElement.parentElement;
    parent.removeChild(movieToDelete);
  }

  function deleteAllMovies(e) {
    if (e.target.tagName != "BUTTON") {
      return;
    }
    const parent = e.target.parentElement.children[1];
    const allMoviesInArchive = e.target.parentElement.children[1].children;
    while (parent.firstChild) {
      parent.firstChild.remove();
    }
  }
}
