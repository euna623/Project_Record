using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicTimer : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider slider;

    void Start()
    {
        // 슬라이더의 최댓값을 음악 재생 시간으로 설정
        slider.maxValue = musicSource.clip.length;
    }

    void Update()
    {
        // 슬라이더의 값 업데이트
        slider.value = musicSource.time;
    }
}
