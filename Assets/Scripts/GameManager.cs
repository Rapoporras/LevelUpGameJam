using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    // [SerializeField] private TextMeshProUGUI energiaText; // Texto para mostrar la energia del jugador
    public bool gameOver = false; // Indica si el juego ha terminado
    public bool bandoJugador = true; // Si es true el jugador es el bando Cientifico, si es false el jugador es el bando Terraplanista
                                     // [SerializeField] private TextMeshProUGUI bandoText;
    public StatusController statusController;
    public InstanciadorAtacantes instanciadorAtacantes;

    public float timeSpawnEnergy = 5f;
    public int energyPerTime = 10;

    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject pauseScreen;
    public bool isPaused = false;

    public AK.Wwise.Event soundWin;
    public AK.Wwise.Event soundGameOver;
    public AK.Wwise.Event soundRecarge;
    public AK.Wwise.Event soundButton;
    // public AK.Wwise.Event soundImpancto;
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
        gameOver = false;
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        instanciadorAtacantes.ResetSpawn();
        Time.timeScale = 1;
        soundButton.Post(gameObject);
        statusController.SetInitialValues();
        StartCoroutine(GenerateEnergy());
    }

    // Update is called once per frame
    void Update()
    {
        // if (bandoJugador)
        // {
        //     bandoText.text = "Científico";
        // }
        // else
        // {
        //     bandoText.text = "Terraplanista";
        // }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (gameOver)
        {
            GameOver();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {

        soundButton.Post(gameObject);
        isPaused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ResetGame()
    {
        gameOver = false;
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        statusController.SetInitialValues();
        instanciadorAtacantes.ResetSpawn();
        StartCoroutine(GenerateEnergy());
        Time.timeScale = 1;
        soundButton.Post(gameObject);
    }

    public void GameOver()
    {
        soundGameOver.Post(gameObject);
        gameOver = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;

    }

    public void WinGame()
    {
        gameOver = true;
        winScreen.SetActive(true);
        Time.timeScale = 0;
        soundGameOver.Post(gameObject);

    }

    public void MainMenu()
    {
        soundButton.Post(gameObject);
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {
        soundButton.Post(gameObject);
        Application.Quit();
    }


    public void EnemigoDerrotado()
    {
        instanciadorAtacantes.EnemyDefeated();
    }
    public void RestarEnergia(int cantidad)
    {
        statusController.RestarEnergia(cantidad);
    }

    public void SumarEnergia(int cantidad)
    {
        statusController.SumarEnergia(cantidad);
        soundRecarge.Post(gameObject);
    }


    public void RestarVida(int cantidad)
    {
        statusController.RestarVida(cantidad);
    }

    public void SumarVidaint(int cantidad)
    {
        statusController.SumarEnergia(cantidad);
    }

    // Llama a esta función para actualizar la energía
    public int GetEnergy()
    {

        return statusController.GetEnergy();
    }
    IEnumerator GenerateEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawnEnergy);
            SumarEnergia(energyPerTime);
        }
    }


    public void UpdateWave(int orda)
    {

        statusController.SumarHorda(orda);
    }
    public void CambiarBando()
    {
        // Cambiar el bando del jugador
        bandoJugador = !bandoJugador;
    }
}
