using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    public virtual void Init()
    {
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, 0.5f).OnComplete(() =>
        {

        });
    }

    public virtual void Init(MainMenuStruct mainMenuStruct)
    {
        Init();
    }
    public virtual void Init(ActionButtonStruct actionButtonStruct)
    {
        Init();
    }

    public virtual void Init(QuizzStruct quizStruct)
    {
        Init();
    }

    public virtual void Init(FinishGameStruct finishGameStruct)
    {
        Init();
    }

    public virtual void Init(SettingStruct settingStruct)
    {
        Init();
    }

    public virtual void DestroyController()
    {
        canvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
