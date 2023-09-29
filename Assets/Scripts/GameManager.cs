using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, bool> miniGameStateDict = new Dictionary<string, bool>();

    
    private void Start()
    {
        EventHandler.CallGameStaeChangeEvent(GameStateEnum.GamePlay);
        Settings.isMiniGameFinished = false;
    }

    
    
}
