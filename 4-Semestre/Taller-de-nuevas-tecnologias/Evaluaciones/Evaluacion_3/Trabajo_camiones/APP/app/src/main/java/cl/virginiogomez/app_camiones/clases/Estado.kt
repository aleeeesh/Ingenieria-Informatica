package cl.virginiogomez.app_camiones.clases

data class ObtenerEstados(
    val idEstado: Int,
    val nombre: String
) {
    override fun toString(): String = nombre.lowercase().replaceFirstChar { it.uppercase() }
}

data class DatosEstado(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<ObtenerEstados>
)