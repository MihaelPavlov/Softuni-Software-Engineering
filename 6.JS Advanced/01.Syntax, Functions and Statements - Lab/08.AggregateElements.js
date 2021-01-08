function aggregateFunction(params){
  let input = params.map(Number);
  let sum =0 ;
  for (let index = 0; index < input.length; index++) {
    sum+=input[index];
    
  }
  console.log(sum);

  let sum2 = 0 ;
  for (i = 0; i < input.length; i++) {
    sum2 += 1 / input[i];
}
 
  console.log(sum2)

  let resultConcat = '';

  for (let index = 0; index < input.length; index++) {
    resultConcat+=input[index];
  }
  console.log(resultConcat);
}

aggregateFunction([1,2,3]);