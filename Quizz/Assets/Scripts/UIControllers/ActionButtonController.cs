using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonController : ScreenUIController
{
    private string responce;
    [SerializeField]
    private Button actionButton;
    [SerializeField]
    private Text responceText;
    [SerializeField]
    private Color correctColor;
    [SerializeField]
    private Color wrongColor;

    public override void Init(ActionButtonStruct actionButtonStruct)
    {
        base.Init(actionButtonStruct);
        responce = actionButtonStruct.responce;
        actionButton.onClick.AddListener(() => actionButtonStruct.onClickButton(responce));
        responceText.text = responce;
        GameManager.Instance.OnValidateResponce += OnValidateResponce;
    }

    private void OnValidateResponce(string res)
    {
        actionButton.onClick.RemoveAllListeners();
        if (res == responce)
        {
            actionButton.image.color = correctColor;
        }
        else
        {
            actionButton.image.color = wrongColor;
        }
        GameManager.Instance.OnValidateResponce -= OnValidateResponce;
    }
}

public struct ActionButtonStruct
{
    public Action<string> onClickButton;
    public string responce;
}
