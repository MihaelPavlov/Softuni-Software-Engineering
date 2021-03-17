async function request(url, option) {
  const response = await fetch(url, option);
  const data = await response.json();
  return data;
}
const host = "http://localhost:3030/jsonstore/collections/books";
async function getAllBooks() {
  return Object.entries(await request(host)).map(([k,v])=>Object.assign(v,{_id:k}));
}

async function getBookById(id) {
  await request(host + "/" + id);
}

async function createBook(book) {
  await request(host, {
    method: "post",
    header: { "Content-Type": "application/json" },
    body: JSON.stringify(book),
  });
}
async function updateBook(id, book) {
  await request(host + "/" + id, {
    method: "put",
    header: { "Content-Type": "application/json" },
    body: JSON.stringify(book),
  });
}

async function deleteBook(id) {
  await request(host + "/" + id, {
    method: "delete",
  });
}
export { getAllBooks, getBookById, createBook, updateBook, deleteBook };
