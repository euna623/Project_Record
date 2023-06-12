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
        // �����̴��� �ִ��� ���� ��� �ð����� ����
        slider.maxValue = musicSource.clip.length;
    }

    void Update()
    {
        // �����̴��� �� ������Ʈ
        slider.value = musicSource.time;
    }
}
