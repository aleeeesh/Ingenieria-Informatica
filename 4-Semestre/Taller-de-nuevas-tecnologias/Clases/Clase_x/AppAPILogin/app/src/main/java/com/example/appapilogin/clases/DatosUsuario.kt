package com.example.appapilogin.clases

data class DatosUsuario(
    var respuesta : String,
    var mensaje :String,
    var lista: List<UsuarioTrae>
)
data class UsuarioTrae(
    var nomUsuario : String,
    var nombreApellido : String,
    var edad : Int,
    var nom_estado : String
)