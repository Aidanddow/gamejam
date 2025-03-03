using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public GameObject badItemPrefab;
    public List<ItemType> badItemTypes;
    public GameObject goodItemPrefab;
    public List<ItemType> goodItemTypes;
    public Item itemPrefab;
    public float spawnRate = 1f;
    public float spawnRange = 8f; // Adjust to the width of your screen
    public float spawnRatio = 0.8f; // Adjust for good/bad ratio

    private float nextSpawnTime;

    void Start()
    {
        // itemPrefab.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnItem();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnItem()
    {
        var randomX = Random.Range(-spawnRange, spawnRange);
        var spawnPosition = new Vector2(randomX, transform.position.y);

        GameObject itemToSpawn;
        // ItemType itemTypeToSpawn;
        if (Random.value < spawnRatio)
        {
            itemToSpawn = goodItemPrefab;
            // itemTypeToSpawn = GetRandom(goodItemTypes);
        }
        else
        {
            itemToSpawn = badItemPrefab;
            // itemTypeToSpawn = GetRandom(badItemTypes);
        }

        Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
        // var item = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        // item.type = itemTypeToSpawn;
        // item.gameObject.SetActive(true);
    }
    
    private static T GetRandom<T>(List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
