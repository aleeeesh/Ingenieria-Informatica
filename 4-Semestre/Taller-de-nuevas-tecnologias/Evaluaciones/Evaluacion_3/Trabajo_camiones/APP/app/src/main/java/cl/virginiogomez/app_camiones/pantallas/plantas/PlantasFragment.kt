package cl.virginiogomez.app_camiones.pantallas.plantas

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.CrearPlanta
import cl.virginiogomez.app_camiones.clases.DatosPlanta
import cl.virginiogomez.app_camiones.clases.ObtenerPlantas
import cl.virginiogomez.app_camiones.conexion.RetrofitCliente
import cl.virginiogomez.app_camiones.databinding.FragmentPlantasBinding
import kotlinx.coroutines.launch

class PlantasFragment : Fragment() {
    private lateinit var binding: FragmentPlantasBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        binding = FragmentPlantasBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.btnAgregarPlanta.setOnClickListener {
            if (!binding.btnAgregarPlanta.isEnabled) return@setOnClickListener

            val nombre = binding.txtNombrePlanta.text.toString().trim()

            if (nombre.isEmpty()) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_nombre_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            binding.btnAgregarPlanta.isEnabled = false

            viewLifecycleOwner.lifecycleScope.launch {
                try {
                    val nuevaPlanta = CrearPlanta(nombre)

                    val llamada = RetrofitCliente.api.registrarPlanta(nuevaPlanta)

                    if (llamada.isSuccessful) {
                        val cuerpo: DatosPlanta? = llamada.body()
                        val mensaje = cuerpo?.mensaje

                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_aviso))
                            .setMessage(mensaje)
                            .create()
                            .show()

                        if (cuerpo?.exito == true) {
                            binding.txtNombrePlanta.text?.clear()

                            cargarPlantas(binding.lstPlantas)
                        }
                    }
                } catch (e: Exception) {
                    Log.d("[Plantas] Exception", e.toString())

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
                    binding.btnAgregarPlanta.isEnabled = true
                }
            }
        }

        cargarPlantas(binding.lstPlantas)
    }

    private var adaptador: AdaptadorPlantas? = null

    fun cargarPlantas(lista: RecyclerView) {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.cargarPlantas()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosPlanta? = llamada.body()

                    if (cuerpo?.exito == true) {
                        if (lista.layoutManager == null) {
                            lista.layoutManager = LinearLayoutManager(requireContext())
                        }

                        val plantas: MutableList<ObtenerPlantas> = cuerpo.datos.toMutableList()
                        adaptador = AdaptadorPlantas(plantas)
                        lista.adapter = adaptador
                    }
                }
            } catch (e: Exception) {
                Log.d("[Cargar plantas] Exception", e.toString())

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