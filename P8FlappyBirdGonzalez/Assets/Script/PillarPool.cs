using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPool : MonoBehaviour
{
    public int PillarPoolSize = 5;
    public GameObject PillarPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[PillarPoolSize];
        for (int i = 0; i < PillarPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate (PillarPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range (columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn == PillarPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
