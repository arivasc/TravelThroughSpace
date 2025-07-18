using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual = 100;

    public Slider barraDeVida;

    void Start()
    {
        vidaActual = vidaMaxima;
        if (barraDeVida != null)
        {
            barraDeVida.maxValue = vidaMaxima;
            barraDeVida.value = vidaActual;
        }
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
            // Aquí podrías mostrar Game Over o reiniciar nivel
        }
    }
}
