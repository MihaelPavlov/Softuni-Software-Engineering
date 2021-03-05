async function request(url, option) {
  const response = await fetch(url, option);
  if (response.ok != true) {
    const error = await response.json();
    alert(error.message);
    throw new Error(error.message);
  }
  const data = await response.json();
  return data;
}

async function getBookById(id) {
  const book = await request(
    "http://localhost:3030/jsonstore/collections/books/" + id
  );

  document.querySelector('#editForm [name="title"]').value = book.title;
  document.querySelector('#editForm [name="author"]').value = book.author;
  document.querySelector('#editForm [name="id"]').value = id;
}

async function getAllBooks() {
  const books = await request(
    "http://localhost:3030/jsonstore/collections/books"
  );

  const rows = Object.entries(books).map(createRow).join("");
  document.querySelector("tbody").innerHTML = rows;
}

function createRow([id, book]) {
  const result = `
  <tr id="${id}">
  <td>${book.title}</td>
  <td>${book.author}</td>
  <td>
      <button class="editBtn">Edit</button>
      <button class="deleteBtn">Delete</button>
  </td>
</tr>
  `;
  return result;
}
async function createBook(e) {
  e.preventDefault();

  const formData = new FormData(e.target);
  let title = formData.get("title");
  let author = formData.get("author");

  const book = {
    title,
    author,
  };
  await request("http://localhost:3030/jsonstore/collections/books", {
    method: "post",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(book),
  });

  // e.target.Reset() -> clean the form inputs
  e.target.reset();
  getAllBooks();
}

async function updateBook(e) {
  e.preventDefault();

  const formData = new FormData(e.target);
  console.log(formData);
  let id = formData.get("id");

  let title = formData.get("title");
  let author = formData.get("author");

  const book = {
    title,
    author,
  };
  await request("http://localhost:3030/jsonstore/collections/books/" + id, {
    method: "put",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(book),
  });
  getAllBooks();
  document.getElementById("createForm").style.display = "block";
  document.getElementById("editForm").style.display = "none";
  e.target.reset();
}

async function deleteBook(id) {
  const result = await request(
    "http://localhost:3030/jsonstore/collections/books/" + id,
    {
      method: "delete",
    }
  );
  getAllBooks();
}

function start() {
  document.getElementById("loadBooks").addEventListener("click", getAllBooks);
  document.getElementById("createForm").addEventListener("submit", createBook);
  document.getElementById("editForm").addEventListener("submit", updateBook);
  document.querySelector("table").addEventListener("click", handleTableClick);
  getAllBooks();
}
function handleTableClick(e) {
  if (e.target.classList.contains("editBtn")) {
    document.getElementById("createForm").style.display = "none";
    const editForm = document.getElementById("editForm");
    editForm.style.display = "block";
    getBookById(e.target.parentElement.parentElement.id);
  } else if (e.target.classList.contains("deleteBtn")) {
    const confirmed = confirm('Are u sure want to delete this book')
    if (confirmed) {
      deleteBook(e.target.parentElement.parentElement.id);
      
    }
  }
}
start();
