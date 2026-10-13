package com.josue.proyectoroom.data

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import com.josue.proyectoroom.model.ApoderadoModel
import com.josue.proyectoroom.model.EstudianteModel
import kotlinx.coroutines.flow.Flow

@Dao
interface ApoderadoDAO {
    @Query("SELECT * FROM apoderado ORDER BY id DESC")
    fun getAll(): Flow<List<EstudianteModel>>

    @Insert
    suspend fun insert(item: ApoderadoModel)

    @Delete
    suspend fun delete(item: EstudianteModel)
}