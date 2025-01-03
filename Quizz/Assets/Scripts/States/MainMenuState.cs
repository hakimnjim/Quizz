using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : State
{
    [SerializeField]
    private State loaderState;
    [SerializeField]
    private State settingState;

   public override void Enter(GlobalStateMachine host)
    {
        base.Enter(host);
        MainMenuController mainMenuController = (MainMenuController) GameManager.Instance.OnSpawnScreen(ScreenType.MainMenu, null);
        mainMenuController.Init(new MainMenuStruct
        {
            onPlayAction = OnPlayAction,
            onSettingAction = OnSettingAction
        });
    }

    private void OnSettingAction()
    {
        Host.CallChangeStateCoroutine(0.5f, settingState);
    }

    private void OnPlayAction()
    {
        Host.CallChangeStateCoroutine(0.5f, loaderState);
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.OnDestroyScreenController(ScreenType.MainMenu, null);
    }
}
