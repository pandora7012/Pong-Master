using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuUIManager : MonoBehaviour
{
    public Text LevelText;
    public GameObject PlayBT;
    public Text coinText;
    public Store storePopup;
    public RectTransform Main; 

    private void Start()
    {
        LevelText.text  = "Level " + PlayerPrefs.GetInt("MaxLevel").ToString();
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    public void PlayButton()
    {
        GameManager.Instance.level = 1;
        PlayBT.transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack);
        
        GameManager.Instance.SceneLoading("PlayScene", 1f);
        
    }

    public void StoreButton()
    {
        storePopup.onOpen();
       // Main.gameObject.SetActive(false);
    }
}
