package com.example.appeditarnotas

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

        val btnAgregar = findViewById<Button>(R.id.btnLayoutAgregar)
        val btnEditar = findViewById<Button>(R.id.btnLayoutEditar)

        btnAgregar.setOnClickListener {
            startActivity(Intent(this, SubirActivity::class.java))
        }

        btnEditar.setOnClickListener {
            startActivity(Intent(this, EditarActivity::class.java))
        }

    }
}