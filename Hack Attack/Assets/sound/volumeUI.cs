using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeUI : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        musicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("musicVolume", 1f));
        sfxSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("sfxVolume", 1f));

        musicSlider.onValueChanged.AddListener(MusicManager.SetVolume);
        sfxSlider.onValueChanged.AddListener(sfxManager.SetVolume);
    }
}
