function solve(input) {
  let firstNumber = Number(input.shift());
  let lastnumber = Number(input.pop());

  return firstNumber + lastnumber;
}

console.log(solve(["20", "30", "40"]));
console.log(solve(["5", "10"]));
