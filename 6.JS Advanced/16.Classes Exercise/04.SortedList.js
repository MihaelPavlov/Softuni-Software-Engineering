class List {
  constructor() {
    this.array = [];
  }
  get size() {
    return this.array.length;
  }

  add(element) {
    this.array.push(element);
  }
  remove(index) {
    this.array.splice(index - 1, index);
  }
  get(index) {
    return this.array[index];
  }
}

let list = new List();
list.add(3);
list.remove(0);

console.log(list.size);
