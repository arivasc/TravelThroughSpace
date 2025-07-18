using UnityEngine;

public class ControladorNavePrimeraPersona : MonoBehaviour
{
    public float velocidadMovimiento = 10f;
    public float velocidadRotacion = 60f;
    public Transform camara;

    void Start()
    {
        Debug.Log("Controlador de nave activado");
    }

    void Update()

    {
        Debug.Log("Input activo: " + Input.GetKey(KeyCode.Space));
        // Movimiento hacia adelante con ESPACIO
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.forward * velocidadMovimiento * Time.deltaTime;
        }

        // Rotación vertical (pitch) con W y S
        float rotacionX = 0f;
        if (Input.GetKey(KeyCode.W))
            rotacionX = -1f;
        else if (Input.GetKey(KeyCode.S))
            rotacionX = 1f;

        // Rotación horizontal (yaw) con A y D
        float rotacionY = 0f;
        if (Input.GetKey(KeyCode.A))
            rotacionY = -1f;
        else if (Input.GetKey(KeyCode.D))
            rotacionY = 1f;

        // Aplicar rotación
        transform.Rotate(rotacionX * velocidadRotacion * Time.deltaTime,
                         rotacionY * velocidadRotacion * Time.deltaTime,
                         0f, Space.Self);
    }
}
