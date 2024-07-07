using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorAtacantes : MonoBehaviour
{
    public GameObject[] atacantes;
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    public int enemiesPerWave = 10;
    public int enemiesDefeatedToAdvance = 10;
    public int maxWaves = 5; // Número máximo de waves
    public GameObject bossPrefab; // Prefab del boss final
    public Transform bossSpawnPoint; // Punto de spawn del boss final

    private int currentWave = 1;
    private int enemiesSpawned;
    private int enemiesDefeated;

    void Start()
    {
        Debug.Log("InstanciadorAtacantes Start");
        InvokeRepeating("SpawnAtacante", spawnTime, spawnTime);
    }
    public void ResetSpawn()
    {
        currentWave = 1;
        enemiesSpawned = 0;
        enemiesDefeated = 0;
        CancelInvoke("SpawnAtacante");
        InvokeRepeating("SpawnAtacante", spawnTime, spawnTime);

        Atacante[] atacantesEnEscena = FindObjectsOfType<Atacante>();
        foreach (Atacante atacante in atacantesEnEscena)
        {
            Destroy(atacante.gameObject);
        }
    }
    void SpawnAtacante()
    {
        if (enemiesSpawned >= enemiesPerWave * currentWave)
        {
            CancelInvoke("SpawnAtacante");
            return;
        }

        Debug.Log("InstanciadorAtacantes SpawnAtacante");
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int atacanteIndex = Random.Range(0, atacantes.Length);
        Instantiate(atacantes[atacanteIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemiesSpawned++;
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        if (enemiesDefeated >= enemiesDefeatedToAdvance * currentWave)
        {
            AdvanceWave();
        }
    }

    void AdvanceWave()
    {
        if (currentWave >= maxWaves)
        {
            InvokeBoss();
        }
        else
        {
            currentWave++;
            GameManager.instance.UpdateWave(currentWave);
            enemiesSpawned = 0;
            enemiesDefeated = 0;
            InvokeRepeating("SpawnAtacante", spawnTime, spawnTime);
        }
    }

    void InvokeBoss()
    {
        Debug.Log("InstanciadorAtacantes InvokeBoss");
        Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
        // Puedes agregar lógica adicional aquí para manejar la batalla con el boss.
    }
}