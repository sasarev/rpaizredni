function zamenjaj() {

    var vredText = document.getElementById("mt").value;
    if (vredText.length == 0) {
        alert("vnesi vrednost");
        return;
    }

    var naslov = document.getElementById("naslov");
    naslov.innerText = vredText;
}