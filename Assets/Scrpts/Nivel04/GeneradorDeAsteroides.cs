using UnityEngine;

public class GeneradorDeAsteroides : MonoBehaviour
{
    public GameObject prefabAsteroide;
    public Transform nave;
    public Transform marte;
    public int cantidadAsteroides = 50;
    public Vector3 dispersión = new Vector3(20f, 20f, 20f);

    void Start()
    {
        Vector3 direccion = marte.position - nave.position;

        for (int i = 0; i < cantidadAsteroides; i++)
        {
            // Posición entre nave y Marte + aleatoriedad
            float t = Random.Range(0.2f, 0.9f); // no tan cerca de nave ni de Marte
            Vector3 basePos = nave.position + direccion * t;
            Vector3 posicion = basePos + new Vector3(
                Random.Range(-dispersión.x, dispersión.x),
                Random.Range(-dispersión.y, dispersión.y),
                Random.Range(-dispersión.z, dispersión.z)
            );

            GameObject asteroide = Instantiate(prefabAsteroide, posicion, Random.rotation);
            float escala = Random.Range(0.5f, 2.5f);
            asteroide.transform.localScale = Vector3.one * escala;
        }
    }
}
