async function lockedProfile() {
  const url = "http://localhost:3030/jsonstore/advanced/profiles";
  const response = await fetch(url);
  const data = await response.json();
console.log(data);
  const profile = document.getElementsByClassName("profile")[0];
  for (const [key, value] of Object.entries(data)) {
    const clone = profile.cloneNode(true);
    clone.children[2].name=key;
    clone.children[4].name=key;
    clone.children[8].value=value.username;
    
    clone.children[9].children[2].value = value.email;
    clone.children[9].children[4].value = value.age;
    console.log(    clone.children[9].children);
    document.getElementsByTagName("main")[0].appendChild(clone);
  }

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
