function addItem() {
  const menu = document.getElementById("menu");

  const inputText = document.getElementById("newItemText");
  const inputValue = document.getElementById("newItemValue");

  let option = document.createElement("OPTION");

  option.textContent = inputText.value;
  option.value = inputValue.value;

  menu.appendChild(option);
  console.log(inputText.value, inputValue.value);

  inputText.value = "";
  inputValue.value = "";
}
