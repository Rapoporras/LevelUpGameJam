using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CientDef1 : Personaje
{
    // Start is called before the first frame updat



    public override void Atacar(Personaje objetivo)
    {
        Debug.Log("Atacando a " + objetivo.name);
    }

    public override void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
    }
}

