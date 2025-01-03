using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class QuizzController : ScreenUIController
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Text title;

    public override void Init(QuizzStruct quizStruct)
    {
        base.Init(quizStruct);
        title.text = "Quiz " + quizStruct.quizzIndex;
        StartCoroutine(PrintQuestion(quizStruct));
    }

    IEnumerator PrintQuestion(QuizzStruct quizStruct)
    {
        for (int i = 0; i < quizStruct.question.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            questionText.text += quizStruct.question[i];
        }
        StartCoroutine(OnSpawnResponce(quizStruct));
    }

    IEnumerator OnSpawnResponce(QuizzStruct quizStruct)
    {
        for (int i = 0; i < quizStruct.responces.Count; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameManager.Instance.OnSpawnScreen(ScreenType.ActionButton, content).Init(new ActionButtonStruct
            {
                responce = quizStruct.responces[i],
                onClickButton = quizStruct.onClickAction
            });
        }
    }
}

public struct QuizzStruct
{
    public Action<string> onClickAction;
    public List<string> responces;
    public string question;
    public int quizzIndex;
}
