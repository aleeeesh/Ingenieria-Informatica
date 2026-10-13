package com.josue.proyectoroom

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material3.*
import androidx.compose.material3.HorizontalDivider
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.unit.dp
import com.josue.proyectoroom.data.AppDatabase
import com.josue.proyectoroom.model.ApoderadoModel
import com.josue.proyectoroom.ui.theme.ProyectoRoomTheme
import kotlinx.coroutines.launch

class ApoderadoActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            ProyectoRoomTheme {
                ApoderadoScreen()
            }
        }
    }
}

@Composable
fun ApoderadoScreen() {
    val context = LocalContext.current
    val scope = rememberCoroutineScope()

    // Instancia directa de la Base de Datos y DAO
    val db = remember { AppDatabase.getDatabase(context) }
    val dao = remember { db.apoderadDAO()}

    // Estados para los campos de texto genéricos
    var nombre by remember { mutableStateOf("") }
    var telefono by remember { mutableStateOf("") }

    // Observar datos en tiempo real con Flow
    val list by dao.getAll().collectAsState(initial = emptyList())

    Column(
        modifier = Modifier
            .fillMaxSize()
            .padding(16.dp)
    ) {
        Text("Mantenedor Mínimo", style = MaterialTheme.typography.headlineMedium)
        Spacer(modifier = Modifier.height(12.dp))

        // Entradas de texto genéricas
        OutlinedTextField(
            value = nombre,
            onValueChange = { nombre = it },
            label = { Text("Nombre") },
            modifier = Modifier.fillMaxWidth()
        )
        Spacer(modifier = Modifier.height(8.dp))
        OutlinedTextField(
            value = telefono,
            onValueChange = { telefono = it },
            label = { Text("Teléfono") },
            modifier = Modifier.fillMaxWidth()
        )
        Spacer(modifier = Modifier.height(12.dp))

        // Botón de Guardar
        Button(
            onClick = {
                if (nombre.isNotBlank() && telefono.isNotBlank()) {
                    scope.launch {
                        dao.insert(ApoderadoModel(nombre = nombre, telefono = telefono))
                        nombre = ""
                        telefono = ""
                    }
                }
            },
            modifier = Modifier.fillMaxWidth()
        ) {
            Text("Agregar Registro")
        }

        Spacer(modifier = Modifier.height(16.dp))
        HorizontalDivider(Modifier, DividerDefaults.Thickness, DividerDefaults.color)
        Spacer(modifier = Modifier.height(16.dp))

        // Lista simple para mostrar los datos almacenados
        LazyColumn(
            modifier = Modifier.fillMaxSize(),
            verticalArrangement = Arrangement.spacedBy(8.dp)
        ) {
            items(list) { item ->
                Card(
                    modifier = Modifier.fillMaxWidth()
                ) {
                    Column(modifier = Modifier.padding(12.dp)) {
                        Text("ID: ${item.id}", style = MaterialTheme.typography.labelSmall)
                        Text("Nombre: ${item.nombre}")
                        Text("telefono: ${item.telefono}")

                        TextButton(
                            onClick = {
                                scope.launch { dao.delete(item) }
                            }
                        ) {
                            Text("Eliminar", color = MaterialTheme.colorScheme.error)
                        }
                    }
                }
            }
        }
    }
}