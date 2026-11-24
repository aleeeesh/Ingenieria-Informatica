package cl.virginiogomez.app_camiones.pantallas.salidas

import android.app.DatePickerDialog
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.CamionPlanta
import cl.virginiogomez.app_camiones.clases.DatosCamion
import cl.virginiogomez.app_camiones.clases.DatosPlanta
import cl.virginiogomez.app_camiones.clases.DatosSalida
import cl.virginiogomez.app_camiones.clases.ObtenerCamiones
import cl.virginiogomez.app_camiones.clases.ObtenerConductores
import cl.virginiogomez.app_camiones.clases.ObtenerPlantas
import cl.virginiogomez.app_camiones.clases.RegistrarSalida
import cl.virginiogomez.app_camiones.clases.RetornarSalida
import cl.virginiogomez.app_camiones.conexion.RetrofitCliente
import cl.virginiogomez.app_camiones.databinding.FragmentSalidasBinding
import kotlinx.coroutines.launch
import java.time.LocalDate
import java.time.format.DateTimeFormatter
import java.util.Calendar

class SalidasFragment : Fragment() {
    private lateinit var binding: FragmentSalidasBinding
    private var planta: ObtenerPlantas? = null
    private var camion: ObtenerCamiones? = null
    private var conductor: ObtenerConductores? = null

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        binding = FragmentSalidasBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.txtFechaSalida.setOnClickListener {
            val hoy = Calendar.getInstance()
            DatePickerDialog(
                requireContext(),
                { _, anio, mes, dia ->
                    binding.txtFechaSalida.setText(String.format("%02d/%02d/%04d", dia, mes + 1, anio))
                },
                hoy.get(Calendar.YEAR),
                hoy.get(Calendar.MONTH),
                hoy.get(Calendar.DAY_OF_MONTH)
            ).show()
        }

