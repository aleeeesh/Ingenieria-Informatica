package cl.virginiogomez.app_camiones.pantallas.usuarios

import android.annotation.SuppressLint
import android.graphics.Color
import android.graphics.drawable.ColorDrawable
import android.graphics.drawable.Drawable
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AlertDialog
import androidx.recyclerview.widget.RecyclerView
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.ObtenerUsuarios
import androidx.core.graphics.drawable.toDrawable

class AdaptadorUsuarios(
    private val listaUsuarios: MutableList<ObtenerUsuarios>,
    private val onCambiarEstadoClick: (ObtenerUsuarios, Int) -> Unit
) : RecyclerView.Adapter<AdaptadorUsuarios.UsuarioViewHolder>() {

    class UsuarioViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val titulo: TextView = itemView.findViewById(R.id.txtTitulo)
        val subtitulo: TextView = itemView.findViewById(R.id.txtSubtitulo)
        val estado: TextView = itemView.findViewById(R.id.txtEstado)
        val btnEstado: Button = itemView.findViewById(R.id.btnEstado)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): UsuarioViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_lista, parent, false)
        return UsuarioViewHolder(view)
    }

    override fun onBindViewHolder(holder: UsuarioViewHolder, position: Int) {
        val item = listaUsuarios[position]
        holder.titulo.text = item.nombreCompleto
        holder.subtitulo.text = item.usuario
        holder.estado.text = item.estado.lowercase().replaceFirstChar { it.uppercase() }

        holder.btnEstado.setOnClickListener {
            val contexto = holder.itemView.context
            AlertDialog.Builder(contexto)
                .setTitle(contexto.getString(R.string.texto_aviso))
                .setMessage(contexto.getString(R.string.texto_cambio_estado))
                .setPositiveButton(R.string.action_si) { _, _ ->
                    val pos = holder.bindingAdapterPosition
                    if (pos != RecyclerView.NO_POSITION) {
                        onCambiarEstadoClick(listaUsuarios[pos], pos)
                    }
                }
                .setNegativeButton(R.string.action_no, null)
                .show()
        }
    }

    override fun getItemCount(): Int = listaUsuarios.size
}