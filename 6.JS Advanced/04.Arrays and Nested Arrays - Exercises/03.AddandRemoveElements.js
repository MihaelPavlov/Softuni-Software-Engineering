function solve(input) {
  let newArray = [];
  let number = 0;
  for (let index = 0; index < input.length; index++) {
    number++;
    if (input[index] === "add") {
      newArray.push(number);
    } else if (input[index] === "remove") {
      newArray.pop();
    }
  }

  if (newArray.length == 0) {
    return "Empty";
  }
  return newArray.join("\r\n");
}

console.log(solve(["remove", "remove", "remove"]));
console.log(solve(["add", "add", "add", "add"]));
console.log(solve(["add", "add", "remove", "add", "add"]));
