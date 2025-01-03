using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingState : State
{
    public override void Enter(GlobalStateMachine host)
    {
        base.Enter(host);
        GameManager.Instance.OnSpawnScreen(ScreenType.Setting, null).Init(new SettingStruct
        {
            onClickAction = OnBackHome,
            onMusicVolumeChange = OnMusicVolumeChange,
            onVfxVolumeChange = OnVfxVolumeChange,
            musicVolume = GameManager.Instance.MusicVolume,
            vfxVolume = GameManager.Instance.VfxVolume
        });
    }

    private void OnVfxVolumeChange(float value)
    {
        GameManager.Instance.UpdateVfxVolume(value);
    }

    private void OnMusicVolumeChange(float value)
    {
        GameManager.Instance.UpdateMusicVolume(value);
    }

    private void OnBackHome()
    {
        Host.CallChangeStateCoroutine(0.5f, NextState);
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.OnDestroyScreenController(ScreenType.Setting, null);
    }
}
