const domGetAllPetsForm = document.querySelector("#petForm");
const domPetShowcaseSection = document.querySelector('#petShowcaseResult');
const domMain = document.querySelector('main');

const petLiArray = [];

function handleDocumentLoaded(e) {
    e.preventDefault();
    fetch('/api/pet/getall')
        .then(res => res.json())
        .then(data => {
            data.forEach(pet => {
                petLiArray.push(getLiElement(pet));
            });
            petLiArray.forEach(pet => domPetShowcaseSection.innerHTML += pet);
        })
        .then(_ => renderPetList())
}

function renderPetList() {
    const petImageLinkCollection = document.querySelectorAll('.pet-image-link');
    petImageLinkCollection.forEach(petImageLink => {
        petImageLink.addEventListener('click', handlePetClick)
    });
}

function handlePetClick(e) {
    e.preventDefault();
    const petId = e.target.id;
    const numberedId = petId.replace('pet-', '');
    fetch(`/api/pet/getbyid/${numberedId}`)
        .then(response => response.json())
        .then(data => renderPetSingle(data))
        .catch(err => console.log(err));
}

function renderPetSingle(petInfo) {
    domMain.innerHTML = JSON.stringify(petInfo);

}

document.addEventListener("DOMContentLoaded", handleDocumentLoaded);