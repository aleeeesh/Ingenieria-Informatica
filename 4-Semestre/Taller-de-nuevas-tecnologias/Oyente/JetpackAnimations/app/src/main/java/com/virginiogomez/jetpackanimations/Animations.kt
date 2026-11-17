package com.virginiogomez.jetpackanimations

import androidx.compose.animation.AnimatedContent
import androidx.compose.animation.AnimatedContentTransitionScope
import androidx.compose.animation.AnimatedVisibility
import androidx.compose.animation.ExperimentalAnimationApi
import androidx.compose.animation.animateColorAsState
import androidx.compose.animation.core.Animatable
import androidx.compose.animation.core.FastOutSlowInEasing
import androidx.compose.animation.core.RepeatMode
import androidx.compose.animation.core.animateDp
import androidx.compose.animation.core.animateDpAsState
import androidx.compose.animation.core.animateFloat
import androidx.compose.animation.core.infiniteRepeatable
import androidx.compose.animation.core.keyframes
import androidx.compose.animation.core.rememberInfiniteTransition
import androidx.compose.animation.core.spring
import androidx.compose.animation.core.tween
import androidx.compose.animation.core.updateTransition
import androidx.compose.animation.expandVertically
import androidx.compose.animation.fadeIn
import androidx.compose.animation.fadeOut
import androidx.compose.animation.shrinkVertically
import androidx.compose.animation.togetherWith
import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.gestures.Orientation
import androidx.compose.foundation.gestures.draggable
import androidx.compose.foundation.gestures.rememberDraggableState
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.offset
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.alpha
import androidx.compose.ui.draw.scale
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.graphicsLayer
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.IntOffset
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.launch

//Ejemplo: Botón que crece y cambia de color
@Composable
fun AnimateAsStateExample() {
    var large by remember { mutableStateOf(false) }

    val size by animateDpAsState(
        targetValue = if (large) 150.dp else 80.dp,
        label = "size"
    )

    val color by animateColorAsState(
        targetValue = if (large) Color(0xFF2196F3) else Color(0xFFFF5722),
        label = "color"
    )

    Box(
        Modifier
            .size(size)
            .background(color, CircleShape)
            .clickable { large = !large }
    )
}

//Ejemplo: Tarjeta que rota, cambia tamaño y opacidad a la vez
@Composable
fun UpdateTransitionExample() {
    var expanded by remember { mutableStateOf(false) }

    val transition = updateTransition(expanded, label = "cardTransition")

    val rotation by transition.animateFloat(label = "rotation") {
        if (it) 180f else 0f
    }

    val alpha by transition.animateFloat(label = "alpha") {
        if (it) 1f else 0.6f
    }

    val height by transition.animateDp(label = "height") {
        if (it) 200.dp else 100.dp
    }

    Box(
        Modifier
            .height(height)
            .fillMaxWidth()
            .graphicsLayer { rotationY = rotation }
            .alpha(alpha)
            .background(Color(0xFF4CAF50), RoundedCornerShape(16.dp))
            .clickable { expanded = !expanded }
    )
}

//3. AnimatedVisibility — Animar aparición/desaparición
// Ejemplo: Ficha que aparece con fade + expand y desaparece con shrink
@Composable
fun AnimatedVisibilityExample() {
    var visible by remember { mutableStateOf(false) }

    Column(horizontalAlignment = Alignment.CenterHorizontally) {
        Button(onClick = { visible = !visible }) {
            Text("Mostrar/Ocultar")
        }

        Spacer(Modifier.height(16.dp))

        AnimatedVisibility(
            visible = visible,
            enter = fadeIn() + expandVertically(),
            exit = fadeOut() + shrinkVertically()
        ) {
            Box(
                Modifier
                    .size(150.dp)
                    .background(Color.Magenta, RoundedCornerShape(12.dp))
            )
        }
    }
}

// 4. rememberInfiniteTransition — Animaciones infinitas
// Ejemplo: Efecto de pulsación (heartbeat)
@Composable
fun InfiniteTransitionExample() {
    val infinite = rememberInfiniteTransition()

    val scale by infinite.animateFloat(
        initialValue = 1f,
        targetValue = 1.2f,
        animationSpec = infiniteRepeatable(
            animation = tween(800, easing = FastOutSlowInEasing),
            repeatMode = RepeatMode.Reverse
        ),
        label = "scale"
    )

    Box(
        Modifier
            .scale(scale)
            .size(120.dp)
            .background(Color.Red, CircleShape)
    )
}

//5. Animatable — Control total (gestos, físicas)
// Ejemplo: Caja que puedes arrastrar y vuelve con un resorte
@Composable
fun AnimatableDragExample() {
    val scope = rememberCoroutineScope()
    val offsetX = remember { Animatable(0f) }

    Box(
        Modifier
            .fillMaxSize()
            .padding(40.dp),
        contentAlignment = Alignment.Center
    ) {
        Box(
            Modifier
                .offset { IntOffset(offsetX.value.toInt(), 0) }
                .size(100.dp)
                .background(Color.Cyan, CircleShape)
                .draggable(
                    orientation = Orientation.Horizontal,
                    state = rememberDraggableState { delta ->
                        scope.launch {
                            offsetX.snapTo(offsetX.value + delta)
                        }
                    },
                    onDragStopped = {
                        offsetX.animateTo(
                            targetValue = 0f,
                            animationSpec = spring(dampingRatio = 0.3f)
                        )
                    }
                )
        )
    }
}

// 6. AnimatedContent — Transición entre contenido
// Ejemplo: Cambiar números con slide + fade
@OptIn(ExperimentalAnimationApi::class)
@Composable
fun AnimatedContentExample() {
    var counter by remember { mutableStateOf(0) }

    Column(horizontalAlignment = Alignment.CenterHorizontally) {
        Button(onClick = { counter++ }) {
            Text("Incrementar")
        }

        Spacer(Modifier.height(20.dp))

        AnimatedContent(
            targetState = counter,
            transitionSpec = {
                slideIntoContainer(AnimatedContentTransitionScope.SlideDirection.Up) +
                        fadeIn() togetherWith
                        slideOutOfContainer(AnimatedContentTransitionScope.SlideDirection.Down) +
                        fadeOut()
            }
        ) { target ->
            Text(
                text = target.toString(),
                fontSize = 48.sp,
                fontWeight = FontWeight.Bold
            )
        }
    }
}

// 7. AnimationSpec — Control de ritmo, tiempo y curvas
// Ejemplo: Caja que se mueve con tween, spring y keyframes
@Composable
fun AnimationSpecExample() {
    var toggle by remember { mutableStateOf(false) }

    val offset by animateDpAsState(
        targetValue = if (toggle) 200.dp else 0.dp,
        animationSpec = keyframes {
            durationMillis = 1200
            50.dp at 300
            150.dp at 600
        },
        label = "keyframes"
    )

    Box(
        Modifier
            .fillMaxSize()
            .padding(40.dp),
        contentAlignment = Alignment.TopStart
    ) {
        Box(
            Modifier
                .offset(x = offset)
                .size(80.dp)
                .background(Color.Black)
                .clickable { toggle = !toggle }
        )
    }
}