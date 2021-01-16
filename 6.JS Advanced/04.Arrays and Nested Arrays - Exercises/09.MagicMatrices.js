function solve(matrix) {
  let isMagic = true;
  let sum = 0;
  let equalSums = [];

  for (let row = 0; row < matrix.length; row++) {
    let everyRow = [];
    for (let col = 0; col < matrix[row].length; col++) {
      everyRow.push(matrix[row][col]);
    }
    sum = everyRow.reduce((acc, el) => {
      return acc + el;
    }, 0);
    equalSums.push(sum);
  }

  equalSums.reduce(function (a, b) {
    return a === b ? a : (isMagic = false);
  });

  return isMagic;
}

console.log(
  solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5],
  ])
);
console.log(
  solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1],
  ])
);
console.log(
  solve([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0],
  ])
);
