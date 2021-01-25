function subtract() {
  const firstNumber = document.getElementById("firstNumber").value;
  const secondNumber = document.getElementById("secondNumber").value;

  const resultElement = document.getElementById("result");

  resultElement.textContent = Number(firstNumber) - Number(secondNumber);
}
