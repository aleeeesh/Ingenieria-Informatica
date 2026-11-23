package com.example.appeditarnotas.clases

data class Alumno(
    var idAlumno: Int,
    var nombres: String?,
    var apellidos: String?
)

data class DatosAlumno(
    var exito: Boolean,
    var mensaje: String,
    var datos: List<Alumno>
)