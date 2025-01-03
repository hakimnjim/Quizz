using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [HideInInspector] public GlobalStateMachine Host;
    public bool isCurrentState;
    public State NextState;

    public virtual void Enter(GlobalStateMachine host)
    {
        Host = host;
        isCurrentState = true;
    }

    public virtual void Exit()
    {
        isCurrentState = false;
    }

    public virtual void Update()
    {
        if (!isCurrentState)
        {
            return;
        }
    }
}
