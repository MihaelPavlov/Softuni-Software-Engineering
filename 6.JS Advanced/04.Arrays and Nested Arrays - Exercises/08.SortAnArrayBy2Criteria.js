function solve(arr) {
  arr.sort((a, b) => a.length - b.length || a.localeCompare(b));

  return arr.join("\r\n");
}

console.log(solve(["test", "Deny", "omen", "Default"]));
console.log(solve(["Isacc", "Theodor", "Jack", "Harrison", "George"]));
