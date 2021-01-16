function solve(input, count) {
  let counter = Number(count);
  while (counter != 0) {
    let lastElement = input.pop();
    input.unshift(lastElement);
    counter--;
  }

  return input.join(" ");
}

console.log(solve(["Banana", "Orange", "Coconut", "Apple"], 15));
console.log(solve(["1", "2", "3", "4"], 2));
