function attachEvents() {
  const token = sessionStorage.getItem("userToken");
  console.log(token);
  document
    .getElementsByClassName("load")[0]
    .addEventListener("click", getListOfCatches);
  document.getElementById("catches").addEventListener("click", handleClick);

  if (token != null) {
    console.log("authenticated");
    document.getElementsByClassName("add")[0].disabled = false;
    document
      .getElementById("addForm")
      .parentElement.addEventListener("submit", createCatche);
  } else {
    console.log("Non-authenticated");
  }
}

async function getListOfCatches() {
  const url = "http://localhost:3030/data/catches";
  const response = await fetch(url);
  const data = await response.json();
  const rows = data.map(createRow).join("");
  const catches = document.getElementById("catches");

  catches.innerHTML = rows;
}

function createRow(catche) {
  const token = sessionStorage.getItem("ownerId");
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

async function createCatche(e) {
  e.preventDefault();
  const url = "http://localhost:3030/data/catches";
  const formData = new FormData(e.target);
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
  if (
    angler == "" ||
    typeof weight != "number" ||
    weight == 0 ||
    species == "" ||
    location == "" ||
    bait == "" ||
    typeof captureTime != "number" ||
    captureTime == 0
  ) {
    return alert("Fields must be correct");
  }

  const response = await fetch(url, {
    method: "post",
    headers: {
      "Content-type": "application/json",
      "X-Authorization": sessionStorage.getItem("userToken"),
    },
    body: JSON.stringify(catche),
  });
  if (response.ok) {
    const data = await response.json();
    console.log(data);
    sessionStorage.setItem("ownerId", data._ownerId);
  } else {
    return alert(`${response.statusText}`);
  }
  e.target.reset();
}

async function deleteCatche(e) {
  if (e.target.classList.contains("delete")) {
    const url =
      "http://localhost:3030/data/catches/" + e.target.parentElement.id;

    const response = await fetch(url, {
      method: "delete",
      headers: { "X-Authorization": sessionStorage.getItem("userToken") },
    });
    if (response.ok) {
      getListOfCatches();
    }
  } else {
    return alert(`you doesn't create that angler`);
  }
}

async function updateCatche(e) {
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
    const url =
      "http://localhost:3030/data/catches/" + e.target.parentElement.id;

    const response = await fetch(url, {
      method: "put",
      headers: { "X-Authorization": sessionStorage.getItem("userToken") },
      body: JSON.stringify(catche),
    });
    console.log("update");
    getListOfCatches();
  }
}
function handleClick(e) {
  if (e.target.classList.contains("update")) {
    updateCatche(e);
  } else if (e.target.classList.contains("delete")) {
    const confirmed = confirm("Are u sure want to delete this book");
    if (confirmed) {
      deleteCatche(e);
    }
  }
}
attachEvents();
