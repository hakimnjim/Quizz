using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizzState : State
{
    public override void Enter(GlobalStateMachine host)
    {
        base.Enter(host);
        Question currentQuestion = GameManager.Instance.GetQuestion();
        QuizzController quizController = (QuizzController) GameManager.Instance.OnSpawnScreen(ScreenType.Quiz, null);
        List<string> responces = new List<string>();
        foreach (var item in currentQuestion.responses)
        {
            responces.Add(item.responseText);
        }
        quizController.Init(new QuizzStruct
        {
            onClickAction = OnClickAction,
            responces = responces,
            question = currentQuestion.questionText,
            quizzIndex = GameManager.Instance.QuizIndex
        });
    }

    private void OnClickAction(string res)
    {
        GameManager.Instance.CheckResponce(res);
        Host.CallChangeStateCoroutine(3, NextState);
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.OnDestroyScreenController(ScreenType.Quiz, null);
    }
}
