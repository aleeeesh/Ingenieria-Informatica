package com.virginiogomez.jetpackanimations

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.animation.AnimatedContent
import androidx.compose.animation.AnimatedVisibility
import androidx.compose.animation.ExperimentalAnimationApi
import androidx.compose.animation.animateColor
import androidx.compose.animation.animateColorAsState
import androidx.compose.animation.core.FastOutLinearInEasing
import androidx.compose.animation.core.FastOutSlowInEasing
import androidx.compose.animation.core.RepeatMode
import androidx.compose.animation.core.animateDp
import androidx.compose.animation.core.animateDpAsState
import androidx.compose.animation.core.animateFloat
import androidx.compose.animation.core.animateSize
import androidx.compose.animation.core.infiniteRepeatable
import androidx.compose.animation.core.rememberInfiniteTransition
import androidx.compose.animation.core.spring
import androidx.compose.animation.core.tween
import androidx.compose.animation.core.updateTransition
import androidx.compose.animation.fadeIn
import androidx.compose.animation.fadeOut
import androidx.compose.animation.slideInVertically
import androidx.compose.animation.slideOutVertically
import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.gestures.Orientation
import androidx.compose.foundation.gestures.draggable
import androidx.compose.foundation.gestures.rememberDraggableState
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.offset
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableIntStateOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.scale
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.IntOffset
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            MaterialTheme(
                colorScheme = MaterialTheme.colorScheme.copy(
                    background = Color(0xFF101010)
                )
            ) {
                Surface(color = MaterialTheme.colorScheme.background) {
                    AnimatedOnboarding()   // ⬅ Tu pantalla principal
                }
            }
        }
    }
}

@OptIn(ExperimentalAnimationApi::class)
@Composable
fun AnimatedOnboarding() {
    var page by remember { mutableIntStateOf(0) }
    val pages = listOf("Bienvenido", "Tu progreso", "Empecemos")

    Column(
        Modifier
            .fillMaxSize()
            .background(Color(0xFF101010))
            .padding(24.dp)
    ) {

        Spacer(modifier = Modifier.height(60.dp))

        LogoAnimatedPulse() // Circulo
        Spacer(modifier = Modifier.height(40.dp))

        AnimatedContent(targetState = page) { targetPage ->
            Text(
                text = pages[targetPage],
                fontSize = 36.sp,
                color = Color.White
            )
        }

        Spacer(modifier = Modifier.height(20.dp))

        AnimatedVisibility(
            visible = page == 0,
            enter = fadeIn() + slideInVertically(),
            exit = fadeOut() + slideOutVertically()
        ) {
            Text(
                "Esta app será tu guía.",
                color = Color.LightGray,
                fontSize = 18.sp
            )
        }

        Spacer(modifier = Modifier.weight(1f))

        SwipeCardExample()

        Spacer(modifier = Modifier.height(24.dp))

        PageIndicator(page = page, total = pages.size)

        Spacer(modifier = Modifier.height(24.dp))

        NextButton(
            label = if (page == pages.lastIndex) "Finalizar" else "Siguiente",
            onClick = {
                if (page < pages.lastIndex) page++
            }
        )
    }
}

@Composable
fun LogoAnimatedPulse() {
    var expanded by remember { mutableStateOf(false) }
    val transition = updateTransition(expanded, label = "cardTransition")

    val color by transition.animateColor (label = "color") {
        if (it) Color(0xFF2196F3) else Color(0xFFFF5722)
    }

    val infinite = rememberInfiniteTransition()

    val scale by infinite.animateFloat(
        initialValue = 1f,
        targetValue = 1.2f,
        animationSpec = infiniteRepeatable(
            animation = tween(800, easing = FastOutLinearInEasing),
            repeatMode = RepeatMode.Reverse
        ),
        label = "logo-scale"
    )

    Box(
        modifier = Modifier
            .scale(scale)
            .size(120.dp)
            .background(color, CircleShape)
    )
}

@Composable
fun SwipeCardExample() {
    val offsetX = remember { androidx.compose.animation.core.Animatable(0f) }
    val scope = rememberCoroutineScope()

    Box(
        Modifier
            .fillMaxWidth()
            .height(180.dp)
            .background(Color(0xFF1E1E1E), RoundedCornerShape(20.dp))
            .draggable(
                orientation = Orientation.Horizontal,
                state = rememberDraggableState { delta ->
                    // Lanza la corrutina para snapTo
                    scope.launch {
                        offsetX.snapTo(offsetX.value + delta)
                    }
                },
                onDragStopped = {
                    scope.launch {
                        offsetX.animateTo(
                            targetValue = 0f,
                            animationSpec = spring(dampingRatio = 0.5f)
                        )
                    }
                }
            )
            .offset { IntOffset(offsetX.value.toInt(), 0) }
            .padding(20.dp)
    ) {
        Text(
            text = "Desliza para explorar",
            color = Color.White,
            fontSize = 18.sp
        )
    }
}

@Composable
fun PageIndicator(page: Int, total: Int) {
    Row(
        horizontalArrangement = Arrangement.Center,
        modifier = Modifier.fillMaxWidth()
    ) {
        repeat(total) { index ->
            val transition = updateTransition(targetState = index == page, label = "dot")

            val size by transition.animateDp(label = "dotSize") {
                if (it) 14.dp else 8.dp
            }

            val color by transition.animateColor(label = "dotColor") {
                if (it) Color(0xFF03DAC5) else Color.Gray
            }

            Box(
                Modifier
                    .padding(6.dp)
                    .size(size)
                    .background(color, CircleShape)
            )
        }
    }
}

@Composable
fun NextButton(label: String, onClick: () -> Unit) {
    var pressed by remember { mutableStateOf(false) }
    val scope = rememberCoroutineScope()

    val width by animateDpAsState(
        targetValue = if (pressed) 260.dp else 220.dp,
        animationSpec = tween(300),
        label = "button-width"
    )

    Button(
        onClick = {
            pressed = true
            onClick()
            scope.launch {
                delay(300)
                pressed = false
            }
        },
        modifier = Modifier
            .height(55.dp)
            .width(width),
        shape = RoundedCornerShape(16.dp)
    ) {
        Text(label, fontSize = 18.sp)
    }
}