using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MiniGame : MonoBehaviour
{
    public GameObject ToH2A;
    public GameObject ToH3;
    private void Start()
    {
        if (Settings.isMiniGameFinished)
        {
            ToH2A.SetActive(false);
            ToH3.SetActive(true);
        }
    }
}
