using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    public bool SoundIsOn = true;
    public bool MusicIsOn = true;
    private static MusicClass musicInstance;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
