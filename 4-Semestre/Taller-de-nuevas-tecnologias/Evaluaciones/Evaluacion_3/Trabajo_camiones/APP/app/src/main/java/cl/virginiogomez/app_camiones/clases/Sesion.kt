package cl.virginiogomez.app_camiones.clases

data class Sesion(
    val usuario: String,
    val contrasena: String
)

data class DatosSesion(
    val exito: Boolean,
    val mensaje: String,
    val nombre: String?
)