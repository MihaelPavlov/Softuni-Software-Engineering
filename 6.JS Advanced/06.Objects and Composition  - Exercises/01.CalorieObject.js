function solve(array) {
  let result = {};
  for (let index = 0; index < array.length; index += 2) {
    let name = array[index];
    let price = Number(array[index + 1]);

    result[name] = price;
  }
  return result;
}

console.log(solve(["Yoghurt", "48", "Rise", "138", "Apple", "52"]));
console.log(
  solve(["Potato", "93", "Skyr", "63", "Cucumber", "18", "Milk", "42"])
);
