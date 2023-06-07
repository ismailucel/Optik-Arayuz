var button = document.querySelector("#copy");
var alerttext = localStorage.getItem("alert");
if (alerttext != null) {
    var text = document.getElementById("alert");
    text.innerText = alerttext;
    var name1 = document.getElementById("name");
    name1.value = localStorage.getItem("name");
    var test = document.getElementById("test");
    test.value = localStorage.getItem("test");
    var classic = document.getElementById("classic");
    classic.value = localStorage.getItem("classic");
    localStorage.removeItem("alert");
    localStorage.removeItem("name");
    localStorage.removeItem("test");
    localStorage.removeItem("classic");

}

button.addEventListener('mousedown', clicked);
var select = document.getElementById("select");
var lastValue = select.options[select.options.length - 1].value;
select.value = lastValue;
function clicked() {
    var select = document.getElementById("select");
    var id = select.value;
    var link = "/ExamPapers/ExamPaperCopy";
    var name = document.getElementById("name").value;
    var test = document.getElementById("test").value;
    var classic = document.getElementById("classic").value;
    $.get(link, { id: id }, function (a) {
        if (a == true) {
            var text = "Kopyalanan Kağıdı Sınav Kağıdı Sekmesineden Düzenleyebilirsiniz";
            localStorage.setItem("alert", text);
            localStorage.setItem("name", name);
            localStorage.setItem("test", test);
            localStorage.setItem("classic", classic);
            location.reload();
        }
    });
   

}