"use strict"
let msg1 = "hello";
let msg2 = "love";
alert(msg1);
alert(msg2);

alert(2/0);
alert(`one and one is ${1+1}`);

let msg3 = prompt("enter name:", "");

if(null != msg3)
{
    alert(`you entered ${msg3}`);
}

let confirmed = confirm("have yoe entered your name?");
if(confirmed)
{
    alert("good for you!");
}
else{
    alert("what a waste...");
}