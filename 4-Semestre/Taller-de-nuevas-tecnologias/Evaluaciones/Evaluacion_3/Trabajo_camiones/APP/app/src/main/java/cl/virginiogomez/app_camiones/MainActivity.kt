package cl.virginiogomez.app_camiones

import android.os.Bundle
import android.util.Log
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.PaddingValues
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.navigationBarsPadding
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.statusBarsPadding
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material3.AlertDialog
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.style.TextDecoration
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import cl.virginiogomez.app_camiones.clases.DatosSesion
import cl.virginiogomez.app_camiones.clases.Sesion
import cl.virginiogomez.app_camiones.conexion.RetrofitCliente
import cl.virginiogomez.app_camiones.ui.theme.APP_CAMIONESTheme
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            APP_CAMIONESTheme {
                Navegacion()
            }
        }
    }
}

@Composable
fun PantallaLogin(modifier: Modifier = Modifier, onLoginExitoso: () -> Unit) {
    var usuario by remember { mutableStateOf("") }
    var contrasena by remember { mutableStateOf("") }

    var mensajeDialog by remember { mutableStateOf<String?>(null) }

    Column(modifier = modifier.fillMaxSize(), horizontalAlignment = Alignment.CenterHorizontally, verticalArrangement = Arrangement.Center) {
        Text(
            text = "Inicio de Sesión",
            fontSize = 30.sp
        )

        Spacer(modifier = Modifier.height(15.dp))

        OutlinedTextField(
            value = usuario,
            onValueChange = { usuario = it },
            placeholder = { Text("Ingrese su usuario...") },
            label = { Text("Usuario") }
        )

        Spacer(modifier = Modifier.height(5.dp))

        OutlinedTextField(
            value = contrasena,
            onValueChange = { contrasena = it },
            placeholder = { Text("Ingrese su contraseña...") },
            label = { Text("Contraseña") },
            visualTransformation = PasswordVisualTransformation(),
            keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Password)
        )
        Spacer(modifier = Modifier.height(10.dp))
        Button(onClick = {
            if (usuario.isEmpty() || contrasena.isEmpty()) {
                mensajeDialog = "Debe ingresar el usuario y contraseña"
                return@Button
            }

            CoroutineScope(Dispatchers.IO).launch {
                try {
                    val sesion = Sesion(usuario, contrasena)

                    val llamada = RetrofitCliente.api.iniciarSesion(sesion)

                    if (llamada.isSuccessful) {
                        val cuerpo: DatosSesion? = llamada.body()

                        if (cuerpo?.exito == false) {
                            withContext(Dispatchers.Main) {
                                mensajeDialog = cuerpo.mensaje
                            }
                        } else {
                            withContext(Dispatchers.Main) {
                                onLoginExitoso()
                            }
                        }
                    }
                } catch(error: Exception) {
                    withContext(Dispatchers.Main) {
                        Log.d("Error Login", error.toString())
                        mensajeDialog = "Ocurrió un error inesperado"
                    }
                }
            }
        }) {
            Text(text = "Ingresar")
        }

        mensajeDialog?.let { mensaje ->
            AlertDialog(
                onDismissRequest = { mensajeDialog = null },
                title = { Text(text = "Aviso") },
                text = { Text(text = mensaje) },
                confirmButton = {
                    TextButton(onClick = { mensajeDialog = null }) {
                        Text("Aceptar")
                    }
                }
            )
        }
    }
}

@Composable
fun PantallaUsuarios(modifier: Modifier = Modifier) {

}

