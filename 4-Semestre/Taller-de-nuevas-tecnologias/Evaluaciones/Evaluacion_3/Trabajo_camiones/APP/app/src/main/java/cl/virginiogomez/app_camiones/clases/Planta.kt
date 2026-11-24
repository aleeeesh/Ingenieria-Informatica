package cl.virginiogomez.app_camiones.clases

data class CrearPlanta(
    val nombre: String
)
data class ObtenerPlantas(
    val idPlanta: Int,
    val nombre: String
) {
    override fun toString(): String = nombre
}

data class DatosPlanta(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<ObtenerPlantas>
)