using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreElements : MonoBehaviour
{
    public Image background;
    public Image icon;
    public Image inUse;
    public bool isBall;


    public BallElement element;


    public void SetData()
    {
        inUse.gameObject.SetActive(false);
        icon.sprite = element.icon; 
    }

    public void checkHold()
    {
        background.color = Store.holdID == element.ID ? Color.cyan : (element.hadBuy ? Color.white : Color.gray); 
        
    }

    public void checkUse()
    {
        if (isBall)
            inUse.gameObject.SetActive(PlayerPrefs.GetInt("BallSkin") == element.ID);
        else
            inUse.gameObject.SetActive(PlayerPrefs.GetInt("CupSkin") == element.ID);

    }

    public void Update()
    {
        checkHold();
        checkUse();
        
    }

    public void OnClick()
    {
        Store.holdID = this.element.ID;
    }





}
