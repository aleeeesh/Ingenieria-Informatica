package com.example.appeditarnotas

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.appeditarnotas.clases.Alumno
import com.example.appeditarnotas.clases.Asignatura
import com.example.appeditarnotas.clases.DatosAlumno
import com.example.appeditarnotas.clases.DatosAsignatura
import com.example.appeditarnotas.conexion.RetrofitCliente
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class SubirActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_subir)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val btnVolver = findViewById<Button>(R.id.btnVolverSubir)

        // Alumno
        val txtId = findViewById<EditText>(R.id.txtIdAlumno)
        val txtNombres = findViewById<EditText>(R.id.txtNombres)
        val txtApellidos = findViewById<EditText>(R.id.txtApellidos)

        val btnAgregarAlumno = findViewById<Button>(R.id.btnAgregarAlumno)

        // Asignatura
        val txtNombre = findViewById<EditText>(R.id.txtAsignatura)

        val btnAgregarAsignatura = findViewById<Button>(R.id.btnAgregarAsignatura)


        btnVolver.setOnClickListener {
            startActivity(Intent(this, MainActivity::class.java))
            finish()
        }

        btnAgregarAlumno.setOnClickListener {
            val id = txtId.text.toString().toIntOrNull() ?: -1
            val nombres = txtNombres.text.toString().trim()
            val apellidos = txtApellidos.text.toString().trim()

            var mensaje = "Debe ingresar: \n"

            if (id == -1) {
                mensaje += "- ID del alumno\n"
            }

            if (nombres.isEmpty()) {
                mensaje += "- Nombres\n"
            }

            if (apellidos.isEmpty()) {
                mensaje += "- Apellidos\n"
            }

            if (mensaje == "Debe ingresar: \n") {
                insertarAlumno(id, nombres, apellidos)
            } else {
                AlertDialog.Builder(this)
                    .setTitle("Faltan datos por ingresar")
                    .setMessage(mensaje)
                    .setNeutralButton("OK") { dialog, id ->
                        dialog.dismiss()
                    }
                    .create()
                    .show()
            }
        }

        btnAgregarAsignatura.setOnClickListener {
            val nombre = txtNombre.text.toString().trim()

            if (nombre.isEmpty()) {
                AlertDialog.Builder(this)
                    .setTitle("Faltan datos por ingresar")
                    .setMessage("Debe ingresar el nombre de la asignatura.")
                    .setNeutralButton("OK") { dialog, id ->
                        dialog.dismiss()
                    }
                    .create()
                    .show()

                return@setOnClickListener
            }

            insertarAsignatura(nombre)
        }
    }

    fun insertarAlumno(id: Int, nombres: String, apellidos: String) {
        val alumno = Alumno(
            id,
            nombres,
            apellidos
        )
        CoroutineScope(Dispatchers.IO).launch {
            try {


                val llamada = RetrofitCliente.api.insertarAlumno(alumno)

                if (llamada.isSuccessful) {
                    val cuerpo: DatosAlumno? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val mensaje = cuerpo?.mensaje
                        Toast.makeText(this@SubirActivity, mensaje, Toast.LENGTH_SHORT).show()
                    }
                }
            } catch(error: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@SubirActivity, error.message, Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    fun insertarAsignatura(nombre: String) {
        CoroutineScope(Dispatchers.IO).launch {
            try {
                val asignatura = Asignatura(null, nombre)

                val llamada = RetrofitCliente.api.insertarAsignatura(asignatura)

                if (llamada.isSuccessful) {
                    val cuerpo: DatosAsignatura? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val mensaje = cuerpo?.mensaje

                        Toast.makeText(this@SubirActivity, mensaje, Toast.LENGTH_SHORT).show()
                    }
                }
            } catch(error: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@SubirActivity, error.message, Toast.LENGTH_SHORT).show()
                }
            }
        }
    }
}