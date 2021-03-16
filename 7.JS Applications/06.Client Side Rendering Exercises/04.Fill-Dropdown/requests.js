export async function getData() {
  const response = await fetch(
    "http://localhost:3030/jsonstore/advanced/dropdown"
  );

  const data = await response.json();

  return data;
}

export async function createNewTown(name) {

  const data = {
    text: name
  }
  const response = await fetch(
    "http://localhost:3030/jsonstore/advanced/dropdown",
    {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    }
  );

 
}
