function solve() {
  const myObj = {
    mage: function (name) {
      const myMage = {
        name,
        health: 100,
        mana: 100,
        cast: function (spellName) {
          this.mana--;
          return console.log(`${this.name} cast ${spellName}`);
        },
      };

      return myMage;
    },

    fighter: function (name) {
      const myFighter = {
        name,
        health: 100,
        stamina: 100,
        fight: function () {
          this.stamina--;
          return console.log(`${this.name} slashes at the foe!`);
        },
      };
      return myFighter;
    },
  };
  return myObj;
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball");
scorcher.cast("thunder");
scorcher.cast("light");

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight();

console.log(scorcher2.stamina);
console.log(scorcher.mana);
