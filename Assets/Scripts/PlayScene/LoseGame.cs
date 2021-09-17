using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class LoseGame : MonoBehaviour
{
    public GameObject nextBt;
    public GameObject homeBt; 
    private void OnEnable()
    {
        Sequence sq = DOTween.Sequence();
        sq.Append(nextBt.transform.DOLocalMove(  Vector2.zero, 1f));
        sq.Append(homeBt.transform.DOLocalMove( new Vector2(0, -300), 1f));
    }
}
