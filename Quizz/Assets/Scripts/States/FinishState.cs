using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : State
{
    public override void Enter(GlobalStateMachine host)
    {
        base.Enter(host);
        GameManager.Instance.OnSpawnScreen(ScreenType.FinishGame, null).Init(new FinishGameStruct
        {
            score = GameManager.Instance.PlayerScore.ToString(),
            onClickAction = OnClickAction
        });
    }

    private void OnClickAction()
    {
        Host.CallChangeStateCoroutine(0.1f, NextState);
        GameManager.Instance.ResetGame();
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.OnDestroyScreenController(ScreenType.FinishGame, null);
    }
}
