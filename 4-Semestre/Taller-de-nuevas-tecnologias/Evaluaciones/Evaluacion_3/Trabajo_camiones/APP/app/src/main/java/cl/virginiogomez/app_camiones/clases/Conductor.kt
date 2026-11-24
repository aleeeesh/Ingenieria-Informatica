package cl.virginiogomez.app_camiones.clases

data class CrearConductor(
    val nombreCompleto: String,
    val idEstado: Int
)

data class ObtenerConductores(
    val idConductor: Int,
    val nombreCompleto: String,
    val estado: String
) {
    override fun toString(): String = nombreCompleto
}

data class EstadoConductor(
    val idConductor: Int
)

data class DatosConductor(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<ObtenerConductores>
)