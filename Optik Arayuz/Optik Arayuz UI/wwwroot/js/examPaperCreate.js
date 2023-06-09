const box = document.querySelector(".A4");
const deleteBox = document.querySelector("#delete");
const items = document.querySelectorAll('.item');
const right = document.querySelector(".right");
const button = document.querySelector("#button");

var count = {
    "Number" :1,
    "Choice": 1,
    "Student": 1,
    "Test": 1,
    "Grade": 1,
    "Logo": 1,
    "Text": 1,
}
var clickedId = "";
var tempx = 0;
var tempy = 0;


//Edit sayfasý olup olmadýðý kontol ediliyor. Edit sayfasý ise path yoluyla id deðeri alýnýyor.
var getValue = () => {
    var path = window.location.pathname.split("/");
    try {
        return parseInt(path[path.length - 1]);
    } catch (error) {
    }
};
var idValue = getValue();

if (Number.isInteger(idValue)) {
    //Ýd var ise Edit sayfasýdýr. Veritabanýndan componentleri getiren ExamPapersContollerstan getExamPaperComponents fonksiyonu çaðrýlýyor.
    var link = "/ExamPapers/getExamPaperComponents";
    $.get(link, { id: idValue }, function (data) {
        var draggable = document.getElementById("Number");
        var components = data.split("/");
        components.forEach(function (component) {
            var values = component.split("_");

            //Her Elementin deðerleri atanarak A4 divine ekleniyor.
            let clone = draggable.cloneNode(true);
            clone.style.top = values[2] + "px";
            clone.style.left = values[1] + "px";
            clone.style.position = "absolute";
            clone.style.margin = "0px";
            clone.classList.add("on");
            var link = "/ComponentsPartial/" + values[0];

            clone.id = values[0] + count[values[0]];
            var sendvalue = count[values[0]].toString();
            count[values[0]] += 1;
            clickedId = clone.id;

            //Elementin deðerleri atandýktan sonra partialviewini oluþturmak için controllerýna istek atýlýyor.
            $.get(link, { value: sendvalue }, function (data) {
                $('#' + clone.id).html(data);
            });

            box.appendChild(clone);
            clone.addEventListener('dragstart', dragStart);
            clone.addEventListener('mousedown', mouseDown);

        });
        
    });
}


//EventListenerlar ayarlanýyor.
button.addEventListener('click', clicked);
items.forEach(item => {
    item.addEventListener('dragstart', dragStart);
    item.addEventListener('mousedown', mouseDown);

});
deleteBox.addEventListener('drop', deleteBoxdrop);
right.addEventListener('mouseenter', mouseEnter);
box.addEventListener('dragenter', dragEnter)
box.addEventListener('dragover', dragOver);
box.addEventListener('dragleave', dragLeave);
box.addEventListener('drop', drop);
deleteBox.addEventListener('dragover', deletedragOver);
deleteBox.addEventListener('drop', deleteBoxdrop);

//Componentlerin veri tabanýna gönderilmesini saðlayan fonksiyon.
function clicked() {
    var paperitems = getPaperItems();
    var values = "";
    //Her elementin konum bilgileri tek bir string valuesine ekleniyor. Diðer bilgileri zaten componentspartialýn statik deðiþkenlerinde mevcut.
    for (var i = 0; i < paperitems.length; i++) {
        values = values +"/"+ paperitems[i].id +"_"+ parseInt(paperitems[i].style.left, 10) +"_"+ parseInt(paperitems[i].style.top, 10);
    }


    var link = "/ExamPapers/SendDatabase";
    //Eðer edit sayfasýysa gönderilen deðerin baþýna exampaper id numarasý yazýlýyor
    if (!isNaN(idValue)) {
        values = idValue + "+" + values;
    }
    else {
        values = values.substr(1);
    }
    $.get(link, { value: values }, function (data) {
        if (data == "true") {
            location.replace("https://localhost:7061/")
        }
    });
}

//Týklanan Componentin Ýnput viewi ve deðerleri alýnýyor.
function mouseDown(e) {
    var mouse = window.event;
    var coordinat = box.getBoundingClientRect();
    var x = (mouse.clientX - Math.round(coordinat.left));
    var y = (mouse.clientY - Math.round(coordinat.top));
    var temp = e.srcElement;
    while (1) {
        if (temp.classList.contains("item")) {
            break;
        }
        temp = temp.parentElement;
    };
    tempx = x - parseInt(temp.style.left, 10);
    tempy = y - parseInt(temp.style.top, 10);
    clickedId = temp.id;
    var id = temp.id;
    var link = "/ComponentsPartial/Inputs/" + id;
    $.get(link, function (data) {
        $('#right').html(data);
    });

}


function mouseEnter() {
    var inputs = document.getElementsByClassName("input");
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener('change', Change);
    }

    const fileform = document.querySelector("#fileform");
    if (fileform != null) {
        fileform.addEventListener('submit', submit);

    }
}
//Ýnput deðeri deðiþtiði zaman deðiþen componentin yeni viewini getiren fonksiyon
function Change(e) {
    var id = clickedId;
    var inputs = document.getElementsByClassName("input");
    var values = "";

    for (var i = 0; i < inputs.length; i++) {

        values = values + inputs[i].value + "/";
    }
    values = values + clickedId;
    id = id.substring(0, (id.length - 1));
    var link = "/ComponentsPartial/" + id;
    $.get(link, { value: values }, function (data) {
        $('#' + clickedId).html(data);
    });
}

