document.querySelector("form").addEventListener("submit", onRegisterSubmit);
document.getElementById("login").addEventListener("submit", onLoginSubmit);
async function onLoginSubmit(e) {
  e.preventDefault();
  const formData = new FormData(e.target);
  const email = formData.get("email");
  const password = formData.get("password");

  const response = await fetch("http://localhost:3030/users/login", {
    method: "post",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify({ email, password }),
  });
  console.log(response);
  if (!response.ok) {
    const error = await response.json();
    return alert(error.message);
  }
  const data = await response.json();
  sessionStorage.setItem("userToken", data.accessToken);
  window.location.pathname = "/05.Fisher-Game/index.html";
  console.log("registerCorrect");
}

async function onRegisterSubmit(e) {
  e.preventDefault();
  const formData = new FormData(e.target);
  const email = formData.get("email");
  const password = formData.get("password");
  const rePass = formData.get("rePass");
  console.log(formData);

  if (email == "" || password == "" || rePass == "") {
    return alert("All fields are retuqired!");
  } else if (password != rePass) {
    return alert("Password don't match!");
  }

  const response = await fetch("http://localhost:3030/users/register", {
    method: "post",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify({ email, password }),
  });

  if (!response.ok) {
    const error = await response.json();
    return alert(error.message);
  }
  const data = await response.json();
  console.log(data);
  sessionStorage.setItem("userToken", data.accessToken);
  window.location.pathname = "/05.Fisher-Game/index.html";
  console.log("login correct");
}
