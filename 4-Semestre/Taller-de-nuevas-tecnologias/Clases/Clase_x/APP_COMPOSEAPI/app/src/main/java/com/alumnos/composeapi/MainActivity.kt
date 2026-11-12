package com.alumnos.composeapi

import android.os.Bundle
import android.widget.Toast
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Icon
import androidx.compose.material3.OutlinedButton
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.alumnos.composeapi.clases.Usuario
import com.alumnos.composeapi.conexion.RetrofitCliente
import com.alumnos.composeapi.ui.theme.ComposeAPITheme
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            ComposeAPITheme {
                vista()

            }
        }
    }
    @Composable
    fun Login() {

        //Variable para utilizar
        val txtUsuario = remember {
            mutableStateOf("")
        }

        //Para colocar los elementos verticales
        Column(
            modifier = Modifier
                .fillMaxHeight()
                .padding(40.dp)
        ) {

            //Mensaje
            Text(
                text = "Bienvenido", fontSize = 25.sp, color = Color.Blue,
                modifier = Modifier.fillMaxWidth().padding(0.dp, 50.dp, 0.dp, 0.dp)
            )

            //Usuario input
            OutlinedTextField(
                value = txtUsuario.value, onValueChange = {
                    txtUsuario.value = it
                },
                leadingIcon = {
                    //Icon(R.drawable.person, contentDescription = "persona")
                },
                label = {
                    Text(text = "USUARIO")
                },
                modifier = Modifier.fillMaxWidth().padding(0.dp, 20.dp, 0.dp, 0.dp)
            )
            //Boton Login
            OutlinedButton(
                onClick = {
                    if (txtUsuario.value.isEmpty()) {
                        Toast.makeText(this@MainActivity, "Debe ingresar usuario", Toast.LENGTH_SHORT).show()
                    } else {
                        CoroutineScope(Dispatchers.IO).launch {
                            val buscarUsuario = RetrofitCliente.api.buscarUsuario(
                                Usuario(
                                    txtUsuario.value,
                                    0,
                                    0
                                )
                            )

                            if (buscarUsuario.isSuccessful) {

                            } else {

                            }
                        }
                    }
                },
                modifier = Modifier.fillMaxWidth().padding(0.dp, 25.dp, 0.dp, 0.dp)
            ) {
                Text(
                    text = "Ingresar",
                    modifier = Modifier.fillMaxWidth().padding(5.dp),
                    textAlign = TextAlign.Center,
                    fontSize = 20.sp
                )
            }
        }
    }

    @Preview
    @Composable
    fun vista(){
        Login();
    }
}