
"use strict";
function ConvertFromTcToTf(temperature) {
    let temperatureF = ((9 / 5) * temperature) + 32;
    console.log("Temperature in: " + temperature + ", convert temperature: " + temperatureF);
}

function ShowAdminName() {
    let admin = "Vasilyi";
    let name = admin;
    console.log(name);
}

function Why() {
    /*
    1. 10 прибавить 10 получаем 20
    2. 20 добавить текст 10 получаем текст 2010, число 20 неявно приводится к строке
    3. присвоить переменной rezult1 значение 2010
    4. с помощью console.log выводим result1 в консоль
    */
    var rezult1 = 10 + 10 + "10";
    console.log(rezult1);

    /*
    1. 10 прибавить текст 10 получаем 1010, число 10 неявно приводится к строке
    2. 1010 прибавить текст 10 получаем текст 101010, число 10 неявно приводится к строке
    3. присвоить переменной rezult2 значение 101010
    4. с помощью console.log выводим result2 в консоль
    */
    var rezult2 = 10 + "10" + 10;
    console.log(rezult2);

    /*
    1. строку "10" приводится к типу number унарным оператором +
    2. число 10 складывается с числом 10 получается 20
    3. к числу 20 прибавляется приведенное число 10 получается 30
    4. с помощью console.log выводим result3 в консоль
    */
    var rezult3 = 10 + 10 + +"10";
    console.log(rezult3);

    /*
    1. строку "2,5" не удается привести унарным оператором + к типу number
    2. число 10 делится на строку
    3. получаем: не число!
    4. с помощью console.log выводим result4 в консоль
    */
    var rezult4 = 10 / -"";
    console.log(rezult4);

    /*
    1. строку "2,5" не удается преобразовать унарным оператором + к типу number
    2. число 10 делится на строку
    3. получаем: не число!
    4. с помощью console.log выводим result5 в консоль
    */
    var rezult5 = 10 / +"2,5";
    console.log(rezult5);
}