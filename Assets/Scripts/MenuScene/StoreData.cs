using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreData" , menuName = "Data/StoreData", order = 1)]
public class StoreData : ScriptableObject
{
    public List<BallElement> balls;
    public List<CupElement> cups; 
}

[System.Serializable]
public class CupElement
{
    public Sprite icon;
    public bool hadBuy;
    public int cost;
    public int ID; 
}
[System.Serializable]
public class BallElement
{
    public Sprite icon;
    public bool hadBuy;
    public int cost;
    public int ID;
}
