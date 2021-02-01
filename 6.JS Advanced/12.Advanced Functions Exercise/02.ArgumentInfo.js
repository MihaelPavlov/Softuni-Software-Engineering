function solve(...input) {
  let result = {};

  for (let i = 0; i < input.length; i++) {
    let typeOfObject = typeof input[i];
    if (result[typeOfObject]) {
      result[typeOfObject] += 1;
    } else {
      result[typeOfObject] = 1;
    }

    console.log(`${typeOfObject}: ${input[i]}`);
  }
  for (const [key, value] of Object.entries(result).sort(
    (a, b) => b[1] - a[1]
  )) {
    console.log(`${key} = ${value}`);
  }
}

console.log(solve({ name: "bob" }, 3.333, 9.999));
