using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 

public class WinGameAnim : MonoBehaviour
{
    public GameObject Popup;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public GameObject nextButton;
    public GameObject Coin;
    public GameObject currentCoin;

    public GameObject homeButton;

    public void OnEnable()
    {
        PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
        Sequence sq = DOTween.Sequence();
        sq.Append(Popup.transform.DOScale(new Vector2(2, 2), 0.25f).From(Vector2.zero));
        sq.Append(star1.transform.DOScale(new Vector2(2, 2), 0.75f).From(Vector2.zero).SetEase(Ease.InOutBack)); 
        sq.Append(star2.transform.DOScale(new Vector2(2, 2), 0.75f).From(Vector2.zero).SetEase(Ease.InOutBack)); 
        sq.Append(star3.transform.DOScale(new Vector2(2, 2), 0.75f).From(Vector2.zero).SetEase(Ease.InOutBack));
        sq.Append(currentCoin.transform.DOLocalMove(new Vector2(0, -650), 0.25f).From(new Vector2(1400, -650)));
        sq.Append(nextButton.transform.DOLocalMove(new Vector2(215, -1100), 0.25f).From(new Vector2(1400, -1100)));
        sq.Join(homeButton. transform.DOLocalMove(new Vector2(-320, -1100), 0.25f).From(new Vector2(1400, -1100)));
        sq.Append(Coin.transform.DOLocalMove(new Vector2(-45, -120), 0.1f).From(new Vector2(-45, 140)));
        sq.Join(Coin.transform.DOScale(new Vector2(2, 2), 0.1f).From(Vector2.zero));
        sq.Append(Coin.transform.DOScale(new Vector2(2, 2), 1f));
        sq.Append(Coin.transform.DOLocalMove(new Vector2(-60, -500), 0.5f));
        sq.Join(Coin.transform.DOScale(new Vector2(0, 0),0.5f)); 
    }
}
