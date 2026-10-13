package com.josue.proyectoroom.model

import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "estudiantes")
data class EstudianteModel(
    @PrimaryKey(autoGenerate = true)
    val id: Int = 0,
    val nombre: String,
    val curso: String
)