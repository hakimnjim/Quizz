using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : State
{
    public override void Enter(GlobalStateMachine host)
    {
        base.Enter(host);
        Host.CallChangeStateCoroutine(1, NextState);

    }

    public override void Exit()
    {
        base.Exit();
    }
}
