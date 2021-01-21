function solve(input) {
  let sortedInput = [];

  for (const product of input) {
    let splitProduct = product.split(" : ");
    sortedInput.push({
      productName: splitProduct[0],
      productPrice: splitProduct[1],
    });
  }

  sortedInput.sort(function (a, b) {
    var nameA = a.productName.toUpperCase(); // ignore upper and lowercase
    var nameB = b.productName.toUpperCase(); // ignore upper and lowercase
    if (nameA < nameB) {
      return -1;
    }
    if (nameA > nameB) {
      return 1;
    }

    // names must be equal
    return 0;
  });

  let result = sortedInput.reduce((r, e) => {
    let group = e.productName[0];

    if (!r[group]) {
      r[group] = { group, children: [e] };
    } else {
      r[group].children.push(e);
    }
    return r;
  }, {});

  let endResult = Object.values(result);
  for (const products of endResult) {
    console.log(products.group);
    for (const product of products.children) {
      console.log(`  ${product.productName}: ${product.productPrice}`);
    }
  }
}

console.log(
  solve([
    "Appricot : 20.4",
    "Fridge : 1500",
    "TV : 1499",
    "Deodorant : 10",
    "Boiler : 300",
    "Apple : 1.25",
    "Anti-Bug Spray : 15",
    "T-Shirt : 10",
  ])
);
console.log(
  solve([
    "Banana : 2",
    "Rubic's Cube : 5",
    "Raspberry P : 4999",
    "Rolex : 100000",
    "Rollon : 10",
    "Rali Car : 2000000",
    "Pesho : 0.000001",
    "Barrel : 10",
  ])
);
