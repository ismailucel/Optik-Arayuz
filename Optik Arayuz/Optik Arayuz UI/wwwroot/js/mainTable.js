

const buttons = document.querySelectorAll('.button');
const blockeds = document.querySelectorAll('.blocked');

buttons.forEach(item => {
    item.addEventListener('mousedown', clicked);
}); 
blockeds.forEach(item => {
    item.removeEventListener('mousedown', clicked);
});


function clicked(e) {
    var path = window.location.pathname;
    var right = document.querySelector("#box");
    if (right != null) {
        right.remove();
    }
    var id = parseInt(e.srcElement.id);
    var link = "";
    if (path.contains("ExamPapers")) {

    }
    else if (path.contains("ExamPapers")) {

    }
    if (e.srcElement.classList.contains("Details")) {
        link = "/ExamPapers/Details";

    }
    else if (e.srcElement.classList.contains("Delete")) {
        link = "/ExamPapers/Delete/" + id;

    }
    else if (e.srcElement.classList.contains("Edit")) {
        link = "/ExamPapers/Edit/"+id;

    }
    $.get(link, { id: id }, function (data) {
       
        let box = document.createElement('div');
        box.innerHTML = data;
        box.classList.add('new-box');
        box.id = "box";

        document.querySelector("#rightContent").appendChild(box);
    });

}
