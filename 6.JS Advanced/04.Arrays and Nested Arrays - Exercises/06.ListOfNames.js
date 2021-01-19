function solve(input) {
  input.sort((a, b) => a.localeCompare(b));

  let result = "";
  for (let index = 0; index < input.length; index++) {
    result += index + 1 + "." + input[index] + "\r\n";
  }
  return result;
}

function solve2(input) {
  let result = input
    .sort((a, b) => a.localeCompare(b))
    .map((el, index) => {
      return `${index + 1}.${el}`;
    });

  return result.join("\r\n");
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));
