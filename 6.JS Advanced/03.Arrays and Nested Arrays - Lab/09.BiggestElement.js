function solve(input) {
  let newArray = [];
  for (let x = 0; x < input.length; x++) {
    newArray.unshift(
      input[x].reduce((acc, el) => {
        return acc < el ? el : acc;
      }, 0)
    );
  }

  let biggestNumber = newArray.reduce((acc, el) => {
    return acc < el ? el : acc;
  }, 0);

  return biggestNumber;
}

console.log(
  solve([
    [20, 50, 10],
    [8, 33, 145],
  ])
);

console.log(
  solve([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4],
  ])
);
