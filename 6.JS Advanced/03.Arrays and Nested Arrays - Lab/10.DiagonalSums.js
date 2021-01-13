function solve(matrix) {
  let sumMain = 0;
  let sumSecond = 0;
  let matrixLenght = matrix.length;
  for (let index = 0; index < matrixLenght; index++) {
    sumMain += matrix[index][index];
    sumSecond += matrix[index][matrixLenght - index - 1];
  }

  return sumMain + " " + sumSecond;
}

console.log(
  solve([
    [20, 40],
    [10, 60],
  ])
);
console.log(
  solve([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89],
  ])
);
