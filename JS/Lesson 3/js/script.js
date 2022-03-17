
"use strict";
function Task1() {

    let maxNumber = 11;
    let i = 0;
    for (i; i < maxNumber; i++) {
        if (i === 0) {
            console.log(`${i} - это ноль`);
            continue;
        }
        if (i % 2 == 0) {
            console.log(`${i} - четное число`);
        }
        else {
            console.log(`${i} - нечетное число`);
        }
    }
}

function Task2() {
    const post = {
        author: "John", //вывести этот текст
        postId: 23,
        comments: [
            {
                userId: 10,
                userName: "Alex",
                text: "lorem ipsum",
                rating: {
                    likes: 10,
                    dislikes: 2 //вывести это число
                }
            },
            {
                userId: 5, //вывести это число
                userName: "Jane",
                text: "lorem ipsum 2", //вывести этот текст
                rating: {
                    likes: 3,
                    dislikes: 1
                }
            },
        ]
    };

    console.log(post.author);
    console.log(post.comments[0].rating.dislikes);
    console.log(post.comments[1].userId);
    console.log(post.comments[1].text);
}

function Task3() {
    const products = [
        {
            id: 3,
            price: 200,
        },
        {
            id: 4,
            price: 900,
        },
        {
            id: 1,
            price: 1000,
        },
    ];

    products.forEach(function (product) {
        console.log(product.price = product.price * 0.85);
    });
}

function Task4() {
    const products = [
        {
            id: 3,
            price: 127,
            photos: [
                "1.jpg",
                "2.jpg",
            ]
        },
        {
            id: 5,
            price: 499,
            photos: []
        },
        {
            id: 10,
            price: 26,
            photos: [
                "3.jpg"
            ]
        },
        {
            id: 8,
            price: 78,
        },
    ];

    let filterProducts = products.filter(product => product.photos?.length > 0);
    filterProducts.forEach(function (product) {
        console.log(`task 4: ${product.id}`);
    })

    let sortProducts = filterProducts.sort(function compare(a, b) {
        if (a.price < b.price) {
            return -1;
        }
        if (a.price > b.price) {
            return 1;
        }
        return 0;
    });
    sortProducts.forEach(function (product) {
        console.log(`task 4: ${product.id}`);
    });
}

function Task5() {
    let maxNumber = 10;
    let iterator = 0;

    let lastArgs = function () {
        console.log(iterator);
        debugger;
        return ++iterator;
    };
    //lastArgs();
    debugger;
    for (iterator; iterator < maxNumber; lastArgs()) {

    };
}

function Task6() {
    let maxNumber = 20;
    let rezultString = "x";
    for (let i = 0; i < maxNumber; i++) {
        console.log(rezultString);
        rezultString += "x";
    }

}