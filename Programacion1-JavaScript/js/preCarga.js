function precargaClientes(){
    miSistema.pudeAgregarCliente("Julieta", "Pas123", "SALVADOR", "4");
    miSistema.pudeAgregarCliente("juan23", "Ta12345", "Max", "1");
    miSistema.pudeAgregarCliente("Tomas", "Abc1RRd", "Luna", "2");
    miSistema.pudeAgregarCliente("MarioDoc", "PaSs123", "Toby", "4");
    miSistema.pudeAgregarCliente("CarlaS", "Pas222L", "Bella", "2");
    miSistema.pudeAgregarCliente("Lucía", "LuC123", "Chispa", "1");
    miSistema.pudeAgregarCliente("NicoG", "Nic567", "Golfo", "4");
    miSistema.pudeAgregarCliente("Emma", "EmMa123", "Pipo", "2");
    miSistema.pudeAgregarCliente("Santi", "San456", "Coco", "2");
    miSistema.pudeAgregarCliente("Vale", "Val123", "Kira", "1");
    miSistema.pudeAgregarCliente("Luz", "Luz001", "Bruno", "4");
    miSistema.pudeAgregarCliente("Marco", "MarC432", "Milo", "2");
    miSistema.pudeAgregarCliente("Cami", "Cam543", "Nina", "1");
    miSistema.pudeAgregarCliente("Ro", "RoPa123", "Tiza", "4");
    miSistema.pudeAgregarCliente("Sofi", "Sof567", "Bali", "2");
    miSistema.pudeAgregarCliente("Fran", "FrAn321", "Nube", "1");
    miSistema.pudeAgregarCliente("Dani", "DaNi654", "Chimuelo", "2");
    miSistema.pudeAgregarCliente("Euge", "Eug345", "Zeus", "4");
    miSistema.pudeAgregarCliente("Ivan", "IvAn765", "Rocco", "2");
    miSistema.pudeAgregarCliente("Lu", "LuPa123", "Bongo", "1");
    miSistema.pudeAgregarCliente("AnaM", "AnaM123", "Rocky", "1");
    miSistema.pudeAgregarCliente("LeoZ", "Leo321", "Lola", "2");
    miSistema.pudeAgregarCliente("Tere89", "Ter456", "Maxi", "4");
    miSistema.pudeAgregarCliente("Beto", "BeTo789", "Sol", "2");
    miSistema.pudeAgregarCliente("MeliK", "MeL345", "Duke", "1");
    miSistema.pudeAgregarCliente("NachoR", "NaCh123", "Terry", "4");
    miSistema.pudeAgregarCliente("Flori", "FlO987", "Luna", "2");
    miSistema.pudeAgregarCliente("Gonza", "GoNz654", "Simba", "1");
    miSistema.pudeAgregarCliente("VeroC", "VeRo321", "Tomi", "4");
    miSistema.pudeAgregarCliente("PabloV", "PaBl098", "Candy", "2");
}

function precargaPaseador(){
    miSistema.pudeAgregarPaseador("David Martinez", "davmart", "Pas1234", 8);
    miSistema.pudeAgregarPaseador("Laura Sánchez", "lausan", "Lau4321", 5);
    miSistema.pudeAgregarPaseador("Carlos Pérez", "carper", "Cpe5678", 3);
    miSistema.pudeAgregarPaseador("María López", "marlo", "Mlo8765", 6);
    miSistema.pudeAgregarPaseador("Pedro Ramos", "pedram", "Per3456", 2);
    miSistema.pudeAgregarPaseador("Jet Black", "JetBlack", "Bebop3456", 9);
}

