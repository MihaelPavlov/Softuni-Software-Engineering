function lockedProfile() {
  document.getElementById("main").addEventListener("click", function (e) {
    if (e.target.tagName == "BUTTON") {
      const profile = e.target.parentNode;
      const isLock =
        e.target.parentNode.querySelector("input[type=radio]:checked").value ===
        "lock";
      console.log(isLock);

      if (isLock) {
        return;
      }

      let div = profile.querySelector("div");
      let isVisible = div.style.display === "block";
      div.style.display = isVisible ? "none" : "block";
      e.target.textContent = isVisible ? "Show more" : "Hide it";
    }
  });
}
