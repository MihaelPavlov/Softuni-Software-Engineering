function toggle() {
  const moreElement = document.getElementsByClassName("button")[0];

  const text = document.getElementById("extra");

  if (moreElement.textContent === "Less") {
    text.style.display = "none";
    moreElement.textContent = "More";
  } else {
    text.style.display = "block";
    moreElement.textContent = "Less";
  }
}
