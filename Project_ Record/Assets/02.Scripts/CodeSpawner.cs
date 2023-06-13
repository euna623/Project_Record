using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // ������ �����յ�
    public float spawnInterval = 1.0f; // ���� ����

    public float frequencyThreshold1 = 100f; // ���� 1�� ���ļ� �Ӱ谪
    public float frequencyThreshold2 = 200f; // ���� 2�� ���ļ� �Ӱ谪
    public float frequencyThreshold3 = 300f; // ���� 3�� ���ļ� �Ӱ谪

    private float timer = 0.0f;
    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        // AudioSource ������Ʈ�� ���� ��쿡 ���� ���� ó��
        if (musicSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

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
        // ����� ����Ʈ�� ������ �迭
        float[] spectrumData = new float[1024];

        // ���� ��� ���� ������� ����Ʈ�� ������ ���
        musicSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // ���ļ� �������� ���� ���� ���ļ� ���� ã��
        float strongestFrequency = 0f;
        float strongestFrequencyMagnitude = 0f;

        for (int i = 1; i < spectrumData.Length; i++)
        {
            if (spectrumData[i] > strongestFrequencyMagnitude)
            {
                strongestFrequency = i * AudioSettings.outputSampleRate / 2 / spectrumData.Length;
                strongestFrequencyMagnitude = spectrumData[i];
            }
        }

        // ���ļ��� ���� ���� �����Ͽ� ������ ����
        if (strongestFrequency <= frequencyThreshold1)
        {
            SpawnPrefabInArea(0); // ���� 1
        }
        else if (strongestFrequency <= frequencyThreshold2)
        {
            SpawnPrefabInArea(1); // ���� 2
        }
        else if (strongestFrequency <= frequencyThreshold3)
        {
            SpawnPrefabInArea(2); // ���� 3
        }
        else
        {
            SpawnPrefabInArea(3); // ���� 4 (������ ����)
        }
    }

    void SpawnPrefabInArea(int areaIndex)
    {
        // ������ �ش��ϴ� ������ ����
        if (areaIndex >= 0 && areaIndex < prefabsToSpawn.Length)
        {
            GameObject prefab = prefabsToSpawn[areaIndex];
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
