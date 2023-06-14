using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    public int StageCount { get { return stages.Count; } }

    private List<StageData> stages;

    private void Awake()
    {
        // Singleton 패턴 적용
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // 스테이지 정보 초기화
        InitializeStages();
    }

    private void InitializeStages()
    {
        stages = new List<StageData>();

        // 스테이지 정보 추가
        // 예시: 스테이지 1
        StageData stage1 = new StageData();
        stage1.stageIndex = 0;
        stage1.backgroundMusic = Resources.Load<AudioClip>("Music/Stage1_BGM");
        // 필요한 다른 스테이지 정보 추가
        stages.Add(stage1);

        // 예시: 스테이지 2
        StageData stage2 = new StageData();
        stage2.stageIndex = 1;
        stage2.backgroundMusic = Resources.Load<AudioClip>("Music/Stage2_BGM");
        // 필요한 다른 스테이지 정보 추가
        stages.Add(stage2);

        // 예시: 스테이지 3
        StageData stage3 = new StageData();
        stage3.stageIndex = 2;
        stage3.backgroundMusic = Resources.Load<AudioClip>("Music/Stage3_BGM");
        // 필요한 다른 스테이지 정보 추가
        stages.Add(stage3);
    }

    public AudioClip GetStageBackgroundMusic(int index)
    {
        if (index >= 0 && index < stages.Count)
            return stages[index].backgroundMusic;
        else
        {
            Debug.LogWarning("Invalid stage index!");
            return null;
        }
    }
}

public class StageData
{
    public int stageIndex; // 스테이지 인덱스
    public AudioClip backgroundMusic; // 배경 음악
    // 필요한 다른 스테이지 정보 추가
}
