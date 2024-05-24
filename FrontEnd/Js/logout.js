


var btnLogOut = document.querySelector("#logout");

btnLogOut.addEventListener("click", event => 
{
    event.preventDefault()
    localStorage.removeItem("token")
    location.href = "index.html"
})
