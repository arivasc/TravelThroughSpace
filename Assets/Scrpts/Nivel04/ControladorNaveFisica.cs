using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControladorNaveFisica : MonoBehaviour
{
    public float aceleracion = 10f;
    public float desaceleracion = 5f;
    public float velocidadMaxima = 20f;
    public float rotacionVelocidad = 60f;
    public int damage = 20; // daño al chocar con objetos

    public AudioSource motorAudio;      // sonido de impulso
    public AudioSource ambienteAudio;   // fondo espacial
    public AudioSource choqueAudio;     // se reproduce al chocar

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (ambienteAudio != null && !ambienteAudio.isPlaying)
            ambienteAudio.Play();
    }

    void Update()
    {
        // Rotación
        float rotX = 0f;
        if (Input.GetKey(KeyCode.W)) rotX = -1f;
        else if (Input.GetKey(KeyCode.S)) rotX = 1f;

        float rotY = 0f;
        if (Input.GetKey(KeyCode.A)) rotY = -1f;
        else if (Input.GetKey(KeyCode.D)) rotY = 1f;

        transform.Rotate(rotX * rotacionVelocidad * Time.deltaTime,
                         rotY * rotacionVelocidad * Time.deltaTime,
                         0f, Space.Self);

        // Sonido de impulso
        if (Input.GetKeyDown(KeyCode.Space) && motorAudio != null)
            motorAudio.Play();
        if (Input.GetKeyUp(KeyCode.Space) && motorAudio != null)
            motorAudio.Stop();
    }

    void FixedUpdate()
    {
        // Aceleración con Space
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * aceleracion, ForceMode.Acceleration);
        }
        else
        {
            // Desaceleración suave
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, desaceleracion * Time.fixedDeltaTime);
        }

        // Limita la velocidad máxima
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, velocidadMaxima);
    }

    void OnCollisionEnter(Collision collision)
    {
        VidaJugador vida = collision.gameObject.GetComponent<VidaJugador>();
        if (vida != null)
        {
            vida.RecibirDamage(damage);
        }
        else
        {
            // Si no es un objeto con VidaJugador, podrías manejarlo de otra forma
            Debug.Log("Colisión con: " + collision.gameObject.name);
        }
        if (choqueAudio != null)
            choqueAudio.Play();
    }
}
