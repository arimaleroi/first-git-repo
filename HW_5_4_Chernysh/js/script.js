function func(num) {
    
    let n = 0;

    return function(num) {
      n += num;
      return n;
    }
  }
  
  let sum = func();
   
  console.log(sum(3)); 
  console.log(sum(5)); 
  console.log(sum(228)); 


function func2() {

    let arr = [];

    return function(value){
        if (value != undefined) {
            arr.push(value);
        }
        else {
            arr = [];
        }
        return arr;
    }
}

    let arrFunc = func2();

console.log(arrFunc(777));
console.log(arrFunc('qwe'));
console.log(arrFunc(1));
console.log(arrFunc());