function deletedragOver(e) {
    e.preventDefault();
}

//Delete box fonksiyonu. Elementi siliyor.
function deleteBoxdrop(e) {
    const id = e.dataTransfer.getData('text/plain');
    const element = document.getElementById(id);
    element.remove();
    deleteBox.classList.remove("delete");
    deleteBox.classList.add("none");
}

function dragStart(e) {
    e.dataTransfer.setData('text/plain', e.currentTarget.id);
    var element = document.getElementById(e.currentTarget.id);
    if (element.classList.contains("on")) {
        deleteBox.classList.remove("none");
        deleteBox.classList.add("delete");
    }
    
}
function dragEnter(e) {
    e.preventDefault();
    box.classList.add("dragging");
}
function dragOver(e) {
    e.preventDefault();
    box.classList.add("dragging");
}
function dragLeave(e) {
    box.classList.remove("dragging");
}


function drop(e) {
    deleteBox.classList.remove("delete");
    deleteBox.classList.add("none");
    var coordinat = box.getBoundingClientRect();
    var mouse = window.event;
    box.classList.remove("dragging");
    const id = e.dataTransfer.getData('text/plain');
    const draggable = document.getElementById(id);
    var x = (mouse.clientX - Math.round(coordinat.left)) + "px";
    var y = (mouse.clientY - Math.round(coordinat.top)) + "px";

    if (draggable.classList.contains("on")) {
        x = parseInt(x, 10) - tempx + "px";
        y = parseInt(y, 10) - tempy + "px";
        
        if (!checkCollide(draggable, x, y)) {
            draggable.style.top = y;
            draggable.style.left = x;
        } else {
            alert("Buraya Koyamazsiniz");
        }
        
        
    }
    else {
        let clone = draggable.cloneNode(true);
        clone.style.top = y;
        clone.style.left = x;
        clone.style.position = "absolute";
        clone.style.margin = "0px";
        clone.classList.add("on");
        var link = "/ComponentsPartial/" + clone.id;

        clone.id = clone.id + (count[draggable.id]);
        count[draggable.id] = count[draggable.id] + 1;
        clickedId = clone.id;
        $.get(link, function (data) {
            $('#' + clone.id).html(data);
        });

        box.appendChild(clone);
        clone.addEventListener('dragstart', dragStart);
        clone.addEventListener('mousedown', mouseDown);


    }
}

//A4 divinin içerisindeki bütün elementleri getiren fonksiyon
function getPaperItems() {
    return box.getElementsByClassName("item");
}

//Collision tespit eden fonksiyonlar
function isCollide(a, b, x, y) {
    var atop = parseInt(a.style.top, 10);
    var aleft = parseInt(a.style.left, 10);
    var btop = parseInt(y, 10);
    var bleft = parseInt(x, 10);
    if ((aleft <= bleft && bleft <= aleft + a.offsetWidth) || (bleft <= aleft && aleft <= bleft + b.offsetWidth)) {
        if ((atop <= btop && btop <= atop + a.offsetHeight) || (btop <= atop && atop <= btop + b.offsetHeight)) {
            return true;
        }
    }
    else { return false; }
}
function boxIsCollide(b, x, y) {
    var a = box.getBoundingClientRect();
    var btop = parseInt(y, 10);
    var bleft = parseInt(x, 10);
    if ((bleft + b.offsetWidth) >= (a.width) || (bleft <= 0)) {
        return true;
    }
    else if (btop + b.offsetHeight >= a.height || btop <= 0) {
        return true;
    }
    else { return false; }
}
function checkCollide(element, x, y) {
    var paperItems = getPaperItems();
    for (let i = 0; i < paperItems.length; i++) {
        if (!(paperItems[i].id == element.id)) {
            if (isCollide(paperItems[i], element, x, y)) {
                return true;
            }
            else if (boxIsCollide(element, x, y)) {
                return true;
            }
        }
    }
    return false;
}


//Logo Componentinin inputunun Controllera Dosya göndermesini saðlayan fonksiyon.
function submit(e) {
    e.preventDefault();
    var sendvalue = clickedId.substring(clickedId.length - 1);
    var formData = new FormData();
    formData.append('file', $('#file')[0].files[0]); // myFile is the input type="file" control
    formData.append('index', sendvalue);
    $.ajax({
        url: "/ExamPapers/UploadLogo",
        type: "POST",
        data: formData,
        processData: false, // Not to process data  
        contentType: false, // Not to set any content header  
        success: function (result) {
            var id = clickedId.substring(0, clickedId.length - 1);

            var link = "/ComponentsPartial/" + id;

            $.get(link, { value: sendvalue }, function (data) {
                $('#' + clickedId).html(data);
            });
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
    

}