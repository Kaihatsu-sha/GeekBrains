
"use strict";
function Task1() {
    //1. Объясните почему код даёт именно такие результаты?
    //пример 1
    let a = 1, b = 1, c, d;
    c = ++a;
    alert(c); // ответ: 2
    /*
    1. инициализация переменных a = 1 типа number
    2. предфиксный инкремент увеличивает а на 1 и возвращает результат получается 2
    3. переменной с присваивается значение а. а имеет значение 2
    5. вывод с помощью alert() получаем 2
    */
    //пример 2
    d = b++;
    alert(d); //ответ: 1
    /*
    1. инициализация переменных b = 1 типа number
    2. постфиксный инкремент возвращает результат
    3. переменной d присваивается значение b, d имеет значение  1
    4. постфиксный инкремент увеличивает значение b на 1, b имеет значение 2
    5. вывод с помощью alert() получаем 1
    */
    //пример 3
    c = 2 + ++a;
    alert(c); //ответ: 5
    /*
    1. переменная a имеет значение 2
    2. предфиксный инкремент увеличивает а на 1 и возвращает результат получается 3
    3. 2 прибавить 3 получается 5
    4. переменной c присваивается значение выражения 5
    5. вывод с помощью alert() получаем 5
    */
    //пример 4
    d = 2 + b++;
    alert(d); //ответ: 4
    alert(a); //3
    alert(b); //3
    /*
    1. переменная b имеет значение 2
    2. постфиксный инкремент возвращает результат 2
    3. 2 прибавить 2 получается 4
    4. постфиксный инкремент увеличивает значение b на 1, b имеет значение 3
    5. переменной d присваивается значение выражения 4
    6. вывод с помощью alert() получаем 4
    */
}
function Task2() {
    //2. Чему будут равны переменные x и a в примере ниже? Написать почему так произошло
    //(описать последовательность действий).

    let a = 2;
    let x = 1 + (a *= 2);
    console.log(x);//5
    /*
    1. вычисляется выражение (a *= 2) т.к.  у скобок приоритет выше
    2. выражение (a *= 2) равняется выражению а = а * 2, получается значение переменной a умножается на 2 и присвается переменной а
    3. 1 прибавить 4, получается 5
    4. переменной x присваивается значения выражения, получается 5
    */
}
function Task3() {
    //3. Объявить две переменные a и b и задать им целочисленные произвольные начальные значения.
    //Затем написать скрипт, который работает по следующему принципу:
    //- если a и b положительные, вывести их разность (ноль можно считать положительным числом);
    //- если а и b отрицательные, вывести их произведение;
    //- * (этот пункт по сложнее, делайте по желанию) если а и b разных знаков, вывести их сумму;

    let numberA = 3;
    let numberB = -4;

    let isPositiveNumberA = numberA >= 0;
    let isPositiveNumberB = numberB >= 0;

    if (isPositiveNumberA && isPositiveNumberB) {
        let diff = numberA - numberB;
        console.log("A and B > 0 :" + diff);
    } else if (!isPositiveNumberA && !isPositiveNumberB) {
        let multi = numberA + numberB;
        console.log("A and B < 0 :" + multi);
    } else if (isPositiveNumberA || isPositiveNumberB) {
        let summ = numberA + numberB;
        console.log("A or B <> 0 :" + summ);
    }
}

//4. Реализовать основные 4 арифметические операции (+, -, /, *) в виде функций с
//двумя параметрами. Т.е. например, функция для сложения должна принимать два числа,
//складывать их и возвращать результат. Обязательно использовать оператор return.

/**
 * Сложение двух чисел
 * @param {number} numberA 
 * @param {number} numberB 
 * @returns результат сложения
 */
function Addition(numberA, numberB) {
    return numberA + numberB;
}

function Subtraction(numberA, numberB) {
    return numberA - numberB;
}

function Dividing(numberA, numberB) {
    return numberA / numberB;
}

function Multiplication(numberA, numberB) {
    return numberA * numberB;
}

//5. Реализовать функцию с тремя параметрами: function mathOperation(arg1, arg2, operation),
//где arg1, arg2 – значения аргументов, operation – строка с названием операции. В зависимости от
//переданного значения операции (использовать switch) выполнить одну из арифметических операций
//(использовать функции из задания 4) и вернуть полученное значение.
function mathOperation(arg1, arg2, operation) {
    switch (String(operation).toLowerCase()) {
        case "add":
            return Addition(arg1, arg2);
        case "sub":
            return Subtraction(arg1, arg2);
        case "div":
            return Dividing(arg1, arg2);
        case "mul":
            return Multiplication(arg1, arg2);
        default:
            console.log("Bad operation :" + operation);
    }
}
let rezult = null;
let arg1 = 10;
let arg2 = 8;
rezult = mathOperation(arg1, arg2, "add");
console.log(`rezult add operation(${arg1},${arg2}):${rezult}`);
rezult = mathOperation(arg1, arg2, "sub");
console.log(`rezult sub operation(${arg1},${arg2}):${rezult}`);
rezult = mathOperation(arg1, arg2, "div");
console.log(`rezult div operation(${arg1},${arg2}):${rezult}`);
rezult = mathOperation(arg1, arg2, "blabla");
console.log(`rezult blabla operation(${arg1},${arg2}):${rezult}`);
rezult = mathOperation(arg1, arg2, "mul");
console.log(`rezult mul operation(${arg1},${arg2}):${rezult}`);