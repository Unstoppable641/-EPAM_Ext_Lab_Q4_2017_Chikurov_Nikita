function buttonSelectorHandler(element, boxFrom, boxTo) {
    $("#" + boxFrom + " option" + (element.value === ">" || element.value === '<' ? ":selected" : "")).each(function () {
        $("#" + boxTo).append(new Option(this.text, this.value));
        this.remove();
        window.countChangedElements++;
    });
    if (window.countChangedElements === 0)
        alert("no available to move !");
}