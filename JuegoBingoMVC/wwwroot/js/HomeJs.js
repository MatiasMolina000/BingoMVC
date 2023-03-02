let userId = "";
let oData = "";


/***** INICIO *****/
function Start() {

    userIdentity = document.getElementById('userIdentity').innerText.substr(5, document.getElementById('userIdentity').innerText.length - 6);

    GetStatus(userIdentity);

}


/*** OBTENSIÓN DE DATA DE JUEGO ***/
function GetStatus(userName) {
    fetch('https://localhost:7062/api/Bingo/GetParty/?usuarioName=' + userName, { method: 'GET' })
        .then((response) => response.json())
        .then((dataJSON) => {
            if (dataJSON.data != "") {
                oData = JSON.parse(dataJSON.data);
                console.log(dataJSON.data);
                localStorage.setItem("JuegoHistorialId", JSON.stringify(oData.PartidaId));
                localStorage.setItem("Cartones", JSON.stringify(oData.Cartones));
                localStorage.setItem("Bolillas", JSON.stringify(oData.Bolillas));
            }
            else {
                localStorage.setItem("JuegoHistorialId", "");
                localStorage.setItem("Cartones", JSON.stringify([]));
                localStorage.setItem("Bolillas", JSON.stringify([]));
            }
            
        }
    );
    if (localStorage.getItem("JuegoHistorialId") != null && localStorage.getItem("JuegoHistorialId") != "") {
            document.getElementById('btn-game').innerHTML = 'Cargar Partida';
    }
    
}


Start();