@Composable
fun Navegacion() {
    val navController = rememberNavController()

    val navegarAPestana: (String) -> Unit = { ruta ->
        navController.navigate(ruta) {
            popUpTo("usuarios") { saveState = true }
            launchSingleTop = true
            restoreState = true
        }
    }

    val cerrarSesion: () -> Unit = {
        navController.navigate("login") {
            popUpTo(0) { inclusive = true }
        }
    }

    NavHost(navController = navController, startDestination = "login") {
        composable("login") {
            PantallaLogin(
                onLoginExitoso = {
                    navController.navigate("usuarios") {
                        popUpTo("login") { inclusive = true }
                    }
                }
            )
        }

        composable("usuarios") {
            PlantillaBase("usuarios", navegarAPestana, cerrarSesion) { padding ->
                PantallaUsuarios(Modifier.padding(padding))
            }
        }
        composable("conductores") {
            PlantillaBase("conductores", navegarAPestana, cerrarSesion) { padding ->
                //PantallaConductores(Modifier.padding(padding))
            }
        }
        composable("camiones") {
            PlantillaBase("camiones", navegarAPestana, cerrarSesion) { padding ->
                //PantallaCamiones(Modifier.padding(padding))
            }
        }
        composable("plantas") {
            PlantillaBase("plantas", navegarAPestana, cerrarSesion) { padding ->
                //PantallaPlantas(Modifier.padding(padding))
            }
        }
        composable("salidas") {
            PlantillaBase("salidas", navegarAPestana, cerrarSesion) { padding ->
                //PantallaSalidas(Modifier.padding(padding))
            }
        }
    }
}

@Composable
fun PlantillaBase(
    rutaActual: String,
    onNavegar: (String) -> Unit,
    onCerrarSesion: () -> Unit,
    contenido: @Composable (PaddingValues) -> Unit
) {
    var nombreUsuario: String? by remember { mutableStateOf("Cargando...") }
    val scope = rememberCoroutineScope()

    LaunchedEffect(Unit) {
        try {
            val llamada = RetrofitCliente.api.obtenerSesion()

            if (llamada.isSuccessful) {
                nombreUsuario = llamada.body()?.nombre ?: "Usuario"
            }
        } catch (e: Exception) {
            nombreUsuario = "Sin conexión"
        }
    }

    val pestanas = listOf(
        "usuarios" to "Usuarios",
        "conductores" to "Conductores",
        "camiones" to "Camiones",
        "plantas" to "Plantas",
        "salidas" to "Salidas"
    )

    Scaffold(
        topBar = {
            Row(
                modifier = Modifier
                    .fillMaxWidth()
                    .statusBarsPadding()
                    .padding(horizontal = 16.dp, vertical = 12.dp),
                horizontalArrangement = Arrangement.SpaceBetween,
                verticalAlignment = Alignment.CenterVertically
            ) {
                Text(
                    text = "Hola, $nombreUsuario",
                    fontSize = 14.sp,
                    fontWeight = FontWeight.Medium
                )
                Button(
                    onClick = {
                        scope.launch(Dispatchers.IO) {
                            try {
                                RetrofitCliente.api.cerrarSesion()
                            } catch (_: Exception) { }
                            withContext(Dispatchers.Main) {
                                onCerrarSesion()
                            }
                        }
                    },
                    colors = ButtonDefaults.buttonColors(),
                    shape = RoundedCornerShape(6.dp),
                    contentPadding = PaddingValues(horizontal = 12.dp, vertical = 4.dp)
                ) {
                    Text("Cerrar Sesión", color = Color.Black, fontSize = 12.sp)
                }
            }
        },
        bottomBar = {
            Row(
                modifier = Modifier
                    .fillMaxWidth()
                    .navigationBarsPadding()
                    .padding(vertical = 12.dp, horizontal = 8.dp),
                horizontalArrangement = Arrangement.SpaceEvenly,
                verticalAlignment = Alignment.CenterVertically
            ) {
                pestanas.forEach { (ruta, titulo) ->
                    val estaActiva = rutaActual == ruta

                    Text(
                        text = titulo,
                        fontSize = 13.sp,
                        fontWeight = if (estaActiva) FontWeight.Bold else FontWeight.Normal,
                        color = if (estaActiva) Color.Blue else Color.Black,
                        textDecoration = if (estaActiva) TextDecoration.Underline else TextDecoration.None,
                        modifier = Modifier.clickable {
                            if (!estaActiva) onNavegar(ruta)
                        }
                    )
                }
            }
        },
        content = contenido
    )
}