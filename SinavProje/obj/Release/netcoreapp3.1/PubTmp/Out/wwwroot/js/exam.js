$(document).ready(function () {

    $('form').submit(function () {
        var request = {
            Exam: {
                UserId: parseInt($("#UserId", this).val()),
                Title: $("#ExamTitle", this).text(),
                Content: $("#ExamContent", this).text()
            },
            Questions: []
        }

        console.log(request);

        for (var i = 1; i < 5; i++) {
            request.Questions.push({
                QNumber: i,
                Q: $("#Q" + i, this).val(),
                Answer: $("#Answer" + i, this).val(),
                A: $("#A" + i, this).val(),
                B: $("#B" + i, this).val(),
                C: $("#C" + i, this).val(),
                D: $("#D" + i, this).val()
            });
        }
        var jsonData = JSON.stringify(request);
        console.log(jsonData);
        $.ajax({
            contentType: 'application/json',
            type: "POST",
            url: "/Exam/AddExam",
            data: jsonData,
            success: function () {
            }
        });
    });
});


function getArticle(id) {
    var xy = "myDIV-" + id;
    var x = document.getElementById(xy);

    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}