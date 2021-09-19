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
        holdID = PlayerPrefs.GetInt("BallSkin");
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
        holdID = PlayerPrefs.GetInt("BallSkin");
        state = 1;
        AudioManager.Instance.Play("Click");
    }

    public void CupButton()
    {
        ballView.gameObject.SetActive(false);
        cupView.gameObject.SetActive(true);
        ballBT.color = Color.white;
        cupBT.color = Color.cyan;
        holdID = PlayerPrefs.GetInt("CupSkin");
        state = 2;
        AudioManager.Instance.Play("Click");
    }

    public void BuyButton()
    {
        if (state == 1)
        {
            if (PlayerPrefs.GetInt("Coin") >= data.balls[holdID - 1].cost && !data.balls[holdID - 1].hadBuy)
                data.balls[holdID - 1].hadBuy = true;
            else if (data.balls[holdID - 1].hadBuy)
            {
                PlayerPrefs.SetInt("BallSkin", holdID);
            }
        }
        else if (state == 2)
        {
            if (PlayerPrefs.GetInt("Coin") >= data.cups[holdID - 1].cost && !data.cups[holdID - 1].hadBuy)
                data.cups[holdID - 1].hadBuy = true;
            else if (data.cups[holdID - 1].hadBuy)
                PlayerPrefs.SetInt("CupSkin", holdID); 
        }

        else Debug.Log("Not enough noney");
        AudioManager.Instance.Play("Coin");
    }

    private void UIUpdate()
    {
        if (state == 1 && !data.balls[holdID - 1].hadBuy)
            buyText.text = data.balls[holdID - 1].cost.ToString();
        else if (state == 2 && !data.cups[holdID - 1].hadBuy)
            buyText.text = data.cups[holdID - 1].cost.ToString();
        else
            buyText.text = "Equip";
    }


}
