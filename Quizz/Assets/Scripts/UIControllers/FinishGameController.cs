using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGameController : ScreenUIController
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Button homeButton;

    public override void Init(FinishGameStruct finishGameStruct)
    {
        base.Init(finishGameStruct);
        scoreText.text = finishGameStruct.score;
        homeButton.onClick.AddListener(() => finishGameStruct.onClickAction());
    }
}

public struct FinishGameStruct
{
    public string score;
    public Action onClickAction;
}
