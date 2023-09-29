using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : PersistentSingleton<AudioManager>
{
    public AudioClip OpenRoad;
    public AudioClip PaperWings;

    public void PlayPaperWings()
    {
        GetComponent<AudioSource>().clip = PaperWings;
        GetComponent<AudioSource>().Play();
    }

    public void PlayOpenRoad()
    {
        GetComponent<AudioSource>().clip = OpenRoad;
        GetComponent<AudioSource>().Play();
    }

    public void StopPlay()
    {
        GetComponent<AudioSource>().Stop();
    }


    private void Update()
    {
        if (Settings.IsBGM)
        {
            if (Settings.IsBGMOn)
            {
                if (Settings.IsBGMInH2A)
                {
                    PlayOpenRoad();
                }
                else
                {
                    PlayPaperWings();
                }
            }
            else
            {
                StopPlay();
            }

            Settings.IsBGM = false;
        }
    }
}
