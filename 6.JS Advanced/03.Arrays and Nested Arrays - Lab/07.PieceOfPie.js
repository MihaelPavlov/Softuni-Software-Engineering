function solve(pieFlavors, startTargetFlavors, endTargetFlavors) {
  let newArray = [];

  let startIndex = pieFlavors.indexOf(startTargetFlavors);
  let endIndex = pieFlavors.indexOf(endTargetFlavors);
  newArray = pieFlavors.slice(startIndex, endIndex + 1);

  return newArray;
}

console.log(
  solve(
    [
      "Apple Crisp",
      "Mississippi Mud Pie",
      "Pot Pie",
      "Steak and Cheese Pie",
      "Butter Chicken Pie",
      "Smoked Fish Pie",
    ],
    "Pot Pie",
    "Smoked Fish Pie"
  )
);
console.log(
  solve(
    [
      "Pumpkin Pie",
      "Key Lime Pie",
      "Cherry Pie",
      "Lemon Meringue Pie",
      "Sugar Cream Pie",
    ],
    "Key Lime Pie",
    "Lemon Meringue Pie"
  )
);
