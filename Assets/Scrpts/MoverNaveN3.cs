using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverNaveN3 : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad de movimiento de la nave
    private Rigidbody rigidbody;
    public AudioSource propulsionAudioSource; // Asigna esto en el Inspector
    private bool isMoving = false;

    void Start()
    {
        Time.timeScale = 1f;
        rigidbody = GetComponent<Rigidbody>();

        // Asegúrate de que el AudioSource esté asignado
        if (propulsionAudioSource == null)
        {
            Debug.LogError("No se encontró el AudioSource para el sonido de propulsión.");
        }
    }

    void Update()
    {
        procesarInput();
    }

    private void procesarInput()
    {
        Mover();
    }

    private void Mover()
    {
        Vector3 direccion = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direccion += Vector3.up; // Mover hacia arriba
        }
        if (Input.GetKey(KeyCode.S))
        {
            direccion += Vector3.down; // Mover hacia abajo
        }
        if (Input.GetKey(KeyCode.A))
        {
            direccion += Vector3.left; // Mover hacia la izquierda
        }
        if (Input.GetKey(KeyCode.D))
        {
            direccion += Vector3.right; // Mover hacia la derecha
        }

        if (direccion != Vector3.zero)
        {
            rigidbody.linearVelocity = direccion.normalized * velocidad; // Mover en la dirección calculada
            if (!isMoving)
            {
                PlayPropulsionSound(true);
            }
        }
        else
        {
            rigidbody.linearVelocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            if (isMoving)
            {
                PlayPropulsionSound(false);
            }
        }
    }

    private void PlayPropulsionSound(bool play)
    {
        if (propulsionAudioSource != null)
        {
            if (play)
            {
                if (!propulsionAudioSource.isPlaying)
                {
                    propulsionAudioSource.Play();
                    isMoving = true;
                }
            }
            else
            {
                propulsionAudioSource.Stop();
                isMoving = false;
            }
        }
        else
        {
            Debug.LogError("propulsionAudioSource es nulo.");
        }
    }
}
