function solve(n, k) {
  let array = [];
  let countSlice = 1;
  for (let index = 0; index < n; index++) {
    if (index == 0) {
      array[index] = 1;
    } else {
      let newArray = array.slice();
      if (index > k) {
        for (let index = 0; index < countSlice; index++) {
          newArray.shift();
        }
        countSlice++;
      }
      array[index] = sumKElements(newArray.slice(0, newArray.length));
    }
  }

  return array;

  function sumKElements(params) {
    let sum = 0;
    for (let index = 0; index < params.length; index++) {
      sum += Number(params[index]);
    }
    return sum;
  }
}

console.log(solve(8, 2));
console.log(solve(6, 3));
