let addToBasketBns = document.querySelectorAll(".add-to-basket");

addToBasketBns.forEach(btn => btn.addEventListener("click", function (e) {
    let url = btn.getAttribute("href");

    e.preventDefault();

    fetch(url)
        .then(response => {
            if (response.status == 200) {
                alert("Added to basket")
            }
            else {
                alert("Could not add to cart!")
            }
        })

    
}))
