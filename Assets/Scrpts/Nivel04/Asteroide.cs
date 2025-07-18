using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float velocidadLateral = 0.5f;
    public int damage = 20;

    void Update()
    {
        // Movimiento lateral constante
        transform.position += Vector3.left * velocidadLateral * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tierra2.0"))
        {
            VidaJugador vida = other.GetComponent<VidaJugador>();
            if (vida != null)
            {
                vida.RecibirDamage(damage);
            }

            // Destruye el asteroide tras chocar (opcional)
            Destroy(gameObject);
        }
    }
}
