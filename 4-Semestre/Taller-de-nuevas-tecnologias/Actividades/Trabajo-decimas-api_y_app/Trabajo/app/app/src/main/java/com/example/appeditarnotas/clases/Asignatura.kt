package com.example.appeditarnotas.clases

data class Asignatura(
    var idAsignatura: Int?,
    var nombre: String
)

data class DatosAsignatura(
    var exito: Boolean,
    var mensaje: String,
    var datos: List<Asignatura>
)