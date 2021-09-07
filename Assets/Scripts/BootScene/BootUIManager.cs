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
        Loading.transform.DOLocalMoveX(0, 6).SetEase(Ease.InOutQuint);
        

        Sequence sq = DOTween.Sequence();
        sq.SetLoops(3, LoopType.Restart);
        sq.Append(pong.transform.DOLocalMoveY(800, 1).SetEase(Ease.OutQuint))
            .Append(pong.transform.DOLocalMoveY(630, 1).SetEase(Ease.InQuint));
        //sq.WaitForKill(true);



    }
}
