function solve(arr) {
  arr.sort((a, b) => a - b);
  let tempArr = [];
  tempArr.length = arr.length;

  let ArrIndex = 0;
  for (
    let i = 0, j = tempArr.length - 1;
    i <= tempArr.length / 2 || j > tempArr.length / 2;
    i++, j--
  ) {
    if (ArrIndex < tempArr.length) {
      tempArr[ArrIndex] = arr[i];
      ArrIndex++;
    }

    if (ArrIndex < tempArr.length) {
      tempArr[ArrIndex] = arr[j];
      ArrIndex++;
    }
  }

  // Modifying original array
  for (let i = 0; i < tempArr.length; i++) {
    arr[i] = tempArr[i];
  }

  return arr;
}

function withWhile(arr) {
  arr.sort((a, b) => a - b);
  let result = [];

  while (arr.length) {
    result.push(arr.shift());
    result.push(arr.pop());
  }
  return result.filter((num) => num != undefined);
}
console.log(withWhile([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
