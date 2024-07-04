using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorAtacantes : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] atacantes;
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    
    void Start()
    {
        InvokeRepeating("SpawnAtacante", spawnTime, spawnTime);
    }
     
    void SpawnAtacante()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int atacanteIndex = Random.Range(0, atacantes.Length);
        Instantiate(atacantes[atacanteIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
   
}
