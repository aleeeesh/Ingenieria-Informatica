package cl.virginiogomez.app_camiones.pantallas.salidas

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AlertDialog
import androidx.recyclerview.widget.RecyclerView
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.ObtenerSalidas

class AdaptadorSalidas(
    private val listaSalidas: MutableList<ObtenerSalidas>,
    private val onCambiarEstadoClick: (ObtenerSalidas, Int) -> Unit
) : RecyclerView.Adapter<AdaptadorSalidas.SalidaViewHolder>() {
    class SalidaViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val titulo: TextView = itemView.findViewById(R.id.txtTitulo)
        val subtitulo: TextView = itemView.findViewById(R.id.txtSubtitulo)
        val subtitulo2: TextView = itemView.findViewById(R.id.txtSubtitulo2)
        val estado: TextView = itemView.findViewById(R.id.txtEstadoSalida)
        val btnEstado: Button = itemView.findViewById(R.id.btnEstadoSalida)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): SalidaViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_salida, parent, false)
        return SalidaViewHolder(view)
    }

    override fun onBindViewHolder(holder: SalidaViewHolder, position: Int) {
        val item = listaSalidas[position]
        holder.titulo.text = "Salida #${item.idSalida} · ${item.fecha?.split("-")?.takeIf { it.size == 3 }?.let { "${it[2]}-${it[1]}-${it[0]}" } ?: item.fecha}"
        holder.subtitulo.text = "${item.camion} · ${item.conductor}"
        holder.subtitulo2.text = "${item.planta} · ${item.usuario}"
        holder.estado.text = item.estado.lowercase().replaceFirstChar { it.uppercase() }

        holder.btnEstado.setOnClickListener {
            val contexto = holder.itemView.context
            AlertDialog.Builder(contexto)
                .setTitle(contexto.getString(R.string.texto_aviso))
                .setMessage(contexto.getString(R.string.texto_retorno, item.idSalida.toString()))
                .setPositiveButton(R.string.action_si) { _, _ ->
                    val pos = holder.bindingAdapterPosition
                    if (pos != RecyclerView.NO_POSITION) {
                        onCambiarEstadoClick(listaSalidas[pos], pos)
                    }
                }
                .setNegativeButton(R.string.action_no, null)
                .show()
        }
    }

    override fun getItemCount(): Int = listaSalidas.size
}
