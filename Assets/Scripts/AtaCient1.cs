using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaCient1 : Personaje
{
    // Start is called before the first frame update
    
    public override void Atacar(Personaje objetivo)
    {
        Debug.Log("Atacando a " + objetivo.name);
    }

    public override void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
    }

    

    private void Update() {
        
        mover();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Colision");
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
