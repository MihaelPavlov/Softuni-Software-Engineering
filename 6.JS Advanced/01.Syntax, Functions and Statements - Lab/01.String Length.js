function stringLength (x,y,z )
{
  let counter = 0; 
  counter+= x.length +y.length+ z.length;
  
  console.log(counter);
  var average = Math.floor(counter/3);
  console.log(average);
} 

stringLength('chocolate' ,'ice gream', 'cake')