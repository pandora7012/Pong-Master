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


    private void Start()
    {
        LevelText.text  = "Level " + PlayerPrefs.GetInt("MaxLevel").ToString();
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    public void PlayButton()
    {
        PlayBT.transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack);
        GameManager.Instance.level = 1;
        GameManager.Instance.SceneLoading("PlayScene", 1f);
        
    }
}
