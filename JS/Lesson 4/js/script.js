
"use strict";
function Task11() {

    //es5
    function Product(name, price) {
        this.name = name;
        this.price = price;
    };

    Product.prototype.make25PercentDiscount = function () {
        this.price = this.price * 0.75;
    }

    let productEs5 = new Product("es5", 100);
    productEs5.make25PercentDiscount();
    console.log(`price: ${productEs5.price} name: ${productEs5.name}`);
    //es6
    class ProductEs6 {
        constructor(name, price) {
            this.name = name;
            this.price = price;
        }

        make25PercentDiscount() {
            this.price = this.price * 0.75;
        }
    }


    let productEs6 = new ProductEs6("es6", 100);
    productEs6.make25PercentDiscount();
    console.log(`price: ${productEs6.price} name: ${productEs6.name}`);
}

function Task12() {

    //es5
    function Post(author, text, date) {
        this.author = author;
        this.text = text;
        this.date = date;
    };

    Post.prototype.edit = function (newText) {
        this.text = newText;
    }

    function AttachedPost(author, text, date) {
        Post.call(this, author, text, date);
        this.highlighted = false;
    }

    AttachedPost.prototype = Object.create(Post.prototype);
    AttachedPost.prototype.constructor = AttachedPost;

    AttachedPost.prototype.makeTextHighlighted = function () {
        this.highlighted = true;
    }

    let attachedPostObj = new AttachedPost("Author", "simple text", "21/01/2022");
    console.log(`author:${attachedPostObj.author} text:${attachedPostObj.text} date:${attachedPostObj.date} highlighted:${attachedPostObj.highlighted}`);
    attachedPostObj.edit("new super text");
    console.log(`author:${attachedPostObj.author} text:${attachedPostObj.text} date:${attachedPostObj.date} highlighted:${attachedPostObj.highlighted}`);
    attachedPostObj.makeTextHighlighted();
    console.log(`author:${attachedPostObj.author} text:${attachedPostObj.text} date:${attachedPostObj.date} highlighted:${attachedPostObj.highlighted}`);
    //es6
    class PostEs6 {
        constructor(author, text, date) {
            this.author = author;
            this.text = text;
            this.date = date;
        }

        edit = function (newText) {
            this.text = newText;
        }
    };

    class AttachedPostEs6 extends PostEs6{
        constructor(author, text, date){
            super(author, text, date);
            this.highlighted = false;
        }

        makeTextHighlighted = function () {
            this.highlighted = true;
        }
    };

    attachedPostObj = new AttachedPostEs6("Author es6", "simple text", "21/01/2022");
    console.log(`author:${attachedPostObj.author} text:${attachedPostObj.text} date:${attachedPostObj.date} highlighted:${attachedPostObj.highlighted}`);
    attachedPostObj.edit("new super text");
    console.log(`author:${attachedPostObj.author} text:${attachedPostObj.text} date:${attachedPostObj.date} highlighted:${attachedPostObj.highlighted}`);
    attachedPostObj.makeTextHighlighted();
    console.log(`author:${attachedPostObj.author} text:${attachedPostObj.text} date:${attachedPostObj.date} highlighted:${attachedPostObj.highlighted}`);
    
}