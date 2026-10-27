package com.example.ejemploapiviews

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import android.util.Log
import android.view.View
import android.widget.*
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import retrofit2.Response
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path
import retrofit2.http.PUT
import retrofit2.http.DELETE

data class Post(
    val userId: Int,
    val id: Int,
    val title: String,
    val body: String
)

interface ApiService {
    @GET("posts/{id}")
    suspend fun getPost(@Path("id") postId: Int): Response<Post>

    @POST("posts")
    suspend fun createPost(@Body post: Post): Response<Post>

    @PUT("posts/{id}")
    suspend fun updatePost(
        @Path("id") id: Int,
        @Body post: Post
    ): Response<Post>

    @DELETE("posts/{id}")
    suspend fun deletePost(@Path("id") id: Int): Response<Unit>
}

object RetrofitClient {
    val apiService: ApiService by lazy {
        Retrofit.Builder()
            .baseUrl("https://jsonplaceholder.typicode.com/")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
            .create(ApiService::class.java)
    }
}

class MainActivity : AppCompatActivity() {

    private lateinit var editTextId: EditText
    private lateinit var buttonBuscar: Button
    private lateinit var progressBar: ProgressBar
    private lateinit var editTextTitle: EditText
    private lateinit var editTextBody: EditText
    private lateinit var textViewResult: TextView
    private lateinit var buttonCrear: Button
    private lateinit var buttonActualizar: Button
    private lateinit var buttonEliminar: Button

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        buttonActualizar = findViewById(R.id.buttonActualizar)
        buttonEliminar = findViewById(R.id.buttonEliminar)
        editTextId = findViewById(R.id.editTextId)
        editTextTitle = findViewById(R.id.editTextTitle)
        editTextBody = findViewById(R.id.editTextBody)
        buttonBuscar = findViewById(R.id.buttonBuscar)
        progressBar = findViewById(R.id.progressBar)
        textViewResult = findViewById(R.id.textViewResult)
        buttonCrear = findViewById(R.id.buttonCrear)

        buttonCrear.setOnClickListener {
            createNewPost()
        }

        buttonBuscar.setOnClickListener {
            val input = editTextId.text.toString().trim()
            val postId = input.toIntOrNull()

            if (postId == null) {
                textViewResult.text = "Ingresa un número válido."
                return@setOnClickListener
            }

            fetchPost(postId)
        }

        buttonActualizar.setOnClickListener {
            updatePost()
        }

        buttonEliminar.setOnClickListener {
            deletePost()
        }
    }

    private fun fetchPost(postId: Int) {
        progressBar.visibility = View.VISIBLE
        textViewResult.text = ""

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val response = RetrofitClient.apiService.getPost(postId)
                withContext(Dispatchers.Main) {
                    progressBar.visibility = View.GONE
                    if (response.isSuccessful) {
                        val post = response.body()
                        textViewResult.text = "Código: ${response.code()}\n\n" +
                                "ID: ${post?.id}\nTítulo: ${post?.title}\n\n${post?.body}"
                    } else {
                        textViewResult.text = "Error HTTP: ${response.code()}"
                    }
                }
            } catch (e: Exception) {
                withContext(Dispatchers.Main) {
                    progressBar.visibility = View.GONE
                    textViewResult.text = "Excepción: ${e.message}"
                    Log.e("API_ERROR", "Exception", e)
                }
            }
        }
    }

    private fun createNewPost() {
        val newPost = Post(
            userId = 1,
            id = 0, // No importa, el servidor lo ignora
            title = editTextTitle.text.toString(),
            body = editTextBody.text.toString()
        )

        progressBar.visibility = View.VISIBLE
        textViewResult.text = ""

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val response = RetrofitClient.apiService.createPost(newPost)
                withContext(Dispatchers.Main) {
                    progressBar.visibility = View.GONE
                    if (response.isSuccessful) {
                        val postResponse = response.body()
                        textViewResult.text = "POST creado exitosamente:\n\n" +
                                "ID: ${postResponse?.id}\n" +
                                "Título: ${postResponse?.title}\n" +
                                "Contenido: ${postResponse?.body}"
                    } else {
                        textViewResult.text = "Error HTTP: ${response.code()}"
                    }
                }
            } catch (e: Exception) {
                withContext(Dispatchers.Main) {
                    progressBar.visibility = View.GONE
                    textViewResult.text = "Excepción: ${e.message}"
                    Log.e("API_ERROR", "Exception", e)
                }
            }
        }
    }

    private fun updatePost() {
        val postId = editTextId.text.toString().trim().toIntOrNull()
        if (postId == null) {
            textViewResult.text = "Ingresa un ID válido para actualizar."
            return
        }

        val updatedPost = Post(
            userId = 1,
            id = postId,
            title = editTextTitle.text.toString(),
            body = editTextBody.text.toString()
        )

        progressBar.visibility = View.VISIBLE
        textViewResult.text = ""

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val response = RetrofitClient.apiService.updatePost(postId, updatedPost)
                withContext(Dispatchers.Main) {
                    progressBar.visibility = View.GONE
                    if (response.isSuccessful) {
                        val postResponse = response.body()
                        textViewResult.text = "POST actualizado correctamente:\n\n" +
                                "ID: ${postResponse?.id}\n" +
                                "Título: ${postResponse?.title}\n" +
                                "Contenido: ${postResponse?.body}"
                    } else {
                        textViewResult.text = "Error HTTP al actualizar: ${response.code()}"
                    }
                }
            } catch (e: Exception) {
                withContext(Dispatchers.Main) {
                    progressBar.visibility = View.GONE
                    textViewResult.text = "Excepción: ${e.message}"
                    Log.e("API_ERROR", "Exception", e)
                }
            }
        }
    }

    private fun deletePost() {
        val postId = editTextId.text.toString().trim().toIntOrNull()
        if (postId == null) {
            textViewResult.text = "Ingresa un ID válido para eliminar."
            return
        }

        progressBar.visibility = View.VISIBLE
        textViewResult.text = ""

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val response = RetrofitClient.apiService.deletePost(postId)
                withContext(Dispatchers.Main) {
                    progressBar.visibility = View.GONE
                    if (response.isSuccessful) {
                        textViewResult.text = "POST eliminado correctamente (Código: ${response.code()})"
                    } else {
                        textViewResult.text = "Error HTTP al eliminar: ${response.code()}"
                    }
                }
            } catch (e: Exception) {
                withContext(Dispatchers.Main) {
                    progressBar.visibility = View.GONE
                    textViewResult.text = "Excepción: ${e.message}"
                    Log.e("API_ERROR", "Exception", e)
                }
            }
        }
    }
}