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

    [Header("Star")]
    public RectTransform recS;
    public Text numTextS; 

    public RectTransform setting;

    public RectTransform chapter; 

    private void Start()
    {
        LevelText.text  = "Level " + PlayerPrefs.GetInt("MaxLevel").ToString();
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        levelRemainHandle();
        starRemainHandle();
    }

    public void PlayButton()
    {
        AudioManager.Instance.PlayVfx("Click");
        GameManager.Instance.level = PlayerPrefs.GetInt("MaxLevel");
        PlayBT.transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack);
        GameManager.Instance.SceneLoading("PlayScene", 1f);
    }


    public void StoreButton()
    {
        storePopup.onOpen();
        AudioManager.Instance.PlayVfx("Click");
        // Main.gameObject.SetActive(false);
    }

    public void levelRemainHandle()
    {
        int cL = PlayerPrefs.GetInt("MaxLevel");
        int cp = 24;
        numText.text = "Level: " + cL.ToString() + "/" + cp.ToString();
        rec.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , 40 + cL / cp * 195);
    }

    public void starRemainHandle()
    {
        int cL = PlayerPrefs.GetInt("SumStar");
        int cp = 72;
        numTextS.text = "Star: " + cL.ToString() + "/" + cp.ToString();
        recS.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 40 + cL / cp * 195);
    }

    public void ChapterButton()
    {
        chapter.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
        AudioManager.Instance.PlayVfx("Click");
    }

    public void SettingButton()
    {
        setting.gameObject.SetActive(true);
        AudioManager.Instance.PlayVfx("Click");
    }
}
