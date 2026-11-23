package cl.virginiogomez.app_camiones.clases

import java.util.Date

data class Salida(
    val idSalida: Int,
    val fecha: Date,
    val planta: String,
    val patente: String,
    val conductor: String,
    val idEstado: Int,
    val estado: String,
    val usuario: String
)

data class RegistrarSalida(
    val fecha: Date,
    val idPlanta: Int,
    val patente: String,
    val idConductor: Int
)

data class CambiarEstadoSalida(
    val idSalida: Int,
    val idEstado: Int
)

data class DatosSalida(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<Salida>
)