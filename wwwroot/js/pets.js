import * as AnonView from './anonView.js';
import * as AdminView from './adminView.js'

function checkLogin() {
    return true;
}

let isLoggedIn = checkLogin();

if (!isLoggedIn) {
    AnonView.setupView();
} else {
    AdminView.setupView();
}
