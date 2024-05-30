let petArray;
let currentIdx = 0;

let domMain = document.querySelector('main');
let domHeroCard;
let domLeftArrow;
let domRightArrow;
let domBodyElement;

export async function setupView() {
    domMain.innerHTML = getAnonViewMarkup();

    domHeroCard = document.querySelector('#heroCard');

    domLeftArrow = document.querySelector('#leftArrow');
    domRightArrow = document.querySelector('#rightArrow');
    domBodyElement = document.querySelector('body');

    domRightArrow.addEventListener('click', handleRightArrowClick);
    domLeftArrow.addEventListener('click', handleLeftArrowClick);
    domLeftArrow.classList.toggle('hidden');
    domRightArrow.classList.toggle('hidden');
    domBodyElement.classList.toggle('anon-view');
    petArray = await getAllPets();
    renderHero(currentIdx);
}

function getAnonViewMarkup() {
    return `
    <div class="arrow hidden" id="leftArrow">
        <img src="./img/arrow.png" alt="" srcset="">
    </div>
    <section class="main-section" id="heroCard">
    </section>
    <div class="arrow hidden" id="rightArrow">
        <img src="./img/arrow.png" alt="" srcset="">
    </div>
    `;
}

async function getAllPets() {
    const response = await fetch('/api/pet/getall');
    const data = await response.json();
    return data;
}

function handleRightArrowClick() {
    currentIdx++;
    if (currentIdx == petArray.length)
        currentIdx = 0;

    renderHero(currentIdx);
}

function handleLeftArrowClick() {
    currentIdx--;
    if (currentIdx == -1)
        currentIdx = petArray.length - 1;

    renderHero(currentIdx);
}

function renderHero(idx) {
    const pet = petArray[idx];
    domHeroCard.innerHTML = `
    <img class="pet-image" src="${pet.imageUrl}" alt="" srcset="">
    <div class="pet-details">
        <h1 class="pet-detail pet-name"><span>Name: </span>${pet.name}</h1>
        <p class="pet-detail pet-description"><span>Description: </span>${pet.description}</p>
        <p class="pet-detail pet-age"><span>Age: </span>${pet.age} years old</p>
        <p class="pet-detail pet-breed"><span>Breed: </span>${pet.breedDto.breedName}</p>
        <p class="pet-detail pet-location"><span>Location: </span>${pet.locationDto.locationName}</p>
    </div>
    `;
}