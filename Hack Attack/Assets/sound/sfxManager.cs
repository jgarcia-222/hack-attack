using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sfxManager : MonoBehaviour
{
    private static sfxManager Instance;

    private static AudioSource audioSource;
    private static sfxLibrary sfxLibrary;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            sfxLibrary = GetComponent<sfxLibrary>();

            DontDestroyOnLoad(gameObject);
            audioSource.volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(string soundName)
    {
        AudioClip audioClip = sfxLibrary.GetRandomClip(soundName);
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
}
