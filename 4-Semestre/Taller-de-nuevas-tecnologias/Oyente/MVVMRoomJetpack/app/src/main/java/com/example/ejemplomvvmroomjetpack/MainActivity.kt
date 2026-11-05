package com.example.ejemplomvvmroomjetpack

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.viewModels
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.ui.Modifier
import com.example.ejemplomvvmroomjetpack.model.room.AppDatabase
import com.example.ejemplomvvmroomjetpack.model.TaskRepository
import com.example.ejemplomvvmroomjetpack.ui.TaskScreen
import com.example.ejemplomvvmroomjetpack.viewmodel.TaskViewModel

class MainActivity : ComponentActivity() {

    private val taskViewModel: TaskViewModel by viewModels {
        val database = AppDatabase.getDatabase(applicationContext)
        val repository = TaskRepository(database.taskDao())
        TaskViewModel.provideFactory(repository)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            MaterialTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    TaskScreen(viewModel = taskViewModel)
                }
            }
        }
    }
}