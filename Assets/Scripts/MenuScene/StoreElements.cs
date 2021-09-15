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
        inUse.gameObject.SetActive(element.isUsing);
        icon.sprite = element.icon; 
    }

    public void checkHold()
    {
        background.color = Store.holdID == element.ID ? Color.cyan : element.hadBuy ? Color.white : Color.gray; 
        
    }

    public void Update()
    {
        checkHold();
    }

    public void OnClick()
    {
        Store.holdID = this.element.ID;
    }





}
