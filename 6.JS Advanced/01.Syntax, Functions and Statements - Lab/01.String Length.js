function stringLength (x,y,z )
{
  let counter = 0;
  let strings =[x,y,z];
  for (let index = 0; index < strings.length; index++)
   {
     for (let index1 = 0; index1 < strings[index].length; index1++)
      {
            counter++;
      }
  }
  console.log(counter);
var average = Math.floor(counter/3);
console.log(average);
} 

stringLength('chocolate' ,'ice gream', 'cake')