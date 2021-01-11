function solve(number , operation1,operation2,operation3,operation4,operation5){

  let endNumber = Number(number);
  let arrayOperations = [operation1,operation2,operation3,operation4,operation5];

 for (let index = 0; index < arrayOperations.length; index++) {
    if (arrayOperations[index] == 'chop') {
      endNumber /= 2;
    }
    else if (arrayOperations[index] == 'dice') {
      endNumber = Math.sqrt(endNumber);
    }
    else if (arrayOperations[index] == 'spice') {
      endNumber += 1;
    }
    else if (arrayOperations[index] == 'bake') {
      endNumber *=3;
    }
    else if (arrayOperations[index] == 'fillet') {
      endNumber *= 1 - 0.20;
    }

    let multiplier = Math.pow(10,1 || 0);
   console.log(Math.round(endNumber * multiplier) / multiplier);
 }

}



solve('9','dice','spice','chop','bake','fillet')