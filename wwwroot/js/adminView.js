import * as ApiUtils from './apiUtils.js';

let domMain = document.querySelector('main');
let petArray;
const domBodyElement = document.querySelector('body');
let domEditButton;
let domSubmitButton;
let domHeroCard;
let globalPet;

function renderSingle(pet) {
    document.querySelector('#heroCard')?.remove();
    const newNode = document.createElement("section");
    newNode.classList.add('main-section');
    newNode.id = "heroCard";
    newNode.innerHTML = `
            <img class="pet-image" src="${pet.imageUrl}" alt="" srcset="">
            <div class="pet-details">
                <div class="pet-detail-container"><span>Name: </span><h1 class="pet-detail pet-name">${pet.name}</h1></div>
                <div class="pet-detail-container"><span>Description: </span><p class="pet-detail pet-description">${pet.description}</p></div>
                <div class="pet-detail-container"><span>Age: </span><p class="pet-detail pet-age">${pet.age} years old</p></div>
                <div class="pet-detail-container"><span>Breed: </span><p class="pet-detail pet-breed">${pet.breedDto.breedName}</p></div>
                <div class="pet-detail-container"><span>Location: </span><p class="pet-detail pet-location">${pet.locationDto.locationName}</p></div>
            </div>
    `;
    domMain.appendChild(newNode);
}

function amendReferences() {
    domHeroCard = document.querySelector('#heroCard');
    domSubmitButton = document.querySelector('#submitButton');
    domEditButton = document.querySelector('#editButton');
}

function handleSubmit() {
    const petName = document.querySelector('.pet-name');
    const petDescription = document.querySelector('.pet-description');
    const petAge = document.querySelector('.pet-age');
    const petBreed = document.querySelector('.pet-breed');
    const petLocation = document.querySelector('.pet-location');

    const petToPost = {
        name: petName.innerHTML,
        age: petAge.innerHTML,
        description: petDescription.innerHTML,
        breedName: petBreed.innerHTML,
        locationName: petLocation.innerHTML
    };
    window.location.reload();
}

function handleCancel(e) {
    console.log('handle cancel fired');
    renderSingle(globalPet);
    disableEditMode();
}

function handleEdit(e) {
    console.log('handle edit fired');
    enableEditMode();
}

function disableEditMode() {
    console.log('DISABLING EDIT MODE HELP')
    const petDetailElements = [...document.querySelectorAll('.pet-detail')];
    petDetailElements.forEach(detail => {
        detail.setAttribute('contenteditable', 'false');
        detail.classList.remove('editing-text');
    });
    const spans = [...document.querySelectorAll('span')];
    spans.forEach(ddd => {
        ddd.style.cursor = '';
    });
    domSubmitButton.classList.add('hidden');
    domEditButton.innerHTML = 'Edit';
    domEditButton.classList.add('edit-button');
    domEditButton.removeEventListener('click', handleCancel);
    domEditButton.addEventListener('click', handleEdit);
    domEditButton.classList.remove('cancel-button');
}

function enableEditMode() {
    const petDetailElements = [...document.querySelectorAll('.pet-detail')];
    petDetailElements.forEach(detail => {
        detail.setAttribute('contenteditable', 'true');
        detail.classList.add('editing-text');
    });
    const spans = [...document.querySelectorAll('span')];
    spans.forEach(ddd => {
        ddd.style.cursor = 'not-allowed';
    });

    domEditButton.innerHTML = 'Cancel';
    domEditButton.classList.add('cancel-button');
    domEditButton.classList.remove('edit-button');
    domEditButton.removeEventListener('click', handleEdit);
    domEditButton.addEventListener('click', handleCancel);

    domSubmitButton.classList.remove('hidden');
    domSubmitButton.addEventListener('click', handleSubmit);
}

export async function setupView() {
    const [isIdPresent, pet] = await ApiUtils.getPetFromQueryString();
    if (!isIdPresent) {
        renderAll();
        return;
    }

    if (pet) {
        globalPet = pet;
        renderButtons();
        renderSingle(pet);
        enterSingleViewMode();
        amendReferences();
        domEditButton.addEventListener('click', handleEdit);

        return;
    }

    domMain.innerHTML = '<h1 class="error">Not found</h1>'
}

function renderButtons() {
    domMain.innerHTML = `
    <div class="buttons-container">
        <button class="edit-button main-button" id="editButton">
            Edit
        </button>
        <button type="submit" class="hidden submit-button" id="submitButton">
            Submit
        </button>
    </div>
    `;
}

function enterSingleViewMode() {
    domMain.classList.add('flex');
    domBodyElement.classList.add('admin-view');
    domBodyElement.classList.add('single-view');
}

async function renderAll() {
    domMain.classList.toggle('grid');
    domBodyElement.classList.toggle('grid-view');
    domBodyElement.classList.toggle('admin-view');
    petArray = await ApiUtils.fetchData('/api/pet/getall');
    if (petArray) {
        petArray.forEach(pet => domMain.innerHTML += getGridElement(pet));
    }
}

function getGridElement(pet) {
    return `
    <div class="pet-card">
        <a href="?id=${pet.petId}" class="pet-image-container"><img id="pet-${pet.petId}" class="pet-image pet-detail" src="${pet.imageUrl}"></a>
        <div class="pet-details">
            <h1 class="pet-name pet-detail">
                ${pet.name}
            </h1>
            <p class="pet-age pet-detail">${pet.age} years old</p>
            <p class="pet-description pet-detail">${pet.description}</p>
        </div>
    </div>
    `
}
