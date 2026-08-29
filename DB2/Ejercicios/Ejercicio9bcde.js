//Ejercicio 9.b

db.encuestas.aggregate([
{
    $match:{tipo:"OFICINA"}
},
{
    $group:{
        _id:"$oficina",
        promedioAtencion:{
            $avg:"$calificaciones.atencion"
        }
    }
},
{
    $sort:{promedioAtencion:-1}
}
])


//Ejercicio 9.c

db.encuestas.aggregate([
{
    $match:{tipo:"VEHICULO"}
},
{
    $group:{
        _id:"$vehiculo",
        promedioLimpieza:{
            $avg:"$calificaciones.limpieza"
        }
    }
},
{
    $match:{
        promedioLimpieza:{$lt:3}
    }
},
{
    $sort:{promedioLimpieza:1}
}
])


//Ejercicio 9.d

db.encuestas.aggregate([
{
    $match:{tipo:"OFICINA"}
},
{
    $group:{
        _id:"$oficina",
        totalEncuestas:{$sum:1},
        negativas:{
            $sum:{
                $cond:[
                    {$eq:["$calificaciones.recomendaria",false]},
                    1,
                    0
                ]
            }
        }
    }
},
{
    $project:{
        porcentajeNegativas:{
            $multiply:[
                {$divide:["$negativas","$totalEncuestas"]},
                100
            ]
        }
    }
},
{
    $match:{
        porcentajeNegativas:{$gt:30}
    }
}
])




//Ejercicio 9.e

db.encuestas.aggregate([
{
    $group:{
        _id:"$pais",
        cantidadEncuestas:{
            $sum:1
        }
    }
},
{
    $sort:{
        cantidadEncuestas:-1
    }
}
])

















