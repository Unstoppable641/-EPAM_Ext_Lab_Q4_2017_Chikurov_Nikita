function SplitString(str, separators) {
    var stringsArr = [];
    var curStr = 0;
    for (var i = 0; i < str.length; i++) {
        if (separators.indexOf(str[i]) === -1)
            stringsArr[curStr] += str[i];
        else if (stringsArr[curStr].length > 0) {
            curStr++;
            stringsArr[curStr] += str[i];
        }
    }
    return stringsArr;
}

function CountOccurrences(str, symbol) {
    var count = 0;
    for (var i = 0; i < str.length; i++) {
        if (str[i] === symbol)
            count++;
    }
    return count;
}

function RemoveSymbol(str, symbol) {
    var resultStr = "";
    for (var i = 0; i < str.length; i++)
        if (str[i] !== symbol)
            resultStr += str[i];
    return resultStr;
}

function RemoveDuplicates(str) {
    var resultString = str;
    var words = SplitString(str, " \t?!:;,.");
    for (var j = 0; j < words.length; j++) {
        for (var i = 0; i < words[j].length; i++) {
            if (CountOccurrences(words[j], words[j][i]) > 1)
                resultString = RemoveSymbol(resultString, words[j][i]);
        }
    }
    return resultString;
}

function ButtonHandler() {
    var fieldWithText = document.getElementById("mainField").value;
    alert(RemoveDuplicates(fieldWithText));
}
