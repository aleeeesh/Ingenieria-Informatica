package com.josue.apilogin

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val btnListadoPersonas = findViewById<Button>(R.id.btnPersonas)
        val btnListadoUsuarios = findViewById<Button>(R.id.btnUsuarios)

        val btnInsertarPersona = findViewById<Button>(R.id.btnInsertarPersona)
        val btnInsertarUsuario = findViewById<Button>(R.id.btnInsertarUsuario)

        btnListadoPersonas.setOnClickListener {
            startActivity(Intent(this, ListadoPersonasActivity::class.java))
        }
    }
}