function solve(arr) {
 
  //Намираме сумите на всички редове
  let rowSums = arr.map((el) => el.reduce((a, b) => a + b), 0);
  // for (let i = 0; i < arr.length; i++) {
  //     let row = arr[i];
  //     let sum = row.reduce((result, curr) => (result + curr), 0);
  //     rowSums.push(sum);
  // }


  //Намираме сумите на всички колони
  let colSums = arr[0].map((_, col) => arr.map((row) => row[col])).map(row => row.reduce((a, b) => a + b));
  // for (let i = 0; i < arr.length; i++) {
  //     let newRow = []
  //     for (let y = 0; y < arr.length; y++) {
  //         newRow.push(arr[y][i])
  //     }

  //     let sum = newRow.reduce((result, curr) => (result + curr), 0);
  //     colSums.push(sum);
  // }

  //Събираме резултатите в един масив и проверяваме дали всички елементи са еднакви
  return rowSums.concat(colSums).every((el, i, arr) => el === arr[0]);

  // for (let i = 0; i < rowSums.length; i++) {
  //     if (rowSums[i] !== colSums[i] || rowSums[0] !== rowSums[i]) {
  //         return false;
  //     }
  // }

  //     return true;
}
// second try
function solve2(arr) {
  let rowSums = arr.map(el=>el.reduce((a,b)=>a+b),0);
  let colSums = arr.map((_,i)=>{
    arr[0].map(col)=>{
      return col[col][i];
    }
  });

  // for (let i = 0; i < arr.length; i++) {
  //   let row = arr[i];
  //   let sum = row.reduce((acc, el) => {
  //     acc + el;
  //   }, 0);
  //   rowSums.push(sum);
  // }

  // for (let i = 0; i < arr.length; i++) {
  //   let newRow = [];
  //   for (let y = 0; y < arr.length; y++) {
  //     newRow.push(arr[y][i]);
  //   }
  //   let sum = newRow.reduce((acc, el) => {
  //     acc + el;
  //   }, 0);
  //   colSums.push(sum);
  // }
  return rowSums.concat(colSums).every((el, i, arr) => el === arr[0]);
}
console.log(
  solve2([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5],
  ])
);
console.log(
  solve2([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1],
  ])
);
console.log(
  solve2([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0],
  ])
);
