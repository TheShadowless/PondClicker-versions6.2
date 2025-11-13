using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] coinPrefabs;
    [SerializeField] private float spawnTime = 15f;
    [SerializeField] private float minX = 0f;
    [SerializeField] private float maxX = 1900f;
    [SerializeField] private float spawnY = 1100f;
    private float timer;

    void Start()
    {
        timer = spawnTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnCoin();
            timer = spawnTime;
        }
    }

    void SpawnCoin()
    {
        if (coinPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, coinPrefabs.Length);
        GameObject randomCoinPrefab = coinPrefabs[randomIndex];

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        GameObject coin = Instantiate(randomCoinPrefab, spawnPosition, Quaternion.identity, transform);
        coin.layer = gameObject.layer;
    }
}

