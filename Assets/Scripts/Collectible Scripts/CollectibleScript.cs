using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DestroyCollectible", 6f);
    }

    private void OnDisable() { }

    void DestroyCollectible()
    {
        gameObject.SetActive(false);
    }
}
