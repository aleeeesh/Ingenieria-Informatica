package cl.virginiogomez.app_camiones.clases

data class Conductor(
    val idConductor: Int,
    val nombreCompleto: String,
    val idEstado: Int
)

data class CambiarEstadoConductor(
    val idConductor: Int,
    val idEstado: Int
)

data class DatosConductor(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<Conductor>
)