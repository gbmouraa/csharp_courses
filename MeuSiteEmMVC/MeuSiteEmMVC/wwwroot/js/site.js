// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const handleAdd = async () => {
    const response = await fetch("/Home/Add", {
        method: "POST"
    })

    if (response.ok) {
        const data = await response.json()
        const span = document.getElementById("count-value")
        span.innerHTML = data.total
    }
}
