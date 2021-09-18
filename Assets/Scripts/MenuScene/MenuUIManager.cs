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

    [Header("RemainLevel")]
    public RectTransform rec;
    public Text numText; 


    private void Start()
    {
        LevelText.text  = "Level " + PlayerPrefs.GetInt("MaxLevel").ToString();
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        levelRemainHandle();
    }

    public void PlayButton()
    {
        AudioManager.Instance.Play("Click");

        GameManager.Instance.level = PlayerPrefs.GetInt("MaxLevel");
        PlayBT.transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack);
        GameManager.Instance.SceneLoading("PlayScene", 1f);
        
    }

    public void StoreButton()
    {
        storePopup.onOpen();
        AudioManager.Instance.Play("Click");
        // Main.gameObject.SetActive(false);
    }

    public void levelRemainHandle()
    {
        int cL = PlayerPrefs.GetInt("MaxLevel");
        int cp = 5;
        numText.text = "Level: " + cL.ToString() + "/" + cp.ToString();
        rec.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , 40 + cL / cp * 195);
    }
}
