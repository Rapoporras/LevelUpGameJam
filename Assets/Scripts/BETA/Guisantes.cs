using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guisantes : MonoBehaviour
{
    public int velocidad = 10;
    public int da�o = 1;


    void Update()
    {
        transform.position += Vector3.right * velocidad * Time.deltaTime;
    }
}
