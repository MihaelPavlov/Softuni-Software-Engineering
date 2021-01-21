function solve(input) {
  let result = [];

  for (let i = 0; i < 1; i++) {
    let args = input[i].split(" | ");

    for (let y = 1; y < input.length; y++) {
      let splitArgs = input[y].split(" | ");
      result.push({
        Town: splitArgs[0].split("| ")[1],
        Latitude: Number(Number(splitArgs[1]).toFixed(2)),
        Longitude: Number(Number(splitArgs[2].split(" |")[0]).toFixed(2)),
      });
    }
  }

  return JSON.stringify(result);
}

console.log(
  solve([
    "| Town | Latitude | Longitude |",
    "| Sofia | 42.696552 | 23.32601 |",
    "| Beijing | 39.913818 | 116.363625 |",
  ])
);
console.log(
  solve([
    "| Town | Latitude | Longitude |",
    "| Veliko Turnovo | 43.0757 | 25.6172 |",
    "| Monatevideo | 34.50 | 56.11 |",
  ])
);
