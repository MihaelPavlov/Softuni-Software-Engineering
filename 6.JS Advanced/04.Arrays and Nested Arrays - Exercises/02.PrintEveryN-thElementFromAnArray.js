function solve(array, count) {
  let newArray = [];
  for (let index = 0; index < array.length; index += count) {
    newArray.push(array[index]);
  }
  return newArray;
}

console.log(solve(["1", "2", "3", "4", "5"], 6));
console.log(solve(["5", "20", "31", "4", "20"], 2));
console.log(solve(["dsa", "asd", "test", "tset"], 2));
