use OUTATIME_ENCUESTAS

db.encuestas.insertOne({
    tipo: "OFICINA",
    pais: "Estados Unidos",
    oficina: "Hill Valley Central",

    calificaciones: {
        atencion: 5,
        tiempoEspera: 4,
        instalaciones: 5,
        recomendaria: true
    }
})

db.encuestas.insertOne({
    tipo: "CHOFER",
    pais: "Estados Unidos",
    chofer: "Marty McFly",

    calificaciones: {
        puntualidad: 5,
        amabilidad: 4,
        conduccionSegura: 5,
        conocimientoDestino: 5
    }
})

db.encuestas.insertOne({
    tipo: "VEHICULO",
    pais: "Estados Unidos",
    vehiculo: "OUT1985",

    calificaciones: {
        limpieza: 2,
        estadoMecanico: 5,
        comodidad: 4,
        seguridad: 5
    }
})

db.encuestas.insertMany([

{
tipo:"OFICINA",
pais:"Estados Unidos",
oficina:"Hill Valley Central",
calificaciones:{atencion:5,tiempoEspera:4,instalaciones:5,recomendaria:true}
},
{
tipo:"OFICINA",
pais:"Estados Unidos",
oficina:"Hill Valley Central",
calificaciones:{atencion:2,tiempoEspera:2,instalaciones:3,recomendaria:false}
},
{
tipo:"OFICINA",
pais:"Japon",
oficina:"Tokyo Future",
calificaciones:{atencion:5,tiempoEspera:5,instalaciones:5,recomendaria:true}
},
{
tipo:"OFICINA",
pais:"Japon",
oficina:"Tokyo Future",
calificaciones:{atencion:4,tiempoEspera:4,instalaciones:4,recomendaria:true}
},
{
tipo:"OFICINA",
pais:"Uruguay",
oficina:"Montevideo TimeHub",
calificaciones:{atencion:1,tiempoEspera:2,instalaciones:3,recomendaria:false}
},
{
tipo:"CHOFER",
pais:"Estados Unidos",
chofer:"Marty McFly",
calificaciones:{puntualidad:5,amabilidad:5,conduccionSegura:4,conocimientoDestino:5}
},
{
tipo:"CHOFER",
pais:"Japon",
chofer:"Hiro Tanaka",
calificaciones:{puntualidad:4,amabilidad:4,conduccionSegura:5,conocimientoDestino:5}
},
{
tipo:"VEHICULO",
pais:"Estados Unidos",
vehiculo:"OUT1985",
calificaciones:{limpieza:2,estadoMecanico:5,comodidad:4,seguridad:5}
},
{
tipo:"VEHICULO",
pais:"Estados Unidos",
vehiculo:"OUT1985",
calificaciones:{limpieza:1,estadoMecanico:4,comodidad:4,seguridad:5}
},
{
tipo:"VEHICULO",
pais:"Japon",
vehiculo:"TIME2015",
calificaciones:{limpieza:5,estadoMecanico:5,comodidad:5,seguridad:5}
}

])




















