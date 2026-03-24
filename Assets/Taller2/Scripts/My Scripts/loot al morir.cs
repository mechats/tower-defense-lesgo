using UnityEngine;

public class LootAlMorir : MonoBehaviour
{
    public GameObject objetoOro;

    void OnDestroy()
    {
        if (gameObject.scene.isLoaded && objetoOro != null)
        {
            Instantiate(objetoOro, transform.position, Quaternion.identity);
        }
    }
}