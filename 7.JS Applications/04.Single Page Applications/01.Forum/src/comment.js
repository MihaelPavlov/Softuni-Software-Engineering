import { getTopicById } from "./create.js";

export async function createComment(e) {
  e.preventDefault();

  const formData = new FormData(e.target);
  const postText = formData.get("postText");
  const username = formData.get("username");

  const newComment = {
    postText,
    username,
    topicId: document.querySelector('div .container').id
  };
  const response = await fetch(
    "http://localhost:3030/jsonstore/collections/myboard/comments",
    {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newComment),
    }
  );
  if (response.ok) {
    alert("Post successfully created");
  } else {
    const data = await response.json();
    return alert(data.message);
  }
  e.target.reset();
  showComments(document.querySelector('div .container').id)
  //assign comment in the right topic
}
export async function showComments(id) {
  document.getElementsByTagName("main")[0].innerHTML = "";
  const topic = await getTopicById(id);
  const response = await fetch(
    "http://localhost:3030/jsonstore/collections/myboard/comments"
  );
  const data = await response.json();
  console.log(Object.values(data).filter(x=>x.topicId==id));
  const comment = Object.values(data).filter(x=>x.topicId==id).map(createCommentRow).join('');
  const view = createPage(topic,comment,id);
  document.getElementsByTagName("main")[0].innerHTML = view;
  document
  .getElementById("commentCreate")
  .addEventListener("submit", createComment);
}
function createPage(topic, comments,id) {
  const view = `
  <div class="container" id="${id}">
  <!-- theme content  -->
  <div class="theme-content">
    <!-- theme-title  -->
    <div class="theme-title">
      <div class="theme-name-wrapper">
        <div class="theme-name">
          <h2>${topic.topicName}</h2>
          <p>Date: <time>2020-10-10 12:08:28</time></p>
        </div>
        <div class="subscribers">
          <p>Subscribers: <span>456</span></p>
          <!-- <button class="subscribe">Subscribe</button>
                      <button class="unsubscribe">Unsubscribe</button> -->
        </div>
      </div>
    </div>
    <!-- comment  -->
   ${comments}
    <div class="answer-comment">
      <p><span>currentUser</span> comment:</p>
      <div class="answer">
        <form id="commentCreate">
          <textarea
            name="postText"
            id="comment"
            cols="30"
            rows="10"
          ></textarea>
          <div>
            <label for="username"
              >Username <span class="red">*</span></label
            >
            <input type="text" name="username" id="username" />
          </div>
          <button>Post</button>
        </form>
      </div>
    </div>
  </div>
</div>
  `;
  return view;
}
function createCommentRow(comment) {
  const element = `
  <div class="comment">
  <header class="header">
    <p>
      <span>${comment.username}</span> posted on <time>2020-10-10 12:08:28</time>
    </p>
  </header>
  <div class="comment-main">
    <div class="userdetails">
      <img src="./static/profile.png" alt="avatar" />
    </div>
    <div class="post-content">
     <p>
      ${comment.postText}
     </p>
    </div>
  </div>
  <div class="footer">
    <p><span>5</span> likes</p>
  </div>
</div>
  `;
  return element;
}
