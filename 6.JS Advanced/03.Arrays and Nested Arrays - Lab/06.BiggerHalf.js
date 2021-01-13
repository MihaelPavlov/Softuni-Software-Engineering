function solve(input) {
  input.sort((a, b) => a - b);
  if (input.length % 2 != 0) {
    return getNumbers(input, input.length / 2);
  } else {
    return getNumbers(input, input.length / 2);
  }

  function getNumbers(input, count) {
    let newArray = [];
    input.reverse();
    for (let index = 0; index < count; index++) {
      newArray.unshift(input[index]);
    }

    return newArray;
  }
}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));
