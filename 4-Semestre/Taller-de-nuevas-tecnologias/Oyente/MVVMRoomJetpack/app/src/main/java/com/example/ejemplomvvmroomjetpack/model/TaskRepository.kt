package com.example.ejemplomvvmroomjetpack.model

import com.example.ejemplomvvmroomjetpack.model.room.task.TaskDao
import com.example.ejemplomvvmroomjetpack.model.room.task.TaskEntity
import kotlinx.coroutines.flow.Flow

class TaskRepository(private val taskDao: TaskDao) {
    val allTasks: Flow<List<TaskEntity>> = taskDao.getAllTasks()

    suspend fun insert(task: TaskEntity) {
        taskDao.insertTask(task)
    }

    suspend fun delete(task: TaskEntity) {
        taskDao.deleteTask(task)
    }
}