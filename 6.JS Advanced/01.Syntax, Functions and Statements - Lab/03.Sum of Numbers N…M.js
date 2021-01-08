function sumOfNumbers(n,m)
{
  let startNumber= parseFloat(n);
  let endNumber = parseFloat(m);

  let sum = 0;

  for (let index = startNumber; index <= endNumber; index++) {
    sum+=index;
    
  }
  return sum;
}

console.log(sumOfNumbers(-8,20));