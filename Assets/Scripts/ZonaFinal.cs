using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class ZonaFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Personaje personaje = other.GetComponent<Personaje>();
        if (personaje != null)
        {
            personaje.destruir();
        }
    }
}
