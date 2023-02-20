let user = "b2a96165-4b8d-4869-a45e-1cd4c35577ff";
let c1 = localStorage.getItem("Carton1");
let c2 = localStorage.getItem("Carton2");
let c3 = localStorage.getItem("Carton3");
let c4 = localStorage.getItem("Carton4");

function Start() {
    if (c1 && c2 && c3 && c4) {
        ReloadGame()
    } else {
        NewGame(user);
    }
}


function ReloadGame() {
    let cartones = localStorage.getItem("Cartones");

    let oData = JSON.parse(cartones);

    BuildParty(oData);
}


function NewGame(userId) {

    fetch('https://localhost:7062/api/Bingo/NewPartidaGuardada/?usuarioId=' + userId, { method: 'POST' })
        .then((response) => response.json())
        .then((dataJSON) => {
            let oData = JSON.parse(dataJSON.data);
            localStorage.setItem("Cartones", JSON.stringify(oData));

            BuildParty(oData);
        }
    );
}

function BuildParty(oData) {
    for (var item in oData) {

        let arrayNros = "";

        localStorage.setItem("Carton" + (parseInt(item) + 1), JSON.stringify(oData[item]));

        arrayNros = oData[item].Numeros.split(',');

        document.getElementById("cartones").innerHTML +=
            "<div class='col-xl-6 col-lg-12' id='" + oData[item].NumeroCarton + "'>" +
            "<div class='row m-3'>" +
            "<div class='col'><h3>" + arrayNros[0] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[3] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[6] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[9] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[12] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[15] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[18] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[21] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[24] + "</h3></div>" +
            "</div>" +
            "<div class='row m-3'>" +
            "<div class='col'><h3>" + arrayNros[1] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[4] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[7] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[10] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[13] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[16] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[19] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[22] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[25] + "</h3></div>" +
            "</div>" +
            "<div class='row m-3'>" +
            "<div class='col'><h3>" + arrayNros[2] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[5] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[8] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[11] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[14] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[17] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[20] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[23] + "</h3></div>" +
            "<div class='col'><h3>" + arrayNros[26] + "</h3></div>" +
            "</div>";
        "</div >";
    };
}

Start();