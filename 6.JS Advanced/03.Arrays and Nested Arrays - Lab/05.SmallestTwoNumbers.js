function solve(input) {
  let newArray = [];

  input.sort((a, b) => a - b);
  newArray.push(input[0]);
  newArray.push(input[1]);
  return newArray;
}
console.log(solve([3, 0, 10, 4, 7, 3]));
console.log(solve([30, 15, 50, 5]));
