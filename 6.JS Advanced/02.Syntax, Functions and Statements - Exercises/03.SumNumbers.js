function solve(input){

  let digits = input.toString().split('');
  let realDigits = digits.map(Number);

  let isAllNumberTheSame = true;
  let number = parseFloat(realDigits[0]);

  var sum = 0 ;
   for (let index = 0; index < realDigits.length; index++) {
     var parseInt = parseFloat(realDigits[index]);

   if (parseInt != number) {
     isAllNumberTheSame=false;
   }
   sum += parseInt;
   }

 console.log(isAllNumberTheSame)
 console.log(sum);
}

solve(1234);