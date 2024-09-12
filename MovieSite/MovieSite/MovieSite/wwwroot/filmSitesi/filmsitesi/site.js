/* movie wrapper section*/
const arrows = document.querySelectorAll(".arrow");
const list = document.querySelectorAll(".movie-list");
let tiklamaSayisi = 0;
let width = screen.width;
arrows.forEach((arrow, i) => {
    const uzunluk = list[i].querySelectorAll("img").length;


    arrow.addEventListener("click", () => {
        tiklamaSayisi++;
        window.onresize = function () {
            list[i].style.transform = `translateX(0)`;
            tiklamaSayisi = 0;
        }
        const ratio = Math.floor(window.innerWidth / 280);
        if (uzunluk - (6 + tiklamaSayisi) + (6 - ratio) >= 0) {
            const currentTransform = getComputedStyle(list[i]).transform;
            const currentTranslateX = parseInt(currentTransform.split(",")[4]);
            list[i].style.transform = `translateX(${currentTranslateX - 300}px)`;

        }


        else {
            list[i].style.transform = `translateX(0)`;
            tiklamaSayisi = 0;
        }
    });

});

const arrow1 = document.querySelectorAll(".arrow1");

arrow1.forEach((arrow, i) => {
    const uzunluk = list[i].querySelectorAll("img").length;


    arrow.addEventListener("click", () => {

        const ratio = Math.floor(window.innerWidth / 280);
        console.log(tiklamaSayisi);
        if (tiklamaSayisi > 0) {
            tiklamaSayisi--;
            const currentTransform = getComputedStyle(list[i]).transform;
            const currentTranslateX = parseInt(currentTransform.split(",")[4]);
            list[i].style.transform = `translateX(${currentTranslateX + 300}px)`;
            console.log(tiklamaSayisi);

        }

    });

});



/* Payment section*/
var x = 0;

function tikla1() {
    x++;


}
function tikla() {
    if (myform.ad.value == "") {
        var y = document.getElementById("name");
        y.style.border = "1px solid red";
        var z = document.getElementById("demo");
        z.innerHTML = "Lütfen adınızı giriniz."
    }
    else {
        var y = document.getElementById("name");
        y.style.border = "1px solid black";
        var z = document.getElementById("demo");
        z.innerHTML = ""
    }


    if (myform.soyad.value == "") {
        var y = document.getElementById("lastName");
        y.style.border = "1px solid red";
        var z = document.getElementById("demo2");
        z.innerHTML = "Lütfen soyadınızı giriniz."
    }
    else {
        var y = document.getElementById("lastName");
        y.style.border = "1px solid black";
        var z = document.getElementById("demo2");
        z.innerHTML = ""
    }

    if (myform.kartNo.value.length != 16 || isNaN(myform.kartNo.value)) {
        var y = document.getElementById("cardNo");
        y.style.border = "1px solid red";
        var z = document.getElementById("demo3");
        z.innerHTML = "Kart numarasınzı yanlış girdiniz.";
    }
    else {
        var y = document.getElementById("cardNo");
        y.style.border = "1px solid black";
        var z = document.getElementById("demo3");
        z.innerHTML = "";
    }


    if (myform.tarih.value.length != 4 || isNaN(myform.tarih.value)) {
        var y = document.getElementById("Date");
        y.style.border = "1px solid red";
        var z = document.getElementById("demo4");
        z.innerHTML = "Tarihi yanlış girdiniz";
    }
    else {
        var y = document.getElementById("Date");
        y.style.border = "1px solid black";
        var z = document.getElementById("demo4");
        z.innerHTML = "";
    }

    if (myform.güvenlikKod.value.length != 3 || isNaN(myform.güvenlikKod.value)) {
        var y = document.getElementById("cod");
        y.style.border = "1px solid red";
        var z = document.getElementById("demo5");
        z.innerHTML = "Güvenlik kodunuz yanlış girdiniz.";
    }
    else {
        var y = document.getElementById("cod");
        y.style.border = "1px solid black";
        var z = document.getElementById("demo5");
        z.innerHTML = "";
    }

    if (x % 2 == 0) {
        var y = document.getElementById("checkbox");
        y.style.border = "1px solid red";
        var z = document.getElementById("demo6");
        z.innerHTML = "Kullanım koşullarını kabul etmeniz gerekmektedir.";
    }
    else {
        var y = document.getElementById("checkbox");
        y.style.border = "1px solid black";
        var z = document.getElementById("demo6");
        z.innerHTML = "";
    }
}
