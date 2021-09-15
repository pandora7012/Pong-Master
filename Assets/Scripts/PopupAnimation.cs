using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopupAnimation : MonoBehaviour
{
    public virtual void onOpen()
    {
        this.transform.DOLocalMove(Vector2.zero, 0.5f).From(new Vector2(0,-3300)).SetEase(Ease.OutBack);

    }

    public virtual void onClose()
    {
        this.transform.DOLocalMove(new Vector2(0, -3300), 1).SetEase(Ease.InOutCirc);
    }

    public virtual void inMain()
    {

    }
}
