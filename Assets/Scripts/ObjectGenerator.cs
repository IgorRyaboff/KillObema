using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public float interval = 1, intervalDeltaPerSecond = 0.001f, minInterval = 0.5f;
    public GameObject spawnPrefab;
    Transform playerTransform, gameplayObjects;
    float lastEnemySpawn = 0;
    float intervalDeltaChanged = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        gameplayObjects = GameObject.Find("GameplayObjects").transform;
    }

    // Update is called once per frame
    void Update()
    {
        lastEnemySpawn += Time.deltaTime;
        intervalDeltaChanged += Time.deltaTime;
        if (intervalDeltaChanged >= 1) {
            intervalDeltaChanged = 0;
            interval -= intervalDeltaPerSecond;
            if (interval < minInterval) interval = minInterval;
        }
        if (lastEnemySpawn >= interval) {
            float left = playerTransform.position.x - 4, right = playerTransform.position.x + 4;
            if (left < -8) left = -8;
            if (right > 8) right = 8;
            Instantiate(spawnPrefab, new Vector2(Random.Range(left, right), 6), transform.rotation, gameplayObjects);
            lastEnemySpawn = 0;
        }
    }
}
