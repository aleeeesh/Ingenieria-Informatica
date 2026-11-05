package com.josue.apilogin.clases

data class DatosPersonas(
    var respuesta: String,
    var mensaje: String,
    var lista: List<Persona>
)

data class Persona(
    var idPersona: Int,
    var nomPersona: String?,
    var apePersona: String?,
    var edad: Int
)