        binding.btnRegistrarSalida.setOnClickListener {
            if (!binding.btnRegistrarSalida.isEnabled) return@setOnClickListener

            val fecha = binding.txtFechaSalida.text.toString().trim()
            val idPlanta = planta?.idPlanta ?: -1
            val codCamion = camion?.codCamion ?: ""
            val idConductor = conductor?.idConductor ?: -1

            if (fecha.isEmpty()) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_selector_fecha_vacia))
                    .create()
                    .show()
                return@setOnClickListener
            }

            if (idPlanta == -1) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_selector_planta_vacia))
                    .create()
                    .show()
                return@setOnClickListener
            }

            if (codCamion.isEmpty()) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_selector_camion_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            if (idConductor == -1) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_selector_conductor_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            binding.btnRegistrarSalida.isEnabled = false

            viewLifecycleOwner.lifecycleScope.launch {
                try {
                    val fechaApi = LocalDate.parse(fecha, DateTimeFormatter.ofPattern("dd/MM/yyyy")).format(DateTimeFormatter.ISO_LOCAL_DATE)

                    val nuevaSalida = RegistrarSalida(fechaApi, idPlanta, codCamion, idConductor)

                    val llamada = RetrofitCliente.api.registrarSalida(nuevaSalida)

                    if (llamada.isSuccessful) {
                        val cuerpo: DatosSalida? = llamada.body()
                        val mensaje = cuerpo?.mensaje

                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_aviso))
                            .setMessage(mensaje)
                            .create()
                            .show()

                        if (cuerpo?.exito == true) {
                            binding.txtFechaSalida.text?.clear()
                            binding.cmbPlantaSalida.setText("", false)
                            binding.cmbCamionSalida.setText("", false)
                            binding.cmbConductorSalida.setText("", false)

                            planta = null
                            camion = null
                            conductor = null

                            cargarSalidas(binding.lstSalidas)
                        }
                    }
                } catch (e: Exception) {
                    Log.d("[Salidas] Exception", e.toString())

                    if (e.toString().contains("failed to connect")) {
                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_error))
                            .setMessage(getString(R.string.error_conexion))
                            .create()
                            .show()
                    } else {
                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_error))
                            .setMessage(getString(R.string.error_inesperado))
                            .create()
                            .show()
                    }
                } finally {
                    binding.btnRegistrarSalida.isEnabled = true
                }
            }
        }

        cargarSalidas(binding.lstSalidas)
        cargarPlantas()
        cargarConductores()
    }

    private var adaptador: AdaptadorSalidas? = null
    fun cargarSalidas(lista: RecyclerView) {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.cargarSalidas()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosSalida? = llamada.body()

                    if (cuerpo?.exito == true) {
                        adaptador =
                            AdaptadorSalidas(cuerpo.datos.toMutableList()) { salida, position ->
                            viewLifecycleOwner.lifecycleScope.launch {
                                val estado = RetornarSalida(salida.idSalida)
                                val cambioEstado = RetrofitCliente.api.retornar(estado)

                                if (cambioEstado.isSuccessful && cambioEstado.body()?.exito == true) {
                                    cargarSalidas(lista)
                                }
                            }
                        }

                        if (lista.layoutManager == null) {
                            lista.layoutManager = LinearLayoutManager(requireContext())
                        }

                        lista.adapter = adaptador
                    }
                }
            } catch (e: Exception) {
                Log.d("[Cargar camiones] Exception", e.toString())

                if (e.toString().contains("failed to connect")) {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_conexion))
                        .create()
                        .show()
                } else {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_inesperado))
                        .create()
                        .show()
                }
            }
        }
    }

    fun cargarPlantas() {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.cargarPlantas()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosPlanta? = llamada.body()

                    if (cuerpo?.exito == true) {
                        val adaptador = ArrayAdapter(
                            requireContext(),
                            android.R.layout.simple_dropdown_item_1line,
                            cuerpo.datos
                        )
                        adaptador.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
                        binding.cmbPlantaSalida.setAdapter(adaptador)

                        binding.cmbPlantaSalida.setOnItemClickListener { _, _, position, _ ->
                            planta = adaptador.getItem(position)
                            cargarCamiones(planta?.idPlanta ?: 0)
                        }
                    }
                }
            } catch (e: Exception) {
                Log.d("[Cargar plantas - salidas] Exception", e.toString())

                if (e.toString().contains("failed to connect")) {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_conexion))
                        .create()
                        .show()
                } else {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_inesperado))
                        .create()
                        .show()
                }
            }
        }
    }

    fun cargarCamiones(idPlanta: Int) {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val filtro = CamionPlanta(idPlanta)
                val llamada = RetrofitCliente.api.filtrarCamiones(filtro)

                if (llamada.isSuccessful) {
                    val cuerpo: DatosCamion? = llamada.body()

                    if (cuerpo?.exito == true) {
                        val adaptador = ArrayAdapter(
                            requireContext(),
                            android.R.layout.simple_dropdown_item_1line,
                            cuerpo.datos
                        )
                        binding.cmbCamionSalida.setAdapter(adaptador)
                        binding.cmbCamionSalida.setOnItemClickListener { _, _, position, _ ->
                            camion = adaptador.getItem(position)
                        }
                    }
                }

            } catch (e: Exception) {
                Log.d("[Cargar camiones - salidas] Exception", e.toString())

                if (e.toString().contains("failed to connect")) {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_conexion))
                        .create()
                        .show()
                } else {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_inesperado))
                        .create()
                        .show()
                }
            }
        }
    }

    fun cargarConductores() {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.filtrarConductores()

                if (llamada.isSuccessful) {
                    val cuerpo = llamada.body()

                    if (cuerpo?.exito == true) {
                        val adaptador = ArrayAdapter(
                            requireContext(),
                            android.R.layout.simple_dropdown_item_1line,
                            cuerpo.datos
                        )
                        binding.cmbConductorSalida.setAdapter(adaptador)
                        binding.cmbConductorSalida.setOnItemClickListener { _, _, position, _ ->
                            conductor = adaptador.getItem(position)
                        }
                    }
                }

            } catch (e: Exception) {
                Log.d("[Cargar conductores - salidas] Exception", e.toString())

                if (e.toString().contains("failed to connect")) {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_conexion))
                        .create()
                        .show()
                } else {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_inesperado))
                        .create()
                        .show()
                }
            }
        }
    }
}