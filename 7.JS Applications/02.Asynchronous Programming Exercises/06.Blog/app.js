async function attachEvents() {
  const posts = document.getElementById("posts");

  const url = "http://localhost:3030/jsonstore/blog/posts";
  const response = await fetch(url);
  const data = await response.json();
  document
    .getElementById("btnLoadPosts")
    .addEventListener("click", function () {
      for (const [key, value] of Object.entries(data)) {
        const option = e("option", value.title, [`value=${value.id}`]);
        posts.appendChild(option);
      }
    });
  document
    .getElementById("btnViewPost")
    .addEventListener("click", async function () {
      const selected = posts.value;
      console.log(selected);
      const url = "http://localhost:3030/jsonstore/blog/comments/";
      const response = await fetch(url);
      const dataComments = await response.json();
      let result = Object.values(dataComments).filter(
        (x) => x.postId == selected
      );
      console.log(data);
      document.getElementById("post-title").textContent = data[selected].title;
      const li = e('li',data[selected].body)
      document.getElementById("post-body").appendChild(li);
     const postComments = document.getElementById("post-comments");
      result.forEach(el => {
          const commentLi = e('li',el.text,[`id=${el.id}`]);
          postComments.appendChild(commentLi)
      });
    });

  function e(type, text, attributes = []) {
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
}
attachEvents();
