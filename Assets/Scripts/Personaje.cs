using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Start is called before the first frame update
    public int vida; // La vida del personaje
    public int costeInvocacion;
    public int daño;
    public float speed;
    public GameObject zona;
    public bool Atacando; // Si es true el jugador es el bando Cientifico, si es false el jugador es el bando Terraplanista
    
     public AK.Wwise.Event soundEventHit;

     public AK.Wwise.Event soundEventAttack;

     public    AK.Wwise.Event soundEventDeath;
    void Start()
    {
        if (Atacando != true)
        {
            GameManager.instance.RestarEnergia(costeInvocacion);
        }
        if (vida == 0)
        {
            Debug.Log("Vida no asignada");
          
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    private void OnDestroy() {
        if(zona!=null)
        {
           zona.GetComponent<Zona>().ocupada = false;
        }
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
        soundEventHit.Post(gameObject);
    }


}
