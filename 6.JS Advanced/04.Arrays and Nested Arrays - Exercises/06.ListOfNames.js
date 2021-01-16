function solve(input) {
  input.sort((a, b) => a.localeCompare(b));

  let result = "";
  for (let index = 0; index < input.length; index++) {
    result += index + 1 + "." + input[index] + "\r\n";
  }
  return result;
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));
