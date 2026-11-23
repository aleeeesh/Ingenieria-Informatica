package cl.virginiogomez.app_camiones.clases

data class CrearUsuario(
    val usuario: String,
    val nombreCompleto: String,
    val contrasena: String
)

data class ObtenerUsuarios(
    val usuario: String,
    val nombreCompleto: String,
    val idEstado: Int
)

data class CambiarEstadoUsuario(
    val usuario: String,
    val idEstado: Int
)

data class DatosUsuario(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<ObtenerUsuarios>
)