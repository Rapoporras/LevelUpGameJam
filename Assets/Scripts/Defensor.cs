using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defensor : Personaje
{
    public GameObject objetoLanzadoPrefab;
    public float frecuenciaDisparo = 1f; // Frecuencia de disparo en segundos
    private float tiempoSiguienteDisparo = 0f; // Tiempo hasta el siguiente disparo permitido
    [SerializeField] private List<Transform> enemigosDetectados = new List<Transform>();
    [SerializeField] private TiposDefensor tipoDefensor;
    [SerializeField] private Animator anim;
    public enum TiposDefensor
    {

        Tank,
        Ranged,
        Melee,
        Summoner,

        Surprised
    }
    private void Update()
    {
        if (tipoDefensor == TiposDefensor.Ranged)
        {
            Transform enemigoMasCercano = EncontrarEnemigoMasCercano();
            if (enemigoMasCercano != null && Time.time >= tiempoSiguienteDisparo)
            {
                anim.SetTrigger("isAttack");
                LanzarObjeto(enemigoMasCercano);

                tiempoSiguienteDisparo = Time.time + frecuenciaDisparo;

            }
        }
        if (vida <= 0)
        {
            Destroy(gameObject);
            soundEventDeath.Post(gameObject);
        }

        if (Atacando)
        {
            mover();
        }

    }

    private void LanzarObjeto(Transform objetivo)
    {
        Debug.Log("LanzarObjeto a " + objetivo.name);
        GameObject objeto = Instantiate(objetoLanzadoPrefab, transform.position, Quaternion.identity);
        ObjetoLanzado objetoLanzadoScript = objeto.GetComponent<ObjetoLanzado>();
        if (objetoLanzadoScript != null)
        {
            objetoLanzadoScript.SetObjetivo(objetivo);
        }
    }

    private Transform EncontrarEnemigoMasCercano()
    {
        Transform enemigoCercano = null;
        float minDistancia = Mathf.Infinity;

        foreach (Transform enemigo in enemigosDetectados)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.position);
            if (distancia < minDistancia)
            {
                enemigoCercano = enemigo;
                minDistancia = distancia;
            }
        }

        return enemigoCercano;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
        //Efecto gato de Schrödinger
        if (other.gameObject.CompareTag("Atacante") && tipoDefensor == TiposDefensor.Surprised)
        {
            Debug.Log("Surprised");
            int random = Random.Range(0, 10);
            if (random % 2 == 0)
            {
                Debug.Log("Libre");
                anim.SetTrigger("libre");
                Destroy(other.gameObject);

            }
            else
            {
                Debug.Log("Explota");
                anim.SetTrigger("explota");
                // Destroy(gameObject);
                // if (!isDestroyed && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
                // {
                //     Destroy(gameObject);
                //     isDestroyed = true;
                // }

            }
        }
        else if (other.gameObject.CompareTag("Atacante") && tipoDefensor == TiposDefensor.Melee)
        {
            other.gameObject.GetComponent<Atacante>().RecibirDaño(daño);
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Atacante"))
        {
            enemigosDetectados.Add(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Atacante"))
        {
            enemigosDetectados.Remove(other.transform);
        }
    }
}