export async function fetchData(url) {
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

export async function getPetFromQueryString() {
    const idFromQueryString = getIdFromQueryString();
    let isIdPresent = true;
    if (idFromQueryString == null) {
        return [false, null];
    }
    let pet = await fetchData(`/api/pet/getbyid/${idFromQueryString}`);
    return [isIdPresent, pet];
}

function getIdFromQueryString() {
    const urlParams = new URLSearchParams(window.location.search);
    const idFromQueryString = urlParams.get('id');
    return idFromQueryString;
}