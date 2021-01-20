function solve(input) {
  function getEngine(power) {
    const engines = [
      { power: 90, volume: 1800 },
      { power: 120, volume: 2400 },
      { power: 200, volume: 3500 },
    ].sort((a, b) => a.power - b.power);

    return engines.find((el) => el.power >= power);
  }

  function getCarriage(carriage, color) {
    return { type: carriage, color: color };
  }

  function getWheels(wheelSize) {
    let weel =
      Math.floor(wheelSize) % 2 == 0
        ? Math.floor(wheelSize) - 1
        : Math.floor(wheelSize);

    return [weel, weel, weel, weel];
  }
  return {
    model: input.model,
    engine: getEngine(input.power),
    carriage: getCarriage(input.carriage, input.color),
    wheels: getWheels(input.wheelsize),
  };
}
console.log(
  solve({
    model: "Opel Vectra",
    power: 110,
    color: "grey",
    carriage: "coupe",
    wheelsize: 17,
  })
);
console.log(
  solve({
    model: "VW Golf II",
    power: 90,
    color: "blue",
    carriage: "hatchback",
    wheelsize: 14,
  })
);
