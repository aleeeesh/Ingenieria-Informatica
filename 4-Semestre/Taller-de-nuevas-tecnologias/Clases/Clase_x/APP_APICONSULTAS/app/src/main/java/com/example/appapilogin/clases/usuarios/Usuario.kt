package com.example.appapilogin.clases.usuarios

data class Usuario(
    var idUsuario: Int,
    var nomUsuario: String,
    var idPersona: Int,
    var idEstado: Int,
)

data class TraeUsuario(
    var nomUsuario : String,
    var nombreCompleto : String,
    var edad : Int,
    var nomEstado : String
)