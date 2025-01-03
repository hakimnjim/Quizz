using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoaderController : ScreenUIController
{
    [SerializeField]
    private Image loadingImage;
    [SerializeField]
    private float rotationDuration = 1f;

    public override void Init()
    {
        base.Init();
        RotateLoader();
    }

    private void RotateLoader()
    {
        loadingImage.rectTransform
            .DORotate(new Vector3(0, 0, -360), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
}
