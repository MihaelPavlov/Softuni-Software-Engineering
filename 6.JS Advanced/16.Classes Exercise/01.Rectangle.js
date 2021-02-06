class Rectangle {
  constructor(width, height, color) {
    this.width = width;
    this.height = height;
    this.color = color;
  }
  get width() {
    return this._width;
  }
  set width(value) {
    if (typeof value != "number") {
      throw new Error("Width is not a number");
    }
    this._width = value;
  }

  get color() {
    return (
      this._color[0].toUpperCase() + this._color.slice(1, this._color.length)
    );
  }
  set color(value) {
    if (typeof value != "string") {
      throw new Error("Color must be string");
    }
    this._color = value;
  }
  calcArea() {
    return this.width * this.height;
  }
}

let rect = new Rectangle(2, 5, "red");
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
console.log(rect);
