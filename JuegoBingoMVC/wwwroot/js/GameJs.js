let userId = "b2a96165-4b8d-4869-a45e-1cd4c35577ff";
//let partidaId = 35;


/***** INICIO *****/
function Start() {
    let cartons = localStorage.getItem("Cartones");

    if (cartons) {
        ReloadGame(cartons)
    }
    else {
        NewGame();
    }
}


/*** CONSTRUCCIÓN DE JUEGO ***/

// Armo partida según LocalStorage
function ReloadGame(cartons) {
    let oData = JSON.parse(cartons);
    BuildParty(oData);
    CheckNumbers();
}

// Armo partida según respuesta de API
function NewGame() {

    fetch('https://localhost:7062/api/Bingo/NewGame/?usuarioId=' + userId, { method: 'POST' })
        .then((response) => response.json())
        .then((dataJSON) => {
            let oData = JSON.parse(dataJSON.data);

            localStorage.setItem("Cartones", JSON.stringify(oData));
            localStorage.setItem("JuegoHistorialId", JSON.stringify(oData[0].JuegoHistorialId));
            localStorage.setItem("Bolillas", "0");
            BuildParty(oData);
        }
    );
}


// Construyo estructura de cartones y muestro última bolilla
function BuildParty(oData) {
    for (var item in oData) {

        let arrayNros = "";

        localStorage.setItem("Carton" + (parseInt(item) + 1), JSON.stringify(oData[item]));

        arrayNros = oData[item].Numeros.split(',');

        document.getElementById("cartones").innerHTML +=
            "<div class='col-xl-5 col-lg-12 mb-4 ms-4 oCart' id='" + oData[item].NumeroCarton + "'>" +
                "<div class='row oFil'>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[0] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[3] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[6] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[9] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[12] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[15] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[18] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[21] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[24] + "</h3></div>" +
                "</div>" +
                "<div class='row oFil'>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[1] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[4] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[7] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[10] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[13] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[16] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[19] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[22] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[25] + "</h3></div>" +
                "</div>" +
                "<div class='row oFil'>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[2] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[5] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[8] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[11] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[14] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[17] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[20] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[23] + "</h3></div>" +
                    "<div class='col C" + oData[item].NumeroCarton + " oCol'><h3 class='oNumber'>" + arrayNros[26] + "</h3></div>" +
                "</div>";
            "</div >";
    };

    PaintCells();  

    if (localStorage.getItem("Bolillas") != "0") {
        var arrayNumbers = JSON.parse(localStorage.getItem("Bolillas"));
        ShowNumber(arrayNumbers[0]);
    }
}

// Pinto celdas vacías 
function PaintCells() {
    var elemento = document.querySelectorAll('.oCol');
    for (var i = 0; i < elemento.length; i++) {
        if (elemento[i].innerText == "") {
            elemento[i].classList.add("celEmpty");
        };
    };
}


/*** JUGABILIDAD ***/

//Botón para cantar números
function CallNumber() {
    let partidaId = localStorage.getItem("JuegoHistorialId");
    fetch('https://localhost:7062/api/Bingo/NewNumber/?partidaId=' + partidaId, { method: 'POST' })
        .then((response) => response.json())
        .then((dataJSON) => {
            let oData = JSON.parse(dataJSON.data);
            let oMessage = dataJSON.message;

            if (oMessage.substr(0, 1) == "G") {
                SwalWinner(oData);
                ShowWinner(oData);
            }
            else {
                SwalNewNumber(oData.Numeros);
                AddNumber(oData.Numeros);
                ShowNumber(oData.Numeros);
            }
        }
    );
}

// Muestro número en ventana
function ShowNumber(number) {
    document.getElementById("lastNumber").innerHTML = 'Bolilla: ' + number;
}

//Agrego a lista de números cantados
function AddNumber(number) {
    if (localStorage.getItem("Bolillas") != "0") {
        var numbersArray = JSON.parse(localStorage.getItem("Bolillas"));
        numbersArray.unshift(number);
        localStorage.setItem("Bolillas", JSON.stringify(numbersArray));
        CheckNewNumber(number);
    }
    else {
        localStorage.setItem("Bolillas", '[' + number + ']');
    }
}

// Muestro cartón ganador en ventana
function ShowWinner(winners) {
    document.getElementById("winnerNumber").innerHTML = 'Cartón Ganador: ' + winners;
}

//SweetAlert Nuestro Número cantado
function SwalNewNumber(number) {
    Swal.fire({
        title: '<H3>Ha salido el Numero: </H3>' + number,
        icon: 'info'
    });
}
//SweetAlert Nuestro Ganador
function SwalWinner(winners) {
    Swal.fire({
        title: '<H3>El cartón ganador es: </H3>' + winners,
        icon: 'success'
    });
}

// Controla todos los números ya cantados
function CheckNumbers() {
    var elemento = document.querySelectorAll('.oCol');
    var numbers = JSON.parse(localStorage.getItem("Bolillas"));

    for (var n = 0; n < numbers.length; n++) {
        for (var c = 0; c < elemento.length; c++) {
            if (numbers[n] == elemento[c].innerText) {
                elemento[c].classList.add("celCheck");
            };
        };
    };
}

// Controla por cada nuevo número
function CheckNewNumber(number) {
    var elemento = document.querySelectorAll('.oCol');
    var numbers = JSON.parse(localStorage.getItem("Bolillas"));

    for (var c = 0; c < elemento.length; c++) {
        if (elemento[c].innerText == number) {
            elemento[c].classList.add("celCheck");
        };
    };
    CheckWinner();
}




// Controla si existe ganador
/*function CheckWinner() {
    var c1 = document.querySelectorAll('.C1.celCheck').length;
    var c2 = document.querySelectorAll('.C2.celCheck').length;
    var c3 = document.querySelectorAll('.C3.celCheck').length;
    var c4 = document.querySelectorAll('.C4.celCheck').length;

    if (c1 == 15 || c2 == 15 || c3 == 15 || c4 == 15) {
        alert("Ganadores:");
    }
}*/

/*
//Botón para cantar números
function Winner() {
    let partidaId = localStorage.getItem("JuegoHistorialId");
    fetch('https://localhost:7062/api/Bingo/Winner/?winners=' + partidaId, { method: 'PUT' })
        .then((response) => response.json())
        .then((dataJSON) => {
            console.log(dataJSON);
        }
        );
}
*/



Start();