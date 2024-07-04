using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Start is called before the first frame update
    public int vida; // La vida del personaje
    public int costeInvocacion;
    public int daño;
    public int speed;

    public bool Atacando; // Si es true el jugador es el bando Cientifico, si es false el jugador es el bando Terraplanista
    void Start()
    {
        GameManager.instance.RestarEnergia(costeInvocacion);
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }

        if (Atacando)
        {
            mover();
        }
    }
    public void destruir()
    {
        Destroy(gameObject);
    }
    public void mover()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    public virtual void Atacar(Personaje objetivo)
    {
        Debug.Log("Atacando a " + objetivo.name);
    }

    public virtual void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
    }
}
