var ertek = document.getElementById("in");
ertek.addEventListener("keyup", function(event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        document.getElementById("doit").click();
    }
});

function doit(){
    var q = document.getElementById("in").value;
    document.getElementById("harmadik").innerHTML = q;
}

function Hozzaad(){
    var n = document.createElement("LI");
    var text = document.createTextNode("Also szöveg");
    n.appendChild(text);
    document.getElementById("lista1").appendChild(n);
}

$(document).ready(function(){

    $("input#dark").click(function(){
        console.log("lefut a dark");
      $("body").css({"background-color": '#161616'});
    });
  
    $("input#light").click(function(){
        console.log("lefut a light");
      $("body").css({"background-color": '#8ec2ff'});
    });

    
  
  });