package com.alumnos.composeapi.clases

data class DatosUsuario(
    var respuesta : Boolean,
    var mensaje :String,
    var datos: List<Usuario>
)