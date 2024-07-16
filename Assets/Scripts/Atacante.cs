using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacante : Personaje
{
    // Start is called before the first frame update



    void OnDestroy()
    {
        GameManager.instance.EnemigoDerrotado();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Atacante OnCollisionEnter2D");
        if (other.gameObject.CompareTag("Defensor"))
        {
            Debug.Log("defensor OnCollisionEnter2D");
            Defensor defensor = other.gameObject.GetComponent<Defensor>();
            if (defensor != null)
            {
                // Detener el movimiento del atacante si hay un defensor delante
                speed = 0;
                // Aquí puedes añadir la lógica de ataque contra el defensor
                defensor.RecibirDaño(daño);
            }
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Atacante OnCollisionExit2D");
        if (other.gameObject.CompareTag("Defensor"))
        {
            Debug.Log("defensor OnCollisionExit2D");
            Defensor defensor = other.gameObject.GetComponent<Defensor>();
            if (defensor != null)
            {
                // Reanudar el movimiento del atacante si no hay un defensor delante
                speed = 1;
            }
        }
    }
    public void LlegarAlFinal()
    {

        Destroy(gameObject);
    }
}
