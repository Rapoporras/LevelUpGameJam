using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Carta : MonoBehaviour
{

    public Cuadricula cuadricula; // La referencia al script de la cuadrícula
    public GameObject personajePrefab; // Prefab del personaje correspondiente a esta carta
    [SerializeField] private GameObject noDisponible; // GameObject que se muestra cuando no hay suficiente energía para invocar al personaje

    public GameObject personajeBandoCientifico; // Prefab del personaje correspondiente al bando Científico
    public GameObject personajeBandoTerraplanista; // Prefab del personaje correspondiente al bando Terraplanista
    private bool cuadriculaActiva = false; // Indica si la cuadrícula está activa

    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer del GameObject

    [SerializeField] private GameObject spriteCientifico; // Sprite del bando Científico
    [SerializeField] private GameObject spriteTerraplanista; // Sprite del bando Terraplanista
    [SerializeField] private Sprite fondoCartaCientifico; // Fondo de la carta del bando Científico
    [SerializeField] private Sprite fondoCartaTerraplanista; // Fondo de la carta del bando Terraplanista
    [SerializeField] private TextMeshProUGUI textoCosteInvocacion; // Texto que muestra el coste de invocación del personaje
    // public AK.Wwise.Event myEvent;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        setPersonajeBando();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (GameManager.instance.bandoJugador)
        {
            spriteRenderer.sprite = fondoCartaCientifico;
            // GetComponent<SpriteRenderer>().sortingOrder = 1;
            spriteCientifico.SetActive(true);

        }
        else
        {
            spriteRenderer.sprite = fondoCartaTerraplanista;
            // GetComponent<SpriteRenderer>().sortingOrder = 1;
            spriteTerraplanista.SetActive(true);
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        setPersonajeBando();
        // Si no hay suficiente energía para invocar al personaje, mostrar el GameObject noDisponible
        if (personajePrefab.GetComponent<Personaje>().costeInvocacion > GameManager.instance.GetEnergy())
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
        if (cuadriculaActiva == false)
        {
            if (cuadricula.HayZonasDisponibles() && personajePrefab.GetComponent<Personaje>().costeInvocacion <= GameManager.instance.GetEnergy())
            {
                // myEvent.Post(gameObject);
                // Pasar el personaje a la cuadrícula y mostrar la cuadrícula
                cuadricula.SetPersonaje(personajePrefab);
                cuadricula.gameObject.SetActive(true);
                cuadriculaActiva = true;
            }
        }
        else
        {
            cuadricula.gameObject.SetActive(false);
            cuadriculaActiva = false;
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

        textoCosteInvocacion.text = personajePrefab.GetComponent<Personaje>().costeInvocacion.ToString();
    }

}