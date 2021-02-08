class SortedList {
  nums = [];
  size = 0;
  add(x) {
    this.nums.push(x);
    this.nums.sort((a, b) => a - b);
    this.size += 1;
  }
  remove(index) {
    if (index >= 0 && index < this.nums.length) {
      this.nums.splice(index, 1);
      this.size -= 1;
    }
  }
  get(index) {
    if (index >= 0 && index < this.nums.length) {
      return this.nums[index];
    }
  }
}

let list = new List();
list.add(3);
list.remove(0);

console.log(list.size);
