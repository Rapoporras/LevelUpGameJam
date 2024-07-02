using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{

    public Cuadricula cuadricula; // La referencia al script de la cuadrícula
    public GameObject personajePrefab; // Prefab del personaje correspondiente a esta carta
    [SerializeField] private GameObject noDisponible; // GameObject que se muestra cuando no hay suficiente energía para invocar al personaje

    public GameObject personajeBandoCientifico; // Prefab del personaje correspondiente al bando Científico
    public GameObject personajeBandoTerraplanista; // Prefab del personaje correspondiente al bando Terraplanista

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        setPersonajeBando();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        setPersonajeBando();
        // Si no hay suficiente energía para invocar al personaje, mostrar el GameObject noDisponible
        if (personajePrefab.GetComponent<Personaje>().costeInvocacion > GameManager.instance.energia)
        {
            noDisponible.SetActive(true);
        }
        else
        {
            noDisponible.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (cuadricula.HayZonasDisponibles() && personajePrefab.GetComponent<Personaje>().costeInvocacion <= GameManager.instance.energia)
        {
            // Pasar el personaje a la cuadrícula y mostrar la cuadrícula
            cuadricula.SetPersonaje(personajePrefab);
            cuadricula.gameObject.SetActive(true);
        }
    }

    private void setPersonajeBando()
    {
        if (GameManager.instance.bandoJugador)
        {
            personajePrefab = personajeBandoCientifico;
        }
        else
        {
            personajePrefab = personajeBandoTerraplanista;
        }
    }

}