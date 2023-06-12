using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource btnSource;
    public Slider musicSlider;
    public Slider buttonSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string ButtonVolumeKey = "ButtonVolume";

    private void Start()
    {
        // 이전에 저장된 사운드 설정 값 불러오기
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        float buttonVolume = PlayerPrefs.GetFloat(ButtonVolumeKey, 1f);

        // 슬라이더에 설정 값 적용
        musicSlider.value = musicVolume;
        buttonSlider.value = buttonVolume;

        // 사운드 설정 값 적용
        SetMusicVolume(musicVolume);
        SetButtonVolume(buttonVolume);

        // 슬라이더 값 변경 시 이벤트 등록
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        buttonSlider.onValueChanged.AddListener(OnButtonSliderValueChanged);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;

        // 사운드 설정 값 저장
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetButtonVolume(float volume)
    {
        btnSource.volume = volume;

        // 사운드 설정 값 저장
        PlayerPrefs.SetFloat(ButtonVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void OnBtn()
    {
        btnSource.Play();
    }

    private void OnMusicSliderValueChanged(float value)
    {
        SetMusicVolume(value);
    }

    private void OnButtonSliderValueChanged(float value)
    {
        SetButtonVolume(value);
    }
}
