function solve() {
  const text = document.getElementById("text").value;
  const namingConvention = document.getElementById("naming-convention").value;
  let result = "";
  const resultElement = document.getElementById("result");
  let words = text.split(" ");
  if (namingConvention === "Camel Case") {
    for (let index = 0; index < words.length; index++) {
      let word = words[index].toLowerCase();
      if (index != 0) {
        result += word.charAt(0).toUpperCase() + word.slice(1);
      } else {
        result += word.charAt(0).toLowerCase() + word.slice(1);
      }
    }
  } else if (namingConvention === "Pascal Case") {
    for (let index = 0; index < words.length; index++) {
      let word = words[index].toLowerCase();
      result += word.charAt(0).toUpperCase() + word.slice(1);
    }
  } else {
    result = "Error!";
  }

  resultElement.textContent = result;
}
