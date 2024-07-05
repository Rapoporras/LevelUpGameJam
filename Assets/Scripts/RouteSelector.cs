using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSelector : MonoBehaviour
{

    public GameManager manager;
    public void NegacionistR()
    {
        manager.bandoJugador = false;
    }

    public void CientificR()
    {
        manager.bandoJugador = true;
    }
}
