function solve(input) {
  let bottles = new Map();
  let juices = {};
  for (let i = 0; i < input.length; i++) {
    let inputArgs = input[i].split(" => ");
    let name = inputArgs[0];
    let count = Number(inputArgs[1]);

    if (!juices.hasOwnProperty(name)) {
      juices[name] = 0;
    }
    juices[name] += count;
    if (juices[name] / 1000 >= 1) {
      let bottlesCount = Math.trunc(juices[name] / 1000);
      juices[name] -= bottlesCount * 1000;
      if (!bottles.has(name)) {
        bottles.set(name, 0);
      }
      bottles.set(name, bottles.get(name) + bottlesCount);
    }
  }
  for (const [key, value] of bottles) {
    console.log(`${key} => ${value}`);
  }
}

console.log(
  solve([
    "Kiwi => 234",
    "Pear => 2345",
    "Watermelon => 3456",
    "Kiwi => 4567",
    "Pear => 5678",
    "Watermelon => 6789",
  ])
);
