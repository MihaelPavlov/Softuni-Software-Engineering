function circleOfArea (x){

  let inputType =typeof(x);

  if (inputType== 'number') {
    result = Math.pow(x,2)*Math.PI;
    console.log(result.toFixed(2));
  }
  else{
    console.log('We can not calculate the circle area, because we receive a '+ inputType +'.');
  }
}

circleOfArea(5);