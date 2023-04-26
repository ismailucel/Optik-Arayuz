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
    $(document).ready(function () { 
        $.get("/ComponentsPartial/NumaraKodlama", function (data) {
            $('#NumaraKodlama').html(data);
            console.log(e);
        });
    });
    e.preventDefault();
    box.classList.add("dragging");
    e.dataTransfer.setData('text/plain', e.target.id);
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
    let clone = draggable.cloneNode(true);
    clone.style.top=(mouse.clientY-Math.round(coordinat.top))-32+"px";
    clone.style.left = (mouse.clientX - Math.round(coordinat.left)) - 32 + "px";
    if(!(checkCollide(clone))){
        if(draggable.classList.contains("on")){
            draggable.style.top=(mouse.clientY-Math.round(coordinat.top))-32+"px";
            draggable.style.left=(mouse.clientX-Math.round(coordinat.left))-32+"px";
        }
        else{
            clone.style.position="absolute";
            clone.classList.add("on");
            clone.id = clone.id+(sayac++);
            box.appendChild(clone);
            clone.addEventListener('dragstart', dragStart);
        }
    }
    else{
        alert("ss");
    }
    
}

function getPaperItems(){
    return box.getElementsByClassName("item");
}

function isCollide(a, b) {
    var atop = parseInt(a.style.top,10);
    var aleft= parseInt(a.style.left,10);
    var btop = parseInt(b.style.top,10);
    var bleft= parseInt(b.style.left,10);
    
    if(
        aleft < bleft+ b.offsetWidth && 
        aleft+ a.offsetWidth > bleft &&
        atop < btop+ b.offsetHeight && 
        atop + a.offsetHeight > btop){
        return true;
    }
    else{return false;}
}

function checkCollide(x){
    var paperItems = getPaperItems();
    for(let i=0;i< paperItems.length;i++){
        if(!(paperItems[i] == x)){
            if(isCollide(paperItems[i],x)){
                return true;
            }
            
        }
    }
    return false;
}

$("#btnIslemYap").click(function () {
    console.log("sa");
    $.get("/ComponentsPartial/NumaraKodlama", function (data) {
        console.log("saa");

        $('#div11').html(data);
    });
});
