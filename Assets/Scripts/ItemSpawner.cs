using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<Item> itemPrefabs;
    [Range(1, 10)]
    [Tooltip("Higher value means wider spread of spawned items")]
    public float spawnRange = 5f;
    [Range(0, 2)]
    [Tooltip("Higher value means more items spawn")]
    public float spawnRate = 1f;
    [Range(0, 1)]
    [Tooltip("Higher value means more coins")]
    public float spawnRatio = 0.8f;

    private List<Item> _badItemPrefabs;
    private List<Item> _goodItemPrefabs;
    private float _nextSpawnTime;

    void Start()
    {
        _badItemPrefabs = new List<Item>();
        _goodItemPrefabs = new List<Item>();

        foreach (var itemPrefab in itemPrefabs)
        {
            if (itemPrefab.coinModifier > 0)
            {
                _goodItemPrefabs.Add(itemPrefab);
            }
            else
            {
                _badItemPrefabs.Add(itemPrefab);
            }
        }
    }

    void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnItem();
            _nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnItem()
    {
        var randomX = Random.Range(-spawnRange, spawnRange);
        var spawnPosition = new Vector2(randomX, transform.position.y);
        var spawnGoodItem = Random.value < spawnRatio;
        var itemToSpawn = GetRandom(spawnGoodItem ? _goodItemPrefabs : _badItemPrefabs);

        Instantiate(itemToSpawn.gameObject, spawnPosition, Quaternion.identity);
    }

    private static T GetRandom<T>(List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
