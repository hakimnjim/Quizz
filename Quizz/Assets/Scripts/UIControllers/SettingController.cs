using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : ScreenUIController
{
    [SerializeField]
    private Slider musicVolume;
    [SerializeField]
    private Slider vfxVolume;
    [SerializeField]
    private Button homeButton;

    public override void Init(SettingStruct settingStruct)
    {
        base.Init(settingStruct);
        musicVolume.value = settingStruct.musicVolume;
        vfxVolume.value = settingStruct.vfxVolume;
        musicVolume.onValueChanged.AddListener(value => settingStruct.onMusicVolumeChange(value));
        vfxVolume.onValueChanged.AddListener(value => settingStruct.onVfxVolumeChange(value));
        homeButton.onClick.AddListener(() => settingStruct.onClickAction());
    }
}

public struct SettingStruct
{
    public Action onClickAction;
    public Action<float> onVfxVolumeChange;
    public Action<float> onMusicVolumeChange;
    public float musicVolume;
    public float vfxVolume;
}
