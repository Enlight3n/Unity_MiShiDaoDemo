using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 这个脚本挂载到传送点上，点击之后根据传送点的不同类型来实现不同场景的切换
/// </summary>
public class Teleport : MonoBehaviour
{
    public ScenesEnum startScene;
    public ScenesEnum destinationScene;
    
    public void Transition()
    {
        TeleportManager.Instance.Transition(startScene,destinationScene);
    }
}