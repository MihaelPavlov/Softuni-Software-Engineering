async function getListCatches() {
  const response = await fetch("http://localhost:3030/data/catches");
  const data = await response.json();
  return data;
}

function createRow(catche) {
  const token = sessionStorage.getItem("userId");
  if (catche._ownerId === token) {
    const row = `
    <div  class="catch">
    <form id="${catche._id}">
    <label>Angler</label>
    <input type="text" class="angler" name='angler' value="${catche.angler}" />
    <hr>
    <label>Weight</label>
    <input type="number" class="weight" name='weight' value="${catche.weight}" />
    <hr>
    <label>Species</label>
    <input type="text" class="species" name='species' value="${catche.species}" />
    <hr>
    <label>Location</label>
    <input type="text" class="location" name='location' value="${catche.location}" />
    <hr>
    <label>Bait</label>
    <input type="text" class="bait" name='bait' value="${catche.bait}" />
    <hr>
    <label>Capture Time</label>
    <input type="number" class="captureTime" name='captureTime' value="${catche.captureTime}" />
    <hr>
    <button class="update">Update</button>
    <button class="delete">Delete</button>
    </form>
  </div>
    `;
    return row;
  } else {
    const row = `
    <div class="catch">
    <form id="${catche._id}">
    <label>Angler</label>
    <input type="text" class="angler" name='angler' value="${catche.angler}" />
    <hr>
    <label>Weight</label>
    <input type="number" class="weight" name='weight' value="${catche.weight}" />
    <hr>
    <label>Species</label>
    <input type="text" class="species" name='species' value="${catche.species}" />
    <hr>
    <label>Location</label>
    <input type="text" class="location" name='location' value="${catche.location}" />
    <hr>
    <label>Bait</label>
    <input type="text" class="bait" name='bait' value="${catche.bait}" />
    <hr>
    <label>Capture Time</label>
    <input type="number" class="captureTime" name='captureTime' value="${catche.captureTime}" />
    <hr>
    <button disabled class="update">Update</button>
    <button disabled class="delete">Delete</button>
    </form>
  </div>
  `;
    return row;
  }
}

export async function showHome() {
  document.getElementsByTagName("main")[0].innerHTML = "";
  const main = document.getElementsByTagName("main")[0];
  const fieldset = document.createElement("fieldset");
  fieldset.id = "main";
  const legend = document.createElement("legend");
  legend.textContent = "Catches";
  const div = document.createElement("div");
  div.id = "catches";
  const aside = document.createElement("aside");
  aside.innerHTML = `
  <button class="load">Load</button>
  <form >
    <fieldset id="addForm">
      <legend>Add Catch</legend>
      <label>Angler</label>
      <input type="text" class="angler" name="angler" />
      <label>Weight</label>
      <input type="number" class="weight" name="weight" />
      <label>Species</label>
      <input type="text" class="species" name="species" />
      <label>Location</label>
      <input type="text" class="location" name="location" />
      <label>Bait</label>
      <input type="text" class="bait" name="bait" />
      <label>Capture Time</label>
      <input type="number" class="captureTime" name="captureTime" />
      <button disabled class="add">Add</button>
    </fieldset>
  </form>
  `;

  const catches = await getListCatches();
  const rows = catches.map(createRow).join("");
  div.innerHTML = rows;
  fieldset.appendChild(legend);
  fieldset.appendChild(div);
  main.appendChild(fieldset);
  main.appendChild(aside);

  const token = sessionStorage.getItem("authToken");
  if (token != null) {
    document.getElementsByClassName("add")[0].disabled = false;
    document
      .getElementsByClassName("add")[0]
      .addEventListener("click", createCatch);

    document.getElementById("catches").addEventListener("click", (event) => {
      event.preventDefault();
      if (
        event.target.tagName == "BUTTON" &&
        event.target.className == "delete"
      ) {
        deleteCatchById(event.target.parentElement.id);
      } else if (
        event.target.tagName == "BUTTON" &&
        event.target.className == "update"
      ) {
        updateCatchById(event.target.parentElement.id, event);
      }
    });
  }
}

async function createCatch(e) {
  e.preventDefault();
  const url = "http://localhost:3030/data/catches";
  const fieldset = document.getElementById("addForm");
  const angler = fieldset.getElementsByClassName("angler")[0];
  const weight = fieldset.getElementsByClassName("weight")[0];
  const species = fieldset.getElementsByClassName("species")[0];
  const location = fieldset.getElementsByClassName("location")[0];
  const bait = fieldset.getElementsByClassName("bait")[0];
  const captureTime = fieldset.getElementsByClassName("captureTime")[0];

  const catche = {
    angler: angler.value,
    weight: weight.value,
    species: species.value,
    location: location.value,
    bait: bait.value,
    captureTime: captureTime.value,
  };
  if (
    angler == "" ||
    weight == "" ||
    species == "" ||
    location == "" ||
    bait == "" ||
    captureTime == ""
  ) {
    return alert("All fields are required!");
  }

  const response = await fetch(url, {
    method: "post",
    headers: {
      "Content-type": "application/json",
      "X-Authorization": sessionStorage.getItem("authToken"),
    },
    body: JSON.stringify(catche),
  });
  if (response.ok) {
    const data = await response.json();
    console.log(data);
    sessionStorage.setItem("ownerId", data._ownerId);
    showHome();
  } else {
    return alert(`${response.statusText}`);
  }
}

async function deleteCatchById(id) {
  const url = "http://localhost:3030/data/catches/" + id;
  const confirmed = confirm("Are you sure you want to delete this catch");
  if (confirmed) {
    const response = await fetch(url, {
      method: "delete",
      headers: { "X-Authorization": sessionStorage.getItem("authToken") },
    });
    if (response.ok) {
      showHome();
    }
  }
}

async function updateCatchById(id, e) {
  e.preventDefault();
  if (e.target.classList.contains("update")) {
    const formData = new FormData(e.target.parentElement);
    const angler = formData.get("angler");
    const weight = Number(formData.get("weight"));
    const species = formData.get("species");
    const location = formData.get("location");
    const bait = formData.get("bait");
    const captureTime = Number(formData.get("captureTime"));

    const catche = {
      angler,
      weight,
      species,
      location,
      bait,
      captureTime,
    };
    const url = "http://localhost:3030/data/catches/" + id;

    const confirmed = confirm("Are you sure you want to update this catch");
    if (confirmed) {
      const response = await fetch(url, {
        method: "put",
        headers: { "X-Authorization": sessionStorage.getItem("authToken") },
        body: JSON.stringify(catche),
      });
      if (response.ok) {
        alert("Successfully updated!");
        showHome();
      }
    }
  }
}
