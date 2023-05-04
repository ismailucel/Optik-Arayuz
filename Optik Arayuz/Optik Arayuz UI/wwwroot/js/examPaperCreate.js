const box = document.querySelector(".A4");
const items = document.querySelectorAll('.item');
 
var sayac = 0;
items.forEach(item => {
    item.addEventListener('dragstart', dragStart);
});

if (box != null) {
    box.addEventListener('dragenter', dragEnter)
    box.addEventListener('dragover', dragOver);
    box.addEventListener('dragleave', dragLeave);
    box.addEventListener('drop', drop);
}


function dragStart(e) {
    e.dataTransfer.setData('text/plain', e.target.id);

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
    var coordinat = box.getBoundingClientRect();
    var mouse = window.event;
    box.classList.remove("dragging");
    const id = e.dataTransfer.getData('text/plain');
    const draggable = document.getElementById(id);
    var x = (mouse.clientX - Math.round(coordinat.left)) - 32 + "px";
    var y = (mouse.clientY - Math.round(coordinat.top)) - 32 + "px";
    if (draggable.classList.contains("on")) {    
        if (!checkCollide(draggable,x,y)) {
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
        var link = "/ComponentsPartial/"+clone.id; 
        clone.id = clone.id + (sayac++);

        $.get(link, function (data) {
            $('#' + clone.id).html(data);
        });
     
        box.appendChild(clone);
        clone.addEventListener('dragstart', dragStart);
        a = clone.id;
        
    }
}


function getPaperItems(){
    return box.getElementsByClassName("item");
}

function isCollide(a,b,x,y) {
    var atop = parseInt(a.style.top, 10);
    var aleft = parseInt(a.style.left, 10);
    var btop = parseInt(y, 10);
    var bleft = parseInt(x, 10);
    console.log(aleft, atop, a.offsetHeight);
    if ((aleft <= bleft && bleft <= aleft + a.offsetWidth) || (bleft <= aleft && aleft <= bleft + b.offsetWidth)) {
        if ((atop <= btop && btop <= atop + a.offsetHeight) || (btop <= atop && atop <= btop + b.offsetHeight)) {
            return true;
        } 
    }
    else{return false;}
}

function checkCollide(element,x,y) {
    console.log(element.offsetHeight);
    var paperItems = getPaperItems();
    for (let i = 0; i < paperItems.length; i++){
        if(!(paperItems[i].id == element.id)){
            if(isCollide(paperItems[i],element,x,y)){
                return true;
            }
            
        }
    }
    return false;
}


