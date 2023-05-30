using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // 생성할 프리팹들
    public float spawnInterval = 1.0f; // 생성 간격

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        // 일정 시간마다 프리팹 생성
        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0.0f;
        }
    }

    void SpawnPrefab()
    {
        // 랜덤한 인덱스 선택
        int randomIndex = Random.Range(0, prefabsToSpawn.Length);

        // 선택한 인덱스에 해당하는 프리팹 생성
        GameObject prefab = prefabsToSpawn[randomIndex];
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
