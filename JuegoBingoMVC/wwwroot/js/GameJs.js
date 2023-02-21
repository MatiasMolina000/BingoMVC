let user = "b2a96165-4b8d-4869-a45e-1cd4c35577ff";
let cartons = localStorage.getItem("Cartones");

function Start() {
    if (cartons) {
        ReloadGame()
    } else {
        NewGame(user);
    }
}

// Armo según LocalStorage
function ReloadGame() {

    let cartones = localStorage.getItem("Cartones");
    let oData = JSON.parse(cartones);

    BuildParty(oData);
}

// Armo llamand a la API
function NewGame(userId) {

    fetch('https://localhost:7062/api/Bingo/NewGame/?usuarioId=' + userId, { method: 'POST' })
        .then((response) => response.json())
        .then((dataJSON) => {
            let oData = JSON.parse(dataJSON.data);
            localStorage.setItem("Cartones", JSON.stringify(oData));

            BuildParty(oData);
        }
    );
}

// Construyo estructura de cartones
function BuildParty(oData) {
    for (var item in oData) {

        let arrayNros = "";

        localStorage.setItem("Carton" + (parseInt(item) + 1), JSON.stringify(oData[item]));

        arrayNros = oData[item].Numeros.split(',');

        document.getElementById("cartones").innerHTML +=
            "<div class='col-xl-5 col-lg-12 mb-4 ms-4 oCart' id='" + oData[item].NumeroCarton + "'>" +
                "<div class='row oFil'>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[0] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[3] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[6] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[9] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[12] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[15] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[18] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[21] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[24] + "</h3></div>" +
                "</div>" +
                "<div class='row oFil'>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[1] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[4] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[7] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[10] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[13] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[16] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[19] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[22] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[25] + "</h3></div>" +
                "</div>" +
                "<div class='row oFil'>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[2] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[5] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[8] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[11] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[14] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[17] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[20] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[23] + "</h3></div>" +
                    "<div class='col oCol'><h3 class='oNumber'>" + arrayNros[26] + "</h3></div>" +
                "</div>";
            "</div >";
    };

    PaintCells();  
}

// Asigno clase a celdas vacías
function PaintCells() {
    var elemento = document.querySelectorAll('.oCol');
    for (var i = 0; i < elemento.length; i++) {
        if (elemento[i].innerText == "") {
            elemento[i].classList.add("celEmpty");
        };
    };
}






Start();