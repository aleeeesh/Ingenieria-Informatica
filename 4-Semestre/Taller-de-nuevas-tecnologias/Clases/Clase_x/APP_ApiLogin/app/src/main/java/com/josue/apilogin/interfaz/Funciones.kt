package com.josue.apilogin.interfaz

import com.josue.apilogin.clases.DatosPersonas
import retrofit2.Response
import retrofit2.http.GET

interface Funciones {
    @GET("ConsultarPersonas")
    suspend fun ConsultarPersonas(): Response<DatosPersonas>
}