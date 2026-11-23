package com.example.appeditarnotas.clases

data class Notas(
    var nota: Double,
    var numNota: Int,
    var idAlumno: Int,
    var idAsignatura: Int
)

data class DatosNotas(
    var exito: Boolean,
    var mensaje: String,
    var datos: List<Notas>
)