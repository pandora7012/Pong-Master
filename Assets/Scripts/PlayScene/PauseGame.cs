using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PauseGame : MonoBehaviour
{
    
    public RectTransform conBT ;
    public RectTransform bgSound;
    public RectTransform VFX;
    public RectTransform Home; 


    private void OnEnable()
    {
        Sequence sq = DOTween.Sequence();
        sq.Append(conBT.transform.DOScale(new Vector2(1, 1), 0.5f).From(Vector2.zero))
            .Append(bgSound.transform.DOLocalMove(new Vector2(-400, 0), 0.25f))
            .Append(Home.transform.DOLocalMove(new Vector2(-0, -400), 0.25f))
            .Append(VFX.transform.DOLocalMove(new Vector2(400, 0), 0.25f));
    }

    public void GoPlay()
    {
        gameObject.SetActive(true);
    }
}
