using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // ������ �����յ�
    public float spawnInterval = 1.0f; // ���� ����

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        // ���� �ð����� ������ ����
        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0.0f;
        }
    }

    void SpawnPrefab()
    {
        // ������ �ε��� ����
        int randomIndex = Random.Range(0, prefabsToSpawn.Length);

        // ������ �ε����� �ش��ϴ� ������ ����
        GameObject prefab = prefabsToSpawn[randomIndex];
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
