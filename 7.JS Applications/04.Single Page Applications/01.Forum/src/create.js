export async function createTopic(e) {
  e.preventDefault();
  const formData = new FormData(e.target);
  const topicName = formData.get("topicName");
  const username = formData.get("username");
  const postText = formData.get("postText");
  if (e.submitter.textContent == "Post") {
    console.log("Post");
  } else if (e.submitter.textContent == "Cancel") {
    e.target.reset();
    return;
  }
  const newTopic = {
    topicName,
    username,
    postText,
    post: [],
  };
  const response = await fetch(
    "http://localhost:3030/jsonstore/collections/myboard/posts",
    {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newTopic),
    }
  );
  if (response.ok) {
    alert("Post successfully created");
  } else {
    const data = await response.json();
    return alert(data.message);
  }
  e.target.reset();
  showTopics();
}

async function getTopics() {
  const response = await fetch(
    "http://localhost:3030/jsonstore/collections/myboard/posts"
  );
  const data = await response.json();
  return data;
}
export async function getTopicById(id) {
  const response = await fetch(
    "http://localhost:3030/jsonstore/collections/myboard/posts/" + id
  );
  const data = await response.json();
  return data;
}
export async function showTopics() {
  const topics = await getTopics();

  const rows = Object.values(topics).map(createRow).join("");
  document.getElementById("allTopics").innerHTML = rows;
}

function createRow(topic) {
  const element = `
  <div class="topic-container">
  <div class="topic-name-wrapper">
      <div class="topic-name">
          <a id="${topic._id}" href="#" class="normal">
              <h2>${topic.topicName}</h2>
          </a>
          <div class="columns">
              <div>
                  <p>Date: <time>2020-10-10T12:08:28.451Z</time></p>
                  <div class="nick-name">
                      <p>Username: <span>${topic.username}</span></p>
                  </div>
              </div>
              <div class="subscribers">
                  <!-- <button class="subscribe">Subscribe</button> -->
                  <p>Subscribers: <span>456</span></p>
              </div>
          </div>
      </div>
  </div>
  </div>
  `;
  return element;
}
