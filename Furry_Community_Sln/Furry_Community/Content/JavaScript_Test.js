var b = false;

function changeColor() {
    if (b === false) {
        div_elem.style.backgroundColor = "#9DC8C1";
        div_elem.style.color = "#C82F3E";
        b = true;
    }
    else {
        b = false;
        div_elem.style.backgroundColor = "#A6C87D";
        div_elem.style.color = "#5A23C8";
    }
    
}

var div_elem = document.getElementById("div-index-vlozh");
div_elem.addEventListener("click", changeColor);





//JQuery



$(document).ready(function ()
{
 


    $("[data-trigger='dropdown']").on("mouseenter", function () {

        var submenu = $(this).parent().find("#listVnizu");
        submenu.addClass("active");
        $("#list-main-niz").on("mouseleave", function () {

            submenu.removeClass("active");

        })

    })


 

})


console.log("Hello world Victor Li");
 