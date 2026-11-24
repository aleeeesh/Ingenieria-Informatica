package cl.virginiogomez.app_camiones.clases

data class CrearUsuario(
    val usuario: String,
    val nombreCompleto: String,
    val contrasena: String
)

data class ObtenerUsuarios(
    val usuario: String,
    val nombreCompleto: String,
    val estado: String
)

data class EstadoUsuario(
    val usuario: String
)

data class DatosUsuario(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<ObtenerUsuarios>
)