function precargaContrataciones(){


let paseador1 = 0;
let cliente1 = 4;
if (miSistema.validarPrecargaContratacion(paseador1, cliente1 )) {
    let unPaseador1 = miSistema.obtenerObjetoPaseador(paseador1);
    let unCliente1 = miSistema.obtenerObjetoCliente(cliente1);
    miSistema.nuevaContratacion(unCliente1, unPaseador1);
}


let paseador2 = 0;
let cliente2 = 5;
if (miSistema.validarPrecargaContratacion(paseador2, cliente2 )) {
    let unPaseador2 = miSistema.obtenerObjetoPaseador(paseador2);
    let unCliente2 = miSistema.obtenerObjetoCliente(cliente2);
    miSistema.nuevaContratacion(unCliente2, unPaseador2);
}


let paseador3 = 0;
let cliente3 = 6;
if (miSistema.validarPrecargaContratacion(paseador3, cliente3)) {
    let unPaseador3 = miSistema.obtenerObjetoPaseador(paseador3);
    let unCliente3 = miSistema.obtenerObjetoCliente(cliente3);
    miSistema.nuevaContratacion(unCliente3, unPaseador3);
}


let paseador4 = 10;
let cliente4 = 7;
if (miSistema.validarPrecargaContratacion(paseador4, cliente4)) {
    let unPaseador4 = miSistema.obtenerObjetoPaseador(paseador4);
    let unCliente4 = miSistema.obtenerObjetoCliente(cliente4);
    miSistema.nuevaContratacion(unCliente4, unPaseador4);
}


let paseador5 = 0;
let cliente5 = 8;
if (miSistema.validarPrecargaContratacion(paseador5, cliente5)) {
    let unPaseador5 = miSistema.obtenerObjetoPaseador(paseador5);
    let unCliente5 = miSistema.obtenerObjetoCliente(cliente5);
    miSistema.nuevaContratacion(unCliente5, unPaseador5);
}


let paseador6 = 0;
let cliente6 = 9;
if (miSistema.validarPrecargaContratacion(paseador6, cliente6)) {
    let unPaseador6 = miSistema.obtenerObjetoPaseador(paseador6);
    let unCliente6 = miSistema.obtenerObjetoCliente(cliente6);
    miSistema.nuevaContratacion(unCliente6, unPaseador6);
}


let paseador7 = 0;
let cliente7 = 10;
if (miSistema.validarPrecargaContratacion(paseador7, cliente7)) {
    let unPaseador7 = miSistema.obtenerObjetoPaseador(paseador7);
    let unCliente7 = miSistema.obtenerObjetoCliente(cliente7);
    miSistema.nuevaContratacion(unCliente7, unPaseador7);
}


let paseador11 = 0;
let cliente11 = 11;
if (miSistema.validarPrecargaContratacion(paseador11, cliente11)) {
    let unPaseador11 = miSistema.obtenerObjetoPaseador(paseador11);
    let unCliente11 = miSistema.obtenerObjetoCliente(cliente11);
    miSistema.nuevaContratacion(unCliente11, unPaseador11);
}


let paseador12 = 0;
let cliente12 = 12;
if (miSistema.validarPrecargaContratacion(paseador12, cliente12)) {
    let unPaseador12 = miSistema.obtenerObjetoPaseador(paseador12);
    let unCliente12 = miSistema.obtenerObjetoCliente(cliente12);
    miSistema.nuevaContratacion(unCliente12, unPaseador12);
}


let paseador13 = 0;
let cliente13 = 13;
if (miSistema.validarPrecargaContratacion(paseador13, cliente13)) {
    let unPaseador13 = miSistema.obtenerObjetoPaseador(paseador13);
    let unCliente13 = miSistema.obtenerObjetoCliente(cliente13);
    miSistema.nuevaContratacion(unCliente13, unPaseador13);
}


let paseador14 = 0;
let cliente14 = 14;
if (miSistema.validarPrecargaContratacion(paseador14, cliente14)) {
    let unPaseador14 = miSistema.obtenerObjetoPaseador(paseador14);
    let unCliente14 = miSistema.obtenerObjetoCliente(cliente14);
    miSistema.nuevaContratacion(unCliente14, unPaseador14);
}


let paseador15 = 0;
let cliente15 = 15;
if (miSistema.validarPrecargaContratacion(paseador15, cliente15)) {
    let unPaseador15 = miSistema.obtenerObjetoPaseador(paseador15);
    let unCliente15 = miSistema.obtenerObjetoCliente(cliente15);
    miSistema.nuevaContratacion(unCliente15, unPaseador15);
}


let paseador16 = 0;
let cliente16 = 16;
if (miSistema.validarPrecargaContratacion(paseador16, cliente16)) {
    let unPaseador16 = miSistema.obtenerObjetoPaseador(paseador16);
    let unCliente16 = miSistema.obtenerObjetoCliente(cliente16);
    miSistema.nuevaContratacion(unCliente16, unPaseador16);
}

let paseador17 = 2;
let cliente17 = 17;
if (miSistema.validarPrecargaContratacion(paseador17, cliente17)) {
    let unPaseador17 = miSistema.obtenerObjetoPaseador(paseador17);
    let unCliente17 = miSistema.obtenerObjetoCliente(cliente17);
    miSistema.nuevaContratacion(unCliente17, unPaseador17);
}


let paseador18 = 1;
let cliente18 = 18;
if (miSistema.validarPrecargaContratacion(paseador18, cliente18)) {
    let unPaseador18 = miSistema.obtenerObjetoPaseador(paseador18);
    let unCliente18 = miSistema.obtenerObjetoCliente(cliente18);
    miSistema.nuevaContratacion(unCliente18, unPaseador18);
}


let paseador19 = 1;
let cliente19 = 19;
if (miSistema.validarPrecargaContratacion(paseador19, cliente19)) {
    let unPaseador19 = miSistema.obtenerObjetoPaseador(paseador19);
    let unCliente19 = miSistema.obtenerObjetoCliente(cliente19);
    miSistema.nuevaContratacion(unCliente19, unPaseador19);
}

miSistema.procesarContratacion(0);
miSistema.procesarContratacion(1);
miSistema.procesarContratacion(2);
miSistema.procesarContratacion(3);


}