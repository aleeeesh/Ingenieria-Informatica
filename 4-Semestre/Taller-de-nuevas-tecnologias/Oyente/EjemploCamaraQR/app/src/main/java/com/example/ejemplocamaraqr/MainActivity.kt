package com.example.ejemplocamaraqr

import android.os.Bundle
import android.widget.Toast
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.ui.Modifier
// Importa el tema de tu aplicación generado por Android Studio
// import com.example.qrscannerapp.ui.theme.QrScannerAppTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            // QrScannerAppTheme {
            Surface(
                modifier = Modifier.fillMaxSize(),
                color = MaterialTheme.colorScheme.background
            ) {
                // Llamamos a nuestro Composable principal del escáner
                QrScannerScreen(
                    onQrDetected = { qrValue ->
                        // Aquí puedes manejar la lógica cuando se detecta el QR:
                        // - Mostrar un Toast
                        // - Navegar a otra pantalla con navController.navigate(...)
                        // - Abrir una URL en el navegador
                        Toast.makeText(this, "QR Detectado: $qrValue", Toast.LENGTH_LONG).show()
                    }
                )
            }
            // }
        }
    }
}