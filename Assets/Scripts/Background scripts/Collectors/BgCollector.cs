using UnityEngine;

public class BgCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Background")
        {
            collision.gameObject.SetActive(false);
        }
    }
}