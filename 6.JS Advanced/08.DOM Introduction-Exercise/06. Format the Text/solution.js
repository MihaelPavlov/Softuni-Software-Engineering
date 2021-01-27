function solve() {
  // split  the text
  //atleast 1 character
  //restrict the sentence to 3
  const getText = document.getElementById("input").value;
  const outputElement = document.getElementById("output");
  const splitText = getText.split(".").filter((e) => e != "");

  let result = "";

  for (let index = 0; index < splitText.length; index += 3) {
    if (splitText[index] != undefined) {
      result += splitText[index] + ".";
    }
    if (splitText[index + 1] != undefined) {
      result += splitText[index + 1] + ".";
    }
    if (splitText[index + 1] != undefined) {
      result += splitText[index + 2] + ".";
    }

    let p = document.createElement("p");
    p.textContent = result;
    outputElement.appendChild(p);
    result = "";
  }
}
