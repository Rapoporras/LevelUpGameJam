using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoLanzado : MonoBehaviour
{
    public float velocidad = 10f;  // Velocidad del objeto lanzado
    private Transform objetivo;    // Objetivo al que se dirige el objeto lanzado
    public int dano = 10;          // Daño que inflige el objeto lanzado

    void Start()
    {
        // Opcional: Destruir el objeto lanzado después de un tiempo para evitar que se quede en la escena indefinidamente
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (objetivo != null)
        {
            // Mover el objeto lanzado hacia el objetivo
            Vector3 direccion = (objetivo.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
        else
        {
            // Si no hay objetivo, destruir el objeto lanzado
            Destroy(gameObject);
        }
    }

    public void SetObjetivo(Transform nuevoObjetivo)
    {
        objetivo = nuevoObjetivo;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Atacante"))
        {
            // Aplicar daño al enemigo
            Atacante enemigo = other.gameObject.GetComponent<Atacante>();
            if (enemigo != null)
            {
                enemigo.RecibirDaño(dano);
            }

            // Destruir el objeto lanzado después de impactar
            Destroy(gameObject);
        }
    }
}