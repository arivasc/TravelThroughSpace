using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float velocidadLateral = 0.5f;
    public int daño = 10;

    void Update()
    {
        // Movimiento lateral constante (opcional)
        transform.position += Vector3.left * velocidadLateral * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tierra2.0"))
        {
            VidaJugador vida = collision.gameObject.GetComponent<VidaJugador>();
            if (vida != null)
            {
                vida.RecibirDamage(daño);
            }

            // Destruir asteroide tras impacto (opcional)
            Destroy(gameObject);
        }
    }
}
