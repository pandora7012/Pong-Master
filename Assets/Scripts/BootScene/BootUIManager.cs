using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BootUIManager : MonoBehaviour
{

    [SerializeField]
    private Image pong;
    [SerializeField]
    private Image Loading;

    void Start()
    {
        Loading.transform.DOLocalMoveX(0, 3).SetEase(Ease.InOutQuint);

        InitPlayerPref();

        Sequence sq = DOTween.Sequence();
        sq.SetLoops(3, LoopType.Restart);
        sq.Append(pong.transform.DOLocalMoveY(800, 1).SetEase(Ease.OutQuint))
            .Append(pong.transform.DOLocalMoveY(630, 1).SetEase(Ease.InQuint));
        //sq.WaitForKill(true);
    }

    public void InitPlayerPref()
    {
        if (!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetInt("Music", 1);
        if (!PlayerPrefs.HasKey("Vfx"))
            PlayerPrefs.SetInt("Vfx", 1);
        if (!PlayerPrefs.HasKey("MaxLevel"))
            PlayerPrefs.SetInt("MaxLevel", 1);

    }
}
