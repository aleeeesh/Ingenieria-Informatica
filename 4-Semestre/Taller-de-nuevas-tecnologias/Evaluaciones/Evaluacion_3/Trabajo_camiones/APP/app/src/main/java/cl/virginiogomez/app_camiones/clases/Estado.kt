package cl.virginiogomez.app_camiones.clases

data class Estado(
    val idEstado: Int,
    val nombre: String
)

data class DatosEstado(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<Estado>
)