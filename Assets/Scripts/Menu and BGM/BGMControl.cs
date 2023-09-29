using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Toggle = UnityEngine.UI.Toggle;

public class BGMControl : MonoBehaviour
{
    public GameObject BGM;
    private Toggle _toggle;
    
    //每次加载主菜单时，都会调用一次start函数，因此用该函数来获取Settings的音乐开关状态，将其赋值给_toggle.isOn
    private void Start()
    {
        _toggle = BGM.GetComponent<Toggle>();
        _toggle.isOn = Settings.IsBGMOn;
    }

    public void BGMToggle(bool isPlay)
    {
        Settings.IsBGM = true;
        Settings.IsBGMOn = isPlay;
    }
}
