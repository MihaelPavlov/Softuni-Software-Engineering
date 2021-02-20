const describe = require("mocha").describe;
const assert = require("chai").assert;

const numberOperations = {
  powNumber: function (num) {
    return num * num;
  },
  numberChecker: function (input) {
    input = Number(input);

    if (isNaN(input)) {
      throw new Error("The input is not a number!");
    }

    if (input < 100) {
      return "The number is lower than 100!";
    } else {
      return "The number is greater or equal to 100!";
    }
  },
  sumArrays: function (array1, array2) {
    const longerArr = array1.length > array2.length ? array1 : array2;
    const rounds =
      array1.length < array2.length ? array1.length : array2.length;

    const resultArr = [];

    for (let i = 0; i < rounds; i++) {
      resultArr.push(array1[i] + array2[i]);
    }

    resultArr.push(...longerArr.slice(rounds));

    return resultArr;
  },
};

describe("Tests …", function () {
    it('is object,' ,function(){
        assert.isObject(numberOperations)

    })
  describe("Test PowNumber", function () {
    it("return the power", function () {
      let number = numberOperations.powNumber(2);
      let number1 = numberOperations.powNumber(2.13);
      let number2 = numberOperations.powNumber(-13);
      let number3 = numberOperations.powNumber(-0.312);
      assert.equal(number, 4);
      assert.equal(number1, 4.536899999999999);
      assert.equal(number2, 169);
      assert.equal(number3, 0.097344);
      assert.isNumber(number);
    });
    it("no need validation", function () {
      let number = numberOperations.powNumber("321");
      let number1 = numberOperations.powNumber("2-321");
      let number2 = numberOperations.powNumber("?;[']");

      assert.equal(number, 103041);
      assert.isNotNaN(number);
      assert.isNaN(number1);
      assert.isNaN(number2);
    });
    it("is function", function () {
      assert.isFunction(numberOperations.powNumber);
    });
  });
  describe("Test NumberChecker", function () {
    it("is function", function () {
      assert.isFunction(numberOperations.numberChecker);
    });
    it("is string result", function () {
        let number = numberOperations.numberChecker(12)
        let number2 = numberOperations.numberChecker(200)
        assert.isString(number);
        assert.isString(number2);
      });
    it("parse and validate input should throw error", function () {
        assert.throw(() =>numberOperations.numberChecker('asas'))
        assert.throw(() =>numberOperations.numberChecker('12das'))
        assert.throw(() =>numberOperations.numberChecker('--?dsa'))
    });
    it("right validate", function () {
        let number = numberOperations.numberChecker(12)
        let number1 = numberOperations.numberChecker(200)
        let number2 = numberOperations.numberChecker(-31)
        let number3 = numberOperations.numberChecker(-31.321321)
        let number4 = numberOperations.numberChecker(3120321.321321)
        let number5 = numberOperations.numberChecker(100)
        assert.equal(number,'The number is lower than 100!')
        assert.equal(number1,'The number is greater or equal to 100!')
        assert.equal(number2,'The number is lower than 100!')
        assert.equal(number3,'The number is lower than 100!')
        assert.equal(number4,'The number is greater or equal to 100!')
        assert.equal(number5,'The number is greater or equal to 100!')
      });
  });
  describe("Test sumArrays", function () {
    it("is function", function () {
      assert.isFunction(numberOperations.sumArrays);
    });
    it("is right", function () {
        let array1 = [1,2,3,4,5];
        let array2 = [1,2,3,4,5];
        let arraySum = numberOperations.sumArrays(array1,array2)
        assert.isArray(arraySum);
        assert.equal(arraySum[0],2);
        assert.deepEqual(arraySum,[ 2, 4, 6, 8, 10 ])
      });
      it("is right 2", function () {
        let array1 = ['21','132'];
        let array2 = [1,2,3,4,5];
        let arraySum = numberOperations.sumArrays(array1,array2)
        assert.isArray(arraySum);
       assert.deepEqual(arraySum,[ '211', '1322', 3, 4, 5 ])
      });
      it("is right 3", function () {
        let array1 = ['21','132'];
        let array2 = [1,-3,3,-31.211,5];
        let arraySum = numberOperations.sumArrays(array1,array2)
      //  assert.throw(()=> numberOperations.sumArrays(array1,));
        assert.isArray(arraySum);
       assert.deepEqual(arraySum,[ '211', '132-3', 3, -31.211, 5 ])
      });
      it("is right 4", function () {
        let array1 = [];
        let array2 = [1];
        let arraySum = numberOperations.sumArrays(array1,array2)
        assert.isArray(arraySum);
       assert.deepEqual(arraySum,[1])
      });
      it("is right 5", function () {
        let array1 = [];
        let array2 = [];
        let arraySum = numberOperations.sumArrays(array1,array2)
        assert.isArray(arraySum);
       assert.deepEqual(arraySum,[])
       assert.isEmpty(arraySum)
      });
  });
  // TODO: …
});
