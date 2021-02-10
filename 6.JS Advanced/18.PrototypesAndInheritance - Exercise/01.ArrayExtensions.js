function solve() {
  let array = [1, 2, 3, 4, 5];
  Array.prototype.last = function () {
    return this[this.length - 1];
  };

  Array.prototype.skip = function (n) {
    let result = [];
    for (let i = n; i < this.length; i++) {
      result.push(this[i]);
    }
    return result;
  };

  console.log(array.skip(1));
  console.log(array.last());
}
solve();
