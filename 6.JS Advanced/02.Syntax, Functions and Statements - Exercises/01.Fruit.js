function fruits(fruit , weight , price ){
  let money = price/1000 *weight;

  weight = Number(weight) / 1000;

  console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

fruits('orange',1563,2.35);