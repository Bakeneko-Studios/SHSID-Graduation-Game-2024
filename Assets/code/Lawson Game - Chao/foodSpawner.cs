using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    
    public float minX = -6f;
    public float maxX = 6f;
    public float[] rowPositions;
    
    public int numberOfFood;


    void Start()
    {
        // Automatically populate foodPrefabs array with prefabs from "Prefabs/Lawson Game - Chao" folder
        foreach (GameObject prefab in foodPrefabs)
        {
            Debug.Log("Loaded prefab: " + prefab.name);
        }
        SpawnFood();
    }

    private void SpawnFood(){
        for(int i = 0; i < numberOfFood; i ++){
            float verticalOffset = Random.Range(-0.1f, -0.1f);
            GameObject foodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), rowPositions[Random.Range(0, rowPositions.Length)], transform.position.z);
            Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
