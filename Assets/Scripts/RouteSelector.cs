using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouteSelector : MonoBehaviour
{

    //public GameManager manager;
    public int level;
    public void NegacionistR()
    {
        PlayerPrefs.SetInt("Negacion", 1);
        //manager.bandoJugador = false;
        SceneManager.LoadSceneAsync(level);
    }

    public void CientificR()
    {

        PlayerPrefs.SetInt("Negacion", 0);
        //manager.bandoJugador = true;

        SceneManager.LoadSceneAsync(level);
    }
}
