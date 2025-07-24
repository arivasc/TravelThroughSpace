using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionTierra : MonoBehaviour
{
    public Canvas nextLvlPlayCanvas; // Referencia al Canvas de "Next Level"
    public string nextSceneName = "Nivel 04"; // Nombre de la siguiente escena

    void Start()
    {
        if (nextLvlPlayCanvas != null)
        {
            nextLvlPlayCanvas.gameObject.SetActive(false); // Asegúrate de que esté desactivado al inicio
            Debug.Log("Canvas de Next Level desactivado al inicio.");
        }
        else
        {
            Debug.LogError("No se encontró el Canvas de Next Level.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name); // Línea de depuración

        if (collision.gameObject.CompareTag("tierra2.0")) // Verifica si el objeto colisionado tiene el tag "tierra"
        {
            Time.timeScale = 0;
            MostrarNextLevelCanvas();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado con: " + other.gameObject.name); // Línea de depuración

        if (other.CompareTag("tierra2.0")) // Verifica si el objeto colisionado tiene el tag "tierra"
        {
           
            MostrarNextLevelCanvas();
        }
    }

    void MostrarNextLevelCanvas()
    {
        if (nextLvlPlayCanvas != null)
        {
            nextLvlPlayCanvas.gameObject.SetActive(true); // Mostrar el Canvas de "Next Level"
            Time.timeScale = 0; // Pausar el juego
             // Pausar el juego
            Debug.Log("Mostrando el Canvas de Siguiente Nivel y pausando el juego.");
        }
        else
        {
            Debug.LogError("nextLvlPlayCanvas no está asignado.");
        }
         
    }
    
}
