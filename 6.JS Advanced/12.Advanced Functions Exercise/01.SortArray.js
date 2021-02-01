function sortArray(input, typeOfSort) {
  if (typeOfSort === "asc") {
    return input.sort((a, b) => a - b);
  } else if (typeOfSort === "desc") {
    return input.sort((a, b) => b - a);
  }
}

console.log(sortArray([14, 7, 17, 6, 8], "desc"));
console.log(sortArray([14, 7, 17, 6, 8], "asc"));
