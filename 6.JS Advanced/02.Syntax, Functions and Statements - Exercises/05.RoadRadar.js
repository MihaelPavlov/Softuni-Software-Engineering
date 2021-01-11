function solve(speed , area){

  var limit = 0 ;

  if (area=='motorway') {
    limit = 130 ; 
  }
  else if(area =='interstate'){
    limit = 90 ; 
  }
  else if(area =='city'){
    limit = 50 ; 
  }
  else if(area =='residential'){
    limit = 20 ; 
  }

  let speedOverTheLimit = limit-speed;


    if (speedOverTheLimit>=-20) {
      console.log(`Driving ${speed} km/h in a ${limit} zone`)
  
    }
    else if (speedOverTheLimit <= 20) {
      console.log(`The speed is ${speedOverTheLimit} km/h faster than the allowed speed of ${limit} - speeding`);
    }
    else if (speedOverTheLimit <= 40) {
      console.log(`The speed is ${speedOverTheLimit} km/h faster than the allowed speed of ${limit} - excessive speeding`);
    }
    else {
      console.log(`The speed is ${speedOverTheLimit} km/h faster than the allowed speed of ${limit} - reckless driving`);
    }    
 
}
solve('40','city');
solve('21','residential');
solve('120','interstate');
solve('200','motorway')