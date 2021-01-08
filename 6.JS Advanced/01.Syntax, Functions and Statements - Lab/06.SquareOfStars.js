function squareOfStarts(x){

  if (x === undefined) {
   calculation(5);
    return;
  }

  calculation(x);
}

function calculation (x){
  let result = '';
  for (let index = 0; index < x; index++) {
    for (let index1 = 0;index1 < x; index1++) {
     result+='* ';
      
    }
  result+='\n';
  }
  console.log(result);
}
squareOfStarts()