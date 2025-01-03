using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderState : State
{
    [SerializeField]
    private State FinishState, QuizState;

    public override void Enter(GlobalStateMachine host)
    {
        base.Enter(host);
        GameManager.Instance.OnSpawnScreen(ScreenType.Loader, null).Init();
        if (GameManager.Instance.CheckIndex())
        {
            Host.CallChangeStateCoroutine(0.5f, QuizState);
        }
        else
        {
            Host.CallChangeStateCoroutine(2, FinishState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.OnDestroyScreenController(ScreenType.Loader, null);
    }
}
