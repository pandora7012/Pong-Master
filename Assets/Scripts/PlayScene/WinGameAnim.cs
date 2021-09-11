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
        Sequence sq = DOTween.Sequence();
        sq.Append(Popup.transform.DOScale(new Vector2(2, 2), 0.25f).From(Vector2.zero));
        sq.Append(star1.transform.DOScale(new Vector2(2, 2), 0.25f).From(Vector2.zero).SetEase(Ease.InOutBack)); 
        sq.Append(star2.transform.DOScale(new Vector2(2, 2), 0.25f).From(Vector2.zero).SetEase(Ease.InOutBack)); 
        sq.Append(star3.transform.DOScale(new Vector2(2, 2), 0.25f).From(Vector2.zero).SetEase(Ease.InOutBack));
        sq.Append(currentCoin.transform.DOMove(new Vector2(0, -650), 0.25f).From(new Vector2(1400, -650)));
        sq.Append(nextButton.transform.DOMove(new Vector2(215, -1100), 0.25f).From(new Vector2(1400, -1100)));
        sq.Join(homeButton. transform.DOMove(new Vector2(-320, -1100), 0.25f).From(new Vector2(1400, -1100)));
        sq.Append(Coin.transform.DOMove(new Vector2(-60, -150), 0.1f).From(new Vector2(-60, 55)));
        sq.Join(Coin.transform.DOScale(new Vector2(2, 2), 0.1f).From(Vector2.zero));
        sq.Append(Coin.transform.DOScale(new Vector2(2, 2), 0.5f));
        sq.Append(Coin.transform.DOMove(new Vector2(-60, 450), 0.5f)); 
        
     
        
    }
}
