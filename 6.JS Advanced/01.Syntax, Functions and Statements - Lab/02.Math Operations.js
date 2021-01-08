function mathOperations (x,y,z)
{
  let calculate = 0;
   if (z == '+') {
     calculate = x + y;
   }
   else if (z == '-') {
    calculate = x - y;
   } 
    else if (z == '*') {
    calculate = x * y;
   }
   else if (z == '/') {
    calculate = x / y;
   }
   else if (z == '%') {
    calculate = x % y;
   }
   else if (z == '**') {
    calculate = x ** y;
   }

   console.log(calculate);
}

mathOperations(100,5,'/');