function solve(input) {
  let myObj = [];

  for (const hero of input) {
    let [name, level, splitItems] = hero.split(" / ");
    level = Number(level);

    let items = splitItems ? splitItems.split(", ") : [];

    myObj.push({ name, level, items });
  }

  return JSON.stringify(myObj);
}

console.log(
  solve([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara",
  ])
);

console.log(solve(["Jake / 1000 / Gauss, HolidayGrenade"]));
