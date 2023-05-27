const box = document.querySelector(".A4");
const deleteBox = document.querySelector("#delete");
const items = document.querySelectorAll('.item');
const right = document.querySelector(".right");
const button = document.querySelector("#button");
var deleteBoxLocation;

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

var getValue = () => {
    var path = window.location.pathname.split("/");
    try {
        return parseInt(path[path.length - 1]);
    } catch (error) {
    }
};
var idValue = getValue();

if (Number.isInteger(idValue)) {
    var link = "/ExamPapers/getExamPaperComponents";
    $.get(link, { id: idValue }, function (data) {
        var draggable = document.getElementById("Number");
        var components = data.split("/");
        components.forEach(function (component) {
            var values = component.split("_");

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

            $.get(link, { value: sendvalue }, function (data) {
                $('#' + clone.id).html(data);
            });

            box.appendChild(clone);
            clone.addEventListener('dragstart', dragStart);
            clone.addEventListener('mousedown', mouseDown);

        });
        
    });
}



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


function clicked() {
    var paperitems = getPaperItems();
    var values = "";

    for (var i = 0; i < paperitems.length; i++) {
        values = values +"/"+ paperitems[i].id +"_"+ parseInt(paperitems[i].style.left, 10) +"_"+ parseInt(paperitems[i].style.top, 10);
    }



    var link = "/ExamPapers/SendDatabase";
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
    console.log(id);
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
}
function Change(e) {
    var id = clickedId;
    var inputs = document.getElementsByClassName("input");
    var values = "";

    for (var i = 0; i < inputs.length; i++) {

        values = values + inputs[i].value + "/";
    }
    values = values + clickedId;
    id = id.substring(0, (id.length - 1));
    console.log(id);
    var link = "/ComponentsPartial/" + id;
    $.get(link, { value: values }, function (data) {
        $('#' + clickedId).html(data);
    });
}
function dragStart(e) {
    e.dataTransfer.setData('text/plain', e.target.id);
    deleteBox.classList.remove("none");
    deleteBox.classList.add("delete");
    deleteBoxLocation = deleteBox.getBoundingClientRect();
}


function deleteBoxdrop(e) {
    deleteBox.classList.remove("delete");
    deleteBox.classList.add("none");
    console.log("sa");
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
        if (!checkDelete()) {
            if (!checkCollide(draggable, x, y)) {
                draggable.style.top = y;
                draggable.style.left = x;
            } else {
                alert("Buraya Koyamazsiniz");
            }
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
        clone.addEventListener('drop', itemDrop);


    }
}

function checkDelete() {
    var a = deleteBoxLocation;
    var mouse = window.event;
    var btop = mouse.clientY;
    var bleft = mouse.clientX;
    console.log(a, btop, bleft);
    
    return false;
}

function getPaperItems() {
    return box.getElementsByClassName("item");
}

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
    console.log(bleft + b.offsetWidth, a.left + a.width);
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