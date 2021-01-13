function solve(input) {
  let newArray = [];

  for (let index = 0; index < input.length; index++) {
    if (input[index] < 0) {
      newArray.unshift(input[index]);
    } else {
      newArray.push(input[index]);
    }
  }

  return newArray;
}

console.log(solve([3, -2, 0, -1]));
console.log(solve([7, -2, 8, 9]));
