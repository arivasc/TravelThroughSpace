using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual = 100;
    public Slider barraDeVida;

    public GameObject canvasGameOver; // <- NUEVO

    void Start()
    {
        vidaActual = vidaMaxima;
        if (barraDeVida != null)
        {
            barraDeVida.maxValue = vidaMaxima;
            barraDeVida.value = vidaActual;
        }

        if (canvasGameOver != null)
            canvasGameOver.SetActive(false); // Asegúrate de ocultarlo al inicio
    }

    public void RecibirDamage(int cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Max(vidaActual, 0);

        if (barraDeVida != null)
            barraDeVida.value = vidaActual;

        Debug.Log("Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            Debug.Log("¡Nave destruida!");
            if (canvasGameOver != null)
                canvasGameOver.SetActive(true);
            Time.timeScale = 0; // Pausa el juego al morir
            // Puedes añadir aquí Time.timeScale = 0 si quieres pausar el juego
        }
    }
}
