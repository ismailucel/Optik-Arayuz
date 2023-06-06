

const buttons = document.querySelectorAll('.button');
const blockeds = document.querySelectorAll('.blocked');

buttons.forEach(item => {
    item.addEventListener('mousedown', clicked);
}); 
blockeds.forEach(item => {
    item.removeEventListener('mousedown', clicked);
});


function clicked(e) {
    console.log("aaa");
    var path = window.location.pathname;
    var right = document.querySelector("#box");
    if (right != null) {
        right.remove();
    }
    var id = parseInt(e.srcElement.id);
    var link = "";

    if (path.includes("ExamPapers")) {
        link = "/ExamPapers";
    }
    else if (path.includes("Announcements")) {
        link = "/Admin/Announcements";
    }
    else if (path.includes("Exams")) {
        link = "/Exams";
    }
    else if (path.includes("Faculties")) {
        link = "/Admin/Faculties";
    }
    else if (path.includes("Departments")) {
        link = "/Admin/Departments";
    }
    
    console.log(link);
    if (e.srcElement.classList.contains("Details")) {
        link = link+ "/Details";

    }
    else if (e.srcElement.classList.contains("Delete")) {
        link = link + "/Delete/" + id;

    }
    else if (e.srcElement.classList.contains("Edit")) {
        link = link + "/Edit/"+id;

    }

    $.get(link, { id: id }, function (data) {
       
        let box = document.createElement('div');
        box.innerHTML = data;
        box.classList.add('new-box');
        box.id = "box";

        document.querySelector("#rightContent").appendChild(box);
    });

}
