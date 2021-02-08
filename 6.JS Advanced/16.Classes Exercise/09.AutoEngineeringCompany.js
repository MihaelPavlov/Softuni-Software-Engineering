function solve(cars) {
  let prodecedCars = new Map();
  let storeCars = {};
  for (const car of cars) {
    let carParts = car.split(" | ");
    let carBrand = carParts[0];
    let carModel = carParts[1];
    let produceCars = Number(carParts[2]);
    if (!storeCars.hasOwnProperty(carBrand)) {
      storeCars[carBrand] = [carModel];
      prodecedCars.set(carBrand, new Map());
    }

    if (prodecedCars.get(carBrand).has(carModel)) {
      let value = Number(prodecedCars.get(carBrand).get(carModel));
      prodecedCars.get(carBrand).set(carModel, value + produceCars);
    } else {
      prodecedCars.get(carBrand).set(carModel, produceCars);
    }
  }

  for (const [key, value] of prodecedCars.entries()) {
    console.log(key);
    for (const [carBrand, produceCars] of value.entries()) {
      console.log(`###${carBrand} -> ${produceCars}`);
    }
  }
}

console.log(
  solve([
    "Audi | Q7 | 1000",
    "Audi | Q6 | 100",
    "BMW | X5 | 1000",
    "BMW | X6 | 100",
    "Citroen | C4 | 123",
    "Volga | GAZ-24 | 1000000",
    "Lada | Niva | 1000000",
    "Lada | Jigula | 1000000",
    "Citroen | C4 | 22",
    "Citroen | C5 | 10",
  ])
);
