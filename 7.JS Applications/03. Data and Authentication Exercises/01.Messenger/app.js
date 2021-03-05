function attachEvents() {
  document.getElementById("submit").addEventListener("click", createNewData);

  document.getElementById("refresh").addEventListener("click", refreshData);
}

async function refreshData() {
  const url = "http://localhost:3030/jsonstore/messenger";
  const response = await fetch(url);
  const data = await response.json();

  const textArea = document.getElementById("messages");
  textArea.textContent=''
  Object.values(data).forEach((el) => {
    if (el.author != "" && el.content != "") {
        textArea.textContent += `${el.author}: ${el.content}\n`;
      
    }
  });
}

async function createNewData() {
  const author = document.getElementById("author");
  const content = document.getElementById("content");
  if (author.value == "" || content.value == "") {
    console.log("error");
    return;
  }
  const data = {
    author: author.value,
    content: content.value,
  };
  const url = "http://localhost:3030/jsonstore/messenger";
  const response = await fetch(url, {
    method: "post",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(data),
  });
 refreshData();
}

attachEvents();
