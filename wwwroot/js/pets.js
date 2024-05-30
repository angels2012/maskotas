import * as AnonView from './anonView.js';
import * as AdminView from './adminView.js'

async function checkLogin() {
    if (localStorage.getItem('jwt') != null) {
        return true;
    }
}

let isLoggedIn = await checkLogin();

if (!isLoggedIn) {
    AnonView.setupView();
} else {
    AdminView.setupView();
}
