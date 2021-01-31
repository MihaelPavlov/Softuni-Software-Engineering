function focus() {
  const inputs = document.querySelectorAll("input");
  for (let i = 0; i < inputs.length; i++) {
    inputs[i].addEventListener("focus", function (e) {
      const parentOfInput = e.target.parentElement;
      console.log(parentOfInput);
      if (e.target.nodeName == "INPUT") {
        parentOfInput.classList.add("focused");
        //parentOfInput.classList.remove("focus");
      }
    });
    inputs[i].addEventListener("blur", function (e) {
      const parentOfInput = e.target.parentElement;
      parentOfInput.classList.remove("focused");
    });
  }
}
