function solve(input) {
  // let copy = input.slice();
  // let currentBiggestOne = 0;
  // for (let index = 0; index < input.length; index++) {
  //   if (input[index] < currentBiggestOne) {
  //     copy[index] = 0;
  //   } else if (input[index] >= currentBiggestOne) {
  //     currentBiggestOne = input[index];
  //   }
  // }

  let result = [];
  for (let index = 0; index < input.length; index++) {
    let elem = input[index];

    if (elem >= result[result.length - 1] || result.length === 0) {
      result.push(elem);
    }
  }
  return result;

  // return copy.filter((x) => x != 0);
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15, 6, 1]));
