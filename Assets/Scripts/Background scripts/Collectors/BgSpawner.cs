using UnityEngine;

public class BgSpawner : MonoBehaviour
{
    private GameObject[] backgrounds;
    private float lastY;

    void Start()
    {
        GetBackgroundAndSetLastY();
    }

    void GetBackgroundAndSetLastY()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");

        lastY = backgrounds[0].transform.position.y;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if (lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background")
        {
            if(collision.transform.position.y == lastY)
            {
                Vector3 temp = collision.transform.position;
                float height = ((BoxCollider2D)collision).size.y;

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;

                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
