function solve(input) {
  const myObj = [];

  for (const hero of input) {
    let splitHero = hero.split(" / ");
    let theHero = createHero(splitHero[0], splitHero[1]);
    myObj.push(theHero);

    let splitItems = splitHero[2].split(", ");

    for (let index = 0; index < splitItems.length; index++) {
      myObj[items].push(splitItems[index]);
    }
  }

  function createHero(name, level) {
    return {
      name,
      level,
      items: [],
    };
  }

  return myObj;
}

console.log(
  solve([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara",
  ])
);

console.log(solve(["Jake / 1000 / Gauss, HolidayGrenade"]));
