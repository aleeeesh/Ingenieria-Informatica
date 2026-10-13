package com.josue.proyectoroom.model

import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "apoderado")
data class ApoderadoModel(
    @PrimaryKey(autoGenerate = true)
    val id: Int = 0,
    val nombre: String,
    val telefono: String
)