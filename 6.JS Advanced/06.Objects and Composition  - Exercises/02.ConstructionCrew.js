function solve(obj) {
  if (obj.dizziness) {
    let requiredWater = obj.weight * 0.1 * obj.experience;
    obj.levelOfHydrated += requiredWater;
    obj.dizziness = false;
  }

  return obj;
}

console.log(
  solve({ weight: 95, experience: 3, levelOfHydrated: 0, dizziness: false })
);
console.log(
  solve({ weight: 80, experience: 1, levelOfHydrated: 0, dizziness: true })
);
console.log(
  solve({ weight: 120, experience: 20, levelOfHydrated: 200, dizziness: true })
);
