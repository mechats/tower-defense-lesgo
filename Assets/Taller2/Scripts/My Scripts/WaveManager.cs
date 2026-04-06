using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public GameObject enemyPrefab;
        public int enemyCount;
        public float spawnInterval;
    }

    [Header("Configuración")]
    public List<Wave> waves;
    public Transform spawnPoint;
    public MMPath rutaPath;
    public float timeBetweenWaves = 5f;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(StartWaves());
    }

    IEnumerator StartWaves()
    {
        while (currentWave < waves.Count)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            yield return StartCoroutine(SpawnWave(waves[currentWave]));
            currentWave++;
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log($"Oleada: {wave.waveName}");

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.spawnInterval);
        }
    }

    void SpawnEnemy(GameObject prefab) 
    {
        GameObject enemy = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        // 1. Obtenemos el componente Character (si lo tiene)
        Character character = enemy.GetComponent<Character>();
    
        MMPathMovement pathMovement = enemy.GetComponent<MMPathMovement>();
    
        if (pathMovement != null)
        {
            // 2. Asignamos la ruta
            pathMovement.PathElements = rutaPath.PathElements;       
        
            // 3. Forzamos la inicialización manual
            pathMovement.Initialization(); 
        }

        // 4. IMPORTANTE: Si es un Character de More Mountains, inicialízalo
        if (character != null)
        {
            character.SetPlayerID("Enemy"); // O el ID que uses
        }
    }
}