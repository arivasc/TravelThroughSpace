using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena1 : MonoBehaviour
{
    public string nextSceneName = "Nivel 03"; // Nombre de la siguiente escena

    public void CargarSiguienteNivel()
    {
        Time.timeScale = 1; // Asegúrate de que el tiempo esté corriendo
        Debug.Log("Cargando siguiente nivel: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
