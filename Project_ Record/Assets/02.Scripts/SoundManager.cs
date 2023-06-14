using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource btnSource;
    public AudioSource otherAudioSource; // �ٸ� ������Ʈ�� AudioSource

    public Slider musicSlider;
    public Slider buttonSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string ButtonVolumeKey = "ButtonVolume";

    private void Start()
    {
        // ������ ����� ���� ���� �� �ҷ�����
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        float buttonVolume = PlayerPrefs.GetFloat(ButtonVolumeKey, 1f);

        // �����̴��� ���� �� ����
        musicSlider.value = musicVolume;
        buttonSlider.value = buttonVolume;

        // ���� ���� �� ����
        SetMusicVolume(musicVolume);
        SetButtonVolume(buttonVolume);

        // �����̴� �� ���� �� �̺�Ʈ ���
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        buttonSlider.onValueChanged.AddListener(OnButtonSliderValueChanged);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        otherAudioSource.volume = volume;

        // ���� ���� �� ����
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetButtonVolume(float volume)
    {
        btnSource.volume = volume;
        otherAudioSource.volume = volume;

        // ���� ���� �� ����
        PlayerPrefs.SetFloat(ButtonVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void OnBtn()
    {
        btnSource.Play();
        otherAudioSource.Play(); // �ٸ� ������Ʈ�� AudioSource ���
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
