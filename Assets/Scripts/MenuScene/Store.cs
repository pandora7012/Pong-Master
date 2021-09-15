using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : PopupAnimation
{

    public RectTransform Content_Ball;
    public RectTransform Content_Cups;
    public Text buyText; 
    public StoreElements prefabs;
    public StoreData data;
    public RectTransform ballView;
    public RectTransform cupView;

    public Image ballBT;
    public Image cupBT; 

    [HideInInspector]
    public List<StoreElements> cups;
    [HideInInspector]
    public List<StoreElements> balls;
    public static int holdID;
    private int state; 
    private void Start()
    {
        InitBallStore();
        holdID = 1;
        state = 1; 
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

    public void Update()
    {
        UIUpdate();
    }


    public void InitBallStore()
    {
        foreach (BallElement i in data.balls)
        {
            StoreElements e = Instantiate(prefabs, Content_Ball);
            e.element.cost = i.cost;
            e.element.hadBuy = i.hadBuy;
            e.element.icon = i.icon;
            e.element.ID = i.ID;
            e.element.isUsing = i.isUsing;
            e.isBall = true;
            e.SetData();
            balls.Add(e); 
        }

        foreach (CupElement i in data.cups)
        {
            StoreElements e = Instantiate(prefabs, Content_Cups);
            e.element.cost = i.cost;
            e.element.hadBuy = i.hadBuy;
            e.element.icon = i.icon;
            e.element.ID = i.ID;
            e.element.isUsing = i.isUsing;
            e.isBall = false; 
            e.SetData();
            cups.Add(e);
        }
    }

    
    public void BallButton()
    {
        ballView.gameObject.SetActive(true);
        cupView.gameObject.SetActive(false);
        ballBT.color = Color.cyan;
        cupBT.color = Color.white;
        holdID = 1;
        state = 1; 
    }

    public void CupButton()
    {
        ballView.gameObject.SetActive(false);
        cupView.gameObject.SetActive(true);
        ballBT.color = Color.white;
        cupBT.color = Color.cyan;
        holdID = 1;
        state = 2; 
    }

    public void BuyButton()
    {
        if (state == 1 && PlayerPrefs.GetInt("Coin") >= data.balls[holdID - 1].cost)
        {
            data.balls[holdID - 1].hadBuy = true;
        }
        else if (state == 2 && PlayerPrefs.GetInt("Coin") >= data.cups[holdID - 1].cost)
        {
            data.cups[holdID - 1].hadBuy = true;
        }

        else Debug.Log("Not enough noney");

    }

    private void UIUpdate()
    {
        if (state == 1)
            buyText.text = data.balls[holdID - 1].cost.ToString(); 
        else
            buyText.text = data.cups[holdID - 1].cost.ToString();

    }


}
