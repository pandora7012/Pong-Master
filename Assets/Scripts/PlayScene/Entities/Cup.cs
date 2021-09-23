using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public SpriteRenderer sprite;

    public Sprite[] niceText; 

    private void Awake()
    {
        sprite.sprite = GameManager.Instance.storedata.cups[PlayerPrefs.GetInt("CupSkin")-1].icon; 
    }

    

}
