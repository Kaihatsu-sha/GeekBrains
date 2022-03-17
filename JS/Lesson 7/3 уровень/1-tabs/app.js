'use strict';
const texts = {
    text1: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit.',
    text2: 'Далеко-далеко за словесными горами в стране гласных и согласных живут рыбные тексты.',
    text3: 'Проснувшись однажды утром после беспокойного сна, Грегор Замза обнаружил.'
};

/* 
1. Получите ссылку на .text, например с помощью querySelector
2. Получите коллекцию, в которой хранятся все .nav-link, например с помощью querySelectorAll
    2.1 Переберите полученную коллекцию, например с помощью forEach, и каждой ссылке назначьте
    обработчик клика функцию clickHandler.
*/

let aTag = document.querySelectorAll(".nav-link");
let text = document.querySelector(".text");
aTag.forEach(a => a.addEventListener("click",clickHandler));

/**
 * Обработчик клика по .nav-link
 * @param {MouseEvent} event 
 */
function clickHandler(event, index) {
    changeActiveClass(event);
    changeText(event);
    // здесь вызывайте changeText и changeActiveClass, и передавайте
    // им объект события.
   
}

/**
 * Эта функция должна убирать .active у предыдущего .nav-link и ставить его
 * на тот, по которому кликнули.
 * @param {MouseEvent} event 
 */
function changeActiveClass(event) {
    aTag.forEach(a => a.classList.remove("active"));
    event.target.classList.add("active");
}

/**
 * Эта фукнция должна читать текст (например через textContent) из 
 * .nav-link по которому кликнули и в зависимости от этого в .text
 * ставить соответствующий текст из texts.
 * @param {MouseEvent} event 
 */
function changeText(event) {
    let index = "text1";
    switch(event.target.textContent){
        case "Link 1":
            index = "text1";
            break;
        case "Link 2":
            index = "text2";
            break;
        case "Link 3":
            index = "text3";
            break;
    }
    text.innerHTML = texts[index];
}