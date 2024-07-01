function deleteProduct(productId) {
    if (confirm('Are you sure you want to remove this product from the basket?')) {
        fetch(`/Product/DeleteBasket?productId=${productId}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value // Include this line if you use anti-forgery tokens
            }
        })
            .then(response => {
                if (response.ok) {
                    document.getElementById(`product-${productId}`).remove();
                    // Optionally, update the total amount here
                } 
            })
           
    }
}

