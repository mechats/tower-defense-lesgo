using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using System.Collections;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f; // Intervalo en segundos
    public WaveManager waveManager;

    private Coroutine spawnCoroutine;

    void Start()
    {
        if (waveManager == null)
        {
            waveManager = Object.FindAnyObjectByType<WaveManager>();
        }

        // Iniciamos la rutina una sola vez al comenzar
        spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    // Eliminamos FixedUpdate porque la corrutina gestiona su propio tiempo
    IEnumerator SpawnRoutine()
    {
        while (true) // Bucle infinito mientras el objeto exista
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy(enemyPrefab);
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Vector3 startPos = waveManager.rutaPath.transform.position;

        GameObject enemy = Instantiate(prefab, startPos, Quaternion.identity);
        Character character = enemy.GetComponent<Character>();

        MMPathMovement pathMovement = enemy.GetComponent<MMPathMovement>();

        if (pathMovement != null)
        {
            // 2. Asignamos la ruta
            pathMovement.PathElements = waveManager.rutaPath.PathElements;

            // 3. Forzamos la inicialización manual
            pathMovement.Initialization();
        }

        // 4. IMPORTANTE: Si es un Character de More Mountains, inicialízalo
        if (character != null)
        {
            character.SetPlayerID("Enemy"); // O el ID que uses
        }
    }

    // Es buena práctica detener la corrutina si el generador muere
    private void OnDisable()
    {
        if (spawnCoroutine != null) StopCoroutine(spawnCoroutine);
    }
}