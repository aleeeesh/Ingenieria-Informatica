package cl.virginiogomez.app_camiones.interfaz

import cl.virginiogomez.app_camiones.clases.CambiarEstadoCamion
import cl.virginiogomez.app_camiones.clases.CambiarEstadoConductor
import cl.virginiogomez.app_camiones.clases.CambiarEstadoSalida
import cl.virginiogomez.app_camiones.clases.CambiarEstadoUsuario
import cl.virginiogomez.app_camiones.clases.Camion
import cl.virginiogomez.app_camiones.clases.CamionPlanta
import cl.virginiogomez.app_camiones.clases.Conductor
import cl.virginiogomez.app_camiones.clases.CrearUsuario
import cl.virginiogomez.app_camiones.clases.DatosCamion
import cl.virginiogomez.app_camiones.clases.DatosConductor
import cl.virginiogomez.app_camiones.clases.DatosEstado
import cl.virginiogomez.app_camiones.clases.DatosPlanta
import cl.virginiogomez.app_camiones.clases.DatosSalida
import cl.virginiogomez.app_camiones.clases.DatosSesion
import cl.virginiogomez.app_camiones.clases.DatosUsuario
import cl.virginiogomez.app_camiones.clases.RegistrarPlanta
import cl.virginiogomez.app_camiones.clases.RegistrarSalida
import cl.virginiogomez.app_camiones.clases.Sesion
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.PUT

interface Endpoints {
    // Sesion
    @GET("sesion")
    suspend fun obtenerSesion(): Response<DatosSesion>

    @POST("sesion/iniciarSesion")
    suspend fun iniciarSesion(@Body sesion: Sesion): Response<DatosSesion>

    @POST("sesion/cerrarSesion")
    suspend fun cerrarSesion(): Response<DatosSesion>

    // Usuarios
    @GET("usuarios")
    suspend fun cargarUsuarios(): Response<DatosUsuario>

    @POST("usuarios")
    suspend fun registrarUsuario(@Body usuario: CrearUsuario): Response<DatosUsuario>

    @PUT("usuarios")
    suspend fun cambiarEstadoUsuario(@Body usuario: CambiarEstadoUsuario): Response<DatosUsuario>

    // Conductores
    @GET("conductores")
    suspend fun cargarConductores(): Response<DatosConductor>

    @GET("conductores/filtrarConductores")
    suspend fun filtrarConductores(): Response<DatosConductor>

    @POST("conductores")
    suspend fun registrarConductor(@Body conductor: Conductor): Response<DatosConductor>

    @PUT("conductores")
    suspend fun cambiarEstadoConductor(@Body conductor: CambiarEstadoConductor): Response<DatosConductor>

    // Camiones
    @GET("camiones")
    suspend fun cargarCamiones(): Response<DatosCamion>

    @GET("camiones/filtrarConductores")
    suspend fun filtrarCamiones(@Body camion: CamionPlanta): Response<DatosCamion>

    @POST("camiones")
    suspend fun registrarCamion(@Body camion: Camion): Response<DatosCamion>

    @PUT("camiones")
    suspend fun cambiarEstadoCamion(@Body camion: CambiarEstadoCamion): Response<DatosCamion>

    // Plantas
    @GET("plantas")
    suspend fun cargarPlantas(): Response<DatosPlanta>

    @POST("plantas")
    suspend fun registrarPlanta(@Body planta: RegistrarPlanta): Response<DatosPlanta>

    // Salidas
    @GET("salidas")
    suspend fun cargarSalidas(): Response<DatosSalida>

    @POST("salidas")
    suspend fun registrarSalida(@Body salida: RegistrarSalida): Response<DatosSalida>

    @PUT("salidas")
    suspend fun cambiarEstadoSalida(@Body salida: CambiarEstadoSalida): Response<DatosSalida>

    // Estados
    @GET("estados")
    suspend fun cargarEstados(): Response<DatosEstado>

    @GET("estados/salidas")
    suspend fun cargarEstadosSalida(): Response<DatosEstado>
}