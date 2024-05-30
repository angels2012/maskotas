const domLoginForm = document.querySelector('#loginForm');

async function handleSubmit(e) {
    e.preventDefault();
    const form = e.target;
    const url = form.action;
    const method = form.method;
    const username = document.querySelector('#username').value;
    const password = document.querySelector('#password').value;
    const payload = {
        username: username,
        password: password
    };
    const response = await fetch(url, {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
            "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        body: JSON.stringify(payload),
    });
    const data = await response.json();
    localStorage.setItem('jwt', data.token);
    console.log(localStorage.getItem('jwt'));
}

domLoginForm.addEventListener('submit', handleSubmit);
