using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int energia = 100; // El energia inicial del jugador
    [SerializeField] private TextMeshProUGUI energiaText; // Texto para mostrar la energia del jugador
    public bool gameOver = false; // Indica si el juego ha terminado
    public bool bandoJugador = true; // Si es true el jugador es el bando Cientifico, si es false el jugador es el bando Terraplanista
    [SerializeField] private TextMeshProUGUI bandoText;
    private void Awake()
    {
        // Verificar si ya existe una instancia del Singleton
        if (instance == null)
        {
            // Si no existe, esta instancia se convierte en la instancia única
            instance = this;
            // Opción para hacer que el GameManager persista entre escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruir esta para asegurar que solo hay una
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        energiaText.text = energia.ToString();


        StartCoroutine(GenerateEnergy());
    }

    // Update is called once per frame
    void Update()
    {
        if (bandoJugador)
        {
            bandoText.text = "Científico";
        }
        else
        {
            bandoText.text = "Terraplanista";
        }
    }

    public void RestarEnergia(int cantidad)
    {
        // Restar la cantidad de energia especificada
        energia -= cantidad;
        // Actualizar el texto de la energia
        energiaText.text = energia.ToString();
    }

    public void SumarEnergia(int cantidad)
    {
        // Sumar la cantidad de energia especificada
        energia += cantidad;
        // Actualizar el texto de la energia
        energiaText.text = energia.ToString();
    }

    IEnumerator GenerateEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            SumarEnergia(5);
        }
    }

    public void CambiarBando()
    {
        // Cambiar el bando del jugador
        bandoJugador = !bandoJugador;
    }
}
