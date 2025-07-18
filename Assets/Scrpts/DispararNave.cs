using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararNave : MonoBehaviour
{
    public GameObject proyectilPrefab; // Prefab del proyectil
    public Transform puntoDisparo; // Punto desde donde se disparar� el proyectil
    public float velocidadProyectil = 20f; // Velocidad del proyectil

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Instancia el proyectil en la posici�n y rotaci�n del punto de disparo
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // A�ade velocidad al proyectil
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        rb.linearVelocity = puntoDisparo.forward * velocidadProyectil;

        // Destruye el proyectil despu�s de 2 segundos para evitar sobrecarga de la escena
        Destroy(proyectil, 2f);
    }
}
