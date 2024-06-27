let deleteBtns = document.querySelectorAll(".product-delete");

deleteBtns.forEach(btn => {

    let url = btn.getAttribute("href");
    btn.addEventListener("click", function (e) {
        e.preventDefault();

       fetch(url)
        .then((response) => {
            if (result.isConfirmed) {

                fetch(url).then(response => {
                    if (response.status == 200) {
                        window.location.reload(true);

                        Swal.fire({
                            title: "Deleted!",
                            text: "Your file has been deleted.",
                            icon: "success"
                        });

                    }
                   
                })
            }
        });
    })
})
