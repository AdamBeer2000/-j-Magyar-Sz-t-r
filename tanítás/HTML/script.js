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