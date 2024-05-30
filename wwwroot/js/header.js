
const isLoggedIn = true;
const domHeader = document.querySelector('header');

domHeader.innerHTML = `
<nav>
    <div class="navbar-logo-container">
        <a href="./">
            <img class="navbar-logo" src="./img/maskotas-logo-grande.png" alt="site logo">
        </a>
    </div>
    <div class="navbar-buttons-container">
        <ul>
            <a href="./index.html">
                <li>Home</li>
            </a>
            ${isLoggedIn == true ? `<a href="./admin.html">
                <li>Admin panel</li>
            </a>` : ''}

            </ul>
            </div>
</nav>
`

