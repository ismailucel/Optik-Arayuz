var button = document.querySelector("#copy");
var alerttext = localStorage.getItem("alert");
if (alerttext != null) {
    var text = document.getElementById("alert");
    text.innerText = alerttext;
    localStorage.removeItem("alert");

}

button.addEventListener('mousedown', clicked);
var select = document.getElementById("select");
var lastValue = select.options[select.options.length - 1].value;
select.value = lastValue;
function clicked() {
    var select = document.getElementById("select");
    var id = select.value;
    var link = "/ExamPapers/ExamPaperCopy";
    $.get(link, { id: id }, function () {
        var text = "Kopyalanan Kağıdı Sınav Kağıdı Sekmesineden Düzenleyebilirsiniz";
        localStorage.setItem("alert", text);
        location.reload();
    });
   

}