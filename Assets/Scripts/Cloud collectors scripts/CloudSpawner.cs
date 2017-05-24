﻿using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] clouds;

    [SerializeField]
    private GameObject[] collectibles;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;
    private GameObject player;

    void Awake()
    {
        controlX = 0;

        SetMinMaxX();
        CreateClouds();

        player = GameObject.Find("PlayerChar");

        for (int i = 0; i < collectibles.Length; i++)
        {
            collectibles[i].SetActive(false);
        }
    }

    void Start()
    {
        PositionPlayer();
    }

    void SetMinMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void Shuffle(GameObject[] cloudsToShuffle)
    {
        for (int i = 0; i < cloudsToShuffle.Length; i++)
        {
            GameObject temp = cloudsToShuffle[i];
            int random = Random.Range(i, cloudsToShuffle.Length);

            cloudsToShuffle[i] = cloudsToShuffle[random];
            cloudsToShuffle[random] = temp;
        }
    }

    void CreateClouds()
    {
        Shuffle(clouds);
        float positionY = 0f;

        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;

            temp.y = positionY;

            temp = RandomiseClouds(temp);

            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;

            positionY -= distanceBetweenClouds;
        }
    }

    private Vector3 RandomiseClouds(Vector3 temp)
    {
        if (controlX == 0)
        {
            temp.x = Random.Range(0f, maxX);
            controlX = 1;
        }
        else if (controlX == 1)
        {
            temp.x = Random.Range(0f, minX);
            controlX = 2;
        }
        else if (controlX == 2)
        {
            temp.x = Random.Range(1.0f, maxX);
            controlX = 3;
        }
        else if (controlX == 3)
        {
            temp.x = Random.Range(-1.0f, minX);
            controlX = 0;
        }

        return temp;
    }

    void PositionPlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < darkClouds.Length; i++)
        {
            if (darkClouds[i].transform.position.y == 0f)
            {
                Vector3 t = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x,
                                                                cloudsInGame[0].transform.position.y,
                                                                cloudsInGame[0].transform.position.z);
                cloudsInGame[0].transform.position = t;
            }
        }

        Vector3 temp = cloudsInGame[0].transform.position;
        for (int i = 1; i < cloudsInGame.Length; i++)
        {
            if (temp.y < cloudsInGame[i].transform.position.y)
            {
                temp = cloudsInGame[i].transform.position;
            }
        }

        temp.y += 2f;

        player.transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cloud" || collision.tag == "Deadly")
        {
            if (collision.transform.position.y == lastCloudPositionY)
            {
                Vector3 temp = collision.transform.position;
                Shuffle(clouds);
                Shuffle(collectibles);

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        temp = RandomiseClouds(temp);

                        temp.y -= distanceBetweenClouds;

                        lastCloudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectibles.Length);

                        if (clouds[i].tag != "Deadly")
                        {
                            if (!collectibles[random].activeInHierarchy)
                            {
                                Debug.Log("Coin spawned");
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;

                                if(collectibles[random].tag == "Life")
                                {
                                    if(PlayerScore.lifeCount < 2)
                                    {
                                        collectibles[random].transform.position = temp2;
                                        collectibles[random].SetActive(true);
                                    }
                                }
                                else
                                {
                                    collectibles[random].transform.position = temp2;
                                    collectibles[random].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}