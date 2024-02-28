using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Referencias a los elementos visuales en el editor de Unity.
    [SerializeField] private TextMeshProUGUI textoPuntos;
    [SerializeField] private TextMeshProUGUI textoTiempo;
    [SerializeField] private TextMeshProUGUI textoFinal;

    private int puntos = 0;
    private float tiempo = 40;
    private bool juegoTerminado = false;

    public void Update()
    {
        if (!juegoTerminado)
        {
            // Disminuir el tiempo en cada fotograma.
            tiempo -= Time.deltaTime;

            // Asegurarse de que el tiempo no sea negativo
            tiempo = Mathf.Max(tiempo, 0);

            // Actualizar el texto del tiempo en la interfaz.
            textoTiempo.text = "" + (int)tiempo;

            // Verificar si el tiempo se ha agotado.
            if (tiempo <= 0f)
            {
                PierdePartida();
            }
            // Verificar si se han obtenido suficientes puntos para ganar.
            if (puntos >= 12)
            {
                GanarPartida();
            }
        }
    }

    public void ObtenerPts()
    {
        if (!juegoTerminado)
        {
            puntos++;

            // Actualizar el texto de puntos en la interfaz.
            textoPuntos.text = "" + puntos;

            if (puntos >= 12)
            {
                GanarPartida();
            }
        }
    }

    private void GanarPartida()
    {
        // Establecer el juego como terminado.
        juegoTerminado = true;

        // Establecer el tiempo en 0 para evitar que siga restando
        tiempo = 0;

        // Mostrar el mensaje de victoria en la interfaz.
        textoFinal.gameObject.SetActive(true);
        textoFinal.text = "Has ganado!";

        // Pausar el tiempo
        Time.timeScale = 0;
    }

    private void PierdePartida()
    {
        juegoTerminado = true;
        textoFinal.gameObject.SetActive(true);
        textoFinal.text = "Has perdido :(";

        Time.timeScale = 0;
    }
}