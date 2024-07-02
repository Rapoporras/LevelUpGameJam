using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Start is called before the first frame update
    public int vida = 100; // La vida del personaje
    public int costeInvocacion = 10; // El coste de invocar al personaje
    void Start()
    {
        GameManager.instance.RestarEnergia(costeInvocacion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
