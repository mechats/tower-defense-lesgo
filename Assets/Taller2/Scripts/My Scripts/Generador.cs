using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using System.Collections;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [Header("Configuración de Spawn")]
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;

    [Header("Referencias")]
    public WaveManager waveManager;

    private MMPathMovement _generatorMovement;
    private Coroutine _spawnLoop;

    void Start()
    {
        _generatorMovement = GetComponent<MMPathMovement>();

        if (waveManager == null)
            waveManager = Object.FindAnyObjectByType<WaveManager>();

        _spawnLoop = StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || _generatorMovement == null) return;

        // 1. Instanciamos el enemigo en la posición actual del generador
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // 2. Obtenemos el componente de movimiento
        MMPathMovement enemyMovement = enemy.GetComponent<MMPathMovement>();

        if (enemyMovement != null)
        {
            // HERENCIA DE RUTA: 
            // Copiamos la lista completa de puntos del generador al enemigo
            // Usamos una nueva lista para no modificar la del generador por referencia
            enemyMovement.PathElements = new System.Collections.Generic.List<MMPathElement>(_generatorMovement.PathElements);

            // SINCRONIZACIÓN: 
            // Buscamos cuál es el punto de la ruta más cercano al generador ahora mismo
            int indiceCercano = 0;
            float distanciaMinima = float.MaxValue;

            for (int i = 0; i < enemyMovement.PathElements.Count; i++)
            {
                float d = Vector3.Distance(transform.position, enemyMovement.PathElements[i].PathElementPosition);
                if (d < distanciaMinima)
                {
                    distanciaMinima = d;
                    indiceCercano = i;
                }
            }

            // LIMPIEZA DE RUTA:
            // Eliminamos de la lista del enemigo todos los puntos que el generador YA PASÓ.
            // Así, para el enemigo, el "Punto 0" será el siguiente nodo en el camino.
            for (int i = 0; i < indiceCercano; i++)
            {
                if (enemyMovement.PathElements.Count > 0)
                {
                    enemyMovement.PathElements.RemoveAt(0);
                }
            }

            // INICIALIZACIÓN Y ACTIVACIÓN:
            // Ahora que la ruta es solo "lo que falta por recorrer", inicializamos
            enemyMovement.Initialization();
            enemyMovement.MovementActive = true;
        }

        // 3. Configuración del Character (TopDown Engine)
        Character character = enemy.GetComponent<Character>();
        if (character != null)
        {
            character.SetPlayerID("Enemy");
            // Nos aseguramos de que el personaje esté en estado normal para moverse
            if (character.ConditionState != null)
            {
                character.ConditionState.ChangeState(CharacterStates.CharacterConditions.Normal);
            }
        }
    }

    private void OnDisable()
    {
        if (_spawnLoop != null) StopCoroutine(_spawnLoop);
    }
}