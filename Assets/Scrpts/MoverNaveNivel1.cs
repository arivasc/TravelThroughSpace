using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverNaveNivel1 : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad de movimiento de la nave

    // Start is called before the first frame update
    Rigidbody rigidbody;
    public AudioSource propulsionAudioSource;
    private bool isMoving = false;
    public Transform transforms;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transforms = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        procesarInput();
        rotacion();
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
            rigidbody.linearVelocity = direccion.normalized * velocidad; // Mover en la direcci�n calculada
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

    public void rotacion()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var rotarDerecha = transforms.rotation;
            rotarDerecha.z -= Time.deltaTime * 1 / 2;
            transforms.rotation = rotarDerecha;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            var rotarIzquierda = transforms.rotation;
            rotarIzquierda.z += Time.deltaTime * 1 / 2;
            transforms.rotation = rotarIzquierda;
        }
 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("meteorito"))
        {
            Debug.Log("La nave ha colisionado con un meteorito.");
            // Aqu� puedes agregar cualquier l�gica que desees cuando la nave colisione con un meteorito
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
