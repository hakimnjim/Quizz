using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MainMenuController : ScreenUIController
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button settingButton;

    public override void Init(MainMenuStruct mainMenuStruct)
    {
        base.Init(mainMenuStruct);
        playButton.onClick.AddListener(() => mainMenuStruct.onPlayAction());
        settingButton.onClick.AddListener(() => mainMenuStruct.onSettingAction());
    }
}

public struct MainMenuStruct
{
    public Action onPlayAction;
    public Action onSettingAction;
}
