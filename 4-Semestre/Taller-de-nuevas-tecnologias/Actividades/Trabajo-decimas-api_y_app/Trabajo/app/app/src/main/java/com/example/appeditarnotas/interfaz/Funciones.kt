package com.example.appeditarnotas.interfaz

import com.example.appeditarnotas.clases.Alumno
import com.example.appeditarnotas.clases.Asignatura
import com.example.appeditarnotas.clases.DatosAlumno
import com.example.appeditarnotas.clases.DatosAsignatura
import com.example.appeditarnotas.clases.DatosNotas
import com.example.appeditarnotas.clases.Notas
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.PUT

interface Funciones {
    // Alumno
    @GET("alumnos")
    suspend fun obtenerAlumnos(): Response<DatosAlumno>

    @POST("alumnos")
    suspend fun insertarAlumno(@Body alumno: Alumno): Response<DatosAlumno>

    // Asignatura
    @GET("asignaturas")
    suspend fun obtenerAsignaturas(): Response<DatosAsignatura>

    @POST("asignaturas")
    suspend fun insertarAsignatura(@Body asignatura: Asignatura): Response<DatosAsignatura>

    // Notas
    @GET("notas")
    suspend fun obtenerNotas(): Response<DatosNotas>

    @POST("notas")
    suspend fun insertarNota(@Body nota: Notas): Response<DatosNotas>

    @PUT("notas")
    suspend fun actualizarNota(@Body nota: Notas): Response<DatosNotas>
}