package com.alumnos.composeapi.interfaz

import com.alumnos.composeapi.clases.DatosUsuario
import com.alumnos.composeapi.clases.Usuario
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.DELETE
import retrofit2.http.GET
import retrofit2.http.POST

interface Funciones {
    // Usuario
    @GET("ListadoUsuarios")
    suspend fun listadoUsuarios() : Response<DatosUsuario>

    @POST("BuscarUsuario")
    suspend fun buscarUsuario(@Body usuario: Usuario): Response<DatosUsuario>

    @POST("InsertarUsuario")
    suspend fun insertarUsuario(@Body usuario: Usuario): Response<DatosUsuario>

    @POST("EditarUsuario")
    suspend fun editarUsuario(@Body usuario: Usuario): Response<DatosUsuario>

    @DELETE("EliminarUsuario")
    suspend fun eliminarUsuario(@Body usuario: Usuario): Response<DatosUsuario>
}