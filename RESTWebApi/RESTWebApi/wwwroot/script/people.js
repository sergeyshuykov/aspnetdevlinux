async function updatePeopleTable() {
    const response = await fetch("api/people", {
        method : "GET",
        headers : { "Accept" : "application/json"}
    });
    if (response.ok) {
        const people = await response.json();
        const tbody = document.querySelector("#people tbody");
        people.forEach(person => tbody.append(rowPerson(person)));
    }
}

function rowPerson(person) {
    const tr = document.createElement("tr");
    
    const idTd = document.createElement("td");
    idTd.append(person.id);
    tr.append(idTd)

    const nameTd = document.createElement("td");
    nameTd.append(person.name);
    tr.append(nameTd)

    const ageTd = document.createElement("td");
    ageTd.append(person.age);
    tr.append(ageTd)
    return tr;
}

window.addEventListener("load", updatePeopleTable);