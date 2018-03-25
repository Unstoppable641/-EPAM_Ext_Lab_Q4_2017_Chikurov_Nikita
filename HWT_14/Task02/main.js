function GetResult(sourceString) {
    var arguments = sourceString.split(/ ?[\+\-\*\/=] ?/);
    var operations = sourceString.match(/[\+\-\*\/]/g);
    arguments.pop();
    var result = Number(arguments[0]);
    for (var i = 1; i < arguments.length; i++) {
        switch (operations[i - 1]) {
            case "+":
                result += Number(arguments[i]);
                break;
            case "-":
                result -= Number(arguments[i]);
                break;
            case "*":
                result *= Number(arguments[i]);
                break;
            case "/":
                result /= Number(arguments[i]);
                break;
            default:
                break;
        }
    }

    return result.toFixed(2);
}

function ButtonExpressionHandler() {
    var fieldWithText = document.getElementById("fieldExpression").value;
    alert(GetResult(fieldWithText));
}