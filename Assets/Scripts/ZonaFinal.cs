using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Atacante llego al final");
        if (other.CompareTag("Atacante"))
        {
            Debug.Log("Atacante llego al final");
            Atacante atacante = other.GetComponent<Atacante>();
            if (atacante != null)
            {
                atacante.LlegarAlFinal();
                GameManager.instance.RestarVida(1);
            }
        }
    }
}
