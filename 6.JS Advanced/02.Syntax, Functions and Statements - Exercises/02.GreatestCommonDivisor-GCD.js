function solve(a, b) {
  if (b) {
      return solve(b, a % b);
  } else {
      return console.log(Math.abs(a));
  }
}
  solve(15,5);