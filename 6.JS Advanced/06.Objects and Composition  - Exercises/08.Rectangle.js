function rectangle(width, height, color) {
  Number(width);
  Number(height);

  function Capitalization(word) {
    return word[0].toUpperCase() + word.slice(1);
  }

  const myObj = {
    width,
    height,
    color: Capitalization(color),
    calcArea: function () {
      return Number(this.width * this.height);
    },
  };

  return myObj;
}

let rect = rectangle(4, 5, "red");
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
