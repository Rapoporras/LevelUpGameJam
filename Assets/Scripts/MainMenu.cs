using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AK.Wwise.Event soundButton;
    public AK.Wwise.Event musicMenu;
    // Start is called before the first frame update
    void Start()
    {
        musicMenu.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        soundButton.Post(gameObject);
        // Cargar la escena del juego
        SceneManager.LoadScene("LoopGameScene");
    }

    public void QuitGame()
    {
        soundButton.Post(gameObject);
        // Salir de la aplicación
        Application.Quit();
    }

    private void OnDestroy()
    {
        musicMenu.Stop(gameObject);
    }

}
