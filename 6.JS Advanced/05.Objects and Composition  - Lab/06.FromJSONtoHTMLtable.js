function jsonsTable(arr) {
  arr.shift();

  let result = [];

  for (let line of arr) {
    let [town, latidude, longitude] = line
      .split("|")
      .filter((x) => x != "")
      .map((x) => x.trim());

    latidude = Number(Number(latidude).toFixed(2));
    longitude = Number(Number(longitude).toFixed(2));
    let obj = { Town: town, Latidude: latidude, Longitude: longitude };
    result.push(obj);
  }

  console.log(JSON.stringify(result));
}

console.log(
  jsonsTable([
    { Name: "Stamat", Score: 5.5 },
    { Name: "Rumen", Score: 6 },
  ])
);
