// With for loop
function solve(input) {
  let result = [];
  for (let index = 0; index < input.length; index++) {
    let elem = input[index];

    if (elem >= result[result.length - 1] || result.length === 0) {
      result.push(elem);
    }
  }
  return result;
}

// With reduce
function withReduce(arr) {
  return arr.reduce((result, currentValue) => {
    if (currentValue >= result[result.length - 1] || result.length === 0) {
      result.push(currentValue);
    }
    return result;
  }, []);
}

console.log(withReduce([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(withReduce([1, 2, 3, 4]));
console.log(withReduce([20, 3, 2, 15, 6, 1]));
