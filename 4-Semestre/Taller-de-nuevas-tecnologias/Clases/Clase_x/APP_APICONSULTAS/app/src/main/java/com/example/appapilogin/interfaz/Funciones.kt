package com.example.appapilogin.interfaz

import com.example.appapilogin.clases.estados.DatosEstado
import com.example.appapilogin.clases.personas.DatosPersona
import com.example.appapilogin.clases.usuarios.DatosUsuario
import com.example.appapilogin.clases.personas.Persona
import com.example.appapilogin.clases.usuarios.Usuario
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.DELETE
import retrofit2.http.GET
import retrofit2.http.POST

interface Funciones {
    // Personas
    @GET("ListadoPersonas") // Mismo nombre que en la API (.NET)
    suspend fun listadoPersonas() : Response<DatosPersona>
    @POST("InsertarPersona")
    suspend fun insertarPersona(@Body persona: Persona): Response<DatosPersona>

    @POST("EditarPersona")
    suspend fun editarPersona(@Body persona: Persona): Response<DatosPersona>

    @DELETE("EliminarPersona")
    suspend fun eliminarPersona(@Body persona: Persona): Response<DatosPersona>

    // Usuario
    @GET("ListadoUsuarios")
    suspend fun listadoUsuarios() : Response<DatosUsuario>

    @POST("InsertarUsuario")
    suspend fun insertarUsuario(@Body usuario: Usuario): Response<DatosUsuario>

    @POST("EditarUsuario")
    suspend fun editarUsuario(@Body usuario: Usuario): Response<DatosUsuario>

    @DELETE("EliminarUsuario")
    suspend fun eliminarUsuario(@Body usuario: Usuario): Response<DatosUsuario>

    // Estado
    @GET("ListadoEstados")
    suspend fun listadoEstados() : Response<DatosEstado>
}