function solve() {
  let select1;
  let select2;
  let result;

  return {
    init(selector1, selector2, resultSelector) {
      select1 = document.querySelector(selector1);
      select2 = document.querySelector(selector2);
      result = document.querySelector(resultSelector);
    },

    add() {
      result.value = Number(select1.value) + Number(select2.value);
      return result;
    },
    subtract() {
      result.value = Number(select1.value) - Number(select2.value);
      return result;
    },
  };
}

let obj = solve();
obj.init("#num1", "#num2", "#result");
let add = obj.add;
let substract = obj.subtract;
