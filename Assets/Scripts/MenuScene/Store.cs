using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : PopupAnimation
{

    public RectTransform Content_Ball;
    public RectTransform Content_Cups;

    public StoreElements prefabs;

    public StoreData data; 

    private void Start()
    {
        InitBallStore();
    }

    public override void onOpen()
    {
        base.onOpen();
    }

    public override void onClose()
    {
        base.onClose();
    }

    public override void inMain()
    {
        base.inMain();
        
    }

    public void InitBallStore()
    {
        foreach (BallElement i in data.balls)
        {
            StoreElements e = Instantiate(prefabs, Content_Cups);
            e.element.cost = i.cost;
            e.element.hadBuy = i.hadBuy;
            e.element.icon = i.icon;
            e.element.ID = i.ID;
            e.element.isUsing = i.isUsing;
            e.SetData();
        }
    }
}
