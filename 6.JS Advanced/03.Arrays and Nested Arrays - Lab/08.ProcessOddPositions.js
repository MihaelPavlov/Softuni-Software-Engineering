function solve(input) {
  let newArray = [];

  for (let index = 0; index < input.length; index++) {
    if (index % 2 != 0) {
      newArray.unshift(input[index] + input[index]);
    }
  }

  return newArray;
}

console.log(solve([3, 0, 10, 4, 7, 3]));
console.log(solve([10, 15, 20, 25]));
