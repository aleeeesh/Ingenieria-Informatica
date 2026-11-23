package com.example.appeditarnotas

import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.Spinner
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.core.widget.doAfterTextChanged
import com.example.appeditarnotas.clases.DatosAlumno
import com.example.appeditarnotas.clases.DatosAsignatura
import com.example.appeditarnotas.clases.DatosNotas
import com.example.appeditarnotas.clases.Notas
import com.example.appeditarnotas.conexion.RetrofitCliente
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class EditarActivity : AppCompatActivity() {
    lateinit var txtNota1: EditText
    lateinit var txtNota2: EditText
    lateinit var txtNota3: EditText
    lateinit var txtPromedio: EditText

    private var idAsignaturaSeleccionada: Int? = null
    private var idAlumnoSeleccionado: Int? = null

    private var existeNota1 = false
    private var existeNota2 = false
    private var existeNota3 = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_editar)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val spnAsignatura = findViewById<Spinner>(R.id.spnCurso)
        val spnAlumno = findViewById<Spinner>(R.id.spnAlumno)

        txtNota1 = findViewById(R.id.txtNota1)
        txtNota2 = findViewById(R.id.txtNota2)
        txtNota3 = findViewById(R.id.txtNota3)
        txtPromedio = findViewById(R.id.txtPromedio)

        val btnNota = findViewById<Button>(R.id.btnActualizarNota)
        val btnVolver = findViewById<Button>(R.id.btnVolverEditar)

        txtNota1.doAfterTextChanged { calcularPromedio() }
        txtNota2.doAfterTextChanged { calcularPromedio() }
        txtNota3.doAfterTextChanged { calcularPromedio() }

        cargarAsignaturas(spnAsignatura)
        cargarAlumnos(spnAlumno)

        btnNota.setOnClickListener {
            guardarNotas()
        }

        btnVolver.setOnClickListener {
            startActivity(Intent(this, MainActivity::class.java))
            finish()
        }
    }

    fun cargarAsignaturas(spinner: Spinner) {
        val asignaturas = ArrayList<String>()

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val llamada = RetrofitCliente.api.obtenerAsignaturas()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosAsignatura? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val exito = cuerpo?.exito
                        val mensaje = cuerpo?.mensaje
                        val datos = cuerpo?.datos

                        if (exito == true && datos != null) {
                            datos.forEach { asignatura ->
                                asignaturas.add(asignatura.nombre)
                            }

                            val adaptador = ArrayAdapter(
                                this@EditarActivity,
                                android.R.layout.simple_spinner_item,
                                asignaturas
                            )
                            adaptador.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
                            spinner.adapter = adaptador

                            spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
                                override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {
                                    idAsignaturaSeleccionada = datos[position].idAsignatura
                                    cargarNotas()
                                }

                                override fun onNothingSelected(parent: AdapterView<*>?) {}
                            }
                        } else {
                            Toast.makeText(this@EditarActivity, mensaje, Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            } catch (error: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@EditarActivity, error.message, Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    fun cargarAlumnos(spinner: Spinner) {
        val alumnos = ArrayList<String>()

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val llamada = RetrofitCliente.api.obtenerAlumnos()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosAlumno? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val exito = cuerpo?.exito
                        val mensaje = cuerpo?.mensaje
                        val datos = cuerpo?.datos

                        if (exito == true && datos != null) {
                            datos.forEach { alumno ->
                                alumnos.add("${alumno.nombres} ${alumno.apellidos}")
                            }

                            val adaptador = ArrayAdapter(
                                this@EditarActivity,
                                android.R.layout.simple_spinner_item,
                                alumnos
                            )
                            adaptador.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
                            spinner.adapter = adaptador

                            spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
                                override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {
                                    idAlumnoSeleccionado = datos[position].idAlumno
                                    cargarNotas()
                                }

                                override fun onNothingSelected(parent: AdapterView<*>?) {}
                            }
                        } else {
                            Toast.makeText(this@EditarActivity, mensaje, Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            } catch (error: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@EditarActivity, error.message, Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    fun cargarNotas() {
        val idAlumno = idAlumnoSeleccionado ?: return
        val idAsignatura = idAsignaturaSeleccionada ?: return

        existeNota1 = false
        existeNota2 = false
        existeNota3 = false

        txtNota1.setText("")
        txtNota2.setText("")
        txtNota3.setText("")

        txtPromedio.setText("")

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val llamada = RetrofitCliente.api.obtenerNotas()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosNotas? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val exito = cuerpo?.exito
                        val mensaje = cuerpo?.mensaje
                        val datos = cuerpo?.datos

                        if (exito == true) {
                            datos?.forEach { nota ->
                                if (nota.idAlumno == idAlumno && nota.idAsignatura == idAsignatura) {
                                    when (nota.numNota) {
                                        1 -> {
                                            txtNota1.setText(nota.nota.toString())
                                            existeNota1 = true
                                        }
                                        2 -> {
                                            txtNota2.setText(nota.nota.toString())
                                            existeNota2 = true
                                        }
                                        3 -> {
                                            txtNota3.setText(nota.nota.toString())
                                            existeNota3 = true
                                        }
                                    }
                                }
                            }

                            calcularPromedio()
                        } else {
                            Toast.makeText(this@EditarActivity, mensaje, Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            } catch (error: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@EditarActivity, error.message, Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    private fun calcularPromedio() {
        val nota1 = txtNota1.text.toString().toDoubleOrNull()
        val nota2 = txtNota2.text.toString().toDoubleOrNull()
        val nota3 = txtNota3.text.toString().toDoubleOrNull()

        if ((nota1 != null && nota1 in 1.0..7.0) && (nota2 != null && nota2 in 1.0..7.0) && (nota3 != null && nota3 in 1.0..7.0)) {
            val promedio = (nota1 + nota2 + nota3) / 3

            txtPromedio.setText("%.1f".format(promedio))
        } else {
            txtPromedio.setText("")
        }
    }

    fun guardarNotas() {
        val idAlumno = idAlumnoSeleccionado
        val idAsignatura = idAsignaturaSeleccionada

        if (idAlumno == null || idAsignatura == null) {
            Toast.makeText(this, "Debes seleccionar un alumno y una asignatura", Toast.LENGTH_SHORT).show()
            return
        }

        val listaNotas = listOf(
            Triple(txtNota1.text.toString().trim(), 1, existeNota1),
            Triple(txtNota2.text.toString().trim(), 2, existeNota2),
            Triple(txtNota3.text.toString().trim(), 3, existeNota3)
        )

        CoroutineScope(Dispatchers.IO).launch {
            try {
                var mensaje: String? = null

                for((txtNota, numNota, existe) in listaNotas) {
                    if (txtNota.isEmpty()) continue

                    val nota = txtNota.toDoubleOrNull()

                    if (nota == null || nota < 1 || nota > 7) {
                        withContext(Dispatchers.Main) {
                            Toast.makeText(this@EditarActivity, "La Nota $numNota debe estar entre 1.0 y 7.0", Toast.LENGTH_SHORT).show()
                        }
                        return@launch
                    }

                    val notas = Notas(nota, numNota, idAlumno, idAsignatura)

                    val llamada = if (existe) {
                        RetrofitCliente.api.actualizarNota(notas)
                    } else {
                        RetrofitCliente.api.insertarNota(notas)
                    }

                    if (llamada.isSuccessful) {
                        val cuerpo: DatosNotas? = llamada.body()

                        mensaje = cuerpo?.mensaje

                        when (numNota) {
                            1 -> existeNota1 = true
                            2 -> existeNota2 = true
                            3 -> existeNota3 = true
                        }
                    }
                }

                if (mensaje != null) {
                    withContext(Dispatchers.Main) {
                        Toast.makeText(this@EditarActivity, mensaje, Toast.LENGTH_SHORT).show()
                    }
                }
            } catch (error: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@EditarActivity, error.message, Toast.LENGTH_SHORT).show()
                }
            }
        }
    }
}