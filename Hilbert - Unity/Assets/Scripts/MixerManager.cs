using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerManager : MonoBehaviour
{
    public AudioMixer audiomixer;
    private MusicClass musicClass;

    public GameObject MusicIsOn;
    public GameObject MusicIsOff;
    public GameObject SoundIsOn;
    public GameObject SoundIsOff;


    private void Start()
    {
        musicClass = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>();
    }
    private void Update()
    {
        if(musicClass.SoundIsOn == true)
        {
            SoundIsOn.SetActive(true);
            SoundIsOff.SetActive(false);
        }
        else
        {
            SoundIsOn.SetActive(false);
            SoundIsOff.SetActive(true);
        }
        if (musicClass.MusicIsOn == true)
        {
            MusicIsOn.SetActive(true);
            MusicIsOff.SetActive(false);
        }
        else
        {
            MusicIsOn.SetActive(false);
            MusicIsOff.SetActive(true);
        }
    }
    public void OffMusic()
    {
        musicClass.MusicIsOn = false;
        audiomixer.SetFloat("MusicVol", -80);
    }

    public void OnMusic()
    {
        musicClass.MusicIsOn = true;
        audiomixer.SetFloat("MusicVol", -0);
    }
    public void OffSound()
    {
        musicClass.SoundIsOn = false;

        audiomixer.SetFloat("SoundVol", -80);
    }
    public void OnSound()
    {
        musicClass.SoundIsOn = true;
        audiomixer.SetFloat("SoundVol", 0);
    }
}
