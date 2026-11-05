package com.example.appapilogin.interfaz

import com.example.appapilogin.clases.Datos
import com.example.appapilogin.clases.DatosUsuario
import com.example.appapilogin.clases.Persona
import com.example.appapilogin.clases.Usuario
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.DELETE
import retrofit2.http.GET
import retrofit2.http.POST

interface Funciones {
    // Personas
    @GET("ListadoPersonas")//FUNCION DE LA API
    suspend fun ListadoPersonas() : Response<Datos>
    @POST("InsertarPersona")
    suspend fun InsertarPersona(@Body persona: Persona): Response<Datos>

    @POST("EditarPersona")
    suspend fun EditarPersona(@Body persona: Persona): Response<Datos>

    @DELETE("EliminarPersona")
    suspend fun EliminarPersona(@Body persona: Persona): Response<Datos>

    // Usuario
    @GET("ListadoUsuario")
    suspend fun ListadoUsuario() : Response<DatosUsuario>

    @POST("InsertarUsuario")
    suspend fun InsertarUsuario(@Body usuario: Usuario): Response<DatosUsuario>

    @POST("EditarUsuario")
    suspend fun EditarUsuario(@Body usuario: Usuario): Response<DatosUsuario>

    @DELETE("EliminarUsuario")
    suspend fun EliminarUsuario(@Body usuario: Usuario): Response<DatosUsuario>
}