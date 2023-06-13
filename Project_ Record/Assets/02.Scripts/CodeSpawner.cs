using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // 생성할 프리팹들
    public float spawnInterval = 1.0f; // 생성 간격

    public float frequencyThreshold1 = 100f; // 영역 1의 주파수 임계값
    public float frequencyThreshold2 = 200f; // 영역 2의 주파수 임계값
    public float frequencyThreshold3 = 300f; // 영역 3의 주파수 임계값

    private float timer = 0.0f;
    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        // AudioSource 컴포넌트가 없는 경우에 대한 예외 처리
        if (musicSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

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
        // 오디오 스펙트럼 데이터 배열
        float[] spectrumData = new float[1024];

        // 현재 재생 중인 오디오의 스펙트럼 데이터 얻기
        musicSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // 주파수 영역에서 가장 강한 주파수 성분 찾기
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

        // 주파수에 따라 영역 설정하여 프리팹 생성
        if (strongestFrequency <= frequencyThreshold1)
        {
            SpawnPrefabInArea(0); // 영역 1
        }
        else if (strongestFrequency <= frequencyThreshold2)
        {
            SpawnPrefabInArea(1); // 영역 2
        }
        else if (strongestFrequency <= frequencyThreshold3)
        {
            SpawnPrefabInArea(2); // 영역 3
        }
        else
        {
            SpawnPrefabInArea(3); // 영역 4 (나머지 영역)
        }
    }

    void SpawnPrefabInArea(int areaIndex)
    {
        // 영역에 해당하는 프리팹 생성
        if (areaIndex >= 0 && areaIndex < prefabsToSpawn.Length)
        {
            GameObject prefab = prefabsToSpawn[areaIndex];
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
