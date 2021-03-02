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

async function getAllBooks() {
  const books = await request(
    "http://localhost:3030/jsonstore/collections/books"
  );

  const rows = Object.entries(books).map(createRow).join("");
  document.querySelector("tbody").innerHTML = rows;
}

function createRow([id, book]) {
  const result = `
  <tr data-id="${id}">
  <td>${book.title}</td>
  <td>${book.author}</td>
  <td>
      <button class="editBtn">Edit</button>
      <button class="deleteBtn">Delete</button>
  </td>
</tr>
  `;
  return result ;
}
async function createBook(book) {
  const result = await request(
    "http://localhost:3030/jsonstore/collections/books",
    {
      method: "post",
      headers: { "Content-type": "application/json" },
      body: JSON.stringify(book),
    }
  );
  return result;
}

async function updateBook(id, book) {
  const result = await request(
    "http://localhost:3030/jsonstore/collections/books/" + id,
    {
      method: "put",
      headers: { "Content-type": "application/json" },
      body: JSON.stringify(book),
    }
  );
  return result;
}

async function deleteBook(id) {
  const result = await request(
    "http://localhost:3030/jsonstore/collections/books/" + id,
    {
      method: "delete",
    }
  );
  return result;
}

function start() {
  document.getElementById("loadBooks").addEventListener("click", getAllBooks);
}

start();
