using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreElements : MonoBehaviour
{
    public Image background;
    public Image icon;
    public Image inUse;  

    public BallElement element;

    public void SetData()
    {
        inUse.gameObject.SetActive(element.isUsing);
        icon.sprite = element.icon; 

    }



}
