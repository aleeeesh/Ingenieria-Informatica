package com.josue.proyectoroom.data

import android.content.Context
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import com.josue.proyectoroom.model.ApoderadoModel
import com.josue.proyectoroom.model.EstudianteModel

@Database(entities = [EstudianteModel::class], version = 1, exportSchema = false)
abstract class AppDatabase : RoomDatabase() {
    abstract fun apoderadDAO(): ApoderadoDAO
    abstract fun estudianteDAO(): EstudianteDAO

    companion object {
        @Volatile
        private var INSTANCE: AppDatabase? = null

        fun getDatabase(context: Context): AppDatabase {
            return INSTANCE ?: synchronized(this) {
                val instance = Room.databaseBuilder(
                    context.applicationContext,
                    AppDatabase::class.java,
                    "miniproject_db"
                ).build()
                INSTANCE = instance
                instance
            }
        }
    }
}