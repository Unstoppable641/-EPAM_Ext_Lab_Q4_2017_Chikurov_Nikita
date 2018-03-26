function startTimer() {
    setInterval(changeTimer, 10);
}

function changeTimer() {
    if (!isPaused) {
        ms--;
        if (ms < 0) {
            ms = 100;
            sec--;
        }
        if (sec < 0)
            toNextPage();
        else
            $(".timer").text((sec < 10 ? "0" : "") + String(sec) + ":" + (ms < 10 ? "0" : "") + String(ms));
    }
}

function toNextPage() {
    isPaused = true;
    var dialogMessage = "Repeat scrolling? (in case of cancellation, the browser window is closed)";
    var indexPage = Number(document.location.href.match(/Page[1-9]/)[0][4]);
    if (indexPage === countPages) {
        if (confirm(dialogMessage))
            document.location.href = "Page1.html";
        else {
            window.close();
        }
    }
    else
        document.location.href = "Page" + String(indexPage + 1) + ".html";
}

function pauseHandler() {
    isPaused = true;
}

function playHandler() {
    isPaused = false;
}

function backHandler() {
    history.back();
}

var countPages = 4;
var isPaused = false;
var sec = 5;
var ms = 0;
