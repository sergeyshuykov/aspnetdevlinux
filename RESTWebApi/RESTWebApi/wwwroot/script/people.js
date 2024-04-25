const PEOPLE_SERVICE_BASE_ADDRESS = "api/people";

async function updatePeopleTable() {
    const response = await fetch(PEOPLE_SERVICE_BASE_ADDRESS, {
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

async function createPerson(personName, personAge)
{
    const response = await fetch(PEOPLE_SERVICE_BASE_ADDRESS, {
        method : "POST",
        headers : { "Accept" : "application/json", "Content-Type": "application/json"},
        body : JSON.stringify({
            name : personName,
            age : parseInt(personAge)
        })
    });
    if (response.ok) {
        const person = await response.json();
        document.querySelector("#people tbody").append(rowPerson(person));
    }
    else
        console.log(await response.text())

}

function reset()
{
    document.getElementById("personName").value = "";
    document.getElementById("personAge").value = "";
}
window.addEventListener("load", function(){
    updatePeopleTable();

    document.getElementById("saveBtn").addEventListener("click",async ()=>{
        const name = document.getElementById("personName").value;
        const age = document.getElementById("personAge").value;
        await createPerson(name, age);
        reset();
    });

});